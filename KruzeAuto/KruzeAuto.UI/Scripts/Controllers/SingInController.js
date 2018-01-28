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
            var username = validateUsername($('#new-username').val());
            var email = validateEmail($('#new-email').val(), '#new-email');
            var password = validatePassword($('#new-password').val(), '#new-password');
            var rePassword = validaterePassword($('#new-c-password').val(), password);
            var phoneNumber = validatePhoneNumber($('#new-phonenumber').val());
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
                var _singIn = new SingIn(inputData, serviceContext);
                _singIn.ChcekData();
            } else {
                alert('something is not ok');
            }
               
            
        });
    };
};