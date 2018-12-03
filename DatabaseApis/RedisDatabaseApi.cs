using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using Newtonsoft.Json;
using StackExchange.Redis;
using ThesisPrototype.DataModels;

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
        

        public static List<M> Search<M>(List<string> keys) where M: IRedisModel
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

        public static void Create<M>(List<M> newModels) where M : IRedisModel
        {
            OpenConnection();

            List<Task> creationTasks = new List<Task>();

            foreach (var model in newModels)
            {
                var modelAsJson = JsonConvert.SerializeObject(model);
                var createModelTask = _databaseConnection.ExecuteAsync("SET", new string[2] { model.ToRedisKey(), modelAsJson });

                creationTasks.Add(createModelTask);
            }

            Task.WaitAll(creationTasks.ToArray());
            CloseConnection();
        }

        public static void Update<M>(List<M> updatedValues) where M : IRedisModel
        {
            // Updating == creating in Redis
            Create<M>(updatedValues);
        }

        public static void Delete<M>(List<string> keys) where M : IRedisModel
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