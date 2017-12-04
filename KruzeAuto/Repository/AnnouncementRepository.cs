using KruzeAuto.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    public class AnnouncementRepository
    {
        #region Methdos
        public void Insert(Announcement announcement)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Announcements_Insert";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@AnnoucementID", announcement.AnnoucementID));
                        command.Parameters.Add(new SqlParameter("@UserID", announcement.UserID));
                        command.Parameters.Add(new SqlParameter("@VehicleType", announcement.VehicleType));
                        command.Parameters.Add(new SqlParameter("@Views", announcement.Views));
                        command.Parameters.Add(new SqlParameter("@Promoted", announcement.Promoted));
                        command.Parameters.Add(new SqlParameter("@Active", announcement.Active));
                        command.Parameters.Add(new SqlParameter("@CreationDate", announcement.CreationDate));
                        command.Parameters.Add(new SqlParameter("@Update", announcement.Update));
                        command.Parameters.Add(new SqlParameter("@Condition", announcement.Condition));
                        command.Parameters.Add(new SqlParameter("@Title", announcement.Title));
                        command.Parameters.Add(new SqlParameter("@Brand", announcement.Brand));
                        command.Parameters.Add(new SqlParameter("@Model", announcement.Model));
                        command.Parameters.Add(new SqlParameter("@Type", announcement.Type));
                        command.Parameters.Add(new SqlParameter("@Kilometer", announcement.Kilometer));
                        command.Parameters.Add(new SqlParameter("@FabricationYear", announcement.FabricationYear));
                        command.Parameters.Add(new SqlParameter("@VIN", announcement.VIN));
                        command.Parameters.Add(new SqlParameter("@FuelType", announcement.FuelType));
                        command.Parameters.Add(new SqlParameter("@Price", announcement.Price));
                        command.Parameters.Add(new SqlParameter("@NegociablePrice", announcement.NegociablePrice));
                        command.Parameters.Add(new SqlParameter("@Currency", announcement.Currency));
                        command.Parameters.Add(new SqlParameter("@Color", announcement.Color));
                        command.Parameters.Add(new SqlParameter("@ColorType", announcement.ColorType));
                        command.Parameters.Add(new SqlParameter("@Power", announcement.Power));
                        command.Parameters.Add(new SqlParameter("@Transmission", announcement.Transmission));
                        command.Parameters.Add(new SqlParameter("@CubicCapacity", announcement.CubicCapacity));
                        command.Parameters.Add(new SqlParameter("@EmissionClass", announcement.EmissionClass));
                        command.Parameters.Add(new SqlParameter("@NumberOfSeats", announcement.NumberOfSeats));
                        command.Parameters.Add(new SqlParameter("@GVW", announcement.GVW));
                        command.Parameters.Add(new SqlParameter("@LoadCapacity", announcement.LoadCapacity));
                        command.Parameters.Add(new SqlParameter("@OperatingHours", announcement.OperatingHours));
                        command.Parameters.Add(new SqlParameter("@Description", announcement.Description));
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Update(Announcement announcement)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Announcements_UpdateByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@AnnoucementID", announcement.AnnoucementID));
                        command.Parameters.Add(new SqlParameter("@VehicleType", announcement.VehicleType));
                        command.Parameters.Add(new SqlParameter("@Views", announcement.Views));
                        command.Parameters.Add(new SqlParameter("@Promoted", announcement.Promoted));
                        command.Parameters.Add(new SqlParameter("@Active", announcement.Active));
                        command.Parameters.Add(new SqlParameter("@CreationDate", announcement.CreationDate));
                        command.Parameters.Add(new SqlParameter("@Update", announcement.Update));
                        command.Parameters.Add(new SqlParameter("@Condition", announcement.Condition));
                        command.Parameters.Add(new SqlParameter("@Title", announcement.Title));
                        command.Parameters.Add(new SqlParameter("@Brand", announcement.Brand));
                        command.Parameters.Add(new SqlParameter("@Model", announcement.Model));
                        command.Parameters.Add(new SqlParameter("@Type", announcement.Type));
                        command.Parameters.Add(new SqlParameter("@Kilometer", announcement.Kilometer));
                        command.Parameters.Add(new SqlParameter("@FabricationYear", announcement.FabricationYear));
                        command.Parameters.Add(new SqlParameter("@VIN", announcement.VIN));
                        command.Parameters.Add(new SqlParameter("@FuelType", announcement.FuelType));
                        command.Parameters.Add(new SqlParameter("@Price", announcement.Price));
                        command.Parameters.Add(new SqlParameter("@NegociablePrice", announcement.NegociablePrice));
                        command.Parameters.Add(new SqlParameter("@Currency", announcement.Currency));
                        command.Parameters.Add(new SqlParameter("@Color", announcement.Color));
                        command.Parameters.Add(new SqlParameter("@ColorType", announcement.ColorType));
                        command.Parameters.Add(new SqlParameter("@Power", announcement.Power));
                        command.Parameters.Add(new SqlParameter("@Transmission", announcement.Transmission));
                        command.Parameters.Add(new SqlParameter("@CubicCapacity", announcement.CubicCapacity));
                        command.Parameters.Add(new SqlParameter("@EmissionClass", announcement.EmissionClass));
                        command.Parameters.Add(new SqlParameter("@NumberOfSeats", announcement.NumberOfSeats));
                        command.Parameters.Add(new SqlParameter("@GVW", announcement.GVW));
                        command.Parameters.Add(new SqlParameter("@LoadCapacity", announcement.LoadCapacity));
                        command.Parameters.Add(new SqlParameter("@OperatingHours", announcement.OperatingHours));
                        command.Parameters.Add(new SqlParameter("@Description", announcement.Description));
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeleteByID(Guid AnnoucementID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Announcements_DeleteByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@AnnoucementID", AnnoucementID));
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Announcement> ReadAll()
        {
            List<Announcement> announcements = new List<Announcement>();
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Announcements_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
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
                                announcements.Add(announcement);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was an SQL error: {0}", sqlEx.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return announcements;
        }

        public Announcement ReadByID(Guid AnnoucementID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            Announcement announcement = new Announcement();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Announcements_ReadByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@AnnoucementID", AnnoucementID));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
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
                            }

                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("There was an error: {0}", ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }

            return announcement;
        }

        public Announcement ReadByUserID(Guid UserID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            Announcement announcement = new Announcement();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Announcements_Users_ReadByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@UserID", UserID));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
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
                            }

                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("There was an error: {0}", ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }

            return announcement;
        }
        #endregion
    }
}
