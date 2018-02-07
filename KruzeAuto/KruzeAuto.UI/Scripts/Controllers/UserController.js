var UserController = function (serviceContext) {
   
    this.LogIn = function () {
        $('#logIn').on('click', function () {
            var email = validateEmail($('#email').val(), '#email');
            var password = validatePassword($('#password').val(), '#password');
            if (email !== '' && password !== '') {
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
                serviceContext.UserService().LogInValidation(email, password, "somedata", LogInCallBack);
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
                var dataToChange = {
                    UserID: CURENT_USER.UserID,
                    Email: email,
                    UserName: username,
                    Password: password,
                    PhoneNumber: phoneNumber,
                    Subscribed: subscribe
                };
               
                function callBack(data) {
                    alert('Success!');
                }
                serviceContext.UserService().UserUpdate(dataToChange, callBack);
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