var user = document.getElementById('user');
var password = document.getElementById('password');

//$(document).ready(function () {
//    Swal.fire({
//        position: 'center',
//        type: 'info',
//        icon: 'info',
//        title: 'Your final score : ' + sessionStorage.getItem("score"),
//        confirmButtonText: 'OK'
//    }).then((resultt) => {
//        if (resultt.isConfirmed) {
//            window.location.href = "https://localhost:44311/";
//        }
//        else {
//            console.log("No");
//        }
//    });
//})

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