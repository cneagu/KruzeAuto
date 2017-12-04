using KruzeAuto.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AnnouncementOptionRepository
    {
        #region Methdos
        public void Insert(AnnouncementOption announcementOption)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.AnnouncementsOptions_Insert";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@AnnoucementID", announcementOption.AnnoucementID));
                        command.Parameters.Add(new SqlParameter("@OptionID", announcementOption.OptionID));
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

        public void Update(AnnouncementOption announcementOption)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.AnnouncementsOptions_UpdateByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@AnnoucementID", announcementOption.AnnoucementID));
                        command.Parameters.Add(new SqlParameter("@OptionID", announcementOption.OptionID));
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

        public void DeleteByID(Guid AnnoucementID, Guid OptionID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.AnnouncementsOptions_DeleteByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@AnnoucementID", AnnoucementID));
                        command.Parameters.Add(new SqlParameter("@OptionID", OptionID));
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

        public List<AnnouncementOption> ReadAnnouncementsOptionsByID()
        {
            List<AnnouncementOption> announcementoptions = new List<AnnouncementOption>();
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.AnnouncementsOptions_ReadAnnouncementsOptionsByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AnnouncementOption announcementOption = new AnnouncementOption();
                                announcementOption.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
                                announcementOption.OptionID = reader.GetGuid(reader.GetOrdinal("OptionID"));
                                announcementoptions.Add(announcementOption);
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
            return announcementoptions;
        }

        public AnnouncementOption ReadByID(Guid AnnoucementID, Guid OptionID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            AnnouncementOption announcementOption = new AnnouncementOption();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.AnnouncementsOptions_ReadByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@AnnoucementID", AnnoucementID));
                        command.Parameters.Add(new SqlParameter("@OptionID", OptionID));

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                announcementOption.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
                                announcementOption.OptionID = reader.GetGuid(reader.GetOrdinal("OptionID"));
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

            return announcementOption;
        }
        #endregion
    }
}
