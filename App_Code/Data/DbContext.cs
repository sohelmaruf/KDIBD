using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JensenEngineers.Data
{
    public class DbContext
    {
        private string connectionString;

        public DbContext()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IEBConnectionString"].ToString();
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }


    }
}