$(document).ready(function () {
    SPA();
    //var _serviceContext = new ServiceContext();
    //var _searchController = new SearchController(_serviceContext);
    var _searchController = new SearchController();
    _searchController.SetMainSearchEngineData();
    _searchController.ActivateData();
});