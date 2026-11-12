using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Post_Of_Sales.Supplier
{
    public partial class Add_New__Supplier : Form
    {
        public Add_New__Supplier()
        {
            InitializeComponent();
        }
        public bool isupdate;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Add_New__Supplier_Load(object sender, EventArgs e)
        {
            if (isupdate)
            {
                btnsave.Text = "Update";
                label1.Text = "Update Supplier Details";
            }
        }
    }
}
