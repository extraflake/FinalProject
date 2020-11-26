﻿$(document).ready(function () {
    //debugger;
    //Referensi
    $.ajax({
        url: "/Registration/GetNameReference/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            var qt = JSON.parse(data);
            console.log(qt);
            var dropDown = document.getElementById("reference");
            for (var i = 0; i < qt.data.length; i++) {

                dropDown.innerHTML = dropDown.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '">' + qt.data[i]['name'] + '</option>';
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    //Posisi
    $.ajax({
        url: "/Registration/GetNamePosition/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            var qt = JSON.parse(data);
            console.log(qt);
            var dropDown = document.getElementById("position");
            for (var i = 0; i < qt.data.length; i++) {

                dropDown.innerHTML = dropDown.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '">' + qt.data[i]['name'] + '</option>';
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    //Skill
    $('#skill').select2({
        placeholder: "Pilih kemampuan yang anda miliki"
    });

    $.ajax({
        url: "/Registration/GetNameSkill/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            //debugger;
            var qt = JSON.parse(data);
            console.log(qt);
            var dropDown = document.getElementById("skill");
            //var dropDown = $('#skill').select2();
            for (var i = 0; i < qt.data.length; i++) {
                dropDown.innerHTML = dropDown.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '">' + qt.data[i]['name'] + '</option>';
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
});