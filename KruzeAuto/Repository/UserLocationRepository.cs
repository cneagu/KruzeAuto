using KruseAuto.Repository.Core;
using KruzeAuto.Model;
using KruzeAuto.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KruseAuto.Repository
{
    public class UserLocationRepository : BaseRepository<UserLocation>, IUserLocationRepository
    {
        #region Methdos
        public void Insert(UserLocation userLocation)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userLocation.UserID),
                new SqlParameter("@Country", userLocation.Country),
                new SqlParameter("@County", userLocation.County),
                new SqlParameter("@City", userLocation.City) };
            ExecuteNonQuery("dbo.UserLocation_Insert", parameters);
        }

        public void Update(UserLocation userLocation)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userLocation.UserID),
                new SqlParameter("@Country", userLocation.Country),
                new SqlParameter("@County", userLocation.County),
                new SqlParameter("@City", userLocation.City) };
            ExecuteNonQuery("dbo.UserLocation_UpdateByID", parameters);
        }

        public void Delete(Guid userID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID) };
            ExecuteNonQuery("dbo.UserLocation_DeleteByID", parameters);
        }

        public List<UserLocation> ReadAll()
        {
            //Get current StudentRepository instance
            return ReadAll("dbo.UserLocation_ReadAll");
        }

        public UserLocation ReadByID(Guid userID)
        {
            List<UserLocation> result = new List<UserLocation>();
            SqlParameter[] parameters = { new SqlParameter("@UserID", userID) };
            result = ReadAll("dbo.UserLocation_ReadByID", parameters);
            return result[0];
        }

        protected override UserLocation GetModelFromReader(SqlDataReader reader)
        {
            UserLocation userLocation = new UserLocation();
            userLocation.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            userLocation.Country = reader.GetString(reader.GetOrdinal("Country"));
            userLocation.County = reader.GetString(reader.GetOrdinal("County"));
            userLocation.City = reader.GetString(reader.GetOrdinal("City"));
            return userLocation;
        }
        #endregion
    }
}
