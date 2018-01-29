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

    this.Setings = function () {
        $('.setings').on('click', function () {
            $("#curent-Username").html(CURENT_USER.UserName);
            $("#curent-Email").html(CURENT_USER.Email);
            $("#curent-PhoneNumber").html(CURENT_USER.PhoneNumber);
            if (CURENT_USER.Subscribed) {
                $('#new-seting-subscribe').attr('checked', true);
            }
                

        });

        $('#update-setings').on('click', function () {

            var username = validateUsername($('#new-seting-username').val(), '#new-seting-username');
            var email = validateEmail($('#new-seting-email').val(), '#new-email'); 
            var curentPassword = validateCurentPassword(validatePassword($('#new-seting-curent-password').val(), '#new-seting-curent-password'));
            var password = validatePassword($('#new-seting-new-password').val(), '#new-seting-new-password');
            var rePassword = validaterePassword($('#new-seting-new-cpassword').val(), password, '#new-seting-new-cpassword');
            var phoneNumber = validatePhoneNumber($('#new-seting-phoneNumber').val(), '#new-seting-phoneNumber');          
            var subscribe = $('#new-seting-subscribe').is(':checked') ? true : false;
          
            var inputData = {
                username: username,
                email: email,
                curentPassword: curentPassword,
                password: password,
                rePassword: rePassword,
                phoneNumber: phoneNumber,
                subscribe: subscribe
            };
            var action = validate(inputData);

            if (action == 1) {
                var data = {
                    UserID: CURENT_USER.UserID,
                    Email: email,
                    UserName: username,
                    Password: password,
                    PhoneNumber: phoneNumber,
                    Subscribed: subscribe
                };
                var _userFunction = new UserFunction(serviceContext);
                _userFunction.Update(data);
            } else {
                alert('something is not ok');
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