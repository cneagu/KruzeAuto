﻿using KruseAuto.Repository.Core;
using KruzeAuto.Model;
using KruzeAuto.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KruseAuto.Repository
{
    public class OptionRepository : BaseRepository<Option>, IOptionRepository
    {
        #region Methdos
        public void Insert(Option option)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@OptionID", option.OptionID),
                new SqlParameter("@Name", option.Name) };
            ExecuteNonQuery("dbo.Options_Insert", parameters);
        }

        public void Update(Option option)
        {
            SqlParameter[] parameters = {
               new SqlParameter("@OptionID", option.OptionID),
                new SqlParameter("@Name", option.Name) };
            ExecuteNonQuery("dbo.Options_UpdateByID", parameters);
        }

        public void Delete(Guid optionID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@OptionID", optionID) };
            ExecuteNonQuery("dbo.Options_DeleteByID", parameters);
        }

        public List<Option> ReadAll()
        {
            return ReadAll("dbo.Options_ReadAll");
        }

        public Option ReadByID(Guid optionID)
        {
            List<Option> result = new List<Option>();
            SqlParameter[] parameters = { new SqlParameter("@OptionID", optionID) };
            result = ReadAll("dbo.Options_ReadByID", parameters);
            return result[0];
        }

        protected override Option GetModelFromReader(SqlDataReader reader)
        {
            Option option = new Option();
            option.OptionID = reader.GetGuid(reader.GetOrdinal("OptionID"));
            option.Name = reader.GetString(reader.GetOrdinal("Name"));
            return (option);
        }
        #endregion
    }
}
