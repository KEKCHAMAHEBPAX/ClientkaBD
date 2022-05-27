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
    public partial class pohodi : Form
    {
        public pohodi()
        {
            InitializeComponent();
            LoadComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Походы.Код,Походы.Наименование,Сложности.Наименование " +
                                                          "from Походы,Сложности " +
                                                           "Where Походы.Сложность=" + comboBox1.SelectedIndex + "and Сложности.Код=" + comboBox1.SelectedIndex, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void LoadComboBox1()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter($"select * from Виды", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Наименование";
            comboBox2.ValueMember = "Код";

            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter1 = new OleDbDataAdapter($"select * from Сложности", con1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con1.Close();
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "Наименование";
            comboBox1.ValueMember = "Код";

            OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter2 = new OleDbDataAdapter($"select * from Тренеры", con2);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            con2.Close();
            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "ФИО";
            comboBox3.ValueMember = "Код";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Походы.Код,Походы.Наименование,Виды.Наименование " +
                                                          "from Походы,Виды " +
                                                           "Where Походы.Вид=" + comboBox2.SelectedIndex + "and Виды.Код=" + comboBox2.SelectedIndex, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Походы.Код,Походы.Наименование,Тренеры.ФИО " +
                                                          "from Походы,Тренеры " +
                                                           "Where Походы.Инструктор=" + comboBox3.SelectedIndex + "and Тренеры.Код=" + comboBox3.SelectedIndex, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection
           (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Delete from Походы where Код=" + label6.Text, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = dataGridView1[0, e.RowIndex].Value.ToString();
        }
    }
}
