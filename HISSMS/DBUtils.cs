using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace HISSMS
{
    class DBUtils
    {
        public static OracleConnection GetDBConnection(string connectionString)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connectionString;
            return conn;
        }
    }
}
