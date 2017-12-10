﻿using KruseAuto.Repository.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KruseAuto.Repository
{
    public class PictureRepository : BaseRepository<Picture>
    {
        #region Methdos
        public void Insert(Picture picture)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@PictureID", picture.PictureID),
                new SqlParameter("@Image", picture.Image) };
            Procedure("dbo.Pictures_Insert", parameters);
        }

        public void Update(Picture picture)
        {
            SqlParameter[] parameters = {
               new SqlParameter("@PictureID", picture.PictureID),
               new SqlParameter("@Image", picture.Image) };
            Procedure("dbo.Pictures_UpdateByID", parameters);
        }

        public void DeleteByID(Guid pictureID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@PictureID", pictureID) };
            Procedure("dbo.Pictures_DeleteByID", parameters);
        }

        public List<Picture> ReadAll()
        {
            return ReadAll("dbo.Pictures_ReadAll");
        }

        public Picture ReadByID(Guid pictureID)
        {
            List<Picture> result = new List<Picture>();
            SqlParameter[] parameters = { new SqlParameter("@PictureID", pictureID) };
            result = ReadAll("dbo.Pictures_ReadByID", parameters);
            return result[0];
        }

        protected override Picture GetModelFromReader(SqlDataReader reader)
        {

            Picture picture = new Picture();
            picture.PictureID = reader.GetGuid(reader.GetOrdinal("PictureID"));
            picture.Image = (byte[])reader["Image"];
            return (picture);
        }
        #endregion
    }
}
