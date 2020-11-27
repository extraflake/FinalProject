var uploadField = document.getElementById("files");

uploadField.onchange = function () {
    if (this.files[0].size > 1024000) {
        //alert("File is too big!");
        swal("Warning!", "File terlalu besar!", "warning");
        this.value = "";
    };
};

function Submit() {
    //debugger;
    //Add ApplicantVM as a new Object
    var ApplicantVM = new Object();

    //Get file
    var input = $('#files').get(0);
    var files = input.files;
    var formData = new FormData();

    //Add skill array
    var skillList = new Array();

    for (var i = 0; i !== files.length; i++) {
        formData.append("files", files[i]);
    }

    $.ajax({
        type: "Post",
        url: '/Registration/Upload',
        data: formData,
        processData: false,
        contentType: false
    }).then((result) => {
        //debugger;
        //console.log(result.date);
        ApplicantVM.CreatedOn = result.date;
        ApplicantVM.PositionId = document.getElementById('position').value;
        ApplicantVM.ReferenceId = document.getElementById('reference').value;

        debugger;
        // Add all skill
        skillList = $("#skill").val();
        ApplicantVM.SkillId = skillList;
        
        //Education Data
        var Univ = document.getElementById('university').value;

        ApplicantVM.FirstName = document.getElementById('firstname').value;
        ApplicantVM.LastName = document.getElementById('lastname').value;
        ApplicantVM.Email = document.getElementById('email').value;
        ApplicantVM.Phone = document.getElementById('hp').value;
        ApplicantVM.BirthDate = document.getElementById('birthdate').value;
        ApplicantVM.GPA = document.getElementById('gpa').value;
        ApplicantVM.Gender = document.getElementById('gender').value;

        var religion = document.getElementById('religion');
        ApplicantVM.Religion = religion.options[religion.selectedIndex].text;

        var university = document.getElementById('university');
        ApplicantVM.University = university.options[university.selectedIndex].text;

        var department = document.getElementById('department');
        ApplicantVM.Department = department.options[department.selectedIndex].text;

        ApplicantVM.Degree = document.getElementById('degree').value;
        ApplicantVM.GraduationYear = document.getElementById('gradyear').value;

        debugger;

        if (Univ == '') {
            swal("Error!", "Silahkan Lakukan Update Data Pendidikan Anda", "error");
        }
        else
        {
            if (ApplicantVM.CreatedOn == null) {
                swal("Error!", "Silahkan Attach CV Anda", "error");
            }
            else if (ApplicantVM.SkillId.length == 0) {
                swal("Error!", "Silahkan Pilih Keahlian Anda", "error");
            }
            else {

                $.ajax({
                    type: "Post",
                    url: '/Registration/Register',
                    data: ApplicantVM
                }).then((result) => {
                    //console.log(result.data);
                    if (result.data == "gagal") {
                        swal("Error!", "Please try again in a moment!", "error");
                    }
                    else if (result.data == "berhasil") {
                        swal("Success!", "Your Registration is Success!", "success");
                        ClearScreen();
                    }
                });
            }
        }
    });
}

function ClearScreen() {
    document.getElementById('files').value = "";
    document.getElementById('skill').value = "";
}

