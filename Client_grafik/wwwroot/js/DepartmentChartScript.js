
var canvas = document.getElementById('deptChart').getContext('2d');
var qt;
var deptName = [];
var deptSum = [];
var coloR = [];

$(document).ready(function () {

    $.ajax({
        "type": "GET",
        "url": "/Grafik/GetDepartment",
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
                deptName[i] = qt[i]['department'];
                deptSum[i] = qt[i]['total'];
                coloR.push(dynamicColors());
            }
            console.log(deptName);
            console.log(deptSum);
            initChart();
        }
    });
})


function initChart() {
    var database = {
        labels: deptName,
        datasets: [{
            label: "Total Applicant",
            data: deptSum,
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