using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.Business
{
    public class UserLocationBusiness
    {
        #region Methdos
        public void Insert(UserLocation userLocation)
        {
            BusinessContext.Current.RepositoryContext.UserLocationRepository.Insert(userLocation);
        }

        public void Update(UserLocation userLocation)
        {
            BusinessContext.Current.RepositoryContext.UserLocationRepository.Update(userLocation);
        }

        public void Delete(Guid userID)
        {
            BusinessContext.Current.RepositoryContext.UserLocationRepository.Delete(userID);
        }

        public List<UserLocation> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.UserLocationRepository.ReadAll();
        }

        public UserLocation ReadByID(Guid userID)
        {
            return BusinessContext.Current.RepositoryContext.UserLocationRepository.ReadByID(userID);
        }
        #endregion
    }
}
