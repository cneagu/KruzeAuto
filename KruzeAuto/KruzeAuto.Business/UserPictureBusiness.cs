using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.Business
{
    public class UserPictureBusiness
    {
        #region Methdos
        public void Insert(UserPicture userPicture)
        {
            BusinessContext.Current.RepositoryContext.UserPictureRepository.Insert(userPicture);
        }

        public void Update(UserPicture userPicture)
        {
            BusinessContext.Current.RepositoryContext.UserPictureRepository.Update(userPicture);
        }

        public void Delete(Guid userID)
        {
            BusinessContext.Current.RepositoryContext.UserPictureRepository.Delete(userID);
        }

        public List<UserPicture> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.UserPictureRepository.ReadAll();
        }

        public UserPicture ReadByID(Guid userID)
        {
            return BusinessContext.Current.RepositoryContext.UserPictureRepository.ReadByID(userID);
        }
        #endregion
    }
}
