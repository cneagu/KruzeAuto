function ajaxService(action, verb, data, handleData) {
    var _url = 'http://localhost:65513/api/';
    var _data = [];
    $('#search').addClass('loader');
     
    var promise = $.ajax({
        crossDomain: true,
        dataType: "json",
        url: _url + action,
        type: verb,
        data: data
    });
    promise.done(function (data) { handleData(data); });
    promise.fail(function () { alert("error"); });
    promise.always(function () { $('#search').removeClass('loader'); });
};