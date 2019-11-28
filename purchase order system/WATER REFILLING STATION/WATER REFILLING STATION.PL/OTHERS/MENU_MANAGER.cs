using System;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.OTHERS
{
    public partial class MENU_MANAGER : Form
    {
        login login;
        public MENU_MANAGER(login _login)
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




        private void mANAGESTAFFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PL.REGISTRATIONS.frmStaffs();

            var frmContainer = new PL.OTHERS.frmCommon("MANAGE STAFFS", frm);
            frmContainer.ShowDialog();
        }

        private void mANAGECUSTOMERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PL.REGISTRATIONS.frmCustomers();

            var frmContainer = new PL.OTHERS.frmCommon("MANAGE CUSTOMERS", frm);
            frmContainer.ShowDialog();
        }

        private void sTAFFSACCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PL.REGISTRATIONS.frmStaffsAccount();

            var frmContainer = new PL.OTHERS.frmCommon("MANAGE STAFFS ACCOUNTS", frm);
            frmContainer.ShowDialog();
        }

        private void mANAGEPARTICULARSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PL.REGISTRATIONS.frmParticulars();

            var frmContainer = new PL.OTHERS.frmCommon("MANAGE PARTICULARS", frm);
            frmContainer.ShowDialog();
        }

        private void mANAGECONTAINERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PL.REGISTRATIONS.frmContainerTypes();

            var frmContainer = new PL.OTHERS.frmCommon("MANAGE CONTAINER TYPES", frm);
            frmContainer.ShowDialog();
        }

        private void mANAGEPRODUCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PL.REGISTRATIONS.frmProducts();

            var frmContainer = new PL.OTHERS.frmCommon("MANAGE PRODUCTS", frm);
            frmContainer.ShowDialog();
        }
    }
}
