﻿$(document).ready(function () {
    //debugger;
    //User Data

    var gradYear = document.getElementById("gradyear");
    $.ajax({
        url: "/Registration/GetEducation/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            debugger;
            var qt = JSON.parse(data);
            //console.log(qt);
            var gpa = $("#gpa").val(qt.data['gpa']);

            var degree = document.getElementById("degree");
            var degreeValue = qt.data['degree'];

            if (degreeValue == 'SMK/SMA') {
                degree.selectedIndex = "0";
            }
            else if (degreeValue == 'D3') {
                degree.selectedIndex = "1";
            }
            else if (degreeValue == 'D4/S1') {
                degree.selectedIndex = "2";
            }
            else if (degreeValue == 'S2') {
                degree.selectedIndex = "3";
            }
            else {
                degree.selectedIndex = "4";
            }

            graduateYear = qt.data['graduateYear'];

            gradYear.selectedIndex = (document.getElementById(graduateYear.toString()).index).toString();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    var EditProfileVM = new Object();
    //Department
    $.ajax({
        type: "Get",
        url: '/Registration/GetDepartment',
        data: EditProfileVM,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (department) {
            debugger;
            var qt = JSON.parse(department);

            var dropDownDepartment = document.getElementById("department");

            //console.log(document.getElementById('Islam').value);

            var DepartmentData = qt.data['name'];
            //console.log(DepartmentData);

            dropDownDepartment.selectedIndex = (document.getElementById(DepartmentData).index).toString();
        }
    });

    $.ajax({
        type: "Get",
        url: '/Registration/GetUniversity',
        data: EditProfileVM,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (university) {
            debugger;
            var qt = JSON.parse(university);

            var dropDownUniversity = document.getElementById("university");

            //console.log(document.getElementById('Islam').value);

            var UniversityData = qt.data['name'];
            //console.log(UniversityData);

            dropDownUniversity.selectedIndex = (document.getElementById(UniversityData).index).toString();
        }
    });
});