using System;
using System.Data;
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
            accountInfo.Accountusername = txtAccountUsername.Text;
            accountInfo.Accountpassword = txtAccountPassword.Text;
        }

        private void getDataFromDatabase()
        {
            foreach (DataRow row in accountBL.Login(accountInfo).Rows)
            {
                accountInfo.Accountid = Convert.ToInt32(row["Account ID"]);
                accountInfo.Accountusername = row["Account Username"].ToString();
                accountInfo.Accountpassword = row["Account Password"].ToString();
                accountInfo.Accountfullname = row["Account Full Name"].ToString();

            }
        }

        private void clearControls()
        {
            txtAccountUsername.ResetText();
            txtAccountPassword.ResetText();
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

            return status;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtAccountUsername;
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
