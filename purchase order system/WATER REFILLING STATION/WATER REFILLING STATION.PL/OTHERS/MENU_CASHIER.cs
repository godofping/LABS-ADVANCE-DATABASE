using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.OTHERS
{
    public partial class MENU_CASHIER : Form
    {
        login login;
        public MENU_CASHIER(login _login)
        {
            InitializeComponent();
            login = _login;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure to logout?", "Logging out", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    login.LogOut();
                    break;
            }
        }

        private void nEWTRANSACTIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PL.TRANSACTIONS.frmNewOrder();

            var frmContainer = new PL.OTHERS.frmCommon("NEW ORDER", frm);
            frmContainer.ShowDialog();
        }
    }
}
