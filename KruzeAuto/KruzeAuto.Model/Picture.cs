using System;

namespace KruzeAuto.Model
{
    public class Picture
    {
        #region Properties
        public Guid PictureID { get; set; }
        public byte[] Image { get; set; }
        #endregion
    }
}
