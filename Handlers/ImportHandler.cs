using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ThesisPrototype
{
    public class ImportHandler
    {
        private readonly RedisDatabaseApi _redisApi;

        public ImportHandler()
        {
            // TODO: Get connection string / api reference in a cleaner way
            _redisApi = new RedisDatabaseApi("192.168.99.100:7000"); 
        }

        public List<SensorValuesRow> SaveImportAndReturnRows(IFormFile importFile)
        {
            if(importFile.Length > 0)
            {
                var rows = new List<SensorValuesRow>();

                using(var stream = new StreamReader(importFile.OpenReadStream()))
                {
                    string header = null;
                    string currentLine;
                    
                    while(stream.Peek() >= 0)
                    {
                        currentLine = stream.ReadLine();

                        if (header == null)
                        {
                            header = currentLine;
                            continue;
                        }

                        string rowAsJson = this.RowToJson(header, currentLine);
                        var rowAsModel = SensorValuesRow.CreateFromJson(rowAsJson);
                        rows.Add(rowAsModel);
                    }
                }

                // Saving all rows at once to avoid having to open a DB connection for each row
                SaveSensorValues(rows.ToList()); // Skipping header
                return rows;
            }
            else
            {
                throw new Exception("Empty import file.");
            }
        }

        private void SaveSensorValues(List<SensorValuesRow> rows)
        {
            var rowsAsKeyAndJsonDict = rows.ToDictionary(k => k.UnixTs.ToString(), v => v);

            _redisApi.Create<SensorValuesRow>(rowsAsKeyAndJsonDict);
        }

        private string RowToJson(string header, string row)
        {
            var headerAsArray = header.Split(',');
            var rowAsArray = row.Split(',');

            var returnDictionary = new Dictionary<string, object>();
            for(int i = 0; i < headerAsArray.Length; i++)
            {
                returnDictionary.Add(headerAsArray[i], rowAsArray[i]);
            }

            return JsonConvert.SerializeObject(returnDictionary);
        }
    }
}