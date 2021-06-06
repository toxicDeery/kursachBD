using System;
using System.Data.SqlClient;
using System.Data;

namespace kursachBD
{
    class DWorks
    {
        //string Credentials = string.Empty;
        SqlConnection connection;
        public DWorks(string Credentials)
        {
            //this.Credentials = Credentials;
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
        public DataSet ReturnTable(string Columns, string TablesName, string Arguments)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter($"SELECT {Columns} FROM {TablesName} {Arguments}", connection);
            DataSet dataSet = new DataSet();
            sqlData.Fill(dataSet);
            return dataSet;
        }
        public string addOrganization(string Name, string kratName, string phoneNum, int adress, string email, string site)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Организация (Название, Краткое_название, Контактный_телефон, Адрес, Эл_адрес, Адрес_сайта) VALUES('{Name}', '{kratName}', '{phoneNum}', {adress}, '{email}', '{site}')", connection);
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
                SqlCommand command = new SqlCommand($"DELETE FROM Организация WHERE Код_организации = {ID}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editOrganization(string edit, string edit1, string edit2, int edit3, string edit4, string edit5 ,int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Организация SET Название = '{edit}', Краткое_название = '{edit1}', Контактный_телефон = '{edit2}', Адрес = {edit3}, Эл_адрес = '{edit4}' , Адрес_сайта = '{edit5}' WHERE Код_организации = {ID}");
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
                SqlCommand command = new SqlCommand($"DELETE FROM Рубрика WHERE Код_рубрики = {ID}", connection);
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
                SqlCommand command = new SqlCommand($"UPDATE Рубрика SET Рубрика = '{edit}' WHERE Код_рубрики = {ID};", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addPodrazdel(string Name, string floor, int OrgCode)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Подразделение (Название, Этаж, Код_организации) VALUES ('{Name}', '{floor}', {OrgCode})", connection);
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
                SqlCommand command = new SqlCommand($"DELETE FROM Подразделение WHERE Код_подразделения = {ID}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editPodrazdel(string edit, string edit1, int OrgCode, int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Подразделение SET Название = '{edit}', Этаж = '{edit1}', Код_организации = {OrgCode}  WHERE Код_подразделения = {ID};", connection);
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
                SqlCommand command = new SqlCommand($"DELETE FROM Статус_сотрудника WHERE Код_статуса = {ID}", connection);
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
                SqlCommand command = new SqlCommand($"UPDATE Статус_сотрудника SET Статус = '{edit}' WHERE Код_статуса = {ID};", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addSotrud(string surname, string name, string otch, int PodrCode, int DolCode, string log, string pass, int StatCode)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Список_сотрудников (Фамилия, Имя, Отчество, Код_подразделения, Код_должности, Логин, Пароль, Код_статуса) VALUES ('{surname}', '{name}', '{otch}', {PodrCode}, {DolCode}, '{log}', '{pass}', {StatCode})", connection);
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
                SqlCommand command = new SqlCommand($"DELETE FROM Список_сотрудников WHERE Код_сотрудника = {ID}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editSotrud(string edit, string edit1, string edit2, int PodrCode, int DolCode, string log, string pass, int StatCode, int ID)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Список_сотрудников SET Фамилия = '{edit}', Имя = '{edit1}', Отчество = '{edit2}', Код_подразделения = {PodrCode}, Код_должности = {DolCode}, Логин = '{log}', Пароль = '{pass}', Код_статуса = {StatCode} WHERE Код_сотрудника = {ID}", connection);
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
                SqlCommand command = new SqlCommand($"DELETE FROM Должность WHERE Код_должности = {id}", connection);
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
                SqlCommand command = new SqlCommand($"UPDATE Должность SET Должность = '{edit}' WHERE Код_должности = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addNews(int RubCode, string Nazv, string text, DateTime date, DateTime date1, string size, int SotrCode)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Новость (Код_рубрики, Название_информации, Текст, Дата_размещения, Дата_перевода_в_архив, Размер_в_Кб, Код_сотрудника) VALUES ({RubCode},'{Nazv}', '{text}', '{date}', '{date1}', '{size}', {SotrCode})", connection);
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
                SqlCommand command = new SqlCommand($"DELETE FROM Новость WHERE Код_новости = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editNews(int RubCode, string edit, string edit1, DateTime date, DateTime date1, string edit2, int SotrCode, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Новость SET Код_рубрики = {RubCode}, Название_информации = '{edit}', Текст = '{edit1}', Дата_размещения = '{date}', Дата_перевода_в_архив = '{date1}', Размер_в_Кб = '{edit2}', Код_сотрудника = {SotrCode} WHERE Код_новости = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addArchive(DateTime date, int NewsCode)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Архив (Дата_новости, Код_новости) VALUES ('{date}', {NewsCode})", connection);
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
                SqlCommand command = new SqlCommand($"DELETE FROM Архив WHERE Код_архива = '{id}'", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editArchive(DateTime date, int NewsCode, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Архив SET Дата_новости = '{date}', Код_новости = {NewsCode} WHERE Код_архива = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addFile(string Name, string size, string type, string kratname, int NewsCode)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Файл (Название, Размер, Тип, Краткое_название, Код_новости) VALUES ('{Name}', '{size}', '{type}', '{kratname}', {NewsCode})", connection);
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
                SqlCommand command = new SqlCommand($"DELETE FROM Файл WHERE Код_файла = '{id}'", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editFile(string edit, string edit1, string edit2, string kratname, int NewsCode, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Файл SET Название = '{edit}', Размер = '{edit1}', Тип = '{edit2}', Краткое_название = '{kratname}', Код_новости = {NewsCode} WHERE Код_файла = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addAdress(string numHome, string korpus, int streetCode, int hoodCode)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Адрес (Номер_дома, Корпус, Код_улицы, Код_нас_пункт) VALUES ('{numHome}', '{korpus}', {streetCode}, {hoodCode})", connection);
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
        public string editAdress(string edit, string edit1, int streetCode, int hoodCode, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Адрес SET Номер_дома = '{edit}', Корпус = '{edit1}', Код_улицы = {streetCode}, Код_нас_пункт = {hoodCode} WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addStreet(string nazv, int typestr)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Улица (Название, Код_типа_улицы) VALUES ('{nazv}', {typestr})", connection);
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
        public string editStreet(string edit, int type, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Улица SET Название = '{edit}', Код_типа_улицы = {type} WHERE Код = {id}", connection);
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
        public string addNaspunkt(string nazvanie, int typenasp)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Населенный_пункт (Название, Код_типа_нас_пункт) VALUES ('{nazvanie}', {typenasp})", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delNaspunkt(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Населенный_пункт WHERE Код = '{id}'", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editNaspunkt(string edit, int ip, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Населенный_пункт SET Название = '{edit}', Код_типа_нас_пункт = {ip} WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string addTypenasp(string nazvanie)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Тип_населенного_пункта (Название) VALUES ('{nazvanie}')", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string delTypenasp(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Тип_населенного_пункта WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string editTypenasp(string edit, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Тип_населенного_пункта SET Название = '{edit}' WHERE Код = {id}", connection);
                return $"Команда выполнена. Задействовано строк таблицы: {command.ExecuteNonQuery()}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

    }
}
