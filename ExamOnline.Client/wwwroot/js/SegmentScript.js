var table = null;
var qt;

$(document).ready(function () {
    console.log("ready!");
    $.ajax({
        type: "GET",
        url: "/Segment/LoadSegment",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            qt = JSON.parse(data);
            table = $('#tableSegment').dataTable({
                "oLanguage": {
                    "sSearch": "Filter Data"
                },
                "iDisplayLength": -1,
                "sPaginationType": "full_numbers",
                "dataSrc": "",
                "columns": [
                    {
                        render: function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    { "data": "title" },
                    { "data": "duration" },
                    { "data": "questionQuantity" },
                    {
                        "render": function (data, type, row) {
                            return '<button class="btn btn-warning" data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + row.Id + ')"><i data-feather="edit"></i></button>' + '&nbsp;' +
                                '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.Id + ')"><i data-feather="trash-2"></i></button>'
                        }
                    }]
            });
            $(qt).each(function () {
                console.log(qt.data);
            })
        }
    }); 
});

function Add() {
    $('#updateBtn').hide();
    $('#title').val('');
    $('#duration').val('');
    $('#questionQty').val('');
}

function Save() {
    var Segment = new Object();
    Segment.Title = $('#title').val();
    Segment.Duration = $('#duration').val();
    Segment.QuestionQuantity = $('#questionQty').val();
    debugger;
    $.ajax({
        type: "Post",
        url: '/segment/addsegment',
        data: Segment
    }).then((result) => {
        debugger;
        console.log(result);
        if (result != "GAGAL") {
            Swal.fire({
                position: 'center',
                type: 'success',
                icon: 'success',
                title: 'Added Successfully'
            });
            //window.location = result.url;
        }
        else {
            Swal.fire({
                position: 'center',
                type: 'error',
                icon: 'error',
                title: 'Failed to add!'
            });
        }
    }).catch((error) => {
        console.log(error);
    });
}




    