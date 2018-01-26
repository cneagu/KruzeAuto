var SearchService = function () {

    this.MainSearch = function (result, functione) {
        ajaxService('search', 'POST', result, functione);
    };
};