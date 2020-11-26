var uploadField = document.getElementById("files");

uploadField.onchange = function () {
    if (this.files[0].size > 1024000) {
        //alert("File is too big!");
        swal("Warning!", "File terlalu besar!", "warning");
        this.value = "";
    };
};

function Submit() {
    debugger;
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
        var Univ = document.getElementById('university').value;
        // Add all skill
        skillList = $("#skill").val();
        ApplicantVM.SkillId = skillList;
        debugger
        $.ajax({
            type: "Post",
            url: '/Registration/Register',
            data: ApplicantVM
        }).then((result) => {
            console.log(result.data);
            //$('#files').value('');
            if (result.data == "gagal") {
                swal("Error!", "Please try again in a moment!", "error");
            }
            else if (result.data == "berhasil") {
                swal("Success!", "Your Registration is Success!", "success");
                ClearScreen();
            }
        });

        //if (Univ == '') {
        //    swal("Error!", "Silahkan Lakukan Update Data Pendidikan Anda", "error");
        //}
        //else
        //{
        //    if (ApplicantVM.CreatedOn == null) {
        //        swal("Error!", "Silahkan Attech CV Anda", "error");
        //    }
        //    else if (ApplicantVM.SkillId == null) {
        //        swal("Error!", "Silahkan Pilih Keahlian Anda", "error");
        //    }
        //    else if (ApplicantVM.SkillId == null) {
        //        swal("Error!", "Silahkan Pilih Keahlian Anda", "error");
        //    }
        //    else {
        //        //debugger
        //        $.ajax({
        //            type: "Post",
        //            url: '/Registration/Register',
        //            data: ApplicantVM
        //        }).then((result) => {
        //            console.log(result.data);
        //            //$('#files').value('');
        //            if (result.data == "gagal") {
        //                swal("Error!", "Please try again in a moment!", "error");
        //            }
        //            else if (result.data == "berhasil") {
        //                swal("Success!", "Your Registration is Success!", "success");
        //                ClearScreen();
        //            }
        //        });
        //    }
        //}
    });
}

function ClearScreen() {
    document.getElementById('files').value = "";
    document.getElementById('skill').value = "";
}

