$(document).ready(function () {
    //debugger;
    //User Data

    var gradYear = document.getElementById("gradyear");
    $.ajax({
        url: "/Registration/GetEducation/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        beforeSend: function () {
            //debugger;
            var createLoader = document.getElementById("loader");
            createLoader.classList.remove('hidden');
        },
        complete: function () {
            var createLoader = document.getElementById("loader");
            createLoader.classList.add('hidden');
        },
        success: function (data) {
            debugger;
            if (data.data != "gagal") {
                var qt = JSON.parse(data.data);
                //console.log(qt);
                var gpa = $("#gpa").val(qt.data['gpa']);

                var degree = document.getElementById("degree");
                var degreeValue = qt.data['degree'];

                if (degreeValue == '') {
                    degree.selectedIndex = "0";
                }
                else if (degreeValue == 'SMK/SMA') {
                    degree.selectedIndex = "1";
                }
                else if (degreeValue == 'D3') {
                    degree.selectedIndex = "2";
                }
                else if (degreeValue == 'D4/S1') {
                    degree.selectedIndex = "3";
                }
                else if (degreeValue == 'S2') {
                    degree.selectedIndex = "4";
                }
                else {
                    degree.selectedIndex = "5";
                }

                graduateYear = qt.data['graduateYear'];

                gradYear.selectedIndex = (document.getElementById(graduateYear.toString()).index).toString();
            }
            

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
        beforeSend: function () {
            //debugger;
            var createLoader = document.getElementById("loader");
            createLoader.classList.remove('hidden');
        },
        complete: function () {
            var createLoader = document.getElementById("loader");
            createLoader.classList.add('hidden');
        },
        success: function (department) {
            debugger;
            if (department.data != "gagal") {
                var qt = JSON.parse(department.data);

                var dropDownDepartment = document.getElementById("department");

                //console.log(document.getElementById('Islam').value);

                var DepartmentData = qt.data['name'];
                //console.log(DepartmentData);

                if (DepartmentData != null) {
                    dropDownDepartment.selectedIndex = (document.getElementById(DepartmentData).index).toString();
                }
            }
        },
        error: function (errormessage) {

        }
    });

    $.ajax({
        type: "Get",
        url: '/Registration/GetUniversity',
        data: EditProfileVM,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        beforeSend: function () {
            //debugger;
            var createLoader = document.getElementById("loader");
            createLoader.classList.remove('hidden');
        },
        complete: function () {
            var createLoader = document.getElementById("loader");
            createLoader.classList.add('hidden');
        },
        success: function (university) {
            //debugger;
            if (university.data != "gagal") {
                var qt = JSON.parse(university.data);

                var dropDownUniversity = document.getElementById("university");

                //console.log(document.getElementById('Islam').value);

                var UniversityData = qt.data['name'];
                //console.log(UniversityData);

                if (UniversityData != null) {
                    dropDownUniversity.selectedIndex = (document.getElementById(UniversityData).index).toString();
                }
            }
        },
        error: function (errormessage) {

        }
    });
});