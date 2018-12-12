using System;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisPrototype.Enums;

namespace ThesisPrototype.DataModels
{
    public class EfSensorValuesRow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EfSensorValuesRowId { get; set; }

        public DateTime ImportTimestamp { get; set; }
        public long RowTimestamp { get; set; }
        public Ship Ship { get; set; }
        public long ShipId { get; set; } 


        public double sensor1 { get; set; } 
        public double sensor2 { get; set; } 
        public double sensor3 { get; set; } 
        public double sensor4 { get; set; } 
        public double sensor5 { get; set; } 
        public double sensor6 { get; set; } 
        public double sensor7 { get; set; } 
        public double sensor8 { get; set; } 
        public double sensor9 { get; set; } 
        public double sensor10 { get; set; } 
        public double sensor11 { get; set; } 
        public double sensor12 { get; set; } 
        public double sensor13 { get; set; } 
        public double sensor14 { get; set; } 
        public double sensor15 { get; set; } 
        public double sensor16 { get; set; } 
        public double sensor17 { get; set; } 
        public double sensor18 { get; set; } 
        public double sensor19 { get; set; } 
        public double sensor20 { get; set; } 
        public double sensor21 { get; set; } 
        public double sensor22 { get; set; } 
        public double sensor23 { get; set; } 
        public double sensor24 { get; set; } 
        public double sensor25 { get; set; } 
        public double sensor26 { get; set; } 
        public double sensor27 { get; set; } 
        public double sensor28 { get; set; } 
        public double sensor29 { get; set; } 
        public double sensor30 { get; set; } 
        public double sensor31 { get; set; } 
        public double sensor32 { get; set; } 
        public double sensor33 { get; set; } 
        public double sensor34 { get; set; } 
        public double sensor35 { get; set; } 
        public double sensor36 { get; set; } 
        public double sensor37 { get; set; } 
        public double sensor38 { get; set; } 
        public double sensor39 { get; set; } 
        public double sensor40 { get; set; } 
        public double sensor41 { get; set; } 
        public double sensor42 { get; set; } 
        public double sensor43 { get; set; } 
        public double sensor44 { get; set; } 
        public double sensor45 { get; set; } 
        public double sensor46 { get; set; } 
        public double sensor47 { get; set; } 
        public double sensor48 { get; set; } 
        public double sensor49 { get; set; } 
        public double sensor50 { get; set; } 
        public double sensor51 { get; set; } 
        public double sensor52 { get; set; } 
        public double sensor53 { get; set; } 
        public double sensor54 { get; set; } 
        public double sensor55 { get; set; } 
        public double sensor56 { get; set; } 
        public double sensor57 { get; set; } 
        public double sensor58 { get; set; } 
        public double sensor59 { get; set; } 
        public double sensor60 { get; set; } 
        public double sensor61 { get; set; } 
        public double sensor62 { get; set; } 
        public double sensor63 { get; set; } 
        public double sensor64 { get; set; } 
        public double sensor65 { get; set; } 
        public double sensor66 { get; set; } 
        public double sensor67 { get; set; } 
        public double sensor68 { get; set; } 
        public double sensor69 { get; set; } 
        public double sensor70 { get; set; } 
        public double sensor71 { get; set; } 
        public double sensor72 { get; set; } 
        public double sensor73 { get; set; } 
        public double sensor74 { get; set; } 
        public double sensor75 { get; set; } 
        public double sensor76 { get; set; } 
        public double sensor77 { get; set; } 
        public double sensor78 { get; set; } 
        public double sensor79 { get; set; } 
        public double sensor80 { get; set; } 
        public double sensor81 { get; set; } 
        public double sensor82 { get; set; } 
        public double sensor83 { get; set; } 
        public double sensor84 { get; set; } 
        public double sensor85 { get; set; } 
        public double sensor86 { get; set; } 
        public double sensor87 { get; set; } 
        public double sensor88 { get; set; } 
        public double sensor89 { get; set; } 
        public double sensor90 { get; set; } 
        public double sensor91 { get; set; } 
        public double sensor92 { get; set; } 
        public double sensor93 { get; set; } 
        public double sensor94 { get; set; } 
        public double sensor95 { get; set; } 
        public double sensor96 { get; set; } 
        public double sensor97 { get; set; } 
        public double sensor98 { get; set; } 
        public double sensor99 { get; set; } 
        public double sensor100 { get; set; } 
        public double sensor101 { get; set; } 
        public double sensor102 { get; set; } 
        public double sensor103 { get; set; } 
        public double sensor104 { get; set; } 
        public double sensor105 { get; set; } 
        public double sensor106 { get; set; } 
        public double sensor107 { get; set; } 
        public double sensor108 { get; set; } 
        public double sensor109 { get; set; } 
        public double sensor110 { get; set; } 
        public double sensor111 { get; set; } 
        public double sensor112 { get; set; } 
        public double sensor113 { get; set; } 
        public double sensor114 { get; set; } 
        public double sensor115 { get; set; } 
        public double sensor116 { get; set; } 
        public double sensor117 { get; set; } 
        public double sensor118 { get; set; } 
        public double sensor119 { get; set; } 
        public double sensor120 { get; set; } 
        public double sensor121 { get; set; } 
        public double sensor122 { get; set; } 
        public double sensor123 { get; set; } 
        public double sensor124 { get; set; } 
        public double sensor125 { get; set; } 
        public double sensor126 { get; set; } 
        public double sensor127 { get; set; } 
        public double sensor128 { get; set; } 
        public double sensor129 { get; set; } 
        public double sensor130 { get; set; } 
        public double sensor131 { get; set; } 
        public double sensor132 { get; set; } 
        public double sensor133 { get; set; } 
        public double sensor134 { get; set; } 
        public double sensor135 { get; set; } 
        public double sensor136 { get; set; } 
        public double sensor137 { get; set; } 
        public double sensor138 { get; set; } 
        public double sensor139 { get; set; } 
        public double sensor140 { get; set; } 
        public double sensor141 { get; set; } 
        public double sensor142 { get; set; } 
        public double sensor143 { get; set; } 
        public double sensor144 { get; set; } 
        public double sensor145 { get; set; } 
        public double sensor146 { get; set; } 
        public double sensor147 { get; set; } 
        public double sensor148 { get; set; } 
        public double sensor149 { get; set; } 
        public double sensor150 { get; set; } 
        public double sensor151 { get; set; } 

        public double GetValue(ESensor sensorEnum)
        {
            return (double) this.GetType().GetProperty(sensorEnum.ToString()).GetValue(this);
        }
    }
}