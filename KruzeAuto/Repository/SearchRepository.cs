using KruseAuto.Repository.Core;
using KruzeAuto.Model;
using KruzeAuto.RepositoryAbstraction;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KruseAuto.Repository
{
    public class SearchRepository : BaseRepository<Search>, ISearchRepository
    {
        public List<Search> MainSearch(int VehicleType, string Condition, string Brand, string Model,
           int Kilometer, int FabricationYear, string FuelType1, string FuelType2, string FuelType3, string FuelType4,
           string FuelType5, string FuelType6, string FuelType7, int Price)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@VehicleType", VehicleType),
                new SqlParameter("@Condition", Condition),
                new SqlParameter("@Brand", Brand),
                new SqlParameter("@Model", Model),
                new SqlParameter("@Kilometer", Kilometer),
                new SqlParameter("@FabricationYear", FabricationYear),
                new SqlParameter("@FuelType1", FuelType1),
                new SqlParameter("@FuelType2", FuelType2),
                new SqlParameter("@FuelType3", FuelType3),
                new SqlParameter("@FuelType4", FuelType4),
                new SqlParameter("@FuelType5", FuelType5),
                new SqlParameter("@FuelType6", FuelType6),
                new SqlParameter("@FuelType7", FuelType7),
                new SqlParameter("@Price", Price)
            };
            return ReadAll("dbo.Announcements_MainSearch", parameters);
        }

        protected override Search GetModelFromReader(SqlDataReader reader)
        {
            Search announcement = new Search();
            announcement.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
            announcement.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            announcement.Promoted = reader.GetBoolean(reader.GetOrdinal("Promoted"));
            announcement.Title = reader.GetString(reader.GetOrdinal("Title"));
            announcement.Brand = reader.GetString(reader.GetOrdinal("Brand"));
            announcement.Model = reader.GetString(reader.GetOrdinal("Model"));
            announcement.Kilometer = reader.GetInt32(reader.GetOrdinal("Kilometer"));
            announcement.FabricationYear = reader.GetInt32(reader.GetOrdinal("FabricationYear"));
            announcement.FuelType = reader.GetString(reader.GetOrdinal("FuelType"));
            announcement.Price = reader.GetInt32(reader.GetOrdinal("Price"));
            announcement.Power = reader.GetInt32(reader.GetOrdinal("Power"));
            announcement.UserName = reader.GetString(reader.GetOrdinal("UserName"));
            announcement.Country = reader.GetString(reader.GetOrdinal("Country"));
            announcement.County = reader.GetString(reader.GetOrdinal("County"));
            return (announcement);
        }
    }
}
