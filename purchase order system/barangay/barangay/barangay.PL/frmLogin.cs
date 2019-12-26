using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barangay.PL
{
    public partial class frmLogin : Form
    {
        EL.Registrations.Accounts accountEL = new EL.Registrations.Accounts();

        BL.Registrations.Accounts accountBL = new BL.Registrations.Accounts();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            methods.ClearTXT(txtUsername, txtPassword);
            this.ActiveControl = txtUsername;
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
                    accountEL.Username = dt.Rows[0]["username"].ToString();
                    frmMenu frmMenu = new frmMenu(this, accountEL);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
