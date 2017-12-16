using System;
using System.Collections.Generic;
using KruzeAuto.Model;
using System.Data.SqlClient;
using KruseAuto.Repository.Core;
using KruzeAuto.RepositoryAbstraction;

namespace KruseAuto.Repository
{
    public class AnnouncementPicturesRepository : BaseRepository<AnnouncementPictures>, IAnnouncementPicturesRepository
    {
        #region Methdos
        public void Insert(AnnouncementPictures announcementPictures)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@PictureID", announcementPictures.PictureID),
                new SqlParameter("@AnnoucementID", announcementPictures.AnnoucementID),
                new SqlParameter("@PrimaryPicture", announcementPictures.PrimaryPicture) };
            ExecuteNonQuery("dbo.AnnouncementsPictures_Insert", parameters);
        }

        public void Update(AnnouncementPictures announcementPictures)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@PictureID", announcementPictures.PictureID),
                new SqlParameter("@AnnoucementID", announcementPictures.AnnoucementID),
                new SqlParameter("@PrimaryPicture", announcementPictures.PrimaryPicture) };
            ExecuteNonQuery("dbo.AnnouncementsPictures_UpdateByID", parameters);
        }

        public void Delete(Guid pictureID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@PictureID", pictureID) };
            ExecuteNonQuery("dbo.AnnouncementsPictures_DeleteByID", parameters);
        }

        public List<AnnouncementPictures> ReadAll(Guid annoucementID)
        {
            SqlParameter[] parameters = { new SqlParameter("@AnnoucementID", annoucementID) };
            return ReadAll("dbo.AnnouncementsPictures_ReadAllPicturesByID", parameters);
        }

        protected override AnnouncementPictures GetModelFromReader(SqlDataReader reader)
        {
            AnnouncementPictures announcementPicture = new AnnouncementPictures();
            announcementPicture.PictureID = reader.GetGuid(reader.GetOrdinal("PictureID"));
            announcementPicture.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
            announcementPicture.PrimaryPicture = reader.GetBoolean(reader.GetOrdinal("PrimaryPicture"));
            return (announcementPicture);
        }
        #endregion
    }
}
