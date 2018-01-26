var MenuController = function(serviceContext) {

    this.PageActivity = function () {
        var _searchController = new SearchController(serviceContext);
        _searchController.SetMainSearchEngineData();
        _searchController.ActivateData();
    };
};