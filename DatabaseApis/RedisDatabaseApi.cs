using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using MessagePack;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Utilities;

namespace ThesisPrototype.DatabaseApis
{
    /// <summary>
    /// A simple API exposing CRUD methods to the Redis KV-store, using the StackExchange Redis driver.
    /// </summary>
    public static class RedisDatabaseApi
    {
        private static readonly string _connectionString;
        private static readonly ConnectionMultiplexer _connectionMultiplexer;
        private static IDatabase _databaseConnection;


        static RedisDatabaseApi()
        {
            _connectionString = GetConnectionString();
            _connectionMultiplexer = ConnectionMultiplexer.Connect(_connectionString);
            _databaseConnection = _connectionMultiplexer.GetDatabase();
        }
        

        public static List<M> Search<M>(List<string> keys) where M: IRedisModel
        {
            var taskList = new List<Task<RedisValue>>();
            var readBatch = _databaseConnection.CreateBatch();

            foreach (var key in keys)
            {
                var task = readBatch.StringGetAsync(key);
                taskList.Add(task);
            }
        
            readBatch.Execute();

            var returnValues = new List<M>();
            foreach (var completedReadTask in taskList)
            {
                if(completedReadTask.Result != RedisValue.Null)
                {
                    var deserializedResult = MessagePackSerializer.Deserialize<M>(completedReadTask.Result);
                    returnValues.Add(deserializedResult);
                }
            }
            return returnValues;
        }

        public static void Create<M>(List<M> newModels) where M : IRedisModel
        {
            List<Task> creationTasks = new List<Task>();

            foreach (var model in newModels)
            {
                string key = model.ToRedisKey();
                byte[] serializedModel = MessagePackSerializer.Serialize(model);

                Task<RedisResult> createModelTask = _databaseConnection.ExecuteAsync("SET", new object[2] { key, serializedModel });
                creationTasks.Add(createModelTask);
            }

            Task.WaitAll(creationTasks.ToArray());
        }

        public static void Update<M>(List<M> updatedValues) where M : IRedisModel
        {
            // Updating == creating in Redis
            Create<M>(updatedValues);
        }

        public static void Delete<M>(List<string> keys) where M : IRedisModel
        {
            List<Task> deletionTasks = new List<Task>();

            foreach (var key in keys)
            {
                var deleteCmdStr = $"DEL '{key}'";
                var cmdAndArgs = SeparateCmdAndArguments(deleteCmdStr);
                
                // Note that this ExecuteAsync command will only be executed once creationBatch.Execute() is called.
                var deleteTask = _databaseConnection.ExecuteAsync(cmdAndArgs.Item1, cmdAndArgs.Item2);
                deletionTasks.Add(deleteTask);
            }

            Task.WaitAll(deletionTasks.ToArray());
        }

        private static T Deserialize<T>(byte[] param)
        {
            using (MemoryStream ms = new MemoryStream(param))
            {
                IFormatter br = new BinaryFormatter();
                return (T)br.Deserialize(ms);
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
    }
}