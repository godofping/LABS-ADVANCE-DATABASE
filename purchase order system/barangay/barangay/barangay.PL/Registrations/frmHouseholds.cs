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
        EL.Registrations.Households householdEL = new EL.Registrations.Households();

        BL.Registrations.Households householdBL = new BL.Registrations.Households();

        string s = "";

        public frmHouseholds()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            methods.ClearTXT(txtHousehold, txtHouseholdNumber);
        }

        private void DGVPopulate()
        {
            methods.LoadDGV(dgv, householdBL.List(txtSearch.Text));
        }

        private void DGVManage()
        {
            DGVPopulate();
            methods.DGVTheme(dgv);
            methods.DGVBUTTONAddEdit(dgv);
        }

        private void ShowForm(bool bol)
        {
            pnlMain.Visible = !bol;
            pnlForm.Visible = bol;
        }

        private void frmHouseholds_Load(object sender, EventArgs e)
        {
            DGVManage();
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
