using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos.PL
{
    public partial class frmMain : Form
    {
        BL.Registrations.products productBL = new BL.Registrations.products();
        BL.Registrations.customers customerBL = new BL.Registrations.customers();


        public frmMain()
        {
            InitializeComponent();
        }

        private void GetInformations()
        {
            lblTotalCustomersValue.Text = customerBL.List("").Rows.Count.ToString();
            lblTotalProductsValue.Text = productBL.List("").Rows.Count.ToString();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timerDate.Start();
            GetInformations();
        }

        private void timerDate_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt");
        }


        private void label3_Click(object sender, EventArgs e)
        {
            var pnl = new Registrations.frmCustomers();
            pnl.ShowDialog();
        }

        private void lblTransactions_Click(object sender, EventArgs e)
        {
            var pnl = new Transactions.frmNewTransaction();
            pnl.ShowDialog();
        }

        private void lblProducts_Click(object sender, EventArgs e)
        {
            var pnl = new Registrations.frmProducts();
            pnl.ShowDialog();
        }

        private void lblCategories_Click(object sender, EventArgs e)
        {
            var pnl = new Registrations.frmCategories();
            pnl.ShowDialog();
        }

        private void lblReports_Click(object sender, EventArgs e)
        {

        }
    }
}
