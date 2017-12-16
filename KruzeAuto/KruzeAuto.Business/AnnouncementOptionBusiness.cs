using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.Business
{
    public class AnnouncementOptionBusiness
    {
        #region Methdos
        public void Insert(AnnouncementOption announcementOption)
        {
            BusinessContext.Current.RepositoryContext.AnnouncementOptionRepository.Insert(announcementOption);
        }

        public void Update(AnnouncementOption announcementOption)
        {
            BusinessContext.Current.RepositoryContext.AnnouncementOptionRepository.Update(announcementOption);
        }

        public void Delete(Guid annoucementID, Guid optionID)
        {
            BusinessContext.Current.RepositoryContext.AnnouncementOptionRepository.Delete(annoucementID, optionID);
        }

        public List<AnnouncementOption> ReadByID(Guid annoucementID)
        {
            return BusinessContext.Current.RepositoryContext.AnnouncementOptionRepository.ReadByID(annoucementID);
        }
        #endregion
    }
}
