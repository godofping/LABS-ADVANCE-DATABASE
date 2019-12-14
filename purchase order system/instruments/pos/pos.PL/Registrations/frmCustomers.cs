using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmCustomers : Form
    {
        EL.Registrations.customers customerEL = new EL.Registrations.customers();

        BL.Registrations.customers customerBL = new BL.Registrations.customers();

        string s = "";

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            methods.ClearTXT(txtFullName,txtContactNumber);
        }

        private void PopulateDGV()
        {
            dgv.DataSource = customerBL.List(txtSearch.Text);
        }

        private void ManageDGV()
        {
            methods.DGVBUTTONAddEdit(dgv);
            PopulateDGV();
            methods.DGVHiddenColumns(dgv, "C");
            methods.DGVTheme(dgv);
            methods.DGVFillWeights(dgv, new string[] { "CUSTOMER ID", "FULL NAME", "CONTACT NUMBER" }, new int[] { 20, 50, 30 });
        }

        private void ShowForm(bool bol)
        {
            ResetForm();
            pnlAddEdit.Visible = bol;
            pnlMain.Visible = !bol;
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("SUCCESS");
                ShowForm(false);
                PopulateDGV();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            ShowForm(false);
            ManageDGV();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            lblTitle.Text = "ADD CATEGORY";
            ShowForm(true);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 | e.ColumnIndex == 1)
                customerEL.Customerid = Convert.ToInt32(dgv.SelectedRows[0].Cells["CUSTOMER ID"].Value);

            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                lblTitle.Text = "UPDATE CUSTOMER";
                ShowForm(true);

                customerEL = customerBL.Select(customerEL);
                txtFullName.Text = customerEL.Fullname;
                txtContactNumber.Text = customerEL.Contactnumber;

            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE TO DELETE THIS SELECTED ITEM?", "DELETING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(customerBL.Delete(customerEL));
                }

            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            bool bol = false;

            if (methods.CheckRequiredTXT(txtFullName, txtContactNumber))
            {
                customerEL.Fullname = txtFullName.Text;
                customerEL.Contactnumber = txtContactNumber.Text;

                if (s.Equals("ADD"))
                {
                    bol = customerBL.Insert(customerEL) > 0;
                }
                else if (s.Equals("EDIT"))
                {
                    bol = customerBL.Update(customerEL);
                }

                ShowResult(bol);

            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL REQUIRED FIELDS WITH AN ASTERISK");
            }
        }
    }
}
