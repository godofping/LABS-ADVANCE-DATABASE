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
    public partial class frmAddAccount : Form
    {

        EL.Registrations.Accounts accountInfo = new EL.Registrations.Accounts();

        BL.Registrations.Accounts accountBL = new BL.Registrations.Accounts();

        frmAccounts frmAccounts;


        public frmAddAccount(frmAccounts FrmAccounts)
        {
            InitializeComponent();

            frmAccounts = FrmAccounts;
        }

        private void clearControls()
        {
            txtAccountUsername.ResetText();
            txtAccountPassword.ResetText();
            txtAccountFullName.ResetText();
            this.ActiveControl = txtAccountUsername;
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

        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            clearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validations())
            {
                getDataFromForm();
                
                if(accountBL.CheckUsername(accountInfo).Rows.Count == 0)
                {
                    if (accountBL.Insert(accountInfo) > 0)
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
                    MessageBox.Show("Username is already taken.");
                }


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
