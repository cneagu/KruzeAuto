var AnnouncementService = function () {

    this.ReadAll = function () {
        return _announcements;
    };

    this.ReadById = function (id) {
        for (var index = 0; index < _announcements.length; index++) {
            if (index === _announcements[index].AnnoucementID) {
                return _announcements[index];
            }
        }
        return null;
    };
};