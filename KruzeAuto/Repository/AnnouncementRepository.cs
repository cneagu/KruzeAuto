using KruseAuto.Repository.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KruseAuto.Repository
{
    public class AnnouncementRepository : BaseRepository<Announcement>
    {
        #region Methdos
        public void Insert(Announcement announcement)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@AnnoucementID", announcement.AnnoucementID),
                new SqlParameter("@UserID", announcement.UserID),
                new SqlParameter("@VehicleType", announcement.VehicleType),
                new SqlParameter("@Views", announcement.Views),
                new SqlParameter("@Promoted", announcement.Promoted),
                new SqlParameter("@Active", announcement.Active),
                new SqlParameter("@CreationDate", announcement.CreationDate),
                new SqlParameter("@Update", announcement.Update),
                new SqlParameter("@Condition", announcement.Condition),
                new SqlParameter("@Title", announcement.Title),
                new SqlParameter("@Brand", announcement.Brand),
                new SqlParameter("@Model", announcement.Model),
                new SqlParameter("@Type", announcement.Type),
                new SqlParameter("@Kilometer", announcement.Kilometer),
                new SqlParameter("@FabricationYear", announcement.FabricationYear),
                new SqlParameter("@VIN", announcement.VIN),
                new SqlParameter("@FuelType", announcement.FuelType),
                new SqlParameter("@Price", announcement.Price),
                new SqlParameter("@NegociablePrice", announcement.NegociablePrice),
                new SqlParameter("@Currency", announcement.Currency),
                new SqlParameter("@Color", announcement.Color),
                new SqlParameter("@ColorType", announcement.ColorType),
                new SqlParameter("@Power", announcement.Power),
                new SqlParameter("@Transmission", announcement.Transmission),
                new SqlParameter("@CubicCapacity", announcement.CubicCapacity),
                new SqlParameter("@EmissionClass", announcement.EmissionClass),
                new SqlParameter("@NumberOfSeats", announcement.NumberOfSeats),
                new SqlParameter("@GVW", announcement.GVW),
                new SqlParameter("@LoadCapacity", announcement.LoadCapacity),
                new SqlParameter("@OperatingHours", announcement.OperatingHours),
                new SqlParameter("@Description", announcement.Description) };
            Procedure("dbo.Announcements_Insert", parameters);
        }

        public void Update(Announcement announcement)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@AnnoucementID", announcement.AnnoucementID),
                new SqlParameter("@VehicleType", announcement.VehicleType),
                new SqlParameter("@Views", announcement.Views),
                new SqlParameter("@Promoted", announcement.Promoted),
                new SqlParameter("@Active", announcement.Active),
                new SqlParameter("@CreationDate", announcement.CreationDate),
                new SqlParameter("@Update", announcement.Update),
                new SqlParameter("@Condition", announcement.Condition),
                new SqlParameter("@Title", announcement.Title),
                new SqlParameter("@Brand", announcement.Brand),
                new SqlParameter("@Model", announcement.Model),
                new SqlParameter("@Type", announcement.Type),
                new SqlParameter("@Kilometer", announcement.Kilometer),
                new SqlParameter("@FabricationYear", announcement.FabricationYear),
                new SqlParameter("@VIN", announcement.VIN),
                new SqlParameter("@FuelType", announcement.FuelType),
                new SqlParameter("@Price", announcement.Price),
                new SqlParameter("@NegociablePrice", announcement.NegociablePrice),
                new SqlParameter("@Currency", announcement.Currency),
                new SqlParameter("@Color", announcement.Color),
                new SqlParameter("@ColorType", announcement.ColorType),
                new SqlParameter("@Power", announcement.Power),
                new SqlParameter("@Transmission", announcement.Transmission),
                new SqlParameter("@CubicCapacity", announcement.CubicCapacity),
                new SqlParameter("@EmissionClass", announcement.EmissionClass),
                new SqlParameter("@NumberOfSeats", announcement.NumberOfSeats),
                new SqlParameter("@GVW", announcement.GVW),
                new SqlParameter("@LoadCapacity", announcement.LoadCapacity),
                new SqlParameter("@OperatingHours", announcement.OperatingHours),
                new SqlParameter("@Description", announcement.Description) };
            Procedure("dbo.Announcements_UpdateByID", parameters);
        }

        public void DeleteByID(Announcement annoucementID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@AnnoucementID", annoucementID) };
            Procedure("dbo.Announcements_DeleteByID", parameters);
        }

        public List<Announcement> ReadAll()
        {
            return ReadAll("dbo.Announcements_ReadAll");
        }

        public Announcement ReadByID(Guid annoucementID)
        {
            List<Announcement> result = new List<Announcement>();
            SqlParameter[] parameters = { new SqlParameter("@AnnoucementID", annoucementID) };
            result = ReadAll("dbo.Announcements_ReadByID", parameters);
            return result[0];
        }

        public List<Announcement> ReadByUserID(Guid userID)
        {
            SqlParameter[] parameters = { new SqlParameter("@UserID", userID) };
            return ReadAll("dbo.Announcements_Users_ReadByID", parameters);
        }

        protected override Announcement GetModelFromReader(SqlDataReader reader)
        {
            Announcement announcement = new Announcement();
            announcement.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
            announcement.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            announcement.VehicleType = reader.GetInt32(reader.GetOrdinal("VehicleType"));
            announcement.Views = reader.GetInt32(reader.GetOrdinal("Views"));
            announcement.Promoted = reader.GetBoolean(reader.GetOrdinal("Promoted"));
            announcement.Active = reader.GetBoolean(reader.GetOrdinal("Active"));
            announcement.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
            announcement.Update = reader.GetDateTime(reader.GetOrdinal("Update"));
            announcement.Condition = reader.GetString(reader.GetOrdinal("Condition"));
            announcement.Title = reader.GetString(reader.GetOrdinal("Title"));
            announcement.Brand = reader.GetString(reader.GetOrdinal("Brand"));
            announcement.Model = reader.GetString(reader.GetOrdinal("Model"));
            announcement.Type = reader.GetString(reader.GetOrdinal("Type"));
            announcement.Kilometer = reader.GetInt32(reader.GetOrdinal("Kilometer"));
            announcement.FabricationYear = reader.GetInt32(reader.GetOrdinal("FabricationYear"));
            announcement.VIN = reader.GetString(reader.GetOrdinal("VIN"));
            announcement.FuelType = reader.GetString(reader.GetOrdinal("FuelType"));
            announcement.Price = reader.GetInt32(reader.GetOrdinal("Price"));
            announcement.NegociablePrice = reader.GetBoolean(reader.GetOrdinal("NegociablePrice"));
            announcement.Currency = reader.GetString(reader.GetOrdinal("Currency"));
            announcement.Color = reader.GetString(reader.GetOrdinal("Color"));
            announcement.ColorType = reader.GetString(reader.GetOrdinal("ColorType"));
            announcement.Power = reader.GetInt32(reader.GetOrdinal("Power"));
            announcement.Transmission = reader.GetString(reader.GetOrdinal("Transmission"));
            announcement.CubicCapacity = reader.GetInt32(reader.GetOrdinal("CubicCapacity"));
            announcement.EmissionClass = reader.GetString(reader.GetOrdinal("EmissionClass"));
            announcement.NumberOfSeats = reader.GetInt32(reader.GetOrdinal("NumberOfSeats"));
            announcement.GVW = reader.GetInt32(reader.GetOrdinal("GVW"));
            announcement.LoadCapacity = reader.GetInt32(reader.GetOrdinal("LoadCapacity"));
            announcement.OperatingHours = reader.GetInt32(reader.GetOrdinal("OperatingHours"));
            announcement.Description = reader.GetString(reader.GetOrdinal("Description"));
            return (announcement);
        }
        #endregion
    }
}
