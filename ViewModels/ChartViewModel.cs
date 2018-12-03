using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisPrototype.ViewModels
{
    public class ChartViewModel
    {
        public ChartTitleViewModel title;
        public ChartSerieViewModel[] series;
    }

    public struct ChartTitleViewModel
    {
        public string text;
    }

    public struct ChartSerieViewModel
    {
        public string name;
        public ChartDataPointViewModel[] data;
    }

    public struct ChartDataPointViewModel
    {
        public object x;
        public object y;
    }
}
