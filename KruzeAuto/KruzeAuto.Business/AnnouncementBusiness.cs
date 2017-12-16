using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.Business
{
    public class AnnouncementBusiness
    {
        #region Methdos
        public void Insert(Announcement announcement)
        {
            BusinessContext.Current.RepositoryContext.AnnouncementRepository.Insert(announcement);
        }

        public void Update(Announcement announcement)
        {
            BusinessContext.Current.RepositoryContext.AnnouncementRepository.Update(announcement);
        }

        public void Delete(Guid annoucementID)
        {
            BusinessContext.Current.RepositoryContext.AnnouncementRepository.Delete(annoucementID);
        }

        public List<Announcement> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.AnnouncementRepository.ReadAll();
        }

        public Announcement ReadByID(Guid annoucementID)
        {
            return BusinessContext.Current.RepositoryContext.AnnouncementRepository.ReadByID(annoucementID);
        }

        public List<Announcement> ReadByUserID(Guid userID)
        {
            return BusinessContext.Current.RepositoryContext.AnnouncementRepository.ReadByUserID(userID);
        }
        #endregion
    }
}
