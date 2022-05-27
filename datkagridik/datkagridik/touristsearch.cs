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
    public partial class touristsearch : Form
    {
        public touristsearch()
        {
            InitializeComponent();

                    LoadComboBox1();

        }

        private void LoadComboBox1()
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

            OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter2 = new OleDbDataAdapter($"select * from Профессионализм", con2);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            con2.Close();
            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "Наименование";
            comboBox3.ValueMember = "Код";

            OleDbConnection con3 = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter3 = new OleDbDataAdapter($"select * from Секции", con3);
            DataTable dt3 = new DataTable();
            adapter3.Fill(dt3);
            con3.Close();
            comboBox4.DataSource = dt3;
            comboBox4.DisplayMember = "Наименование";
            comboBox4.ValueMember = "Код";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox4.SelectedIndex.ToString());
            //$"select ФИО from Туристы WHERE Секция=" + comboBox4.SelectedIndex
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Туристы.ID_Tur,Туристы.ФИО,Секции.Наименование " +
                                                          "from Туристы,Секции " +
                                                           "Where Туристы.Секция=" + comboBox4.SelectedIndex + "and Секции.Код=" + comboBox4.SelectedIndex, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Туристы.ID_Tur,Туристы.ФИО,Походный.Наименование " +
                                                          "from Туристы,Походный " +
                                                           "Where Туристы.Уровень_походного_профессионализма=" + comboBox2.SelectedIndex + "and Походный.Код=" + comboBox2.SelectedIndex, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Туристы.ID_Tur,Туристы.ФИО,Пол.Наименование " +
                                                          "from Туристы,Пол " +
                                                           "Where Туристы.Пол=" + comboBox1.SelectedIndex + "and Пол.Код=" + comboBox1.SelectedIndex, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Туристы.ID_Tur,Туристы.ФИО,Профессионализм.Наименование " +
                                                          "from Туристы,Профессионализм " +
                                                           "Where Туристы.Уровень_профессионализма=" + comboBox3.SelectedIndex + "and Профессионализм.Код=" + comboBox3.SelectedIndex, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection
           (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Delete from Туристы where ID_Tur=" + label6.Text, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = dataGridView1[0, e.RowIndex].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection
           (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("insert into Туристы (ФИО,Уровень_профессионализма,Уровень_походного_профессионализма,Секция,Пол) " +
                                                            $"values ('{textBox1.Text}',{comboBox3.SelectedIndex},{comboBox2.SelectedIndex},{comboBox4.SelectedIndex},{comboBox1.SelectedIndex})", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            Close();
        }
    }
}
