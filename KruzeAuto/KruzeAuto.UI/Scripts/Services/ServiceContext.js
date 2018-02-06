var ServiceContext = function () {
    var _announcementService;
    var _userService;
    var _searchService;
    var _userLocationService;

    this.AnnouncementService = function () {
        if (!_announcementService) {
            _announcementService = new AnnouncementService();
        }
        return _announcementService;
    };

    this.UserService = function () {
        if (!_userService) {
            _userService = new UserService();
        }
        return _userService;
    };

    this.SearchService = function () {
        if (!_searchService) {
            _searchService = new SearchService();
        }
        return _searchService;
    };

    this.UserLocationService = function () {
        if (!_userLocationService) {
            _userLocationService = new UserLocationService();
        }
        return _userLocationService;
    };

};