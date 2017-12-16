using System;

namespace KruzeAuto.RepositoryAbstraction.Core
{
    public interface IRepositoryContext : IDisposable
    {
        IAnnouncementOptionRepository AnnouncementOptionRepository { get; }
        IAnnouncementPicturesRepository AnnouncementPicturesRepository { get; }
        IAnnouncementRepository AnnouncementRepository { get; }
        IMessageInboxRepository MessageInboxRepository { get; }
        IOptionRepository OptionRepository { get; }
        IPictureRepository PictureRepository { get; }
        IUserLocationRepository UserLocationRepository { get; }
        IUserPictureRepository UserPictureRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
