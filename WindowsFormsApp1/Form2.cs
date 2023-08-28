using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=localhost\\MSSQLSERVER01;Initial Catalog=ListTry;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Users", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand add = new SqlCommand("insert into Users(Name,Surname,Role) values (@p1,@p2,@p3)", conn);
            add.Parameters.AddWithValue("@p1", textBox1.Text);
            add.Parameters.AddWithValue("@p2", textBox2.Text);
            add.Parameters.AddWithValue("@p3", textBox3.Text);

            add.ExecuteNonQuery();
            conn.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand delete = new SqlCommand("Delete From Users where Name=@name", conn);
            delete.Parameters.AddWithValue("@name", textBox1.Text);
            delete.ExecuteNonQuery();
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;

            string name = dataGridView1.Rows[chosen].Cells[1].Value.ToString();

            string surname = dataGridView1.Rows[chosen].Cells[2].Value.ToString();

            string role = dataGridView1.Rows[chosen].Cells[3].Value.ToString();

            textBox1.Text = name;

            textBox2.Text = surname;

            textBox3.Text = role;


        }

        private void Edit_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand edit = new SqlCommand("UPDATE Users SET Name=@p1, Surname=@p2, Role=@p3 WHERE Name=@p4", conn);
            edit.Parameters.AddWithValue("@p1", textBox1.Text);
            edit.Parameters.AddWithValue("@p2", textBox2.Text);
            edit.Parameters.AddWithValue("@p3", textBox3.Text);

            edit.ExecuteNonQuery();
            conn.Close();


        }
    }
}
