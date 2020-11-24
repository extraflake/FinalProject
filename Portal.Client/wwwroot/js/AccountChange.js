var newPass = document.getElementById('new');
var confirm = document.getElementById('confirm');

function Change() {
    if (newPass.value != confirm.value) {
        swal("Error!", "Password yang anda masukkan tidak cocok", "error");
    }
    else {
        var RegisterVM = new Object();
        RegisterVM.User_Password = newPass.value;

        $.ajax({
            type: "PUT",
            url: '/Account/Change',
            data: RegisterVM
        }).then((result) => {
            console.log(result.data);
        });
    }
}