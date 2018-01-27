var UserService = function () {

    this.ReadById = function (id, data, handleData) {
        ajaxService('User/ReadById/' + id, 'POST', data, handleData, '#singin');
    };

    this.ReadSingIn = function (data, handleData) {
        ajaxService('SingIn', 'POST', data, handleData, '#singin');
    };

    this.Insert = function (data, handleData) {
        ajaxService('User/Insert', 'POST', data, handleData, '#singin');
    };

    this.LogInValidation = function (Email, Password, data, handleData) {
        var data = '';
        ajaxService('User/LogIn/' + Email + '/' + Password , 'GET', data, handleData, 'body');
    }

    this.UserLocationInsert = function (data, handleData) {
        ajaxService('User/UserLocation/Insert', 'POST', data, handleData, '#singin');
    };
};