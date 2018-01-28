var UserController = function (serviceContext) {
   
    this.LogIn = function () {
        $('#logIn').on('click', function () {
            var email = validateEmail($('#email').val(), '#email');
            var password = validatePassword($('#password').val(), '#password');
            if (email !== '' && password !== '') {
                var _logIn = new LogIn(serviceContext);
                _logIn.ValidateLogIn(email, password);
            }
        });
    };

    this.LogOut = function () {
        $('#logOut').on('click', function () {
            $('#user_menu').attr("hidden", "true");
            $('#login-button').removeAttr('hidden');

            //data-dismiss
            CURENT_USER = [];
            CURENT_LOCATION = [];
            CURENT_ANNOUNCEMENTS = [];
            CURENT_INBOX = [];

            //$('input').val('');
            //$('option').attr('selected', false)
        });
    };

    this.UserProfile = function () {

        
    };

};