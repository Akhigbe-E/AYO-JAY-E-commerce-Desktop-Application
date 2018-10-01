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
    public partial class Nike : Form
    {
        public Nike()
        {
            InitializeComponent();
        }
        void AddToCart(string id)
        {
            string itemName = "";
            int unitPrice = 0;
            int quantity = 1;
            
            if (id == "1")
            {
                itemName = label4.Text;
                unitPrice = int.Parse(label7.Text.Substring(1).Split('.')[0]);
                
            }
            if (id == "2")
            {
                itemName = label5.Text;
                unitPrice = int.Parse(label8.Text.Substring(1).Split('.')[0]);
                
            }
            if (id == "3")
            {
                itemName = label6.Text;
                unitPrice = int.Parse(label9.Text.Substring(1).Split('.')[0]);
                
            }

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;database=menshoe";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            MySqlCommand commandUsername = new MySqlCommand("SELECT COUNT(*) FROM cart WHERE item='" + itemName + "'", databaseConnection);
            Int64 countUsername = (Int64)commandUsername.ExecuteScalar();
            if (countUsername == 0)
            {
                string addCart = "INSERT INTO cart VALUES('" + itemName + "','" + quantity + "', '" + unitPrice + "')";
                MySqlCommand commandAddtoCart = new MySqlCommand(addCart, databaseConnection);
                commandAddtoCart.ExecuteNonQuery();
            }
            else
            {
                string incrQuantity = "UPDATE cart SET quantity = quantity + 1 WHERE item = '" + itemName + "'";
                MySqlCommand commandIncrQuant = new MySqlCommand(incrQuantity, databaseConnection);
                commandIncrQuant.ExecuteNonQuery();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Nike_Load(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddToCart("1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddToCart("1");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddToCart("2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddToCart("2");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddToCart("3");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddToCart("3");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cart crt = new Cart();
            crt.Show();
        }
    }
}
