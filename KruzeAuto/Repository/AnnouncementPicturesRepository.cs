using System;
using System.Collections.Generic;
using KruzeAuto.Model;
using System.Data.SqlClient;
using KruseAuto.Repository.Core;


namespace KruseAuto.Repository
{
    public class AnnouncementPicturesRepository : BaseRepository<AnnouncementPictures>
    {
        #region Methdos
        public void Insert(AnnouncementPictures announcementPictures)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@PictureID", announcementPictures.PictureID),
                new SqlParameter("@AnnoucementID", announcementPictures.AnnoucementID),
                new SqlParameter("@PrimaryPicture", announcementPictures.PrimaryPicture) };
            Procedure("dbo.AnnouncementsPictures_Insert", parameters);
        }

        public void Update(AnnouncementPictures announcementPictures)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@PictureID", announcementPictures.PictureID),
                new SqlParameter("@AnnoucementID", announcementPictures.AnnoucementID),
                new SqlParameter("@PrimaryPicture", announcementPictures.PrimaryPicture) };
            Procedure("dbo.AnnouncementsPictures_UpdateByID", parameters);
        }

        public void DeleteByID(Guid pictureID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@PictureID", pictureID) };
            Procedure("dbo.AnnouncementsPictures_DeleteByID", parameters);
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
