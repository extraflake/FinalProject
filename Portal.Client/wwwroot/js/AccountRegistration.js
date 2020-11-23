function SignUp() {
    var RegisterVM = new Object();
    RegisterVM.UserEmail = $('#email').val();
    RegisterVM.UserPassword = $('#password').val();
    $.ajax({
        type: "POST",
        url: '/Accounts/Get',
        data: RegisterVM
    }).then((result) => {
        //console.log(result.data);
        if (result.data == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Login Success',
                showConfirmButton: false,
                timer: 3000
            }).then(() => {
                window.location = result.url;
            });
        }
    }).catch((error) => {
        Swal.fire({
            position: 'top-center',
            icon: 'error',
            title: 'Login Error',
            showConfirmButton: true,
            timer: 3000
        });
        ClearScreen();
    });
}

function ClearScreen() {
    $('#email').val('');
    $('#password').val('');
}