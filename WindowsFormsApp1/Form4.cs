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
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost\\MSSQLSERVER01;Initial Catalog=ListTry;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            conn.Open();

            string query = "SELECT * FROM Users";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string surname = reader["Surname"].ToString();
                string role = reader["Role"].ToString();

                string userLine = $"{name} {surname} - {role}";
                listBox1.Items.Add(name);
            }

            reader.Close();

            conn.Close();
        }
    }
}
