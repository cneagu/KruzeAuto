using KruseAuto.Repository;
using System;

namespace KruseAuto.Repository.Core
{
    public class RepositoryContext : IDisposable
    {
        #region Members
        private AnnouncementOptionRepository _announcementOptionRepository;
        private AnnouncementPicturesRepository _announcementPicturesRepository;
        private AnnouncementRepository _announcementRepository;
        private MessageInboxRepository _messageInboxRepository;
        private OptionRepository _optionRepository;
        private PictureRepository _pictureRepository;
        private UserLocationRepository _userLocationRepository;
        private UserPictureRepository _userPictureRepository;
        private UserRepository _userRepository;
        #endregion

        #region Properties
        public AnnouncementOptionRepository AnnouncementOptionRepository
        {
            get
            {
                if (_announcementOptionRepository == null)
                    _announcementOptionRepository = new AnnouncementOptionRepository();
                return _announcementOptionRepository;
            }
        }

        public AnnouncementPicturesRepository AnnouncementPicturesRepository
        {
            get
            {
                if (_announcementPicturesRepository == null)
                    _announcementPicturesRepository = new AnnouncementPicturesRepository();
                return _announcementPicturesRepository;
            }
        }

        public AnnouncementRepository AnnouncementRepository
        {
            get
            {
                if (_announcementRepository == null)
                    _announcementRepository = new AnnouncementRepository();
                return _announcementRepository;
            }
        }

        public MessageInboxRepository MessageInboxRepository
        {
            get
            {
                if (_messageInboxRepository == null)
                    _messageInboxRepository = new MessageInboxRepository();
                return _messageInboxRepository;
            }
        }

        public OptionRepository OptionRepository
        {
            get
            {
                if (_optionRepository == null)
                    _optionRepository = new OptionRepository();
                return _optionRepository;
            }
        }

        public PictureRepository PictureRepository
        {
            get
            {
                if (_pictureRepository == null)
                    _pictureRepository = new PictureRepository();
                return _pictureRepository;
            }
        }

        public UserLocationRepository UserLocationRepository
        {
            get
            {
                if (_userLocationRepository == null)
                    _userLocationRepository = new UserLocationRepository();
                return _userLocationRepository;
            }
        }

        public UserPictureRepository UserPictureRepository
        {
            get
            {
                if (_userPictureRepository == null)
                    _userPictureRepository = new UserPictureRepository();
                return _userPictureRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository();
                return _userRepository;
            }
        }
        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (_announcementOptionRepository != null)
                {
                    //_connection.Dispose();
                    _announcementOptionRepository = null;
                }

                if (_announcementPicturesRepository != null)
                {
                    _announcementPicturesRepository = null;
                }

                if (_announcementRepository != null)
                {
                    _announcementRepository = null;
                }

                if (_messageInboxRepository != null)
                {
                    _messageInboxRepository = null;
                }

                if (_optionRepository != null)
                {
                    _optionRepository = null;
                }

                if (_pictureRepository != null)
                {
                    _pictureRepository = null;
                }

                if (_userLocationRepository != null)
                {
                    _userLocationRepository = null;
                }

                if (_userPictureRepository != null)
                {
                    _userPictureRepository = null;
                }

                if (_userRepository != null)
                {
                    _userRepository = null;
                }
            }
        }

        ~RepositoryContext()
        {
            Dispose(false);
        }
        #endregion
    }
}
