﻿using KruseAuto.Repository.Core;
using KruzeAuto.Model;
using KruzeAuto.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KruseAuto.Repository
{
    public class AnnouncementOptionRepository : BaseRepository<AnnouncementOption>, IAnnouncementOptionRepository
    {
        #region Methdos
        public void Insert(AnnouncementOption announcementOption)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@AnnoucementID", announcementOption.AnnoucementID),
                new SqlParameter("@OptionID", announcementOption.OptionID) };
            ExecuteNonQuery("dbo.AnnouncementsOptions_Insert", parameters);
        }

        public void Update(AnnouncementOption announcementOption)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@AnnoucementID", announcementOption.AnnoucementID),
                new SqlParameter("@OptionID", announcementOption.OptionID) };
            ExecuteNonQuery("dbo.AnnouncementsOptions_UpdateByID", parameters);
        }

        public void Delete(Guid annoucementID, Guid optionID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", annoucementID),
                new SqlParameter("@optionID", optionID) };
            ExecuteNonQuery("dbo.AnnouncementsOptions_DeleteByID", parameters);
        }

        public List<AnnouncementOption> ReadByID(Guid annoucementID)
        {
            SqlParameter[] parameters = { new SqlParameter("@AnnoucementID", annoucementID) };
            return ReadAll("dbo.AnnouncementsOptions_ReadByID", parameters);
        }

        protected override AnnouncementOption GetModelFromReader(SqlDataReader reader)
        {
            AnnouncementOption announcementOption = new AnnouncementOption();
            announcementOption.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
            announcementOption.OptionID = reader.GetGuid(reader.GetOrdinal("OptionID"));
            return (announcementOption);
        }
        #endregion
    }
}
