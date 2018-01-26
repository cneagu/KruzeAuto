var UserService = function () {

    //this.ReadAll = function () {
    //    return _users;
    //};

    //this.ReadById = function (id) {
    //    for (var index = 0; index < _users.length; index++) {
    //        if (index == _users[index].AnnoucementID) {
    //            return _users[index];
    //        }
    //    }
    //    return null;
    //};

    this.ReadSingIn = function (data, handleData) {
        ajaxService('singIn', 'POST', data, handleData,'#singin');
    }
};