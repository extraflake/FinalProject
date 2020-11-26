var table = null;

$(document).ready(function () {
    console.log("ready!");

    var dropdown = document.getElementById('segmentName');
    $.ajax({
        "type": "GET",
        "url": "/Segment/LoadSegment",
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (data) {
            qt = JSON.parse(data);
            
            debugger;
            console.log(qt.data);
            for (var i = 0; i < qt.data.length; i++) {
                dropdown.innerHTML = dropdown.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '">' + qt.data[i]['title'] + '</option>';
            }
        }
    }); 

    $.ajax({
    });
    /*debugger;
    table = $('#tableQuestion').DataTable({
        ajax: {
            "type": "GET",
            "url": "/Question/LoadQuestion",
            "contentType": "application/json; charset=utf-8",
            "dataType": "json",
            "dataSrc": "data",
            "success": function (data) {
                qt = JSON.parse(data);
                console.log(qt);
            },
            
             columns: [
                {
                    render: function (data, type, row, meta) {
                        return meta.row + meta.settings._iDisplayStart + 1;
                    }
                },
                {
                    "data": "id",
                    "visible": false
                },
                { "data": "title" },
                { "data": "quest" },
                {
                    "data": "answerA",
                    "visible": false
                },
                {
                    "data": "answerB",
                    "visible": false
                },
                {
                    "data": "answerC",
                    "visible": false
                },
                {
                    "data": "answerD",
                    "visible": false
                },
                {
                    "data": "point",
                    "visible": false
                },
                {
                    "data": "segmentId",
                    "visible": false
                },
                {
                    "render": function (data, type, row) {
                        return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + row.id + ');"><i class="fa fa-edit"></i></button >' + '&nbsp;' +
                            '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return DeleteQuestion(' + row.id + ');"><i class="fa fa-trash"></i></button>'
                    }
                }]
        }
        
    });
    console.log();*/

     $.ajax({
        "type": "GET",
        "url": "/Question/LoadQuestion",
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (data) {
            qt = JSON.parse(data);
            console.log(qt);
             $('#tableQuestion').DataTable({
                data: qt,
                columns: [
                    {
                        render: function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    {
                        "data": "id",
                        "visible": false
                    },
                    { "data": "title" },
                    {   "data": "quest" },
                    {
                        "data": "answerA",
                        "visible":false
                    },
                    {
                        "data": "answerB",
                        "visible":false
                    },
                    {
                        "data": "answerC",
                        "visible" : false
                    },
                    {
                        "data": "answerD",
                        "visible":false
                    },
                    {
                        "data": "point",
                        "visible":false
                    },
                    {
                        "data": "segmentId",
                        "visible":false
                    },
                    {
                        "render": function (data, type, row) {
                            return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + row.id + ');"><i class="fa fa-edit"></i></button >' + '&nbsp;' +
                                '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return DeleteQuestion(' + row.id + ');"><i class="fa fa-trash"></i></button>'
                        }
                    }]
            });
        }
    });
});

function Save() {
    var QuestionVM = new Object();
    QuestionVM.segmentId = $('#segmentName').val();
    QuestionVM.quest = $('#question').val();
    QuestionVM.answerA = $('#answerA').val();
    QuestionVM.answerB = $('#answerB').val();
    QuestionVM.answerC = $('#answerC').val();
    QuestionVM.answerD = $('#answerD').val();
    QuestionVM.point = $('#point').val();
    var choiceCorrect = $('#correctAnswer').val();
    var correctAnswer = $('#' + choiceCorrect).val();
    QuestionVM.correctAnswer = correctAnswer;
    debugger;
    $.ajax({
        type: "POST",
        url: '/question/addquestion',
        data: QuestionVM
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
            //table.ajax.reload();

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

function Add() {
    $('#segmentName').val('');
    $('#question').val('');
    $('#answerA').val('');
    $('#answerB').val('');
    $('#answerC').val('');
    $('#answerD').val('');
    $('#point').val('');
    $('#correctAnswer').val('');
    $('#updateBtn').hide();
    $('#saveBtn').show();
    ClearScreen();
}

function DeleteQuestion(id) {
    var QuestionVM = new Object();
    QuestionVM.Id = id;
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this data!",
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: "Don't Delete",
    }).then((resultt) => {
        if (resultt.isConfirmed) {
            $.ajax({
                type: "POST",
                url: '/Question/DeleteQuestion',
                data: QuestionVM
            }).then((result) => {
                debugger;
                if (result != "GAGAL") {
                    Swal.fire({
                        position: 'center',
                        type: 'success',
                        icon: 'success',
                        title: 'Delete successfully!'
                    });
                    table.ajax.reload();
                }
                else {
                    Swal.fire({
                        position: 'center',
                        type: 'error',
                        icon: 'error',
                        title: 'Failed to delete!'
                    });
                }
            }).catch((error) => {
                console.log(error);
            });
        } else if (resultt.isDenied) {
            Swal.fire('Changes are not saved', '', 'info')
        }
    });
}

function GetById(id) {
    var QuestionVM = new Object();
    QuestionVM.Id = id;
    $.ajax({
        type: "POST",
        url: '/Question/GetById',
        data: QuestionVM
    }).then((result) => {
        debugger;
        if (result != "GAGAL") {
            const obj = JSON.parse(result);
            $('#Id').val(obj['id']);
            $('#segmentName').val(obj['segmentId']);
            $('#question').val(obj['quest']);
            $('#answerA').val(obj['answerA']);
            $('#answerB').val(obj['answerB']);
            $('#answerC').val(obj['answerC']);
            $('#answerD').val(obj['answerD']);
            $('#point').val(obj['point']);
            $('#segment').val(obj['segmentId']);

            if (obj['correctAnswer'] == obj['answerA']) {
                $('#correctAnswer').val('answerA');
            }
            else if (obj['correctAnswer'] == obj['answerB']) {
                $('#correctAnswer').val('answerB');
            }
            else if (obj['correctAnswer'] == obj['answerC']) {
                $('#correctAnswer').val('answerC');
            }
            else if (obj['correctAnswer'] == obj['answerD']) {
                $('#correctAnswer').val('answerD');
            }

            $('#myModal').modal();
            $('#updateBtn').show();
            $('#saveBtn').hide();
            
        }
    }).catch((error) => {
        console.log(error);
    });
}
function ClearScreen() {
    $('#Id').val('');
    $('#segmentName').val('');
    $('#question').val('');
    $('#answerA').val('');
    $('#answerB').val('');
    $('#answerC').val('');
    $('#answerD').val('');
    $('#point').val('');
    $('#segment').val('');
}

function UpdateQuestion() {
    var QuestionVM = new Object();
    QuestionVM.id = $('#Id').val();
    QuestionVM.segmentId = $('#segmentName').val();
    QuestionVM.quest = $('#question').val();
    QuestionVM.answerA = $('#answerA').val();
    QuestionVM.answerB = $('#answerB').val();
    QuestionVM.answerC = $('#answerC').val();
    QuestionVM.answerD = $('#answerD').val();
    QuestionVM.point = $('#point').val();
    var choiceCorrect = $('#correctAner').val();
    var correctAnswer = $('#' + choiceCorrect).val();
    QuestionVM.correctAnswer = correctAnswer;
    debugger;
    $.ajax({
        type: "PUT",
        url: '/question/updatequestion',
        data: QuestionVM
    }).then((result) => {
        debugger;
        console.log(result);
        if (result != "GAGAL") {
            Swal.fire({
                position: 'center',
                type: 'success',
                icon: 'success',
                title: 'Updated successfully!'
            });
            $('#tableQuestion').DataTable(ajax.reload());
            ClearScreen();
        }
        else {
            Swal.fire({
                position: 'center',
                type: 'error',
                icon: 'error',
                title: 'Failed to update!'
            });
        }
    }).catch((error) => {
        console.log(error);
    });
}