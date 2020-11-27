
var canvas = document.getElementById('univChart').getContext('2d');
var qt;
var univName = [];
var univSum = [];
var coloR = [];

$(document).ready(function () {

    $.ajax({
        "type": "GET",
        "url": "/Grafik/GetUniversity",
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (data) {

            var dynamicColors = function () {
                var r = Math.floor(Math.random() * 255);
                var g = Math.floor(Math.random() * 255);
                var b = Math.floor(Math.random() * 255);
                return "rgb(" + r + "," + g + "," + b + ")";
            };

            qt = JSON.parse(data);
            for (var i = 0; i < qt.length; i++) {
                univName[i] = qt[i]['university'];
                univSum[i] = qt[i]['total'];
                coloR.push(dynamicColors());
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
            data: univSum,
            backgroundColor: coloR,
            borderColor: coloR,
            borderWidth: [1, 1, 1, 1, 1]
        }]
    };
    var chartOptions = {
        responsive: true,
        legend: {
            display: true,
            position: "bottom",
            labels: {
                fontColor: "#333",
                fontSize: 16
            }
        }
    };
    var lineChart = new Chart(canvas, {
        type: 'doughnut',
        data: database,
        options: chartOptions
    });
}