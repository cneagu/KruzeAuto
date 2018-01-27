var ServiceContext = function () {
    var _service;

    this.AnnouncementService = function () {
        if (!_service) {
            _service = new AnnouncementService();
        }
        return _service;
    };

    this.UserService = function () {
        if (!_service) {
            _service = new UserService();
        }
        return _service;
    };

    this.SearchService = function () {
        if (!_service) {
            _service = new SearchService();
        }
        return _service;
    };

    this.UserLocationService = function () {
        if (!_service) {
            _service = new UserLocationService();
        }
        return _service;
    };

};