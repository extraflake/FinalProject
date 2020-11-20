$(document).ready(function () {
    console.log("ready!");
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
                            return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + row.id + ');"><i data-feather="edit"></i></button >' + '&nbsp;' +
                                '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return DeleteQuestion(' + row.id + ');"><i data-feather="trash-2"></i></button>'
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
            $('#tableQuestion').DataTable(ajax.reload());

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
    $('#updateBtn').hide();
    $('#saveBtn').show();
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
}

function DeleteQuestion(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this data!",
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: "Don't Delete",
    }).then((resultt) => {
        if (resultt.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: '/Question/DeleteQuestion',
                data: { Id: id }
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

}