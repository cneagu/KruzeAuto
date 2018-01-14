$(document).ready(function () {
    SPA();
    var _serviceContext = new ServiceContext();
    var _searchController = new SearchController(_serviceContext);
    _searchController.SetMainSearchEngineData();
    _searchController.ActivateData();
    var _userController = new UserController(_serviceContext);
});