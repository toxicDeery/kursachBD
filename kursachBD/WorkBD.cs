using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace kursachBD
{
    class WorkBD
    {
        string Credentials = string.Empty;
        SqlConnection connection;
        public WorkBD(string Credentials)
        {
            this.Credentials = Credentials;
            connection = new SqlConnection(Credentials);
            connection.Open(); GC.SuppressFinalize(this);
        }
        ~WorkBD()
        {
            connection.Close();
        }
    }
}
