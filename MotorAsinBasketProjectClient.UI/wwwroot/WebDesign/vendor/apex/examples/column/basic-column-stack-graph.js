//fetch('/Home/GetTopDocuments')
//    .then(response => response.json())
//    .then(data => {
//        var series = [{
//            name: data.map(item => item. ProductName),
//            data: data.map(item => item.TotalQuantity)
//        }];
//        var categories = data.map(item => item.CustomerName);
//        var options = {
//            chart: {
//                height: 300,
//                type: 'bar',
//                stacked: true,
//                toolbar: {
//                    show: false
//                },
//                dropShadow: {
//                    enabled: true,
//                    opacity: 0.1,
//                    blur: 5,
//                    left: -10,
//                    top: 10
//                },
//                zoom: {
//                    enabled: true
//                }
//            },
//            responsive: [{
//                breakpoint: 480,
//                options: {
//                    legend: {
//                        position: 'bottom',
//                        offsetX: -10,
//                        offsetY: 0
//                    }
//                }
//            }],
//            plotOptions: {
//                bar: {
//                    horizontal: false
//                }
//            },
//            dataLabels: {
//                enabled: true
//            },
//            series: series,
//            xaxis: {
//                type: 'category',
//                categories: categories
//            },
//            legend: {
//                position: 'top',
//                offsetY: 10
//            },
//            fill: {
//                opacity: 1
//            },
//            grid: {
//                borderColor: '#e0e6ed',
//                strokeDashArray: 5,
//                xaxis: {
//                    lines: {
//                        show: true
//                    }
//                },
//                yaxis: {
//                    lines: {
//                        show: false,
//                    }
//                },
//                padding: {
//                    top: 0,
//                    right: 0,
//                    bottom: 0,
//                    left: 0
//                },
//            },
//            colors: ['#e02539', '#3c3c3c', '#585858', '#a2a2a2', '#dcdcdc']
//        };

//        var chart = new ApexCharts(
//            document.querySelector("#basic-column-stack-graph"),
//            options
//        );
//        chart.render();
//    })
//    .catch(error => {
//        console.error('Veri alýnýrken bir hata oluþtu:', error);
//    });
