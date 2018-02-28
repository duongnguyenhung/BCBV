using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace HISSMS
{
    class Database
    {
        public static OracleConnection GetDBConnection()
        {

            string host = "10.100.2.68";
            int port = 1521;
            string sid = "hsoft.quang";
            string user = "hsoft";
            string password = "hsoft";

            return Ket_Noi.GetDBConnection(host, port, sid, user, password);
        }
    }
}
