﻿using System;
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
        public string addNews(string Nazv, string text, DateTime date, DateTime date1)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Новость (Название_информации, Текст, Дата_размещения, Дата_перевода_в_архив) VALUES ('{Nazv}', '{text}', '{date}', '{date1}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delNews(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Новость WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editNews(string edit, string edit1, DateTime date, DateTime date1, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Новость SET Название_информации = '{edit}', Текст = '{edit1}', Дата_размещения = '{date}', Дата_перевода_в_архив = '{date1}' WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addArchive(DateTime date)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Архив (Дата_новости) VALUES ('{date}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delArchive(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Архив WHERE Код = '{id}'", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editArchive(DateTime date, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Архив SET Дата_новости = '{date}' WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addFile(string Name, string size, string type)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Файл (Название, Размер, Тип) VALUES ('{Name}', '{size}', '{type}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delFile(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Файл WHERE Код = '{id}'", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editFile(string edit, string edit1, string edit2, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Файл SET Назавние = '{edit}', Размер = '{edit1}', Тип = '{edit2}' WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addAdress(string numHome, string korpus)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Адрес (Номер_дома, Корпус) VALUES ('{numHome}', '{korpus}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delAdress(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Адрес WHERE Код = '{id}'", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editAdress(string edit, string edit1, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Адрес SET Номер_дома = '{edit}', Корпус = '{edit1}' WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addStreet(string nazv)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Улица (Название) VALUES ('{nazv}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delStreet(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Улица WHERE Код = '{id}'", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editStreet(string edit, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Улица SET Название = '{edit}' WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addTypestreet(string nazvan)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Тип_улицы (Название) VALUES ('{nazvan}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delTypestreet(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Тип_улицы WHERE Код = '{id}'", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editTypestreet(string edit, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Тип_улицы SET Название = '{edit}' WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
