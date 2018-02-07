var SingInController = function (serviceContext) {

    this.InsertLocationData = function () {
        for (var i = 0; i < COUNTRY_DATA.length; i++)
            $("#new-country").append(" <option value='" + COUNTRY_DATA[i].name + "'>" + COUNTRY_DATA[i].name + "</option>");

        $("#new-country").change(function () {
            var country = $("#new-country").val();
            $("#new-county").children().remove();
            if (country === 'Romania')
            {
                for (var property in COUNTY_DATA)
                    $("#new-county").append(" <option value='" + property + "'>" + property + "</option>");
            }

            var county = $("#new-county").val();
            $("#new-city").children().remove();
            for (var property in COUNTY_DATA[county])
                $("#new-city").append(" <option value='" + property + "'>" + property + "</option>");
        });

        $("#new-county").change(function () {
            var county = $("#new-county").val();
            $("#new-city").children().remove();
            for (var property in COUNTY_DATA[county])
                $("#new-city").append(" <option value='" + property + "'>" + property + "</option>");
        });
    };

    this.SubmitForm = function () {
        $("#singIn").on('click', function () {
            var username = validateUsername($('#new-username').val(), '#new-username');
            var email = validateEmail($('#new-email').val(), '#new-email');
            var password = validatePassword($('#new-password').val(), '#new-password');
            var rePassword = validaterePassword($('#new-c-password').val(), password, '#new-c-password');
            var phoneNumber = validatePhoneNumber($('#new-phonenumber').val(), '#new-phonenumber');
            var country = $('#new-country').val();
            var county = $('#new-county').val();
            var city = $('#new-city').val();
            var terms = validateTerms($('#new-terms').is(':checked') ? 1 : 0);
            var subscribe = $('#new-subscribe').is(':checked') ? true : false;
            var location = locationValidate(country, county, city);

            var inputData = {
                username: username,
                email: email,
                password: password,
                rePassword: rePassword,
                phoneNumber: phoneNumber,
                country: country,
                county: county,
                city: city,
                terms: terms,
                subscribe: subscribe,
                location: location
            };
            var action = validate(inputData);

            if (action == 1) {
                function responseNewUser(data) {
                    //console.log(data);
                    alert('New account created!   now you can login :)');
                }
                function responseNewUserLocation(data) {
                    //console.log(data);
                    window.location.hash = '#home';
                }

                function checkteUserData(user) {
                    if (user.UserName || user.PhoneNumber || user.Email) {
                        var msg = '';
                        if (user.UserName == inputData.username)
                            msg += 'UserName : ' + user.UserName + ' ';
                        if (user.PhoneNumber == inputData.phoneNumber)
                            msg += 'PhoneNumber : ' + user.PhoneNumber + ' ';
                        if (user.Email == inputData.email)
                            msg += 'Email : ' + user.Email;
                        alert('The field already exists ' + msg);

                    } else {
                        var guid = newGuid();
                        var date = newDate();
                        var user = {
                            UserID: guid,
                            Email: inputData.email,
                            UserName: inputData.username,
                            Password: inputData.password,
                            PhoneNumber: inputData.phoneNumber,
                            CreationDate: date,
                            Subscribed: inputData.subscribe
                        };
                        var userLocation = {
                            UserID: guid,
                            Country: inputData.country,
                            County: inputData.county,
                            City: inputData.city
                        };

                        serviceContext.UserService().Insert(user, responseNewUser);
                        serviceContext.UserService().UserLocationInsert(userLocation, responseNewUserLocation);
                    }
                }
                serviceContext.UserService().ReadSingIn(inputData, checkteUserData);
            } else {
                alert('something is not ok');
            }
        });
    };
};