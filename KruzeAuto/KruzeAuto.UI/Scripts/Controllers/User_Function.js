var UserFunction = function (serviceContext) {
    this.Update = function (inputData) {
        function callBack(data) {
            alert('Success!');
        }
        serviceContext.UserService().UserUpdate(inputData, callBack);
    }
};