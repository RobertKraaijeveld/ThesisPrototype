using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;

namespace ThesisPrototype.Handlers
{
    public class EntityFrameworkImportHandler : AbstractImportHandler
    {
        private readonly KpiCalculationHandler _kpiCalculationHandler;

        public EntityFrameworkImportHandler(KpiCalculationHandler kpiCalculationHandler)
        {
            _kpiCalculationHandler = kpiCalculationHandler;
        }

        public override void Handle(FileStream importFile)
        {
            string importFileName = importFile.Name.Split('\\').Last();
            long shipIdOfImport = GetShipIdFromFileName(importFileName);
            DateTime dateTimeOfImport = GetImportDateFromFileName(importFileName);

            using (var context = new PrototypeContext())
            {
                if (importFile.Length > 0)
                {
                    using (var stream = new StreamReader(importFile))
                    {
                        string header = null;
                        string currentLine;

                        while (stream.Peek() >= 0)
                        {
                            currentLine = stream.ReadLine();

                            if (header == null)
                            {
                                header = currentLine;
                                continue; // Skipping header
                            }

                            Dictionary<ESensor, string> rowAsDict = base.RowToDictionary(header, currentLine);

                            #region Horrible dictionary to entity assignment code which avoids reflection

                            context.SensorValuesRows.Add(new EfSensorValuesRow()
                            {
                                sensor1 = double.Parse(rowAsDict[ESensor.sensor1]),
                                sensor2 = double.Parse(rowAsDict[ESensor.sensor2]),
                                sensor3 = double.Parse(rowAsDict[ESensor.sensor3]),
                                sensor4 = double.Parse(rowAsDict[ESensor.sensor4]),
                                sensor5 = double.Parse(rowAsDict[ESensor.sensor5]),
                                sensor6 = double.Parse(rowAsDict[ESensor.sensor6]),
                                sensor7 = double.Parse(rowAsDict[ESensor.sensor7]),
                                sensor8 = double.Parse(rowAsDict[ESensor.sensor8]),
                                sensor9 = double.Parse(rowAsDict[ESensor.sensor9]),
                                sensor10 = double.Parse(rowAsDict[ESensor.sensor10]),
                                sensor11 = double.Parse(rowAsDict[ESensor.sensor11]),
                                sensor12 = double.Parse(rowAsDict[ESensor.sensor12]),
                                sensor13 = double.Parse(rowAsDict[ESensor.sensor13]),
                                sensor14 = double.Parse(rowAsDict[ESensor.sensor14]),
                                sensor15 = double.Parse(rowAsDict[ESensor.sensor15]),
                                sensor16 = double.Parse(rowAsDict[ESensor.sensor16]),
                                sensor17 = double.Parse(rowAsDict[ESensor.sensor17]),
                                sensor18 = double.Parse(rowAsDict[ESensor.sensor18]),
                                sensor19 = double.Parse(rowAsDict[ESensor.sensor19]),
                                sensor20 = double.Parse(rowAsDict[ESensor.sensor20]),
                                sensor21 = double.Parse(rowAsDict[ESensor.sensor21]),
                                sensor22 = double.Parse(rowAsDict[ESensor.sensor22]),
                                sensor23 = double.Parse(rowAsDict[ESensor.sensor23]),
                                sensor24 = double.Parse(rowAsDict[ESensor.sensor24]),
                                sensor25 = double.Parse(rowAsDict[ESensor.sensor25]),
                                sensor26 = double.Parse(rowAsDict[ESensor.sensor26]),
                                sensor27 = double.Parse(rowAsDict[ESensor.sensor27]),
                                sensor28 = double.Parse(rowAsDict[ESensor.sensor28]),
                                sensor29 = double.Parse(rowAsDict[ESensor.sensor29]),
                                sensor30 = double.Parse(rowAsDict[ESensor.sensor30]),
                                sensor31 = double.Parse(rowAsDict[ESensor.sensor31]),
                                sensor32 = double.Parse(rowAsDict[ESensor.sensor32]),
                                sensor33 = double.Parse(rowAsDict[ESensor.sensor33]),
                                sensor34 = double.Parse(rowAsDict[ESensor.sensor34]),
                                sensor35 = double.Parse(rowAsDict[ESensor.sensor35]),
                                sensor36 = double.Parse(rowAsDict[ESensor.sensor36]),
                                sensor37 = double.Parse(rowAsDict[ESensor.sensor37]),
                                sensor38 = double.Parse(rowAsDict[ESensor.sensor38]),
                                sensor39 = double.Parse(rowAsDict[ESensor.sensor39]),
                                sensor40 = double.Parse(rowAsDict[ESensor.sensor40]),
                                sensor41 = double.Parse(rowAsDict[ESensor.sensor41]),
                                sensor42 = double.Parse(rowAsDict[ESensor.sensor42]),
                                sensor43 = double.Parse(rowAsDict[ESensor.sensor43]),
                                sensor44 = double.Parse(rowAsDict[ESensor.sensor44]),
                                sensor45 = double.Parse(rowAsDict[ESensor.sensor45]),
                                sensor46 = double.Parse(rowAsDict[ESensor.sensor46]),
                                sensor47 = double.Parse(rowAsDict[ESensor.sensor47]),
                                sensor48 = double.Parse(rowAsDict[ESensor.sensor48]),
                                sensor49 = double.Parse(rowAsDict[ESensor.sensor49]),
                                sensor50 = double.Parse(rowAsDict[ESensor.sensor50]),
                                sensor51 = double.Parse(rowAsDict[ESensor.sensor51]),
                                sensor52 = double.Parse(rowAsDict[ESensor.sensor52]),
                                sensor53 = double.Parse(rowAsDict[ESensor.sensor53]),
                                sensor54 = double.Parse(rowAsDict[ESensor.sensor54]),
                                sensor55 = double.Parse(rowAsDict[ESensor.sensor55]),
                                sensor56 = double.Parse(rowAsDict[ESensor.sensor56]),
                                sensor57 = double.Parse(rowAsDict[ESensor.sensor57]),
                                sensor58 = double.Parse(rowAsDict[ESensor.sensor58]),
                                sensor59 = double.Parse(rowAsDict[ESensor.sensor59]),
                                sensor60 = double.Parse(rowAsDict[ESensor.sensor60]),
                                sensor61 = double.Parse(rowAsDict[ESensor.sensor61]),
                                sensor62 = double.Parse(rowAsDict[ESensor.sensor62]),
                                sensor63 = double.Parse(rowAsDict[ESensor.sensor63]),
                                sensor64 = double.Parse(rowAsDict[ESensor.sensor64]),
                                sensor65 = double.Parse(rowAsDict[ESensor.sensor65]),
                                sensor66 = double.Parse(rowAsDict[ESensor.sensor66]),
                                sensor67 = double.Parse(rowAsDict[ESensor.sensor67]),
                                sensor68 = double.Parse(rowAsDict[ESensor.sensor68]),
                                sensor69 = double.Parse(rowAsDict[ESensor.sensor69]),
                                sensor70 = double.Parse(rowAsDict[ESensor.sensor70]),
                                sensor71 = double.Parse(rowAsDict[ESensor.sensor71]),
                                sensor72 = double.Parse(rowAsDict[ESensor.sensor72]),
                                sensor73 = double.Parse(rowAsDict[ESensor.sensor73]),
                                sensor74 = double.Parse(rowAsDict[ESensor.sensor74]),
                                sensor75 = double.Parse(rowAsDict[ESensor.sensor75]),
                                sensor76 = double.Parse(rowAsDict[ESensor.sensor76]),
                                sensor77 = double.Parse(rowAsDict[ESensor.sensor77]),
                                sensor78 = double.Parse(rowAsDict[ESensor.sensor78]),
                                sensor79 = double.Parse(rowAsDict[ESensor.sensor79]),
                                sensor80 = double.Parse(rowAsDict[ESensor.sensor80]),
                                sensor81 = double.Parse(rowAsDict[ESensor.sensor81]),
                                sensor82 = double.Parse(rowAsDict[ESensor.sensor82]),
                                sensor83 = double.Parse(rowAsDict[ESensor.sensor83]),
                                sensor84 = double.Parse(rowAsDict[ESensor.sensor84]),
                                sensor85 = double.Parse(rowAsDict[ESensor.sensor85]),
                                sensor86 = double.Parse(rowAsDict[ESensor.sensor86]),
                                sensor87 = double.Parse(rowAsDict[ESensor.sensor87]),
                                sensor88 = double.Parse(rowAsDict[ESensor.sensor88]),
                                sensor89 = double.Parse(rowAsDict[ESensor.sensor89]),
                                sensor90 = double.Parse(rowAsDict[ESensor.sensor90]),
                                sensor91 = double.Parse(rowAsDict[ESensor.sensor91]),
                                sensor92 = double.Parse(rowAsDict[ESensor.sensor92]),
                                sensor93 = double.Parse(rowAsDict[ESensor.sensor93]),
                                sensor94 = double.Parse(rowAsDict[ESensor.sensor94]),
                                sensor95 = double.Parse(rowAsDict[ESensor.sensor95]),
                                sensor96 = double.Parse(rowAsDict[ESensor.sensor96]),
                                sensor97 = double.Parse(rowAsDict[ESensor.sensor97]),
                                sensor98 = double.Parse(rowAsDict[ESensor.sensor98]),
                                sensor99 = double.Parse(rowAsDict[ESensor.sensor99]),
                                sensor100 = double.Parse(rowAsDict[ESensor.sensor100]),
                                sensor101 = double.Parse(rowAsDict[ESensor.sensor101]),
                                sensor102 = double.Parse(rowAsDict[ESensor.sensor102]),
                                sensor103 = double.Parse(rowAsDict[ESensor.sensor103]),
                                sensor104 = double.Parse(rowAsDict[ESensor.sensor104]),
                                sensor105 = double.Parse(rowAsDict[ESensor.sensor105]),
                                sensor106 = double.Parse(rowAsDict[ESensor.sensor106]),
                                sensor107 = double.Parse(rowAsDict[ESensor.sensor107]),
                                sensor108 = double.Parse(rowAsDict[ESensor.sensor108]),
                                sensor109 = double.Parse(rowAsDict[ESensor.sensor109]),
                                sensor110 = double.Parse(rowAsDict[ESensor.sensor110]),
                                sensor111 = double.Parse(rowAsDict[ESensor.sensor111]),
                                sensor112 = double.Parse(rowAsDict[ESensor.sensor112]),
                                sensor113 = double.Parse(rowAsDict[ESensor.sensor113]),
                                sensor114 = double.Parse(rowAsDict[ESensor.sensor114]),
                                sensor115 = double.Parse(rowAsDict[ESensor.sensor115]),
                                sensor116 = double.Parse(rowAsDict[ESensor.sensor116]),
                                sensor117 = double.Parse(rowAsDict[ESensor.sensor117]),
                                sensor118 = double.Parse(rowAsDict[ESensor.sensor118]),
                                sensor119 = double.Parse(rowAsDict[ESensor.sensor119]),
                                sensor120 = double.Parse(rowAsDict[ESensor.sensor120]),
                                sensor121 = double.Parse(rowAsDict[ESensor.sensor121]),
                                sensor122 = double.Parse(rowAsDict[ESensor.sensor122]),
                                sensor123 = double.Parse(rowAsDict[ESensor.sensor123]),
                                sensor124 = double.Parse(rowAsDict[ESensor.sensor124]),
                                sensor125 = double.Parse(rowAsDict[ESensor.sensor125]),
                                sensor126 = double.Parse(rowAsDict[ESensor.sensor126]),
                                sensor127 = double.Parse(rowAsDict[ESensor.sensor127]),
                                sensor128 = double.Parse(rowAsDict[ESensor.sensor128]),
                                sensor129 = double.Parse(rowAsDict[ESensor.sensor129]),
                                sensor130 = double.Parse(rowAsDict[ESensor.sensor130]),
                                sensor131 = double.Parse(rowAsDict[ESensor.sensor131]),
                                sensor132 = double.Parse(rowAsDict[ESensor.sensor132]),
                                sensor133 = double.Parse(rowAsDict[ESensor.sensor133]),
                                sensor134 = double.Parse(rowAsDict[ESensor.sensor134]),
                                sensor135 = double.Parse(rowAsDict[ESensor.sensor135]),
                                sensor136 = double.Parse(rowAsDict[ESensor.sensor136]),
                                sensor137 = double.Parse(rowAsDict[ESensor.sensor137]),
                                sensor138 = double.Parse(rowAsDict[ESensor.sensor138]),
                                sensor139 = double.Parse(rowAsDict[ESensor.sensor139]),
                                sensor140 = double.Parse(rowAsDict[ESensor.sensor140]),
                                sensor141 = double.Parse(rowAsDict[ESensor.sensor141]),
                                sensor142 = double.Parse(rowAsDict[ESensor.sensor142]),
                                sensor143 = double.Parse(rowAsDict[ESensor.sensor143]),
                                sensor144 = double.Parse(rowAsDict[ESensor.sensor144]),
                                sensor145 = double.Parse(rowAsDict[ESensor.sensor145]),
                                sensor146 = double.Parse(rowAsDict[ESensor.sensor146]),
                                sensor147 = double.Parse(rowAsDict[ESensor.sensor147]),
                                sensor148 = double.Parse(rowAsDict[ESensor.sensor148]),
                                sensor149 = double.Parse(rowAsDict[ESensor.sensor149]),
                            });

                            #endregion
                        }
                    }

                    var dataImportMeta = new DataImportMeta(shipIdOfImport, dateTimeOfImport);
                    SaveDataImportMeta(dataImportMeta);

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Empty import file.");
                }
            }
        }
    }
}