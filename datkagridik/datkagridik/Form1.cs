using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace datkagridik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Тренеры.Код, Тренеры.ФИО, Пол.Наименование, Походный.Наименование, Тренеры.Зарплата, Секции.Наименование " +
                                                          "from Тренеры,Пол,Походный,Секции " +
                                                           "Where Тренеры.Пол=Пол.Код" + " and Тренеры.Походный_профессионализм=Походный.Код" + " and Тренеры.Секция=Секции.Код", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void trstsrch_Click(object sender, EventArgs e)
        {
            touristsearch form = new touristsearch();
            form.ShowDialog();
        }
        private void trnrsrch_Click(object sender, EventArgs e)
        {
            add form = new add();
            form.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            //OleDbDataAdapter adapter = new OleDbDataAdapter($"select * from Туристы", con);
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Туристы.ID_Tur, Туристы.ФИО, Пол.Наименование, Походный.Наименование, Профессионализм.Наименование " +
                                                          "from Туристы,Пол,Походный,Профессионализм " +
                                                           "Where Туристы.Пол=Пол.Код"  + " and Туристы.Уровень_походного_профессионализма=Походный.Код"+ " and Туристы.Уровень_профессионализма=Профессионализм.Код", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source= erwin.accdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select Походы.Код, Походы.Наименование, Виды.Наименование, Сложности.Наименование, Тренеры.ФИО " +
                                                          "from Походы,Тренеры,Сложности,Виды " +
                                                           "Where Походы.Вид=Виды.Код" + " and Походы.Сложность=Сложности.Код" + " and Походы.Инструктор=Тренеры.Код", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pohodi form = new pohodi();
            form.ShowDialog();
        }
    }
}
