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
        console.log(result.date);
        ApplicantVM.CreatedOn = result.date;
        ApplicantVM.PositionId = document.getElementById('position').value;
        ApplicantVM.ReferenceId = document.getElementById('reference').value;

        // Add all skill
        skillList = $("#skill").val();
        ApplicantVM.SkillId = skillList;

        //debugger;
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

