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
        }
        string Credentials =
            @"Server = localhost\SQLExpress;" +
            "Integrated security = SSPI;"+
            "database = kurs;";
        int tempeID = -1;
        string selectedTable;
        int tempStudID = -1;

        #region Тип_нас_пункт
        private void TypenpaddBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            listBox1.Items.Add(database.addTypenasp(TypenaspTB.Text));
        }

        private void TypenaspeditBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != -1) { listBox1.Items.Add(database.editTypenasp(TypenaspTB.Text, tempeID)); tempeID = -1; } 
        }

        private void TypenaspdelBTN_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            if (tempeID != 1) { listBox1.Items.Add(database.delTypenasp(tempeID)); tempeID = -1; }
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
                case "Населенный_пункт": break;
                case "Тип_улицы": break;
                case "Улица": break;
                case "Адрес": break;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1: tab3(); break;
                case 0: tab0(); break;
                case 2: tab4(); break;
            }
        }
     

        void tab3()
        {
            DWorks tet = new DWorks(Credentials);
            switch (tabControl3.SelectedIndex)
            {
                case 0: { selectedTable = "Адрес"; dataGridView1.DataSource = tet.dataSet("Номер_дома, Корпус", "Адрес", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Адрес", null).Tables[0].DefaultView; break; }
                case 1: { selectedTable = "Улица"; dataGridView1.DataSource = tet.dataSet("Название", "Улица", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Улица", null).Tables[0].DefaultView; break; }
                case 2: { selectedTable = "Тип_улицы"; dataGridView1.DataSource = tet.dataSet("Название", "Тип_улицы", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Тип_улицы", null).Tables[0].DefaultView; break; }
                case 3: { selectedTable = "Населенный_пункт"; dataGridView1.DataSource = tet.dataSet("Название", "Населенный_пункт", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Населенный_пункт", null).Tables[0].DefaultView; break; }
                case 4: { selectedTable = "Тип_населенного_пункта"; dataGridView1.DataSource = tet.dataSet("Название", "Тип_населенного_пункта", null).Tables[0].DefaultView; dataGridView2.DataSource = tet.dataSet("*", "Тип_населенного_пункта", null).Tables[0].DefaultView; break; }
            }
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tab3();
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

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
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
    }
}
