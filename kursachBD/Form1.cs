using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace kursachBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComboUpdates();
            TableUpdate();
        }
        string Credentials =
            @"Server = localhost\SQLExpress;" +
            "Integrated security = SSPI;" +
            "database = kurs;";
        int tempeID = -1;
        string selectedTable;
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tempeID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            switch (selectedTable)
            {
                case "Тип_населенного_пункта": TypenaspTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); break;
                case "Населенный_пункт": NaspTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); TypenaspCB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); break;
                case "Тип_улицы": TypestrTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); break;
                case "Улица": StreetTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); TypestrCB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); break;
                case "Адрес":
                    NumHomeTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    KorpusTB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    StreetCB.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    NaspCB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    break;
                case "Должность":
                    DolznTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); break;
                case "Статус_сотрудника":
                    StatusTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); break;
                case "Список_сотрудников":
                    SurnameTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    NameTB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MiddlenameTB.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    PodrazdelCB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    DolznCB.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    LogTB.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    PasswordTB.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    StatusCB.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(); break;
                case "Подразделение":
                    PodrazdelTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    FloorTB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    OrgaCB.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); break;
                case "Организация": 
                    OrgTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    KratOrgTB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    NumPhoneTB.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    AdressCB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    EmailTB.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    SiteTB.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); break;
                case "Рубрика":
                    RubrickTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); break;
                case "Новость":
                    RubrickCB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); 
                    NewsTB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    TextTB.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    DateRazmDTP.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    DateArchiveDTP.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                    SizeNTB.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    SotrudCB.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); break;
                case "Архив":
                    NewsDTP.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    NewsCB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); break;
                case "Файл":
                    FileTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    SizeFileTB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    TypefTB.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    KratfTB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    NewsFArchCB.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); break;

            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: tab0(); break;
                case 1: tab3(); break;
                case 2: tab4(); break;
            }
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tab0();
        }

        void tab0()
        {
            DWorks tet = new DWorks(Credentials);
            switch (tabControl2.SelectedIndex)
            {
                case 0: { selectedTable = "Организация"; dataGridView1.DataSource = tet.dataSet("Название, Краткое_название, Контактный_телефон, Адрес, Эл_адрес, Адрес_сайта", "Организация", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Организация", null).Tables[0].DefaultView; break; }
                case 1: { selectedTable = "Подразделение"; dataGridView1.DataSource = tet.dataSet("Название, Этаж, Код_организации", "Подразделение", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Подразделение", null).Tables[0].DefaultView; break; }
                case 2: { selectedTable = "Список_сотрудников"; dataGridView1.DataSource = tet.dataSet("Фамилия, Имя, Отчество, Код_подразделения, Код_должности, Логин, Пароль, Код_статуса, Дата_принятия", "Список_сотрудников", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Список_сотрудников", null).Tables[0].DefaultView; break; }
                case 3: { selectedTable = "Статус_сотрудника"; dataGridView1.DataSource = tet.dataSet("Статус", "Статус_сотрудника", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Статус_сотрудника", null).Tables[0].DefaultView; break; }
                case 4: { selectedTable = "Должность"; dataGridView1.DataSource = tet.dataSet("Должность", "Должность", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Должность", null).Tables[0].DefaultView; break; }
            }
        }        
        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tab3();
        }
        void tab3()
        {
            DWorks tet = new DWorks(Credentials);
            switch (tabControl3.SelectedIndex)
            {
                case 0: { selectedTable = "Адрес"; dataGridView1.DataSource = tet.dataSet("Номер_дома, Корпус, Код_улицы, Код_нас_пункт, Код_организации", "Адрес", null).Tables[0].DefaultView; dataGridViewListReturner.DataSource = tet.dataSet("*", "Адрес", null).Tables[0].DefaultView; break; }
                case 1: { selectedTable = "Улица"; dataGridView1.DataSource = tet.dataSet("Название, Код_типа_улицы", "Улица", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Улица", null).Tables[0].DefaultView; break; }
                case 2: { selectedTable = "Тип_улицы"; dataGridView1.DataSource = tet.dataSet("Название", "Тип_улицы", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Тип_улицы", null).Tables[0].DefaultView; break; }
                case 3: { selectedTable = "Населенный_пункт"; dataGridView1.DataSource = tet.dataSet("Название, Код_типа_нас_пункт", "Населенный_пункт", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Населенный_пункт", null).Tables[0].DefaultView; break; }
                case 4: { selectedTable = "Тип_населенного_пункта"; dataGridView1.DataSource = tet.dataSet("Название", "Тип_населенного_пункта", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Тип_населенного_пункта", null).Tables[0].DefaultView; break; }
            }
        }
       

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            tab4();
        }
        void tab4()
        {
            DWorks tet = new DWorks(Credentials);
            switch (tabControl4.SelectedIndex)
            {
                case 0: { selectedTable = "Новость"; dataGridView1.DataSource = tet.dataSet("Код_рубрики, Название_информации, Текст, Дата_размещения, Дата_перевода_в_архив, Размер_в_Кб, Код_сотрудника", "Новость", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Новость", null).Tables[0].DefaultView; break; }
                case 1: { selectedTable = "Рубрика"; dataGridView1.DataSource = tet.dataSet("Рубрика", "Рубрика", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Рубрика", null).Tables[0].DefaultView; break; }
                case 2: { selectedTable = "Архив"; dataGridView1.DataSource = tet.dataSet("Дата_новости, Код_новости", "Архив", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Архив", null).Tables[0].DefaultView; break; }
                case 3: { selectedTable = "Файл"; dataGridView1.DataSource = tet.dataSet("Название, Размер, Тип, Краткое_название, Код_новости", "Файл", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Файл", null).Tables[0].DefaultView; break; }
            }
        }

        int GetDirCode(string Table, string ToFind, int cell) // Вернуть код (итератор) из справочника
        {
            DWorks database = new DWorks(Credentials);
            dataGridViewListReturner.DataSource = database.ReturnTable("*", Table, null).Tables[0].DefaultView;
            for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
            {
                if (dataGridViewListReturner.Rows[i].Cells[cell].Value.ToString() == ToFind)
                {
                    return Convert.ToInt32(dataGridViewListReturner.Rows[i].Cells[0].Value);
                }
            }
            return -1;
        }
        
        void ComboUpdates()
        {
            TypenaspCB.Items.Clear();
            TypestrCB.Items.Clear();
            StreetCB.Items.Clear();
            NaspCB.Items.Clear();
            DolznCB.Items.Clear();
            StatusCB.Items.Clear();
            AdressCB.Items.Clear();
            OrgaCB.Items.Clear();
            PodrazdelCB.Items.Clear();
            RubrickCB.Items.Clear();
            SotrudCB.Items.Clear();
            NewsCB.Items.Clear();
            NewsFArchCB.Items.Clear();
           
            QueryPodrazCB.Items.Clear();
            foreach (string i in BufferListUpdate(0))
            {
                TypenaspCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(1))
            {
                TypestrCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(2))
            {
                StreetCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(3))
            {
                NaspCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(4))
            {
                DolznCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(5))
            {
                StatusCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(6))
            {
                AdressCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(7))
            {
                OrgaCB.Items.Add(i);
                
            }
            foreach (string i in BufferListUpdate(8))
            {
                PodrazdelCB.Items.Add(i);
                QueryPodrazCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(9))
            {
                RubrickCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(10))
            {
                SotrudCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(11))
            {
                NewsCB.Items.Add(i);
                NewsFArchCB.Items.Add(i);
            }


        }
        List<string> BufferListUpdate(int Index)
        {
            DWorks database = new DWorks(Credentials);
            List<string> Temp = new List<string>();
            switch (Index)
            {
                case 0: //Добавить тип нас.пункт
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название", "Тип_населенного_пункта", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 1: //Добавить тип_улицы
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название", "Тип_улицы", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 2: // Заполнение улицы
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название", "Улица", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 3: // Заполнение населенного пункта
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название", "Населенный_пункт", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 4: // Заполнение должности сотрудника
                    dataGridViewListReturner.DataSource = database.ReturnTable("Должность", "Должность", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 5: // Заполнение статуса сотрудника
                    dataGridViewListReturner.DataSource = database.ReturnTable("Статус", "Статус_сотрудника", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 6: // Заполнение адреса
                    dataGridViewListReturner.DataSource = database.ReturnTable("Код", "Адрес", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 7: // Организация
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название", "Организация", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 8: // Подразделение
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название", "Подразделение", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 9: // Рубрика
                    dataGridViewListReturner.DataSource = database.ReturnTable("Рубрика", "Рубрика", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 10: // Сотрудник
                    dataGridViewListReturner.DataSource = database.ReturnTable("Фамилия", "Список_сотрудников", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 11: // Новость
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название_информации", "Новость", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;




            }
            return Temp;
        }
        void TableUpdate()
        {
            DWorks database = new DWorks(Credentials);
            switch (selectedTable)
            {
                case "Тип_населенного_пункта":
                    dataGridView1.DataSource = database.ReturnTable("Название", "Тип_населенного_пункта", null).Tables[0].DefaultView; break;
                case "Тип_улицы":
                    dataGridView1.DataSource = database.ReturnTable("Название", "Тип_улицы", null).Tables[0].DefaultView; break;
                case "Населенный_пункт":
                    dataGridView1.DataSource = database.ReturnTable("Название, Код_типа_нас_пункт", "Населенный_пункт", null).Tables[0].DefaultView; break;
                case "Улица":
                    dataGridView1.DataSource = database.ReturnTable("Название, Код_типа_улицы", "Улица", null).Tables[0].DefaultView; break;
                case "Адрес":
                    dataGridView1.DataSource = database.ReturnTable("Номер_дома, Корпус, Код_улицы, Код_нас_пункт", "Адрес", null).Tables[0].DefaultView; break;
                case "Должность":
                    dataGridView1.DataSource = database.ReturnTable("Должность", "Должность", null).Tables[0].DefaultView; break;
                case "Статус_сотрудника":
                    dataGridView1.DataSource = database.ReturnTable("Статус", "Статус_сотрудника", null).Tables[0].DefaultView; break;
                case "Список_сотрудников":
                    dataGridView1.DataSource = database.ReturnTable("Фамилия, Имя, Отчество, Код_подразделения, Код_должности, Логин, Пароль, Код_статуса, Дата_принятия", "Список_сотрудников", null).Tables[0].DefaultView; break;
                case "Подразделение":
                    dataGridView1.DataSource = database.ReturnTable("Название, Этаж, Код_организации", "Подразделение", null).Tables[0].DefaultView; break;
                case "Организация":
                    dataGridView1.DataSource = database.ReturnTable("Название, Краткое_название, Контактный_телефон, Адрес, Эл_адрес, Адрес_сайта", "Организация", null).Tables[0].DefaultView; break;
                case "Рубрика":
                    dataGridView1.DataSource = database.ReturnTable("Рубрика", "Рубрика", null).Tables[0].DefaultView; break;
                case "Архив":
                    dataGridView1.DataSource = database.ReturnTable("Дата_новости, Код_новости", "Архив", null).Tables[0].DefaultView; break;
                case "Файл":
                    dataGridView1.DataSource = database.ReturnTable("Название, Размер, Тип, Краткое_название, Код_новости", "Файл", null).Tables[0].DefaultView; break;
                case "Новость":
                    dataGridView1.DataSource = database.ReturnTable("Код_рубрики, Название_информации, Текст, Дата_размещения, Дата_перевода_в_архив, Размер_в_Кб, Код_сотрудника", "Новость", null).Tables[0].DefaultView; break;
            }

        }
        #region Нас_пункт
        private void NpktAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            
            listBox1.Items.Add(database.addNaspunkt(NaspTB.Text, GetDirCode("Тип_населенного_пункта", $"{TypenaspCB.SelectedItem.ToString()}", 1)));
            TableUpdate(); ComboUpdates();
        }
        private void NpktEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editNaspunkt(NaspTB.Text, GetDirCode("Тип_населенного_пункта", $"{TypenaspCB.SelectedItem.ToString()}", 1), tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        private void NpktDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delNaspunkt(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region Тип_улицы
        private void TypestraddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addTypestreet(TypestrTB.Text));
            TableUpdate(); ComboUpdates();
        }
        private void TypestrEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editTypestreet(TypestrTB.Text, tempeID)); tempeID = -1; }
            TableUpdate();ComboUpdates();
        }
        private void TypestrDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delTypestreet(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region File
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        #endregion
        #region Адрес
        private void AdressAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addAdress(
                NumHomeTB.Text, KorpusTB.Text,
                GetDirCode("Улица", $"{StreetCB.SelectedItem.ToString()}", 1),
                GetDirCode("Населенный_пункт", $"{NaspCB.SelectedItem.ToString()}", 1)
                //GetDirCode("Организация", $"{OrganizeCB.SelectedItem.ToString()}", 1)
                ));
            TableUpdate(); ComboUpdates();
        }
        private void AdressEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editAdress(NumHomeTB.Text, KorpusTB.Text,
                GetDirCode("Улица", $"{StreetCB.SelectedItem.ToString()}", 1),
                GetDirCode("Населенный_пункт", $"{NaspCB.SelectedItem.ToString()}", 1),
                //GetDirCode("Организация", $"{OrganizeCB.SelectedItem.ToString()}", 1), 
                tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        private void AdressDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delAdress(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region Улица
        private void StrAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addStreet(StreetTB.Text, GetDirCode("Тип_улицы", $"{TypestrCB.SelectedItem.ToString()}", 1)));
            TableUpdate(); ComboUpdates();
        }
        private void StrEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editStreet(StreetTB.Text, GetDirCode("Тип_улицы", $"{TypestrCB.SelectedItem.ToString()}", 1)  ,tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        private void StrDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delStreet(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region Тип_нас_пункт
        private void TypenpaddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addTypenasp(TypenaspTB.Text));
            TableUpdate(); ComboUpdates();
            TypenaspTB.Clear();
        }

        private void TypenaspeditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editTypenasp(TypenaspTB.Text, tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }

        private void TypenaspdelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delTypenasp(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region Dolznost
        private void DolznAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addDolzn(DolznTB.Text));
            TableUpdate(); ComboUpdates();
        }
        private void DolznEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editDolzn(DolznTB.Text, tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }

        private void DolznDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delDolzn(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }

        #endregion
        #region Status
        private void StatusAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addStatusSotr(StatusTB.Text));
            TableUpdate(); ComboUpdates();
        }

        private void StatusEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editStatusSotr(StatusTB.Text, tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }

        private void StatusDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delStatusSotr(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region Sotrudnik
        private void SotrAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addSotrud(
                SurnameTB.Text, NameTB.Text, MiddlenameTB.Text,
                GetDirCode("Подразделение", $"{PodrazdelCB.SelectedItem.ToString()}", 1),
                GetDirCode("Должность", $"{DolznCB.SelectedItem.ToString()}", 1), LogTB.Text, PasswordTB.Text,
                GetDirCode("Статус_сотрудника", $"{StatusCB.SelectedItem.ToString()}", 1), AddSotrDTP.Value
                ));
            TableUpdate(); ComboUpdates();
        }

        private void SotrEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1)
            {
                listBox1.Items.Add(database.editSotrud(SurnameTB.Text, NameTB.Text, MiddlenameTB.Text,
                GetDirCode("Подразделение", $"{PodrazdelCB.SelectedItem.ToString()}", 1),
                GetDirCode("Должность", $"{DolznCB.SelectedItem.ToString()}", 1), LogTB.Text, PasswordTB.Text,
                GetDirCode("Статус_сотрудника", $"{StatusCB.SelectedItem.ToString()}", 1), AddSotrDTP.Value,
                tempeID)); tempeID = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void SotrDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delSotrud(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region Podrazdel
        private void PodrazAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addPodrazdel(PodrazdelTB.Text, FloorTB.Text, GetDirCode("Организация", $"{OrgaCB.SelectedItem.ToString()}", 1)));
            TableUpdate(); ComboUpdates();
        }

        private void PodrazEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editPodrazdel(PodrazdelTB.Text, FloorTB.Text, GetDirCode("Организация", $"{OrgaCB.SelectedItem.ToString()}", 1), tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }

        private void PodrazDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delPodrazdel(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region Organization
        private void OrgAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addOrganization(OrgTB.Text, KratOrgTB.Text, NumPhoneTB.Text, GetDirCode("Адрес", $"{AdressCB.SelectedItem.ToString()}", 0), EmailTB.Text, SiteTB.Text));
            TableUpdate(); ComboUpdates();
        }

        private void OrgEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editOrganization(OrgTB.Text, KratOrgTB.Text, NumPhoneTB.Text, GetDirCode("Адрес", $"{AdressCB.SelectedItem.ToString()}", 0), EmailTB.Text, SiteTB.Text, tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }

        private void OrgDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.deleteOrganization(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region Rubrick
        private void RubrickAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addRubrick(RubrickTB.Text));
            TableUpdate(); ComboUpdates();
        }

        private void RubrickEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editRubrick(RubrickTB.Text, tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }

        private void RubrickDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delRubrick(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region News
        private void NewsAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addNews(
                GetDirCode("Рубрика", $"{RubrickCB.SelectedItem.ToString()}", 1),
                NewsTB.Text, TextTB.Text,
                DateRazmDTP.Value, DateArchiveDTP.Value,
                SizeNTB.Text,
                GetDirCode("Список_сотрудников", $"{SotrudCB.SelectedItem.ToString()}", 1)
                ));
            TableUpdate(); ComboUpdates();
        }

        private void NewsEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1)
            {
                listBox1.Items.Add(database.editNews(GetDirCode("Рубрика", $"{RubrickCB.SelectedItem.ToString()}", 1),
                NewsTB.Text, TextTB.Text,
                DateRazmDTP.Value, DateArchiveDTP.Value,
                SizeNTB.Text,
                GetDirCode("Список_сотрудников", $"{SotrudCB.SelectedItem.ToString()}", 1),
                tempeID)); tempeID = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void NewsDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delNews(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region Archive
        private void ArchiveAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addArchive(NewsDTP.Value, GetDirCode("Новость", $"{NewsCB.SelectedItem.ToString()}", 2)));
            TableUpdate(); ComboUpdates();
        }

        private void ArchiveEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editArchive(NewsDTP.Value, GetDirCode("Новость", $"{NewsCB.SelectedItem.ToString()}", 2), tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }

        private void ArchiveDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delArchive(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion
        #region Fileadd
        private void FileAddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addFile(FileTB.Text, SizeFileTB.Text, TypefTB.Text, KratfTB.Text, GetDirCode("Новость", $"{NewsFArchCB.SelectedItem.ToString()}", 2)));
            TableUpdate(); ComboUpdates();
        }

        private void FileEditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editFile(FileTB.Text, SizeFileTB.Text, TypefTB.Text, KratfTB.Text, GetDirCode("Новость", $"{NewsFArchCB.SelectedItem.ToString()}", 2), tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }

        private void FileDelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.delFile(tempeID)); tempeID = -1; }
            TableUpdate(); ComboUpdates();
        }
        #endregion

        private void Query1_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            dataGridView1.DataSource = database.Query1(DateQuery1DTP.Value).Tables[0].DefaultView;
        }

        private void Query2_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            dataGridView1.DataSource = database.Query2(DateQuery2DTP.Value).Tables[0].DefaultView;
        }
        string[] Months = new string[12]
        {
                "Январь",
                "Февраль",
                "Март",
                "Апрель",
                "Май",
                "Июнь",
                "Июль",
                "Август",
                "Сентябрь",
                "Октябрь",
                "Ноябрь",
                "Декабрь"
        };
        string GetSQLFormatDate(DateTime Date)
        {
            string Temp = string.Empty;
            foreach (char i in Date.ToString("yyyy/MM/dd"))
            {
                if (i != '.')
                {
                    Temp += i;
                }
            }
            return Temp;
        }

        private void Query3_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            chart1.Series.Clear();
            chart1.Series.Add(new Series($"{QueryPodrazCB.SelectedItem}")
            {
                ChartType = SeriesChartType.Column
            });
            dataGridView1.DataSource = database.Query3(QueryPodrazCB.SelectedItem.ToString(), Query3FromDTP.Value, Query3ToDTP.Value).Tables[0].DefaultView;
            int TempCount = 0;
            double CYear;
            for (int i = 0; i < Math.Abs(Query3FromDTP.Value.Year - Query3ToDTP.Value.Year) * 12; i++)
            {
                CYear = Query3FromDTP.Value.Year + Math.Round((double)(i / 12));
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    if(CYear == Convert.ToDateTime(dataGridView1.Rows[j].Cells[1].Value).Year && Convert.ToDateTime(dataGridView1.Rows[j].Cells[1].Value).Month == ((i % 12) + 1))
                    {
                        TempCount++;
                    }
                }
                chart1.Series[$"{QueryPodrazCB.SelectedItem}"].Points.AddXY($"{Months[i % 12]} {CYear}", TempCount);
                TempCount = 0;
            }

        }
    }
}
