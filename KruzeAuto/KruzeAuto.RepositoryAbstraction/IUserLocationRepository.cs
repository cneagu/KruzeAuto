using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.RepositoryAbstraction
{
    public interface IUserLocationRepository
    {
        void Insert(UserLocation userLocation);
        void Update(UserLocation userLocation);
        void Delete(Guid userID);
        List<UserLocation> ReadAll();
        UserLocation ReadByID(Guid userID);
    }
}
