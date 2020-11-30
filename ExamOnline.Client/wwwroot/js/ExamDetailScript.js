var table = null;
var qt;
var data;
var endTime = new Date();

$.ajax({
    "type": "GET",
    "url": "/ExamDetail/LoadExamDetail",
    "contentType": "application/json; charset=utf-8",
    "dataType": "json",
    "success": function (data) {
        debugger;
        qt = JSON.parse(data);
        console.log(qt);
        $('#tableExamDetail').DataTable({
            data: qt,
            columns: [
                {
                    "render": function (data, type, row, meta) {
                        return meta.row + meta.settings._iDisplayStart + 1;
                    }
                },
                {
                    "data": "id",
                    "visible": false
                },
                { "data": "applicantId" },
                { "data": "finalScore" },
                {
                    "data": "endTime",
                    "render": function (data, type, row, meta) {
                        endTime = new Date(data);
                        endTime = endTime.getTime();
                    },
                    "visible": false
                },
                {
                    "data": "startTime",
                    "render": function (data, type, row, meta) {
                        var start = new Date(data);
                        start = start.getTime();
                        var distance = endTime - start;
                        var h = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                        var m = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                        var s = Math.floor((distance % (1000 * 60)) / 1000);

                        console.log(h, m, s);
                        return h + "h " + m + "m " + s + "s";
                    }
                },
                { "data": "grades" }
            ]
        });
    }
}); 