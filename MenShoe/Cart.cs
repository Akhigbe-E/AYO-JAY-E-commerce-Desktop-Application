using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MenShoe
{
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
        }
        string connectionString = "datasource=127.0.0.1; port=3306;username=root;password=;database=menshoe";

        private void Cart_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connect = new MySqlConnection(connectionString))
            {
                connect.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT* FROM cart", connect);
                DataTable dtlTa = new DataTable();
                sqlDa.Fill(dtlTa);
                dataGridView1.DataSource = dtlTa;
                connect.Close();
            }
          }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CheckOut chkOut = new CheckOut();
            chkOut.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT* FROM cart", sqlCon);
                DataTable dtlTa = new DataTable();
                sqlDa.Fill(dtlTa);
                dataGridView1.DataSource = dtlTa;
                sqlCon.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.Show();
        }
    }
}

