$(document).ready(function () {
    //debugger;
    var d = new Date();
    var year = d.getFullYear();

    var gradYear = document.getElementById("gradyear");
    for (var i = 0; i < 8; i++) {
        //console.log(year - 4 + i);
        var yearOpt = year - 4 + i;
        //console.log(yearOpt);
        //console.log(dropDown.innerHTML + '<option value="' + year - 4 + i + '">' + year - 4 + i + '</option>');
        gradYear.innerHTML = gradYear.innerHTML +
            '<option value="' + yearOpt + '">' + yearOpt + '</option>';
    }
});

function Submit() {
    debugger;
    //Add ApplicantVM as a new Object
    var EditProfileVM = new Object();


    EditProfileVM.FirstName = document.getElementById('firstname').value;
    EditProfileVM.LastName = document.getElementById('lastname').value;
    EditProfileVM.User_Email = document.getElementById('email').value;
    EditProfileVM.Phone = document.getElementById('hp').value;
    EditProfileVM.BirthDate = document.getElementById('birthdate').value;
    EditProfileVM.GPA = document.getElementById('gpa').value;

    EditProfileVM.Gender = document.getElementById('gender').value;
    EditProfileVM.ReligionId = document.getElementById('religion').value;
    EditProfileVM.UniversityId = document.getElementById('university').value;
    EditProfileVM.DepartmentId = document.getElementById('department').value;
    EditProfileVM.Degree = document.getElementById('degree').value;
    EditProfileVM.GraduateYear = document.getElementById('gradyear').value;





    //$.ajax({
    //    type: "Post",
    //    url: '/Registration/Upload',
    //    data: formData,
    //    processData: false,
    //    contentType: false
    //}).then((result) => {
    //    //debugger;
    //    //console.log(result.date);
    //    ApplicantVM.CreatedOn = result.date;
    //    ApplicantVM.PositionId = document.getElementById('position').value;
    //    ApplicantVM.ReferenceId = document.getElementById('reference').value;
    //    var Univ = document.getElementById('university').value;
    //    // Add all skill
    //    skillList = $("#skill").val();
    //    ApplicantVM.SkillId = skillList;
    //    debugger
    //    if (Univ == '') {
    //        swal("Error!", "Silahkan Lakukan Update Data Pendidikan Anda", "error");
    //    }
    //    else {
    //        if (ApplicantVM.CreatedOn == null) {
    //            swal("Error!", "Silahkan Attech CV Anda", "error");
    //        }
    //        else if (ApplicantVM.SkillId == null) {
    //            swal("Error!", "Silahkan Pilih Keahlian Anda", "error");
    //        }
    //        else if (ApplicantVM.SkillId == null) {
    //            swal("Error!", "Silahkan Pilih Keahlian Anda", "error");
    //        }
    //        else {
    //            //debugger
    //            $.ajax({
    //                type: "Post",
    //                url: '/Registration/Register',
    //                data: ApplicantVM
    //            }).then((result) => {
    //                console.log(result.data);
    //                //$('#files').value('');
    //                if (result.data == "gagal") {
    //                    swal("Error!", "Please try again in a moment!", "error");
    //                }
    //                else if (result.data == "berhasil") {
    //                    swal("Success!", "Your Registration is Success!", "success");
    //                    ClearScreen();
    //                }
    //            });
    //        }
    //    }
    //});
}

function ClearScreen() {
    document.getElementById('files').value = "";
    document.getElementById('skill').value = "";
}
