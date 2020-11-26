
var canvas = document.getElementById('univChart').getContext('2d');
var qt;
var univName = [];
var univSum = [];

$(document).ready(function () {

    $.ajax({
        "type": "GET",
        "url": "/Grafik/GetUniversity",
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (data) {
            qt = JSON.parse(data);
            for (var i = 0; i < qt.length; i++) {
                univName[i] = qt[i]['university'];
                univSum[i] = qt[i]['total'];
            }
            console.log(univName);
            console.log(univSum);
            initChart();
        }
    }); 
})

function initChart() {
    var database = {
        labels: univName,
        datasets: [{
            label: "Total Applicant",
            data: univSum
        }]
    };
    var chartOptions = {
        legend: {
            display: true,
            position: 'top',
            labels: {
                boxWidth: 80,
                fontColor: 'black'
            }
        }
    };
    var lineChart = new Chart(canvas, {
        type: 'bar',
        data: database,
        options: chartOptions
    });
}