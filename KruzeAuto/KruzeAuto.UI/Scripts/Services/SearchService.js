var SearchService = function () {

    this.MainSearch = function (result, handleData) {
        ajaxService('search', 'POST', result, handleData,'#search');
    };
};