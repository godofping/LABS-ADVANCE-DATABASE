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
        BL.Transactions.transactions transactionBL = new BL.Transactions.transactions();

        public frmMain()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void GetInformations()
        {
            lblTodaySalesValue.Text = methods.ConvertToMoneyFormat(Convert.ToInt32(transactionBL.TodaySales(DateTime.Now.ToString("yyyy-MM-dd")).Rows[0]["SALES"].ToString()));
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
            GetInformations();
        }


        private void label3_Click(object sender, EventArgs e)
        {
            var pnl = new Registrations.frmCustomers();
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

        private void lblNewTransaction_Click(object sender, EventArgs e)
        {
            var pnl = new Transactions.frmNewTransaction();
            pnl.ShowDialog();
        }

        private void lblTransactions_Click(object sender, EventArgs e)
        {
            var pnl = new Transactions.frmTransactions();
            pnl.ShowDialog();
        }

        private void lblDailySales_Click(object sender, EventArgs e)
        {
            var pnl = new Transactions.frmRerportDailySales();
            pnl.ShowDialog();
        }

        private void lblInventory_Click(object sender, EventArgs e)
        {
            var pnl = new Transactions.frmReportInventory();
            pnl.ShowDialog();
        }
    }
}
