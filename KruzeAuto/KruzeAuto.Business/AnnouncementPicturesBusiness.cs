using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.Business
{
    public class AnnouncementPicturesBusiness
    {
        #region Methdos
        public void Insert(AnnouncementPictures announcementPictures)
        {
            BusinessContext.Current.RepositoryContext.AnnouncementPicturesRepository.Insert(announcementPictures);
        }

        public void Update(AnnouncementPictures announcementPictures)
        {
            BusinessContext.Current.RepositoryContext.AnnouncementPicturesRepository.Update(announcementPictures);
        }

        public void Delete(Guid pictureID)
        {
            BusinessContext.Current.RepositoryContext.AnnouncementPicturesRepository.Delete(pictureID);
        }

        public List<AnnouncementPictures> ReadAll(Guid annoucementID)
        {
            return BusinessContext.Current.RepositoryContext.AnnouncementPicturesRepository.ReadAll(annoucementID);
        }
        #endregion
    }
}