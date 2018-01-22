using KruzeAuto.RepositoryAbstraction;
using KruzeAuto.RepositoryAbstraction.Core;
using System;

namespace KruseAuto.Repository.Core
{
    public class RepositoryContext : IRepositoryContext
    {
        #region Members
        private static IRepositoryContext _instance;
        private IAnnouncementOptionRepository _announcementOptionRepository;
        private IAnnouncementPicturesRepository _announcementPicturesRepository;
        private IAnnouncementRepository _announcementRepository;
        private IMessageInboxRepository _messageInboxRepository;
        private IOptionRepository _optionRepository;
        private IPictureRepository _pictureRepository;
        private IUserLocationRepository _userLocationRepository;
        private IUserPictureRepository _userPictureRepository;
        private IUserRepository _userRepository;
        private ISearchRepository _searchRepository;
        #endregion

        #region Constructor
        public RepositoryContext()
        {
            _instance = this;
        }
        #endregion

        #region Properties
        internal static IRepositoryContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("No RepositoryContext instance available!");
                }
                return _instance;
            }
        }

        public IAnnouncementOptionRepository AnnouncementOptionRepository
        {
            get
            {
                if (_announcementOptionRepository == null)
                    _announcementOptionRepository = new AnnouncementOptionRepository();
                return _announcementOptionRepository;
            }
        }

        public IAnnouncementPicturesRepository AnnouncementPicturesRepository
        {
            get
            {
                if (_announcementPicturesRepository == null)
                    _announcementPicturesRepository = new AnnouncementPicturesRepository();
                return _announcementPicturesRepository;
            }
        }

        public IAnnouncementRepository AnnouncementRepository
        {
            get
            {
                if (_announcementRepository == null)
                    _announcementRepository = new AnnouncementRepository();
                return _announcementRepository;
            }
        }

        public IMessageInboxRepository MessageInboxRepository
        {
            get
            {
                if (_messageInboxRepository == null)
                    _messageInboxRepository = new MessageInboxRepository();
                return _messageInboxRepository;
            }
        }

        public IOptionRepository OptionRepository
        {
            get
            {
                if (_optionRepository == null)
                    _optionRepository = new OptionRepository();
                return _optionRepository;
            }
        }

        public IPictureRepository PictureRepository
        {
            get
            {
                if (_pictureRepository == null)
                    _pictureRepository = new PictureRepository();
                return _pictureRepository;
            }
        }

        public IUserLocationRepository UserLocationRepository
        {
            get
            {
                if (_userLocationRepository == null)
                    _userLocationRepository = new UserLocationRepository();
                return _userLocationRepository;
            }
        }

        public IUserPictureRepository UserPictureRepository
        {
            get
            {
                if (_userPictureRepository == null)
                    _userPictureRepository = new UserPictureRepository();
                return _userPictureRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository();
                return _userRepository;
            }
        }

        public ISearchRepository SearchRepository
        {
            get
            {
                if (_searchRepository == null)
                    _searchRepository = new SearchRepository();
                return _searchRepository;
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

                if(_searchRepository != null)
                {
                    _searchRepository = null;
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
