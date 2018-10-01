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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;database=menshoe");
            conn.Open();

            // Get values enetered by user
            string fullname = textBox1.Text;
            string username = textBox2.Text;
            string email = textBox3.Text;
            string password = textBox4.Text;

            // check if account exists
            MySqlCommand cmdExists = new MySqlCommand("SELECT COUNT(*) FROM signup WHERE username='" + username + "' AND email='" + email + "'", conn);
            Int64 exists = (Int64)cmdExists.ExecuteScalar();

            // create account if it doesn't exist
            if (exists == 0)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO signup VALUES ('" + fullname + "', '" + username + "', '" + email + "', '" + password + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account Creation Successful");
                this.Hide();
                Home hm = new Home();
                hm.Show();
            }
            else
            {
                MessageBox.Show("Account exists already");
                this.Hide();
                SignIn login = new SignIn();
                login.Show();
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn sIn = new SignIn();
            sIn.Show();
        }
    }
}
