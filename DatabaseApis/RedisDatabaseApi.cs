using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ThesisPrototype
{
    public class RedisDatabaseApi
    {
        private readonly string _connectionString;
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private IDatabase _databaseConnection;


        public RedisDatabaseApi(string connectionString)
        {
            _connectionString = connectionString;

            _connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        }


        

        public List<M> Search<M>(List<string> keys) where M : AbstractModel, new()
        {
            this.OpenConnection();

            var taskList = new List<Task<RedisValue>>();
            var readBatch = _databaseConnection.CreateBatch();

            foreach (var key in keys)
            {
                var task = readBatch.StringGetAsync(key);
                taskList.Add(task);
            }
        
            readBatch.Execute();
            this.CloseConnection();

            return taskList.Select(t => JsonConvert.DeserializeObject<M>(t.Result))
                           .ToList();
        }

        public void Create<M>(Dictionary<string, M> keysAndValues) where M : AbstractModel, new()
        {
            this.OpenConnection();

            List<Task> creationTasks = new List<Task>();

            foreach (var kv in keysAndValues)
            {
                var modelAsJson = JsonConvert.SerializeObject(kv.Value);
                var createStr = $"SET '{kv.Key}' '{modelAsJson}'";
                var cmdAndArgs = this.SeparateCmdAndArguments(createStr);

                var createModelTask = _databaseConnection.ExecuteAsync(cmdAndArgs.Item1, cmdAndArgs.Item2);
                creationTasks.Add(createModelTask);
            }

            Task.WaitAll(creationTasks.ToArray());
        }

        public void Update<M>(Dictionary<string, M> keysAndValues) where M : AbstractModel, new()
        {
            // Updating == creating in Redis
            this.Create<M>(keysAndValues);
        }

        public void Delete<M>(List<string> keys) where M : AbstractModel, new()
        {
            this.OpenConnection();

            List<Task> deletionTasks = new List<Task>();

            foreach (var key in keys)
            {
                var deleteStr = $"DEL '{key}'";
                var cmdAndArgs = this.SeparateCmdAndArguments(deleteStr);
                
                // Note that this ExecuteAsync command will only be executed once creationBatch.Execute() is called.
                var deleteTask = _databaseConnection.ExecuteAsync(cmdAndArgs.Item1, cmdAndArgs.Item2);
                deletionTasks.Add(deleteTask);
            }

            Task.WaitAll(deletionTasks.ToArray());
            this.CloseConnection();
        }

        public void TruncateAll()
        {
            using (var adminConnection = ConnectionMultiplexer.Connect($"{_connectionString},allowAdmin=true"))
            {
                var endpoints = adminConnection.GetEndPoints();
                var masterServers = endpoints.Select(x => adminConnection.GetServer(x))
                                             .Where(x => !x.IsSlave)
                                             .ToList();
                masterServers.ForEach(x => x.FlushDatabase());
            }
        }


        private Tuple<string, string[]> SeparateCmdAndArguments(string cmdString)
        {
            var splitCmd = cmdString.Split(' ');
            return new Tuple<string, string[]>(splitCmd[0], splitCmd.Skip(1).ToArray());
        }

        private List<M> SerializeRedisValues<M>(RedisValue[] values) where M : AbstractModel, new()
        {
            var results = new List<M>();

            // We can't tell whether a value is of type M beforehand. So we just try
            // and try serialize the value; if this fails, its not of type M and we just continue.
            foreach (var value in values)
            {
                try
                {
                    var valueStr = value.ToString();

                    // stripping away first enclosing single quotes, otherwise JSON deserialization fails 
                    var valueWithoutEnclosingQuotes = valueStr.Remove(0, 1);
                    valueWithoutEnclosingQuotes = valueWithoutEnclosingQuotes.Remove(valueWithoutEnclosingQuotes.Length - 1, 1);

                    results.Add(JsonConvert.DeserializeObject<M>(valueWithoutEnclosingQuotes));
                }
                catch (JsonSerializationException)
                { } // Do nothing and continue
                catch (Exception e)
                {
                    throw e; // Other type of exception, so it needs to be thrown
                }
            }
            return results;
        }

        private void OpenConnection()
        {
            _databaseConnection = _connectionMultiplexer.GetDatabase();
        }

        private void CloseConnection()
        {
            _databaseConnection = null;
        }
    }
}