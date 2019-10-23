using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos
{
    public partial class frmMenu : Form
    {
        BL.Registrations.Accounts accountBL = new BL.Registrations.Accounts();

        EL.Registrations.Accounts accountInfo;

        frmLogin frmLogin;

        public frmMenu(frmLogin FrmLogin,EL.Registrations.Accounts AccountInfo)
        {
            InitializeComponent();

            frmLogin = FrmLogin;
            accountInfo = AccountInfo;
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    frmLogin.Close();
                    break;
            }
        }

        private void btnSupplies_Click(object sender, EventArgs e)
        {
            Registrations.Supplies.frmSupplies frmSupplies = new Registrations.Supplies.frmSupplies();
            frmSupplies.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            Registrations.Suppliers.frmSuppliers frmSuppliers = new Registrations.Suppliers.frmSuppliers();
            frmSuppliers.ShowDialog();
        }

        private void btnPurchaseOrders_Click(object sender, EventArgs e)
        {
            Transactions.Purchase_Orders.frmPurchaseOrders frmPurchaseOrders = new Transactions.Purchase_Orders.frmPurchaseOrders();
            frmPurchaseOrders.ShowDialog();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            Registrations.Accounts.frmAccounts frmAccounts = new Registrations.Accounts.frmAccounts();
            frmAccounts.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure you want to logout?", "Logging out", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    this.Hide();
                    frmLogin.Show();
                    break;
            }            
        }

   

    }
}
