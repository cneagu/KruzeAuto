var LogIn = function (serviceContext) {
    this.ValidateLogIn = function (email, password) {

        function UserReadByIdCallBack(user) {

            CURENT_USER = user;

            $("#loginModal .close").click();
            $('#user_menu').removeAttr('hidden');
            $('#login-button').attr("hidden", "true");
            $('#head-userName').html("<i class='fa fa-user'></i>  " + user.UserName);

        }

        function LogInCallBack(guid) {
            if (guid == '00000000-0000-0000-0000-000000000000') {
                alert("Account doesn't exist");
            }
            else {
                alert('You are LogIn');
                window.location.hash = '#user_profile';
                serviceContext.UserService().ReadById(guid, "somedata", UserReadByIdCallBack);
            }
        }
        serviceContext.UserService().LogInValidation(email, password,"somedata", LogInCallBack);
    }
}