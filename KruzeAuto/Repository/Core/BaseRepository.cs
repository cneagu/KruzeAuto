using KruzeAuto.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace KruseAuto.Repository.Core
{
    public abstract class BaseRepository<T>
    {
        #region Members
        protected static string _connectionString = GetConnectionString();
        #endregion

        #region Methods
        private static string GetConnectionString()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["KruzeAutoDB"];
            if (connectionStringSettings == null)
            {
                throw new ArgumentNullException("No connection string defined in the configuration file!");
            }

            return connectionStringSettings.ConnectionString;
        }

        public List<T> ReadAll(string storedProcedureName, SqlParameter[] parameters = default(SqlParameter[]))
        {
            List<T> result = new List<T>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = storedProcedureName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        if (parameters != null)
                            command.Parameters.AddRange(parameters);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(GetModelFromReader(reader));
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

                    DisposePattern disposePattern = new DisposePattern();
                    disposePattern.Dispose();
                }
            }

            return result;
        }

        public void Procedure(string storedProcedureName, SqlParameter[] parameters = default(SqlParameter[]))
        {        
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();                   
                    command.Connection = connection;
                    command.CommandText = storedProcedureName;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    command.ExecuteReader();                   
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
                    DisposePattern disposePattern = new DisposePattern();
                    disposePattern.Dispose();
                }
            }
        }

        protected abstract T GetModelFromReader(SqlDataReader reader);
        #endregion
    }
}
