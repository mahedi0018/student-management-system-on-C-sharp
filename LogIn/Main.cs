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
    public partial class Main : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=Mahedi;Initial Catalog=stdb;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public Main()
        {
            InitializeComponent();
        }

        private void btnSAdd_Click(object sender, EventArgs e)
        {
            
            

                cmd = new SqlCommand("insert into StudentData1 (Student_ID, Student_Name) values (@Student_ID, @Student_Name)", cn);
                cn.Open();
                cmd.Parameters.AddWithValue("Student_ID", txtSId.Text);
                cmd.Parameters.AddWithValue("Student_Name", txtSName.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Inserted");
            
            

            

        }

        private void btnSUp_Click(object sender, EventArgs e)
        {


            cn.Open();
            cmd = new SqlCommand("update StudentData1 set Student_Name =@Student_Name where Student_Id =@Student_ID", cn);
            cmd.Parameters.AddWithValue("Student_ID", txtSId.Text);
            cmd.Parameters.AddWithValue("Student_Name", txtSName.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Updated");
        }

        private void btnSDel_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("delete from StudentData1 where Student_Id =@Student_ID", cn);
            cmd.Parameters.AddWithValue("Student_ID", txtSId.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Deleted");
        }

        private void btnLSt_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter(@"SELECT Student_ID, Student_Name FROM StudentData1", cn);
            cn.Open();
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }

        private void btnAddC_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("insert into Course1 (Course_ID, Course_Name) values (@Course_ID, @Course_Name)", cn);
            cn.Open();
            cmd.Parameters.AddWithValue("Course_ID", txtCouID.Text);
            cmd.Parameters.AddWithValue("Course_Name", txtCouN.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Inserted");

        }

        private void btnUpC_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("update Course1 set Course_Name =@Course_Name where Course_Id =@Course_ID", cn);
            cmd.Parameters.AddWithValue("Course_ID", txtCouID.Text);
            cmd.Parameters.AddWithValue("Course_Name", txtCouN.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Updated");
        }

        private void btnDeC_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("delete from Course1 where Course_Id =@Course_ID", cn);
            cmd.Parameters.AddWithValue("Course_ID", txtCouID.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Deleted");
        }

        private void btnLoC_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter(@"SELECT * FROM Course1", cn);
            cn.Open();
            dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            cn.Close();
        }

        private void btnAddT_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into Teacher (Teacher_ID, Teacher_Name) values (@Teacher_ID, @Teacher_Name)", cn);
            cn.Open();
            cmd.Parameters.AddWithValue("Teacher_ID", txtTID.Text);
            cmd.Parameters.AddWithValue("Teacher_Name", txtTN.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Inserted");
        }

        private void btnUpT_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("update Teacher set Teacher_Name =@Teacher_Name where Teacher_Id =@Teacher_ID", cn);
            cmd.Parameters.AddWithValue("Teacher_ID", txtTID.Text);
            cmd.Parameters.AddWithValue("Teacher_Name", txtTN.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Updated");
        }

        private void btnTDel_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("delete from Teacher where Teacher_Id =@Teacher_ID", cn);
            cmd.Parameters.AddWithValue("Teacher_ID", txtTID.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Deleted");
        }

        private void btnLoT_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter(@"SELECT Teacher_ID, Teacher_Name FROM Teacher", cn);
            cn.Open();
            dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            cn.Close();
        }

        private void btnReCT_Click(object sender, EventArgs e)
        {

            da = new SqlDataAdapter("SELECT * FROM Teacher Where Teacher_ID='" + textBox1.Text + "'", cn);
            cn.Open();
            dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            if (dt.Select().Length > 0)
            {
                da = new SqlDataAdapter("SELECT * FROM Course1 Where Course_ID='" + txtCoID.Text + "'", cn);
                cn.Open();
                dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                if (dt.Select().Length > 0)
                {
                    cmd = new SqlCommand("insert into CourseTeacher1 (Registration_ID, Course_ID, Teacher_ID) values (@Registration_ID, @Course_ID, @Teacher_ID)", cn);
                    cn.Open();
                    cmd.Parameters.AddWithValue("Registration_ID", txtRCT.Text);
                    cmd.Parameters.AddWithValue("Course_ID", txtCoID.Text);
                    cmd.Parameters.AddWithValue("Teacher_ID", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Inserted");
                }
                else
                {
                    MessageBox.Show("Course ID NOt Found");
                }

            }
            else
            {
                MessageBox.Show("Teacher ID NOt Found");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter(@"SELECT StudentData1.Student_ID, Customers.CustomerName, Orders.OrderDate
            FROM Orders
            INNER JOIN Customers
            ON Orders.CustomerID=Customers.CustomerID;", cn);
            cn.Open();
            dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            cn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            da = new SqlDataAdapter(@"SELECT Teacher_ID, Teacher_Name FROM Teacher", cn);
            cn.Open();
            dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            cn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter(@"SELECT * FROM Course1", cn);
            cn.Open();
            dt = new DataTable();
            da.Fill(dt);
            dataGridView6.DataSource = dt;
            cn.Close();
        }

        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView5.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                break;
            }
        }

        private void dataGridView6_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView6.SelectedRows)
            {
                txtCoID.Text = row.Cells[0].Value.ToString();
                break;
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btnLCT_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter(@"SELECT * FROM CourseTeacher1", cn);
            cn.Open();
            dt = new DataTable();
            da.Fill(dt);
            dataGridView7.DataSource = dt;
            cn.Close();
        }

        private void btnUpCT_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("update CourseTeacher1 set Course_ID =@Course_ID, Teacher_ID =@Teacher_ID where Registration_ID =@Registration_ID", cn);
            cmd.Parameters.AddWithValue("Registration_ID", txtRCT.Text);
            cmd.Parameters.AddWithValue("Course_ID", txtCoID.Text);
            cmd.Parameters.AddWithValue("Teacher_ID", textBox1.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Updated");

        }

        private void btnDeCT_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("delete from CourseTeacher1 where Registration_ID =@Registration_ID", cn);
            cmd.Parameters.AddWithValue("Registration_ID", txtRCT.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Deleted");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dbcon = new DataClasses1DataContext();
            var prod = from n in dbcon.StudentData1s
                       select new { n.Student_ID, n.Course1.Course_ID, n.Course1.Course_Name };

            dataGridView9.DataSource = prod;
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView9.CurrentCell != null && dataGridView9.CurrentCell.ColumnIndex == 0)
                textBox5.Text = dataGridView9.CurrentCell.Value.ToString();
            else if (dataGridView9.CurrentCell != null && dataGridView9.CurrentCell.ColumnIndex == 1)
                textBox6.Text += dataGridView9.CurrentCell.Value.ToString() + ",";

        }

        private void btnRsc_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(textBox2.Text);
            da = new SqlDataAdapter("SELECT * FROM StudentData1 Where Student_ID='" + textBox5.Text + "'", cn);
            cn.Open();
            dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            if (dt.Select().Length > 0)
            {
                String course = textBox6.Text;
                String[] courses=course.Split(',');
                foreach (String id in courses) {
                if (id.CompareTo("") == 0) { continue; }
                da = new SqlDataAdapter("SELECT * FROM Course1 Where Course_ID='" + id + "'", cn);
                cn.Open();
                dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                if (dt.Select().Length > 0)
                {
                    cmd = new SqlCommand("insert into Registration (Registration_ID, Student_ID, Course_ID) values (@Registration_ID, @Student_ID, @Course_ID)", cn);
                    cn.Open();
                    cmd.Parameters.AddWithValue("Registration_ID", i);
                    cmd.Parameters.AddWithValue("Student_ID", textBox5.Text);
                    cmd.Parameters.AddWithValue("Course_ID", id);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    i++;
                    MessageBox.Show("Inserted course: " + id + " for student id: " + textBox5.Text);
                }
                else
                {
                    MessageBox.Show("course: " + id + " not found");
                }
            }

            }

            else
            {
                MessageBox.Show("Student ID Not Found");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            da = new SqlDataAdapter(@"SELECT Registration_ID, Student_ID, Course_ID FROM Registration", cn);
            cn.Open();
            dt = new DataTable();
            da.Fill(dt);
            dataGridView8.DataSource = dt;
            cn.Close();
        }

        private void btnUsc_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("update Registration set Course_ID =@Course_ID, Student_ID =@Student_ID where Registration_ID =@Registration_ID", cn);
            cmd.Parameters.AddWithValue("Registration_ID", textBox2.Text);
            cmd.Parameters.AddWithValue("Student_ID", textBox5.Text);
            cmd.Parameters.AddWithValue("Course_ID", textBox6.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Updated");
        }

        private void btnDsc_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("delete from Registration where Registration_ID =@Registration_ID", cn);
            cmd.Parameters.AddWithValue("Registration_ID", textBox2.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Deleted");
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}