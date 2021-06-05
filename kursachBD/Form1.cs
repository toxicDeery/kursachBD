using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //int tempStudID = -1;

        #region Тип_нас_пункт
        private void TypenpaddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addTypenasp(TypenaspTB.Text));
            TableUpdate(); ComboUpdates();
        }

        private void TypenaspeditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editTypenasp(TypenaspTB.Text, tempeID)); tempeID = -1; }
            TableUpdate();
        }

        private void TypenaspdelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != 1) { listBox1.Items.Add(database.delTypenasp(tempeID)); tempeID = -1; }
            TableUpdate();
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tempeID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            switch (selectedTable)
            {
                case "Тип_населенного_пункта": TypenaspTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); break;
                case "Населенный_пункт": NaspTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); NaspCB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); break;
                case "Тип_улицы": break;
                case "Улица": break;
                case "Адрес": break;
                
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
                case 1: { selectedTable = "Подразделение"; dataGridView1.DataSource = tet.dataSet("Название, Этаж", "Подразделение", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Подразделение", null).Tables[0].DefaultView; break; }
                case 2: { selectedTable = "Список_сотрудников"; dataGridView1.DataSource = tet.dataSet("Фамилия, Имя, Отчество", "Список_сотрудников", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Список_сотрудников", null).Tables[0].DefaultView; break; }
                case 3: { selectedTable = "Статус_сотрудника"; dataGridView1.DataSource = tet.dataSet("Статус", "Статус_сотрудника", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Статус_сотрудника", null).Tables[0].DefaultView; break; }
                case 4: { selectedTable = "Должность"; dataGridView1.DataSource = tet.dataSet("Должность", "Должность", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Должность", null).Tables[0].DefaultView; break; }
            }
        }        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tab3();
        }
        void tab3()
        {
            DWorks tet = new DWorks(Credentials);
            switch (tabControl3.SelectedIndex)
            {
                case 0: { selectedTable = "Адрес"; dataGridView1.DataSource = tet.dataSet("Номер_дома, Корпус, Код_улицы, Код_нас_пункт, Код_организации", "Адрес", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Адрес", null).Tables[0].DefaultView; break; }
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
                case 0: { selectedTable = "Новость"; dataGridView1.DataSource = tet.dataSet("Название_информации, Текст, Дата_размещения, Дата_перевода_в_архив, Размер_в_Кб", "Новость", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Новость", null).Tables[0].DefaultView; break; }
                case 1: { selectedTable = "Рубрика"; dataGridView1.DataSource = tet.dataSet("Рубрика", "Рубрика", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Рубрика", null).Tables[0].DefaultView; break; }
                case 2: { selectedTable = "Архив"; dataGridView1.DataSource = tet.dataSet("Дата_новости", "Архив", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Архив", null).Tables[0].DefaultView; break; }
                case 3: { selectedTable = "Файл"; dataGridView1.DataSource = tet.dataSet("Название, Размер, Тип", "Файл", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Файл", null).Tables[0].DefaultView; break; }
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
            foreach(string i in BufferListUpdate(0))
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

        }
        private void NpktDelBTN_Click(object sender, EventArgs e)
        {

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

        }
        private void TypestrDelBTN_Click(object sender, EventArgs e)
        {

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

        }
        private void AdressDelBTN_Click(object sender, EventArgs e)
        {

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

        }
        private void StrDelBTN_Click(object sender, EventArgs e)
        {

        }




        #endregion

        
    }
}
