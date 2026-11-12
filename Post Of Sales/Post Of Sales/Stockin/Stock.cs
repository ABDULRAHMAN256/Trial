using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Post_Of_Sales.Stockin
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (New_Stock ns = new New_Stock())
            {
                ns.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (New_Stock ns = new New_Stock())
            {
                ns.IsUpdate = true;
                ns.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (New_Order ord = new New_Order())
            {
                ord.ShowDialog();
            }
        }
    }
}
