using KruseAuto.Repository.Core;
using KruzeAuto.Model;
using KruzeAuto.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KruseAuto.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Methdos
        public void Insert(User user)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", user.UserID),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@PhoneNumber", user.PhoneNumber),
                new SqlParameter("@CreationDate", user.CreationDate),
                new SqlParameter("@Subscribed", user.Subscribed) };
            ExecuteNonQuery("dbo.Users_Insert", parameters);    
        }

        public void Update(User user)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", user.UserID),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@PhoneNumber", user.PhoneNumber),
                new SqlParameter("@Subscribed", user.Subscribed) };
            ExecuteNonQuery("dbo.Users_UpdateByID", parameters);
        }

        public void Delete(Guid userID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID) };
            ExecuteNonQuery("dbo.Users_DeleteByID", parameters);
        }

        public List<User> ReadAll()
        {
            return ReadAll("dbo.Users_ReadAll");
        }

        public User ReadByID(Guid userID)
        {
            List<User> result = new List<User>();
            SqlParameter[] parameters = { new SqlParameter("@UserID", userID) };
            result = ReadAll("dbo.Users_ReadByID", parameters);
            return result[0];
        }

        protected override User GetModelFromReader(SqlDataReader reader)
        {
            User user = new User();
            user.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            user.Email = reader.GetString(reader.GetOrdinal("Email"));
            user.UserName = reader.GetString(reader.GetOrdinal("UserName"));
            user.Password = reader.GetString(reader.GetOrdinal("Password"));
            user.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            user.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
            user.Subscribed = reader.GetBoolean(reader.GetOrdinal("Subscribed"));
            return(user);
        }
        #endregion
    }
}
