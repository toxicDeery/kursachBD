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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
                case 0: { dataGridView1.DataSource = tet.dataSet("*", "Адрес", null).Tables[0].DefaultView; break; }
                case 1: { dataGridView1.DataSource = tet.dataSet("*", "Улица", null).Tables[0].DefaultView; break; }
                case 2: { dataGridView1.DataSource = tet.dataSet("*", "Тип_улицы", null).Tables[0].DefaultView; break; }
                case 3: { dataGridView1.DataSource = tet.dataSet("*", "Населенный_пункт", null).Tables[0].DefaultView; break; }
                case 4: { dataGridView1.DataSource = tet.dataSet("*", "Тип_населенного_пункта", null).Tables[0].DefaultView; break; }
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
                case 0: { dataGridView1.DataSource = tet.dataSet("*", "Организация", null).Tables[0].DefaultView; break; }
                case 1: { dataGridView1.DataSource = tet.dataSet("*", "Подразделение", null).Tables[0].DefaultView; break; }
                case 2: { dataGridView1.DataSource = tet.dataSet("*", "Список_сотрудников", null).Tables[0].DefaultView; break; }
                case 3: { dataGridView1.DataSource = tet.dataSet("*", "Статус_сотрудника", null).Tables[0].DefaultView; break; }
                case 4: { dataGridView1.DataSource = tet.dataSet("*", "Должность", null).Tables[0].DefaultView; break; }
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
                case 0: { dataGridView1.DataSource = tet.dataSet("*", "Новость", null).Tables[0].DefaultView; break; }
                case 1: { dataGridView1.DataSource = tet.dataSet("*", "Рубрика", null).Tables[0].DefaultView; break; }
                case 2: { dataGridView1.DataSource = tet.dataSet("*", "Архив", null).Tables[0].DefaultView; break; }
                case 3: { dataGridView1.DataSource = tet.dataSet("*", "Файл", null).Tables[0].DefaultView; break; }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
