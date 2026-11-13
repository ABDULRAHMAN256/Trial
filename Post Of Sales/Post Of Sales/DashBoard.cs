using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Post_Of_Sales
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void addNewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplier.Supplier sp = new Supplier.Supplier();
            sp.MdiParent = DashBoard.ActiveForm;
            sp.Show();

        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock stk = new Stock();
            stk.MdiParent = DashBoard.ActiveForm;
            stk.Show();

        }

    }
}
