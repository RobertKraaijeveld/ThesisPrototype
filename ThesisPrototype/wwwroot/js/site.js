function CreateKpiChart(divId, type, title, series)
{
    Highcharts.chart(divId, {
        chart: {
            type: type
        },
        marker: {
            enabled: true,
            radius: 1
        },
        boost: {
            useGPUTranslations: true,
            allowForce: true // ( ͡° ͜ʖ ͡°)
        },
        xAxis: {
            type: 'datetime',
        },
        title: title,
        series: series
    });

}