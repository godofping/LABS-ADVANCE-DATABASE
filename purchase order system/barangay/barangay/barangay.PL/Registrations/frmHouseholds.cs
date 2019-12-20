using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barangay.PL.Registrations
{
    public partial class frmHouseholds : Form
    {
        public frmHouseholds()
        {
            InitializeComponent();
        }

        private void ShowForm(bool bol)
        {
            pnlMain.Visible = !bol;
            pnlForm.Visible = bol;
        }

        private void frmHouseholds_Load(object sender, EventArgs e)
        {
            ShowForm(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowForm(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }

        
    }
}
