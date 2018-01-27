var SearchService = function () {

    this.MainSearch = function (result, handleData) {
        ajaxService('Search', 'POST', result, handleData,'#search');
    };
};