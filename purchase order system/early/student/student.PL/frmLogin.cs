using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace student.PL
{
    public partial class frmLogin : Form
    {
        EL.Registrations.accounts accountEL = new EL.Registrations.accounts();

        BL.Registrations.accounts accountBL = new BL.Registrations.accounts();
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            methods.ClearTXT(txtUsername, txtPassword);
            this.ActiveControl = txtUsername;
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtUsername, txtPassword))
            {
                accountEL.Username = txtUsername.Text;
                accountEL.Password = txtPassword.Text;

                var dt = accountBL.Login(accountEL);

                if (dt.Rows.Count > 0)
                {
                    accountEL.Accountid = Convert.ToInt32(dt.Rows[0]["accountid"]);
                    frmMain frmMenu = new frmMain(this);
                    this.Hide();
                    frmMenu.ShowDialog();

                }
                else
                {
                    MessageBox.Show("LOGIN FAILED");
                }
                ClearForm();
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL REQUIRED FIELDS WITH AN ASTERISK");
            }
        }

    }
}
