var UserLocationService = function () {
    this.Insert = function (data, handleData) {
        ajaxService('UserLocation/Insert', 'POST', data, handleData, '#singin');
    };
}