using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datkagridik
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
            LoadComboBox();

        }

        private void LoadComboBox()
            {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter($"select * from Походный", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Наименование";
            comboBox2.ValueMember = "Код";

            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter1 = new OleDbDataAdapter($"select * from Пол", con1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con1.Close();
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "Наименование";
            comboBox1.ValueMember = "Код";

            OleDbConnection con3 = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter3 = new OleDbDataAdapter($"select * from Секции", con3);
            DataTable dt3 = new DataTable();
            adapter3.Fill(dt3);
            con3.Close();
            comboBox3.DataSource = dt3;
            comboBox3.DisplayMember = "Наименование";
            comboBox3.ValueMember = "Код";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Тренеры.Код,Тренеры.ФИО,Тренеры.Зарплата,Пол.Наименование " +
                                                          "from Тренеры,Пол " +
                                                           "Where Тренеры.Пол=" + comboBox1.SelectedIndex + "and Пол.Код=" + comboBox1.SelectedIndex, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Тренеры.Код,Тренеры.ФИО,Походный.Наименование " +
                                                          "from Тренеры,Походный " +
                                                           "Where Тренеры.Походный_профессионализм=" + comboBox2.SelectedIndex + "and Походный.Код=" + comboBox2.SelectedIndex, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Тренеры.Код,Тренеры.ФИО,Секции.Наименование " +
                                                          "from Тренеры,Секции " +
                                                           "Where Тренеры.Секция=" + comboBox3.SelectedIndex + "and Секции.Код=" + comboBox3.SelectedIndex, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Text = dataGridView1[0, e.RowIndex].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection
           (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Delete from Тренеры where Код=" + label5.Text, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            Close();
        }
    }
}
