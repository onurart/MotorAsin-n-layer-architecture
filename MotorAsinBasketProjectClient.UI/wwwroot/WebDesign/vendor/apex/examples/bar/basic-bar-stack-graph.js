fetch('/home/gettopdocuments')
    .then(response => response.json())
    .then(jsonData => {
        // Verileri ayrýþtýr
        var labels = jsonData.map(item => item.CustomerName);
        var data = jsonData.map(item => item.TotalQuantity);
        var productNames = jsonData.map(item => item.ProductName);
        // Grafik konteynerini al
        var chartContainer = document.getElementById('chart-container');
        var barBorderColor = '#FFFF00'; // Yellow
        var barColor = '#db273c'; // Black
        var barBorderColor = '#FFFF00'; // Yellow
        var barBorderWidth = 10; // Border geniþlið
        //var barColor = '#585858'; // Green
        var barBorderRadius = 2; // Border yuvarlaklýðý
        // Grafik oluþturma
        var chart = new ApexCharts(chartContainer, {
            chart: {
                type: 'bar',
                height: 300,
                toolbar: {
                    show: false,
                }
            },
            plotOptions: {
                bar: {
                    colors: {
                        ranges: [
                            {
                                from: 0,
                                to: 0,
                            }
                        ],
                        backgroundBarColors: [barColor],     // çubuk rengini barColor deðiþkenine atanan deðere ayarlar
                        barHeight: '100%', // çubuk yüksekliði
                        barWidth: '100%', // çubuk geniþliði
                        borderWidth: barBorderWidth, // çubuk kenar geniþliði
                        borderColor: barBorderColor, // çubuk kenar rengi
                        borderRadius: barBorderRadius, // çubuklara border-radius uygula
                    }
                }
            },
            series: [{
                name: 'Toplam Adet',
                data: data
            }],
            xaxis: {
                categories: labels
            },
            tooltip: {
                enabled: true,
                enabledOnSeries: undefined,
                shared: false,
                followCursor: true,
                intersect: false,
                inverseOrder: false,
                custom: function ({ series, seriesIndex, dataPointIndex, w }) {
                    return `<div class="custom-tooltip" style="background-color: #454f58 ; color: #fff;">${productNames[dataPointIndex]}</div>`;
                },
                onDatasetHover: {
                    highlightDataSeries: false,
                },
                x: {
                    show: true,
                    format: 'dd MMM',
                    formatter: undefined,
                },
                y: {
                    formatter: function (value, { series, seriesIndex, dataPointIndex, w }) {
                        return '';
                    }
                },
                z: {
                    formatter: undefined,
                    title: 'Size: '
                },
                marker: {
                    show: true,
                },
                fixed: {
                    enabled: false,
                    position: 'topRight',
                    offsetX: 0,
                    offsetY: 0,
                },
            },
            responsive: [{
                breakpoint: 768,
                options: {
                    chart: {
                        height: 200
                    }
                }
            }]
        });

        chart.render();
    });
