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
        public string addOrganization(string Name, string kratName, string phoneNum, string adress, string email, string site)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Организация (Название, Краткое_название, Контактный_телефон, Адрес, Эл_адрес, Адрес_сайта) VALUES('{Name}', '{kratName}', '{phoneNum}',' {adress}', '{email}', '{site}')", connection);
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
                SqlCommand command = new SqlCommand($"DELETE FROM Организация WHERE Код = {ID}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editOrganization(string edit, string edit1, string edit2, string edit3, string edit4, string edit5 ,int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Организация SET Название = '{edit}', Краткое_название = '{edit1}', Контактный_телефон = '{edit2}', Адрес = '{edit3}', Эл_адрес = '{edit4}' , Адрес_сайта = '{edit5}' WHERE Код = {ID}");
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addRubrick(string Rubrick)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Рубрика (Рубрика) VALUES ('{Rubrick}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delRubrick(int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Рубрика WHERE Код = {ID}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editRubrick(string edit, int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Рубрика SET Рубрика = '{edit}' WHERE Код = {ID};", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addPodrazdel(string Name, string floor)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Подразделение (Название, Этаж) VALUES ('{Name}', '{floor}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delPodrazdel(int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Подразделение WHERE Код = {ID}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editPodrazdel(string edit, string edit1, int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Подразделение SET Название = '{edit}', Этаж = '{edit1}'  WHERE Код = {ID};", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
