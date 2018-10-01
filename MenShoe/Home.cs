using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenShoe
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nike nk = new Nike();
            nk.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adidas adid = new Adidas();
            adid.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewBalance nbl = new NewBalance();
            nbl.Show();
        }
    }
}
