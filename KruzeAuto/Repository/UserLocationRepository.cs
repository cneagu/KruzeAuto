using KruzeAuto.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    class UserLocationRepository
    {
        #region Methdos
        public void Insert(UserLocation userLocation)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.UserLocation_Insert";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@UserID", userLocation.UserID));
                        command.Parameters.Add(new SqlParameter("@Country", userLocation.Country));
                        command.Parameters.Add(new SqlParameter("@County", userLocation.County));
                        command.Parameters.Add(new SqlParameter("@City", userLocation.City));

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

        public void Update(UserLocation userLocation)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.UserLocation_UpdateByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@UserID", userLocation.UserID));
                        command.Parameters.Add(new SqlParameter("@Country", userLocation.Country));
                        command.Parameters.Add(new SqlParameter("@County", userLocation.County));
                        command.Parameters.Add(new SqlParameter("@City", userLocation.City));
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

        public void DeleteByID(Guid userID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.UserLocation_DeleteByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@UserID", userID));
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

        public List<UserLocation> ReadAll()
        {
            List<UserLocation> userslocation = new List<UserLocation>();
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.UserLocation_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserLocation userLocation = new UserLocation();
                                userLocation.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
                                userLocation.Country = reader.GetString(reader.GetOrdinal("Country"));
                                userLocation.County = reader.GetString(reader.GetOrdinal("County"));
                                userLocation.City = reader.GetString(reader.GetOrdinal("City"));
                                userslocation.Add(userLocation);
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
            return userslocation;
        }

        public UserLocation ReadByID(Guid UserID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            UserLocation userLocation = new UserLocation();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.UserLocation_ReadByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@UserID", UserID));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userLocation.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
                                userLocation.Country = reader.GetString(reader.GetOrdinal("Country"));
                                userLocation.County = reader.GetString(reader.GetOrdinal("County"));
                                userLocation.City = reader.GetString(reader.GetOrdinal("City"));
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

            return userLocation;
        }
        #endregion
    }
}
