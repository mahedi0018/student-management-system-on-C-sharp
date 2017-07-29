using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LogIn
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(@"Data Source=Mahedi;Initial Catalog=stdb;Integrated Security=True");
            SqlDataAdapter sqld = new SqlDataAdapter("Select Count(*) FROM Login where Username='"+ textBox1.Text +" ' and Password ='" + textBox2.Text +"'", sql);
            DataTable dt = new DataTable();
            sqld.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Main ss = new Main();
                ss.Show();
            }
            else {
                MessageBox.Show("Please cheack your Username and Password");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
