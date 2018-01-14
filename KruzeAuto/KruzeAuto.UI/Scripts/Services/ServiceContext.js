var ServiceContext = function () {
    var _announcementService;

    this.AnnouncementService = function () {
        if (!_announcementService) {
            _announcementService = new AnnouncementService();
        }
        return _announcementService;
    }

    this.UserService = function () {
        if (!_announcementService) {
            _announcementService = new UserService();
        }
        return _announcementService;
    }
}