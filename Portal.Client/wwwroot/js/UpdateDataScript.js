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

    $.ajax({
        type: "Put",
        url: '/Registration/UpdateData',
        data: EditProfileVM
    }).then((result) => {
        //console.log(result.data);
        //$('#files').value('');
        if (result.data == "gagal") {
            swal("Error!", "Please try again in a moment!", "error");
        }
        else if (result.data == "sukses") {
            swal("Success!", "Update Data Berhasil!", "success").then(() => {
                //window.location = result.url;
                console.log(result.log);
            });
        }
    });
}
