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
    public partial class MENU_MANAGER : Form
    {
        public MENU_MANAGER()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

   
       

        private void mANAGESTAFFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PL.REGISTRATIONS.frmStaffs();

            var frmContainer = new PL.OTHERS.frmContainer("MANAGE STAFFS", frm);
            frmContainer.ShowDialog();
        }

        private void mANAGECUSTOMERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PL.REGISTRATIONS.frmCustomers();

            var frmContainer = new PL.OTHERS.frmContainer("MANAGE CUSTOMERS", frm);
            frmContainer.ShowDialog();
        }

        private void sTAFFSACCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PL.REGISTRATIONS.frmStaffsAccount();

            var frmContainer = new PL.OTHERS.frmContainer("STAFFS ACCOUNTS", frm);
            frmContainer.ShowDialog();
        }
    }
}
