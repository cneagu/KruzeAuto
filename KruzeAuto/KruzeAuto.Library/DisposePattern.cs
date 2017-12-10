using System;
using System.Data.SqlClient;


namespace KruzeAuto.Library
{
    public class DisposePattern : IDisposable
    {
        private SqlConnection _connection;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }
        }

        ~DisposePattern()
        {
            Dispose(false);
        }
    }
}
