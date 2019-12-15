using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrystalReport.Data
{
    public static class DbCon
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CRConnectionString"].ToString();
            return new SqlConnection(connectionString);
        }
        

    }
}