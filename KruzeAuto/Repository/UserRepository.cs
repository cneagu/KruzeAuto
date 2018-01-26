using KruseAuto.Repository.Core;
using KruzeAuto.Model;
using KruzeAuto.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KruseAuto.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Methdos
        public void Insert(User user)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", user.UserID),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@PhoneNumber", user.PhoneNumber),
                new SqlParameter("@CreationDate", user.CreationDate),
                new SqlParameter("@Subscribed", user.Subscribed) };
            ExecuteNonQuery("dbo.Users_Insert", parameters);    
        }

        public void Update(User user)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", user.UserID),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@PhoneNumber", user.PhoneNumber),
                new SqlParameter("@Subscribed", user.Subscribed) };
            ExecuteNonQuery("dbo.Users_UpdateByID", parameters);
        }

        public void Delete(Guid userID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID) };
            ExecuteNonQuery("dbo.Users_DeleteByID", parameters);
        }

        public List<User> ReadAll()
        {
            return ReadAll("dbo.Users_ReadAll");
        }

        public User ReadByID(Guid userID)
        {
            List<User> result = new List<User>();
            SqlParameter[] parameters = { new SqlParameter("@UserID", userID) };
            result = ReadAll("dbo.Users_ReadByID", parameters);
            if (result.Count > 0)
            {

                return result[0];
            }
            else
                return new User();
        }

        public User ReadSingIn(string email, string userName, string phoneNumber)
        {
            User result = new User();
            SqlParameter[] parameters = {
                new SqlParameter("@Email", email),
                new SqlParameter("@UserName", userName),
                new SqlParameter("@PhoneNumber", phoneNumber) };
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Users_Read_SingIn";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        if (parameters != null)
                            command.Parameters.AddRange(parameters);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User();
                                user.Email = reader.GetString(reader.GetOrdinal("Email"));
                                user.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                                user.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                                result = user;
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
                    connection.Dispose();
                }
            }
            return result;
        }

        public User ReadLogIn(string email, string password)
        {
            User result = new User();
            SqlParameter[] parameters = {
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password)
            };
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                        command.CommandText = "dbo.Users_Read_LogIn";
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            if (parameters != null)
                                command.Parameters.AddRange(parameters);
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                User user = new User();
                                user.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
                                //user.Email = reader.GetString(reader.GetOrdinal("Email"));
                                //user.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                                //user.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                                result = user;
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
                        connection.Dispose();
                    }
                }
                return result;
            }


        protected override User GetModelFromReader(SqlDataReader reader)
        {
            User user = new User();
            user.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            user.Email = reader.GetString(reader.GetOrdinal("Email"));
            user.UserName = reader.GetString(reader.GetOrdinal("UserName"));
            user.Password = reader.GetString(reader.GetOrdinal("Password"));
            user.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            user.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
            user.Subscribed = reader.GetBoolean(reader.GetOrdinal("Subscribed"));
            return(user);
        }
        #endregion
    }
}
