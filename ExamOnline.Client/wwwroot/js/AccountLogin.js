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
        debugger;
        sessionStorage.setItem("applicantId", result.data);
        if (result.data != "GAGAL") {
            console.log(result.token);
            window.location = result.url;
        }
        else {
            Swal.fire({
                position: 'center',
                type: 'error',
                icon: 'error',
                title: 'Failed to Login!'
            });
        }
    });
}