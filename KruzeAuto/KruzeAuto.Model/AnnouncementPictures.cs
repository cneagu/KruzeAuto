using System;

namespace KruzeAuto.Model
{
    class AnnouncementPictures
    {
        #region Properties
        public Guid PictureID { get; set; }
        public Guid AnnoucementID { get; set; }
        public bool PrimaryPicture { get; set; }
        #endregion
    }
}
