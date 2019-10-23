using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.Registrations.Accounts
{
    public partial class frmEditAccount : Form
    {

        EL.Registrations.Accounts accountInfo;

        BL.Registrations.Accounts accountBL = new BL.Registrations.Accounts();

        frmAccounts frmAccounts;

        public frmEditAccount(frmAccounts FrmAccounts, EL.Registrations.Accounts AccountInfo)
        {
            InitializeComponent();

            frmAccounts = FrmAccounts;
            accountInfo = AccountInfo;
        }

        private void populateControls()
        {
            txtAccountUsername.Text = accountInfo.Accountusername;
            txtAccountPassword.Text = accountInfo.Accountpassword;
            txtAccountFullName.Text = accountInfo.Accountfullname;
        }

        private void readOnlyControls()
        {
            txtAccountUsername.ReadOnly = true;
        }

        private void clearControls()
        {

            txtAccountUsername.ResetText();
            txtAccountPassword.ResetText();
            txtAccountFullName.ResetText();

            this.ActiveControl = txtAccountPassword;
        }

        private bool validations()
        {
            bool status = true;

            if (txtAccountUsername.Text.Equals(""))
            {
                errorProvider1.SetError(txtAccountUsername, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtAccountUsername, "");

            if (txtAccountPassword.Text.Equals(""))
            {
                errorProvider1.SetError(txtAccountPassword, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtAccountPassword, "");

            if (txtAccountFullName.Text.Equals(""))
            {
                errorProvider1.SetError(txtAccountFullName, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtAccountFullName, "");

            return status;
        }

        private void getDataFromForm()
        {
            accountInfo.Accountusername = txtAccountUsername.Text;
            accountInfo.Accountpassword = txtAccountPassword.Text;
            accountInfo.Accountfullname = txtAccountFullName.Text;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validations())
            {
                getDataFromForm();
                if (accountBL.Edit(accountInfo))
                {
                    frmAccounts.loadData(frmAccounts.txtSearch.Text);
                    MessageBox.Show("Success.");
                    clearControls();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed.");
                }
            }
            else
            {
                MessageBox.Show("Please complete the required fields.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditAccount_Load(object sender, EventArgs e)
        {
            clearControls();
            populateControls();
            readOnlyControls();
        }
    }
}
