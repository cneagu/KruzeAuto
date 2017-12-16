using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.RepositoryAbstraction
{
    public interface IAnnouncementRepository
    {
        void Insert(Announcement announcement);
        void Update(Announcement announcement);
        void Delete(Guid annoucementID);
        List<Announcement> ReadAll();
        Announcement ReadByID(Guid annoucementID);
        List<Announcement> ReadByUserID(Guid userID);
    }
}
