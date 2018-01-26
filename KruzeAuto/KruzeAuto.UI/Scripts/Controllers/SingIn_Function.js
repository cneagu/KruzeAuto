var SingIn = function (inputData, serviceContext) {
    this.PutData = function () {

    };

    this.ChcekData = function () {
        var user = '';
        function callBack(data) {
            user = data;
            console.log(data);
            //aici
        }
        serviceContext.UserService().ReadSingIn(inputData, callBack);

    };
};