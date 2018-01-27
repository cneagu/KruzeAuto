using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.RepositoryAbstraction
{
    public interface IUserRepository
    {
        void Insert(User user);
        void Update(User user);
        void Delete(Guid userID);
        List<User> ReadAll();
        User ReadByID(Guid userID);
        User ReadSingIn(string email, string userName, string phoneNumber);
        Guid ReadLogIn(string email, string password);
    }
}
