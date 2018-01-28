var AnnouncementService = function () {

    this.Insert = function (announcement, handleData) {
        ajaxService('Announcement/InsertAnnouncement', 'POST', announcement, handleData, '#user_profile');
    };
 
};