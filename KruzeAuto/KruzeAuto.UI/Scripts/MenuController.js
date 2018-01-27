var MenuController = function(serviceContext) {

    this.PageActivity = function () {
        var _searchController = new SearchController(serviceContext);
        _searchController.SetMainSearchEngineData();
        _searchController.ActivateData();

        var _singInController = new SingInController(serviceContext);
        _singInController.InsertLocationData();
        _singInController.SubmitForm();

        var _userController = new UserController(serviceContext);
        _userController.LogIn();
    };
};