var SingIn = function (inputData, serviceContext) {
    this.ChcekData = function () {

        function newGuid() {
            var chars = '0123456789abcdef'.split('');

            var guid = [], rnd = Math.random, r;
            guid[8] = guid[13] = guid[18] = guid[23] = '-';
            guid[14] = '6';

            for (var i = 0; i < 36; i++) {
                if (!guid[i]) {
                    r = 0 | rnd() * 16;

                    guid[i] = chars[(i == 19) ? (r & 0x3) | 0x8 : r & 0xf];
                }
            }
            return guid.join('');
        }

        var today = new Date();
        today = today.getFullYear() + '-' + parseInt(today.getMonth() + 1) + '-' + today.getDate() + " " + today.getHours() + ":" + today.getMinutes();

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
                var date = today;
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