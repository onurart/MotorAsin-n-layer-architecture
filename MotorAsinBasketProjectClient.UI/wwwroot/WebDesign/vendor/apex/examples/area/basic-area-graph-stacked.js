$(document).ready(function () {
    GetCustomerPurchases();
});

function GetCustomerPurchases() {
    // Müþteri satýn alma verilerini almak için AJAX isteði yapýn
    $.ajax({
        url: '/home/getcustomerpurchases', // Verileri almak için uygun URL'yi ayarlayýn
        method: 'GET',
        success: function (data) {
            // AJAX isteði baþarýlý olduðunda çalýþacak kod
            var purchases = data; // Alýnan verileri purchases deðiþkenine atayýn

            // Grafik için gerekli series verisini oluþturun
            var series = purchases.map(function (item) {
                return {
                    name: item.customerName,
                    data: generateDayWiseTimeSeries(new Date(item.purchaseDate).getTime(), item.purchaseCount, {
                        min: 10,
                        max: 60
                    })
                };
            });

            // options nesnesini güncelleyin
            options.series = series;

            // Grafik nesnesini yeniden oluþturun ve yeniden çizin
            var chart = new ApexCharts(document.querySelector("#basic-area-stack-graph"), options);
            chart.render();
        },
        error: function (xhr, status, error) {
            // AJAX isteði baþarýsýz olduðunda çalýþacak kod
            console.log("Hata alýndý:", error);
        }
    });
}

function generateDayWiseTimeSeries(baseval, count, yrange) {
    var i = 0;
    var series = [];
    while (i < count) {
        var x = baseval;
        var y = Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;

        series.push([x, y]);
        baseval += 86400000;
        i++;
    }
    return series;
}
