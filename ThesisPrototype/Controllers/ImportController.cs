using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;
using ThesisPrototype.Handlers;
using ThesisPrototype.Retrievers;
using ThesisPrototype.Utilities;

namespace ThesisPrototype.Controllers
{
    public class ImportController : BaseController
    {
        #region Performance metrics for both Redis and EF

        private static List<long> EfImportTimesMillis = new List<long>();
        private static List<long> RedisImportTimesMillis = new List<long>();
        private static List<long> RedisUpdatingTimesMillis = new List<long>();
        private static List<long> EfUpdatingTimesMillis = new List<long>();
        private static List<long> RedisDeletingTimesMillis = new List<long>();
        private static List<long> EfDeletingTimesMillis = new List<long>();

        private static double AverageEfImportTimeMillis = 0;
        private static double AverageRedisImportTimeMillis = 0;
        private static double AverageEfUpdatingTimeMillis = 0;
        private static double AverageRedisUpdatingTimeMillis = 0;
        private static double AverageEfDeletingTimeMillis = 0;
        private static double AverageRedisDeletingTimeMillis = 0;

        #endregion

        private readonly RedisImportHandler _redisImportHandler;
        private readonly EntityFrameworkImportHandler _entityFrameworkImportHandler;
        private readonly SensorValuesRowRetriever _sensorValuesRowRetriever;

        public ImportController(RedisImportHandler redisImportHandler,
                                EntityFrameworkImportHandler entityFrameworkImportHandler,
                                SensorValuesRowRetriever sensorValuesRowRetriever,
                                UserManager<User> userManager) : base(userManager)
        {
            _redisImportHandler = redisImportHandler;
            _entityFrameworkImportHandler = entityFrameworkImportHandler;
            _sensorValuesRowRetriever = sensorValuesRowRetriever;
        }

        public IActionResult Index()
        {
            return View();
        }




        public IActionResult ImportLocalFile(string filePath)
        {
            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
                var sw = new Stopwatch();
                sw.Start();

                _redisImportHandler.Handle(fileStream, calculateKpis: true);

                sw.Stop();
                RedisImportTimesMillis.Add(sw.ElapsedMilliseconds);
                AverageRedisImportTimeMillis = RedisImportTimesMillis.Average();
            }

            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
               var sw = new Stopwatch();
               sw.Start();

               _entityFrameworkImportHandler.Handle(fileStream, calculateKpis: true);

               sw.Stop();
               EfImportTimesMillis.Add(sw.ElapsedMilliseconds);
               AverageEfImportTimeMillis = EfImportTimesMillis.Average();
            }

            return Ok();
        }


        #region Updating / deleting values (for testing purposes)

        public IActionResult UpdatingAllSensorValues(long shipId)
        {
            var firstAndLastImportMillis = GetFirstAndLastImportUnixTs(shipId);
            long firstImportUnixTimeMillis = firstAndLastImportMillis.Item1;
            long lastImportUnixTimeMillis = firstAndLastImportMillis.Item2;


            // Redis
            var sw = new Stopwatch();
            sw.Start();

            var allRedisSensorValuesForShip = _sensorValuesRowRetriever.GetRange(shipId, firstImportUnixTimeMillis, lastImportUnixTimeMillis)
                                                                       .Take(25000)
                                                                       .ToList();
            allRedisSensorValuesForShip.ForEach(x => x.SensorValues[ESensor.sensor1] = 100.0);

            RedisDatabaseApi.Update(allRedisSensorValuesForShip);

            sw.Stop();
            RedisUpdatingTimesMillis.Add(sw.ElapsedMilliseconds);
            AverageRedisUpdatingTimeMillis = RedisUpdatingTimesMillis.Average();
            
            
            // Entity Framework
            sw = new Stopwatch();
            sw.Start();

            using(var context = new PrototypeContext())
            {
                var allEfSensorValuesForShip = context.SensorValuesRows.Where(x => x.ShipId == shipId 
                                                                              && x.RowTimestamp >= firstImportUnixTimeMillis
                                                                              && x.RowTimestamp <= lastImportUnixTimeMillis)
                                                                       .Take(25000)
                                                                       .ToList();
                allEfSensorValuesForShip.ForEach(sv => sv.sensor1 += 100);
                context.SaveChanges();
            }

            sw.Stop();
            EfUpdatingTimesMillis.Add(sw.ElapsedMilliseconds);
            AverageEfUpdatingTimeMillis = EfUpdatingTimesMillis.Average();
            
            return Ok();
        }

        public IActionResult DeletingAllSensorValues(long shipId)
        {
            var firstAndLastImportMillis = GetFirstAndLastImportUnixTs(shipId);
            long firstImportUnixTimeMillis = firstAndLastImportMillis.Item1;
            long lastImportUnixTimeMillis = firstAndLastImportMillis.Item2;

            // Redis
            var sw = new Stopwatch();
            sw.Start();

            var allRedisSensorValuesForShip = _sensorValuesRowRetriever.GetRange(shipId, firstImportUnixTimeMillis, lastImportUnixTimeMillis);
            RedisDatabaseApi.Delete<RedisSensorValuesRow>(allRedisSensorValuesForShip.Select(x => x.ToRedisKey()).Take(25000).ToList());

            sw.Stop();
            RedisDeletingTimesMillis.Add(sw.ElapsedMilliseconds);
            AverageRedisDeletingTimeMillis = RedisDeletingTimesMillis.Average();
            
            
            // Entity Framework
            sw = new Stopwatch();
            sw.Start();

            using(var context = new PrototypeContext())
            {
                var allEfSensorValuesForShip = context.SensorValuesRows.Where(x => x.ShipId == shipId 
                                                                              && x.RowTimestamp >= firstImportUnixTimeMillis
                                                                              && x.RowTimestamp <= lastImportUnixTimeMillis)
                                                                       .Take(25000)
                                                                       .ToList();
                context.RemoveRange(allEfSensorValuesForShip);
                context.SaveChanges();
            }

            sw.Stop();
            EfDeletingTimesMillis.Add(sw.ElapsedMilliseconds);
            AverageEfDeletingTimeMillis = EfDeletingTimesMillis.Average();

            return Ok();
        }   


        private Tuple<long, long> GetFirstAndLastImportUnixTs(long shipId)
        {
            long firstImportUnixTimeMillis;
            long lastImportUnixTimeMillis;
            using(var context = new PrototypeContext())
            {
                firstImportUnixTimeMillis = context.DataImportMetas.Where(x => x.ShipId == shipId)
                                                                   .First()
                                                                   .ImportDate
                                                                   .ToUnixMilliTs();
                lastImportUnixTimeMillis = context.DataImportMetas.Where(x => x.ShipId == shipId)
                                                                  .Last()
                                                                  .ImportDate
                                                                  .ToUnixMilliTs();
            }
            return new Tuple<long, long>(firstImportUnixTimeMillis, lastImportUnixTimeMillis);
        }

        #endregion
    }
}
