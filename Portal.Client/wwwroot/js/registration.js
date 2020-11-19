//Global Variables
var ApplicantVM = new Object();

function Upload(inputId) {
    debugger;
    var input = $('#files').get(0);
    var files = input.files;
    var formData = new FormData();

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
        ApplicantVM.FileName = result.name;
        ApplicantVM.FileType = result.type;
        ApplicantVM.CreatedOn = result.date;
        ApplicantVM.DataFile = result.files;
    });
}

function Submit() {
    ApplicantVM.PositionId = 1;
    ApplicantVM.SkillId = 1;
    ApplicantVM.ReferenceId = 1;
    debugger;
    $.ajax({
        type: "Post",
        url: '/Registration/Register',
        data: ApplicantVM
    }).then((result) => {
        if (result.result == 'Redirect') {
            window.location = result.url;
        }
    });

}