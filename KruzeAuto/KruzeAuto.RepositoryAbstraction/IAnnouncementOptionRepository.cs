using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.RepositoryAbstraction
{
    public interface IAnnouncementOptionRepository
    {
        void Insert(AnnouncementOption announcementOption);
        void Update(AnnouncementOption announcementOption);
        void Delete(Guid annoucementID, Guid optionID);
        List<AnnouncementOption> ReadByID(Guid annoucementID);
    }
}
