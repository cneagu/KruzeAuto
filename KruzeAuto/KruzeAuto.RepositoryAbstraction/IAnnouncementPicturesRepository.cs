using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.RepositoryAbstraction
{
    public interface IAnnouncementPicturesRepository
    {
        void Insert(AnnouncementPictures announcementPictures);
        void Update(AnnouncementPictures announcementPictures);
        void Delete(Guid pictureID);
        List<AnnouncementPictures> ReadAll(Guid annoucementID);
    }
}
