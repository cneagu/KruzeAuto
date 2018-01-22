using KruzeAuto.RepositoryAbstraction.Core;
using KruzeAuto.RepositoryFactory;
using System;

namespace KruzeAuto.Business.Core
{
    public class BusinessContext : IDisposable
    {
        #region Members
        private static BusinessContext _instance;
        private IRepositoryContext _repositoryContext;
        private AnnouncementOptionBusiness _announcementOptionBusiness;
        private AnnouncementPicturesBusiness _announcementPicturesBusiness;
        private AnnouncementBusiness _announcementBusiness;
        private MessageInboxBusiness _messageInboxBusiness;
        private OptionBusiness _optionBusiness;
        private PictureBusiness _pictureBusiness;
        private UserLocationBusiness _userLocationBusiness;
        private UserPictureBusiness _userPictureBusiness;
        private UserBusiness _userBusiness;
        private SearchBusiness _searchBusiness;
        #endregion

        #region Constructor
        public BusinessContext()
        {
            _instance = this;
            _repositoryContext = Getter.GetRepository();
        }
        #endregion

        #region Properties
        internal static BusinessContext Current
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

        public AnnouncementOptionBusiness AnnouncementOptionBusiness
        {
            get
            {
                if (_announcementOptionBusiness == null)
                    _announcementOptionBusiness = new AnnouncementOptionBusiness();
                return _announcementOptionBusiness;
            }
        }

        public AnnouncementPicturesBusiness AnnouncementPicturesBusiness
        {
            get
            {
                if (_announcementPicturesBusiness == null)
                    _announcementPicturesBusiness = new AnnouncementPicturesBusiness();
                return _announcementPicturesBusiness;
            }
        }

        public AnnouncementBusiness AnnouncementBusiness
        {
            get
            {
                if (_announcementBusiness == null)
                    _announcementBusiness = new AnnouncementBusiness();
                return _announcementBusiness;
            }
        }

        public MessageInboxBusiness MessageInboxBusiness
        {
            get
            {
                if (_messageInboxBusiness == null)
                    _messageInboxBusiness = new MessageInboxBusiness();
                return _messageInboxBusiness;
            }
        }

        public OptionBusiness OptionBusiness
        {
            get
            {
                if (_optionBusiness == null)
                    _optionBusiness = new OptionBusiness();
                return _optionBusiness;
            }
        }

        public PictureBusiness PictureBusiness
        {
            get
            {
                if (_pictureBusiness == null)
                    _pictureBusiness = new PictureBusiness();
                return _pictureBusiness;
            }
        }

        public UserLocationBusiness UserLocationBusiness
        {
            get
            {
                if (_userLocationBusiness == null)
                    _userLocationBusiness = new UserLocationBusiness();
                return _userLocationBusiness;
            }
        }

        public UserPictureBusiness UserPictureBusiness
        {
            get
            {
                if (_userPictureBusiness == null)
                    _userPictureBusiness = new UserPictureBusiness();
                return _userPictureBusiness;
            }
        }

        public UserBusiness UserBusiness
        {
            get
            {
                if (_userBusiness == null)
                    _userBusiness = new UserBusiness();
                return _userBusiness;
            }
        }

        public SearchBusiness SearchBusiness
        {
            get
            {
                if (_searchBusiness == null)
                    _searchBusiness = new SearchBusiness();
                return _searchBusiness;
            }
        }

        internal IRepositoryContext RepositoryContext
        {
            get { return _repositoryContext; }
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
                if (_announcementOptionBusiness != null)
                {
                    //_connection.Dispose();
                    _announcementOptionBusiness = null;
                }

                if (_announcementPicturesBusiness != null)
                {
                    _announcementPicturesBusiness = null;
                }

                if (_announcementBusiness != null)
                {
                    _announcementBusiness = null;
                }

                if (_messageInboxBusiness != null)
                {
                    _messageInboxBusiness = null;
                }

                if (_optionBusiness != null)
                {
                    _optionBusiness = null;
                }

                if (_pictureBusiness != null)
                {
                    _pictureBusiness = null;
                }

                if (_userLocationBusiness != null)
                {
                    _userLocationBusiness = null;
                }

                if (_userPictureBusiness != null)
                {
                    _userPictureBusiness = null;
                }

                if (_userBusiness != null)
                {
                    _userBusiness = null;
                }

                if(_searchBusiness != null)
                {
                    _searchBusiness = null;
                }
            }
        }

        ~BusinessContext()
        {
            Dispose(false);
        }
        #endregion
    }
}
