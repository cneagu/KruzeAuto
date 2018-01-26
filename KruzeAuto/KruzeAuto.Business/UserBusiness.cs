using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.Business
{
    public class UserBusiness
    {
        #region Methdos
        public void Insert(User user)
        {
            BusinessContext.Current.RepositoryContext.UserRepository.Insert(user);
        }

        public void Update(User user)
        {
            BusinessContext.Current.RepositoryContext.UserRepository.Update(user);
        }

        public void Delete(Guid userID)
        {
            BusinessContext.Current.RepositoryContext.UserRepository.Delete(userID);
        }

        public List<User> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.UserRepository.ReadAll();
        }

        public User ReadByID(Guid userID)
        {
            return BusinessContext.Current.RepositoryContext.UserRepository.ReadByID(userID);
        }

        public User ReadSingIn(string email, string userName, string phoneNumber)
        {
            return BusinessContext.Current.RepositoryContext.UserRepository.ReadSingIn(email, userName, phoneNumber);
        }

        public User ReadLogIn(string email, string password)
        {
            return BusinessContext.Current.RepositoryContext.UserRepository.ReadLogIn(email, password);
        }
        #endregion
    }
}