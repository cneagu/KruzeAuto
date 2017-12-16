using KruseAuto.Repository.Core;
using KruzeAuto.Model;
using KruzeAuto.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KruseAuto.Repository
{
    public class UserPictureRepository : BaseRepository<UserPicture>, IUserPictureRepository
    {
        #region Methdos
        public void Insert(UserPicture userPicture)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userPicture.UserID),
                new SqlParameter("@PictureID", userPicture.PictureID) };
            ExecuteNonQuery("dbo.UsersPictures_Insert", parameters);
        }

        public void Update(UserPicture userPicture)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userPicture.UserID),
                new SqlParameter("@PictureID", userPicture.PictureID) };
            ExecuteNonQuery("dbo.UsersPictures_UpdateByID", parameters);
        }

        public void Delete(Guid userID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID) };
            ExecuteNonQuery("dbo.UsersPictures_DeleteByID", parameters);
        }

        public List<UserPicture> ReadAll()
        {
            return ReadAll("dbo.UsersPictures_ReadAll");
        }

        public UserPicture ReadByID(Guid userID)
        {
            List<UserPicture> result = new List<UserPicture>();
            SqlParameter[] parameters = { new SqlParameter("@UserID", userID) };
            result = ReadAll("dbo.UsersPictures_ReadByID", parameters);
            return result[0];
        }

        protected override UserPicture GetModelFromReader(SqlDataReader reader)
        {
            UserPicture userPicture = new UserPicture();
            userPicture.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            userPicture.PictureID = reader.GetGuid(reader.GetOrdinal("PictureID"));
            return (userPicture);
        }
        #endregion
    }
}
