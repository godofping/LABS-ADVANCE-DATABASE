using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos
{
    public partial class frmLogin : Form
    {
        BL.Registrations.Accounts accountBL = new BL.Registrations.Accounts();

        EL.Registrations.Accounts accountInfo = new EL.Registrations.Accounts();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void getDataFromForm()
        {
            accountInfo.Accountusername = txtUsername.Text;
            accountInfo.Accountpassword = txtPassword.Text;
        }

        private void getDataFromDatabase()
        {
            foreach (DataRow row in accountBL.Login(accountInfo).Rows)
            {
                accountInfo.Accountid = Convert.ToInt32(row["Account ID"]);
                accountInfo.Accountusername = row["Username"].ToString();
                accountInfo.Accountpassword = row["Password"].ToString();
                accountInfo.Accountfirstname = row["First Name"].ToString();
                accountInfo.Accountmiddlename = row["Middle Name"].ToString();
                accountInfo.Accountlastname = row["Last Name"].ToString();
            }
        }

        private void clearControls()
        {
            txtUsername.ResetText();
            txtPassword.ResetText();
            this.ActiveControl = txtUsername;
        }

        private bool validations()
        {
            bool status = true;

            if (txtUsername.Text.Equals(""))
            {
                errorProvider1.SetError(txtUsername, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtUsername, "");

            if (txtPassword.Text.Equals(""))
            {
                errorProvider1.SetError(txtPassword, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtPassword, "");

            return status;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUsername;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (validations())
            {
                getDataFromForm();

                if (accountBL.Login(accountInfo).Rows.Count > 0)
                {
                    MessageBox.Show("Login success");
                    getDataFromDatabase();
                    frmMenu frmMenu = new frmMenu(this, accountInfo);
                    frmMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed");
                }
                clearControls();
            }

        }
    }
}
