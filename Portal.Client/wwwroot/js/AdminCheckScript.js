var table = null;
$(document).ready(function () {
    console.log("Bisa masuk!");
    table = $('#table1').DataTable({
        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        "ajax": {
            "url": "/Admin/GetApplicant",
            "type": "GET",
            "datatype": "json"
        },
        "datasrc": "data",
        columns: [
            {
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "id"
                //"visible": false
            },
            {
                "data": "alreadyCheck"
                //"render": function(data, type, row, meta) {
                //    if (data === true) {
                //        return (data === true) ? '<span class="glyphicon glyphicon-ok"></span>' : '<span class="glyphicon glyphicon-remove"></span>';
                //    }   
                //}
            },
            {
                "data": "fileId",
                "visible": false
            },
            {
                "data": "file",
                "visible": false
            },
            {
                "data": "position",
                "visible": false
            },
            {
                "data": "reference",
                "visible": false
            },
            {
                "data": "employeeId"
                //"visible": false
            },
            {
                "data": "skills",
                "visible": false
            },
            {
                "render": function (data, type, row) {
                    return '<button class="btn pull-left hidden-sm-down btn-warning" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + row.id + ');"><i class="fa fa-edit"></i></button >' + '&nbsp;' +
                        '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.id + ');"><i class="fa fa-trash"></i></button>'
                }
            }]
    });
});
