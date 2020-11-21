function Submit() {
    debugger;
    var ApplicantVM = new Object();
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
        console.log(result.date);
        ApplicantVM.CreatedOn = result.date;

        ApplicantVM.PositionId = document.getElementById('position').value;
        ApplicantVM.SkillId = document.getElementById('skill').value;
        ApplicantVM.ReferenceId = document.getElementById('reference').value;
        debugger;
        $.ajax({
            type: "Post",
            url: '/Registration/Register',
            data: ApplicantVM
        }).then((result) => {
            console.log(result.data);
            $('#files').value('');
        });
    });
}

