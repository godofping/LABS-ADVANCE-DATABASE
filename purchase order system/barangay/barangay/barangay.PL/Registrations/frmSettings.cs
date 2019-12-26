using System;
using System.Data;
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
    public partial class frmSettings : Form
    {

        EL.Registrations.Accounts accountEL;

        BL.Registrations.Accounts accountBL = new BL.Registrations.Accounts();


        public frmSettings(EL.Registrations.Accounts _accountEL)
        {
            InitializeComponent();
            accountEL = _accountEL;
        }

        private void ClearForm()
        {
            methods.ClearTXT(txtOldPassword, txtNewPassword, txtConfirmNewPassword);
            lblTitle.Text = "";
        }


        private void ShowChangePassword()
        {
            ClearForm();
            pnlChangePassword.Visible = true;
            pnlMain.Visible = false;
        }

        private void ShowMain()
        {
            pnlChangePassword.Visible = false;
            pnlMain.Visible = true;
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("SUCCESS");
                ShowMain();
            }
            else
            {
                MessageBox.Show("FAILED");
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            ShowMain();
            ClearForm();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ShowChangePassword();
            lblTitle.Text = "Change Password";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtOldPassword, txtNewPassword, txtConfirmNewPassword))
            {
                if (accountEL.Password.Equals(txtOldPassword.Text) & txtNewPassword.Text.Equals(txtConfirmNewPassword.Text))
                {
                    accountEL.Password = txtNewPassword.Text;

                    ShowResult(accountBL.Update(accountEL));
                }
                else
                {
                    MessageBox.Show("SOMETHING WRONG. PLEASE TRY AGAIN");
                }
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL REQUIRED FIELDS WITH AN ASTERISK");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        
    }
}
