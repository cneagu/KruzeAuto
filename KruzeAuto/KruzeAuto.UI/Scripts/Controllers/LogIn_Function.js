var LogIn = function (serviceContext) {
    this.ValidateLogIn = function (email, password) {

        function UserReadByIdCallBack(user) {
            console.log(user);
            $("#loginModal .close").click();
            $('#user_menu').removeAttr('hidden');
            $('#login-button').attr("hidden", "true");
            $('#head-userName').text(user.UserName);
            $('#logOut').on('click', function () {
                $('#user_menu').attr("hidden", "true");
                $('#login-button').removeAttr('hidden');
                //data-dismiss
            });

        }

        function LogInCallBack(guid) {
            if (guid == '00000000-0000-0000-0000-000000000000')
                alert("Account doesn't exist");
            else {
                alert('You are LogIn');
                window.location.hash = '#user_profile';
                serviceContext.UserService().ReadById(guid, "somedata", UserReadByIdCallBack);

            }
        }
        serviceContext.UserService().LogInValidation(email, password,"somedata", LogInCallBack);
    }
}