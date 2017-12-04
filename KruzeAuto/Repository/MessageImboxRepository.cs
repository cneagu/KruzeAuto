using KruzeAuto.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Repository
{
    public class MessageImboxRepository
    {
        #region Methdos
        public void Insert(MessageImbox messageImbox)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.MessageImbox_Insert";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@MessageID", messageImbox.MessageID));
                        command.Parameters.Add(new SqlParameter("@UserID", messageImbox.UserID));
                        command.Parameters.Add(new SqlParameter("@AnnoucementID", messageImbox.AnnoucementID));
                        command.Parameters.Add(new SqlParameter("@CreationDate", messageImbox.CreationDate));
                        command.Parameters.Add(new SqlParameter("@Read", messageImbox.Read));
                        command.Parameters.Add(new SqlParameter("@MesageContent", messageImbox.MesageContent));

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

        public void Update(MessageImbox messageImbox)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.MessageImbox_UpdateByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@MessageID", messageImbox.MessageID));
                        command.Parameters.Add(new SqlParameter("@Read", messageImbox.Read));
                        command.Parameters.Add(new SqlParameter("@MesageContent", messageImbox.MesageContent));
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

        public void DeleteByID(Guid MessageID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.MessageImbox_DeleteByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@MessageID", MessageID));
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

        public List<MessageImbox> ReadByUserID(Guid UserID)
        {
            List<MessageImbox> messages = new List<MessageImbox>();
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.MessageImbox_ReadByUserID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@UserID", UserID));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MessageImbox messageImbox = new MessageImbox();
                                messageImbox.MessageID = reader.GetGuid(reader.GetOrdinal("MessageID"));
                                messageImbox.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
                                messageImbox.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
                                messageImbox.Read = reader.GetBoolean(reader.GetOrdinal("Read"));
                                messageImbox.MesageContent = reader.GetString(reader.GetOrdinal("MesageContent"));
                                messages.Add(messageImbox);
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
            return messages;
        }

        public List<MessageImbox> ReadByAnnouncementsID(Guid AnnoucementID)
        {
            List<MessageImbox> messages = new List<MessageImbox>();
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.MessageImbox_ReadByAnnouncementsID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@AnnoucementID", AnnoucementID));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MessageImbox messageImbox = new MessageImbox();
                                messageImbox.MessageID = reader.GetGuid(reader.GetOrdinal("MessageID"));
                                messageImbox.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
                                messageImbox.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
                                messageImbox.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
                                messageImbox.Read = reader.GetBoolean(reader.GetOrdinal("Read"));
                                messageImbox.MesageContent = reader.GetString(reader.GetOrdinal("MesageContent"));
                                messages.Add(messageImbox);
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
            return messages;
        }

        public MessageImbox ReadByID(Guid MessageID)
        {
            string connectionString = "Server=NEAGU;Database=KruzeAutoDB;Trusted_Connection=True;";
            MessageImbox messageImbox = new MessageImbox();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.MessageImbox_ReadByID";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@MessageID", MessageID));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                messageImbox.MessageID = reader.GetGuid(reader.GetOrdinal("MessageID"));
                                messageImbox.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
                                messageImbox.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
                                messageImbox.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
                                messageImbox.Read = reader.GetBoolean(reader.GetOrdinal("Read"));
                                messageImbox.MesageContent = reader.GetString(reader.GetOrdinal("MesageContent"));
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

            return messageImbox;
        }
        #endregion
    }
}
