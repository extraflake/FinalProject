var user = document.getElementById('user');
var password = document.getElementById('password');

function SignIn() {
    var RegisterVM = new Object();
    RegisterVM.User_Email = user.value;
    RegisterVM.Username = user.value;
    RegisterVM.Phone = user.value;
    RegisterVM.User_Password = password.value;

    $.ajax({
        type: "POST",
        url: '/Account/Login',
        data: RegisterVM
    }).then((result) => {
        //console.log(result.data);
        if (result.data == "berhasil") {
            console.log(result.token);
            swal("Success!", "Registrasi anda berhasil!", "success");
        }
        else swal("Error!", result.data, "error")
    });
}