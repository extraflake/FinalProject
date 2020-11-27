var user = document.getElementById('user');
var password = document.getElementById('password');

function SignIn() {
    var LoginVM = new Object();
    LoginVM.User_Email = user.value;
    LoginVM.Username = user.value;
    LoginVM.Phone = user.value;
    LoginVM.User_Password = password.value;

    $.ajax({
        type: "POST",
        url: '/Login/Login',
        data: LoginVM
    }).then((result) => {
        //console.log(result.data);
        if (result.data == "berhasil") {
            console.log(result.token);
            //swal("Success!", "Registrasi anda berhasil!", "success");
            window.location = result.url;
        }
        else swal("Error!", result.data, "error")
    });
}