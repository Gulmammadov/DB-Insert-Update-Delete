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

namespace _20171214Win_Db_InsertUpdateDelete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\TMS.accdb;Persist Security Info=False;";

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "";
            OleDbConnection conn = new OleDbConnection(connectionString);
            if (textBox1.Text =="")
            {
                sorgu = "Select * from telebe";
            }
            else
            {
                sorgu = string.Format("Select * from telebe where Adi='{0}'",textBox1.Text);
            }
            OleDbCommand cmd = new OleDbCommand(sorgu,conn);
            DataTable dt = new DataTable();     
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "";
            OleDbConnection conn = new OleDbConnection(connectionString);

            sorgu = string.Format("Insert into telebe (Adi, Soyadi, Bali, TelebeNomresi) values('{0}','{1}','{2}','{3}')",txtAdi.Text,txtSoyadi.Text,txtBali.Text,txtTNomresi.Text);
            OleDbCommand cmd = new OleDbCommand(sorgu, conn);
            DataTable dt = new DataTable();
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            button1_Click(null,null);
        }


    }
}
