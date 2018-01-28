var NewAnnouncement = function (serviceContext, announcement) {
    this.Insert = function () {
        function callBackFunction(data) {
            alert('Create New Announcement');
        }
        serviceContext.AnnouncementService().Insert(announcement,callBackFunction);
    };
};