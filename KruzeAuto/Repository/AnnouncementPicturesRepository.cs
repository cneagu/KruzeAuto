using System;
using System.Collections.Generic;
using KruzeAuto.Model;
using System.Data.SqlClient;

namespace Repository
{
    public class AnnouncementPicturesRepository
    {
        #region Methdos
        public void Insert(AnnouncementPictures announcementPictures)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.AnnouncementsPictures_Insert";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PictureID", announcementPictures.PictureID));
                        command.Parameters.Add(new SqlParameter("@AnnoucementID", announcementPictures.AnnoucementID));
                        command.Parameters.Add(new SqlParameter("@PrimaryPicture", announcementPictures.PrimaryPicture));
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

        public void Update(AnnouncementPictures announcementPictures)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.AnnouncementsPictures_UpdateByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PictureID", announcementPictures.PictureID));
                        command.Parameters.Add(new SqlParameter("@AnnoucementID", announcementPictures.AnnoucementID));
                        command.Parameters.Add(new SqlParameter("@PrimaryPicture", announcementPictures.PrimaryPicture));
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

        public void DeleteByID(Guid PictureID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.AnnouncementsPictures_DeleteByID";
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

        public List<AnnouncementPictures> ReadAllPicturesByID()
        {
            List<AnnouncementPictures> announcementpictures = new List<AnnouncementPictures>();
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.AnnouncementsPictures_ReadAllPicturesByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AnnouncementPictures announcementPicture = new AnnouncementPictures();
                                announcementPicture.PictureID = reader.GetGuid(reader.GetOrdinal("PictureID"));
                                announcementPicture.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
                                announcementPicture.PrimaryPicture = reader.GetBoolean(reader.GetOrdinal("PrimaryPicture"));
                                announcementpictures.Add(announcementPicture);
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
            return announcementpictures;
        }

        public AnnouncementPictures ReadByID(Guid AnnoucementID, Guid PictureID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            AnnouncementPictures announcementPictures = new AnnouncementPictures();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.AnnouncementsPictures_ReadByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@AnnoucementID", AnnoucementID));
                        command.Parameters.Add(new SqlParameter("@PictureID", PictureID));

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                announcementPictures.PictureID = reader.GetGuid(reader.GetOrdinal("PictureID"));
                                announcementPictures.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
                                announcementPictures.PrimaryPicture = reader.GetBoolean(reader.GetOrdinal("PrimaryPicture"));
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

            return announcementPictures;
        }
        #endregion
    }
}
