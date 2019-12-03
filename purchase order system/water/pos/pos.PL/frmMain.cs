using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.PL
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Transactions.frmOrders frm = new Transactions.frmOrders();
            frm.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Registrations.frmCustomers frm = new Registrations.frmCustomers();
            frm.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Registrations.frmProducts frm = new Registrations.frmProducts();
            frm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Transactions.frmReports frm = new Transactions.frmReports();
            frm.ShowDialog();
        }
    }
}
