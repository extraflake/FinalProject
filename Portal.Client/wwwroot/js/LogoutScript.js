function Logout() {
    $.ajax({
        url: '/Registration/Logout',
        data: RegisterVM
    });
}