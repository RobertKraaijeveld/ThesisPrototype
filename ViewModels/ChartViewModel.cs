﻿namespace ThesisPrototype.ViewModels
{
    public class ChartViewModel
    {
        public string Id;
        public long CreationTimeInMillis;
        public double AverageCreationTimeInMillis;
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
