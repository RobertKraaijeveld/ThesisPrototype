using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ThesisPrototype
{
    public static class RedisDatabaseApi
    {
        private static readonly string _connectionString;
        private static readonly ConnectionMultiplexer _connectionMultiplexer;
        private static IDatabase _databaseConnection;


        static RedisDatabaseApi()
        {
            _connectionString = GetConnectionString();
            _connectionMultiplexer = ConnectionMultiplexer.Connect(_connectionString);
        }
        

        public static List<M> Search<M>(List<string> keys) 
        {
            OpenConnection();

            var taskList = new List<Task<RedisValue>>();
            var readBatch = _databaseConnection.CreateBatch();

            foreach (var key in keys)
            {
                var task = readBatch.StringGetAsync(key);
                taskList.Add(task);
            }
        
            readBatch.Execute();
            CloseConnection();

            return taskList.Select(t => JsonConvert.DeserializeObject<M>(t.Result))
                           .ToList();
        }

        public static void Create<M>(Dictionary<string, M> keysAndValues) 
        {
            OpenConnection();

            List<Task> creationTasks = new List<Task>();

            foreach (var kv in keysAndValues)
            {
                var modelAsJson = JsonConvert.SerializeObject(kv.Value);
                var createStr = $"SET '{kv.Key}' '{modelAsJson}'";
                var cmdAndArgs = SeparateCmdAndArguments(createStr);

                var createModelTask = _databaseConnection.ExecuteAsync(cmdAndArgs.Item1, cmdAndArgs.Item2);
                creationTasks.Add(createModelTask);
            }

            Task.WaitAll(creationTasks.ToArray());
        }

        public static void Update<M>(Dictionary<string, M> keysAndValues) 
        {
            // Updating == creating in Redis
            Create<M>(keysAndValues);
        }

        public static void Delete<M>(List<string> keys) 
        {
            OpenConnection();

            List<Task> deletionTasks = new List<Task>();

            foreach (var key in keys)
            {
                var deleteStr = $"DEL '{key}'";
                var cmdAndArgs = SeparateCmdAndArguments(deleteStr);
                
                // Note that this ExecuteAsync command will only be executed once creationBatch.Execute() is called.
                var deleteTask = _databaseConnection.ExecuteAsync(cmdAndArgs.Item1, cmdAndArgs.Item2);
                deletionTasks.Add(deleteTask);
            }

            Task.WaitAll(deletionTasks.ToArray());
            CloseConnection();
        }

        public static void TruncateAll()
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


        private static Tuple<string, string[]> SeparateCmdAndArguments(string cmdString)
        {
            var splitCmd = cmdString.Split(' ');
            return new Tuple<string, string[]>(splitCmd[0], splitCmd.Skip(1).ToArray());
        }

        private static List<M> SerializeRedisValues<M>(RedisValue[] values) 
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

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            return configuration.GetSection("DatabaseConfiguration")["RedisConnectionString"];
        }

        private static void OpenConnection()
        {
            _databaseConnection = _connectionMultiplexer.GetDatabase();
        }

        private static void CloseConnection()
        {
            _databaseConnection = null;
        }
    }
}