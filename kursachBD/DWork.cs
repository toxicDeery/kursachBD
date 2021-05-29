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
        public string addOrganization(string Name)
        {
            try
            {
                SqlCommand command = new SqlCommand($"", connection);
                return $"Команда выполнена. Задействовано строк таблицы: { command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string deleteOrganization(int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
