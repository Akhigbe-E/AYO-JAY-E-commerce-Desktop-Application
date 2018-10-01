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
using System.IO;

namespace MenShoe
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;database=menshoe");
            conn.Open();

            // Get values enetered by user
            string username = textBox1.Text;
            string password = textBox2.Text;
            string passFromDatabase = "";

            // ensure valid input is entered and retreive password from database
            if (username != "" && password != "")
            {
                MySqlCommand command = new MySqlCommand("SELECT password FROM signup WHERE username='" + username + "'", conn);
                passFromDatabase = (string)command.ExecuteScalar();
            }
            else
            {
                MessageBox.Show("Fill in all fields");
            }

            // Authenticate password
            if (password == passFromDatabase)
            {
                // file to hold current user
                using (StreamWriter fileStr = File.CreateText("CurrentUser.txt"))
                {
                    fileStr.Write(username);
                }
                // show store page
                this.Hide();
                Home hmFr = new Home();
                hmFr.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            conn.Close();
        }
    }
}
