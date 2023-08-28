using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost\\MSSQLSERVER01;Initial Catalog=ListTry;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            conn.Open();

            string query = "SELECT * FROM Users"; 
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
