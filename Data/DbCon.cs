using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
   public static class DbCon
    {
        public static SqlConnection GetConnection()
        {
            string dbCon = @"Data Source=DESKTOP-SHB3L6S\SQLEXPRESS;Initial Catalog=Learning;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return new SqlConnection(dbCon);
        } 
    }
}
