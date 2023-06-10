$(document).ready(function () {
    GetCustomerPurchases();
});

function GetCustomerPurchases() {
    // M��teri sat�n alma verilerini almak i�in AJAX iste�i yap�n
    $.ajax({
        url: '/home/getcustomerpurchases', // Verileri almak i�in uygun URL'yi ayarlay�n
        method: 'GET',
        success: function (data) {
            // AJAX iste�i ba�ar�l� oldu�unda �al��acak kod
            var purchases = data; // Al�nan verileri purchases de�i�kenine atay�n

            // Grafik i�in gerekli series verisini olu�turun
            var series = purchases.map(function (item) {
                return {
                    name: item.customerName,
                    data: generateDayWiseTimeSeries(new Date(item.purchaseDate).getTime(), item.purchaseCount, {
                        min: 10,
                        max: 60
                    })
                };
            });

            // options nesnesini g�ncelleyin
            options.series = series;

            // Grafik nesnesini yeniden olu�turun ve yeniden �izin
            var chart = new ApexCharts(document.querySelector("#basic-area-stack-graph"), options);
            chart.render();
        },
        error: function (xhr, status, error) {
            // AJAX iste�i ba�ar�s�z oldu�unda �al��acak kod
            console.log("Hata al�nd�:", error);
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
