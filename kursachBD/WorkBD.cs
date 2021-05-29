using System;
using System.Data.SqlClient;
using System.Data;

namespace kursachBD
{
    class DWorks
    {
        string Credentials = string.Empty;
        SqlConnection connection;
        public DWorks(string Credentials)
        {
            this.Credentials = Credentials;
            connection = new SqlConnection(Credentials);
            connection.Open(); GC.SuppressFinalize(this);
        }
        ~DWorks()
        {
            connection.Close();
        }
        public DataSet dataSet(string Columns, string Tables, string Arguments)
        {
            DataSet Temp = new DataSet();
            SqlDataAdapter sqlData = new SqlDataAdapter($"SELECT {Columns} FROM {Tables} {Arguments}", connection);
            sqlData.Fill(Temp);
            return Temp;
        }

    }
}
