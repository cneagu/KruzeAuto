using KruzeAuto.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    public class PictureRepository
    {
        #region Methdos
        public void Insert(Picture picture)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Pictures_Insert";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PictureID", picture.PictureID));
                        command.Parameters.Add(new SqlParameter("@Image", picture.Image));

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

        public void Update(Picture picture)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Pictures_UpdateByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PictureID", picture.PictureID));
                        command.Parameters.Add(new SqlParameter("@Image", picture.Image));

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

        public void Pictures_DeleteByID(Guid PictureID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Pictures_DeleteByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PictureID", PictureID));
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

        public List<Picture> ReadAll()
        {
            List<Picture> pictures = new List<Picture>();
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Pictures_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Picture picture = new Picture();
                                picture.PictureID = reader.GetGuid(reader.GetOrdinal("PictureID"));
                               // picture.Image = reader.GetByte(reader.GetOrdinal("Image"));

                                pictures.Add(picture);
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
            return pictures;
        }

        public Picture ReadByID(Guid PictureID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            Picture picture = new Picture();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Pictures_ReadByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@PictureID", PictureID));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                picture.PictureID = reader.GetGuid(reader.GetOrdinal("PictureID"));
                                // picture.Image = reader.GetByte(reader.GetOrdinal("Image"));
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

            return picture;
        }
        #endregion
    }
}
