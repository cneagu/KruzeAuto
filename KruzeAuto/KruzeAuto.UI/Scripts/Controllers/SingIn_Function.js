var SingIn = function (inputData, serviceContext) {
    this.ChcekData = function () {
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
    };
};