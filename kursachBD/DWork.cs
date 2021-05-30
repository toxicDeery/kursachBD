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
        public string addStatusSotr(string status)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Статус_сотрудника (Статус) VALUES ('{status}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delStatusSotr(int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Статус_сотрудника WHERE Код = {ID}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editStatusSotr(string edit, int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Статус_сотрудника SET Статус = '{edit}' WHERE Код = {ID};", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addSotrud(string surname, string name, string otch)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Список_сотрудников (Фамилия, Имя, Отчество) VALUES ('{surname}', '{name}', '{otch}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delSotrud(int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Список_сотрудников WHERE Код = {ID}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editSotrud(string edit, string edit1, string edit2, int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Список_сотрудников SET Фамилия = '{edit}', Имя = '{edit1}', Отчество = '{edit2}' WHERE Код = {ID}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addDolzn(string dolzn)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Должность (Должность) VALUES ('{dolzn}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delDolzn(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Должность WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editDolzn(string edit, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Должность SET Должность = '{edit}' WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
