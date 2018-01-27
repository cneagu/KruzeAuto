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

};