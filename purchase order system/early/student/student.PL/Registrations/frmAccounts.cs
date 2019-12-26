using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace student.PL.Registrations
{
    public partial class frmAccounts : Form
    {
        EL.Registrations.accounts accountEL = new student.EL.Registrations.accounts();

        BL.Registrations.accounts accountBL = new student.BL.Registrations.accounts();

        string s = "";
        public frmAccounts()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            methods.ClearTXT(txtUsername, txtPassword);
        }

        private void ShowForm(bool bol)
        {
            pnlMain.Visible = !bol;
            pnlCRUD.Visible = bol;

            ClearControls();
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, accountBL.List(txtSearch.Text));
        }

        private void ManageDGV()
        {

            methods.DGVHiddenColumns(dgv, "ACCOUNT ID","PASSWORD", "C");
            methods.DGVTheme(dgv);
            methods.DGVFillWeights(dgv, new string[] { "USERNAME"}, new int[] { 100 });
            methods.DGVAddButtons(dgv);
            PopulateDGV();
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                PopulateDGV();
                MessageBox.Show("SUCCESS");
            }
            else
            {
                MessageBox.Show("FAILED");
            }
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            PopulateDGV();
            ShowForm(false);
            ManageDGV();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtUsername, txtPassword))
            {
                bool bol = false;

                accountEL.Username = txtUsername.Text;
                accountEL.Password = txtPassword.Text;

                if (s.Equals("ADD"))
                {
                    bol = accountBL.Insert(accountEL) > 0;
                }
                else if (s.Equals("EDIT"))
                {
                    bol = accountBL.Update(accountEL);
                }

                ShowForm(false);
                ShowResult(bol);


            }
            else
            {
                MessageBox.Show("PLEASE FILL OUT THE FIELDS MARKED WITH AN ASTERISK");
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            accountEL.Accountid = Convert.ToInt32(dgv.SelectedRows[0].Cells["ACCOUNT ID"].Value);

            if (e.ColumnIndex == 0)
            {
                lblTitle.Text = "EDIT ACCOUNT";
                s = "EDIT";
                ShowForm(true);

                accountEL = accountBL.Select(accountEL);

                txtUsername.Text = accountEL.Username;
                txtPassword.Text = accountEL.Password;
            }

            if (e.ColumnIndex == 1)
            {
                switch (MessageBox.Show(this, "ARE YOU SURE TO DELETE THIS SELECTED ITEM?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        ShowResult(accountBL.Delete(accountEL));
                        break;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "ADD ACCOUNT";
            s = "ADD";
            ShowForm(true);
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }

        
    }
}
