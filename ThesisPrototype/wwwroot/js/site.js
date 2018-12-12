function CreateKpiChart(divId, type, title, series)
{
    Highcharts.chart(divId, {
        chart: {
            type: "scatter"
        },
        plotOptions: {
            series: {
                turboThreshold: 0 // 0 == disabled
            }
        },
        marker: {
            enabled: true,
            radius: 1
        },
        xAxis: {
            type: 'datetime'
        },
        title: title,
        series: series
    });

}