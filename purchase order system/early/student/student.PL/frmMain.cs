using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace student.PL
{
    public partial class frmMain : Form
    {
        frmLogin frmLogin;
        public frmMain(frmLogin _frmLogin)
        {
            InitializeComponent();
            frmLogin = _frmLogin;
        }

        private void sTRANDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Registrations.frmStrands();
            frm.ShowDialog();
        }

        private void rEGISTEREDSTUDENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Registrations.frmRegisteredStudents();
            frm.ShowDialog();
        }

        private void lISTOFREGISTEREDSTUDENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Reports.frmReportRegisteredStudents();
            frm.ShowDialog();
        }

        private void lISTOFPOPULATIONSPERSTRANDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Reports.frmStrandsPopulations();
            frm.ShowDialog();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "ARE YOU SURE LOGOUT?", "LOGGING OUT", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    this.Close();
                    frmLogin.Show();
                    break;
            }
            
        }

        private void aCCOUNTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Registrations.frmAccounts();
            frm.ShowDialog();
        }

      
    }
}
