using System;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmLogin : Form
    {
        pos.BL.Transactions.Login LoginDL = new pos.BL.Transactions.Login();
        pos.EL.Transactions.Login StaffEL = new pos.EL.Transactions.Login();


        public frmLogin()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public class BufferedPanel : Panel
        {
            public BufferedPanel()
            {
                DoubleBuffered = true;
            }
        }

        private void ClearFields()
        {
            txtUsername.ResetText();
            txtPassword.ResetText();
            this.ActiveControl = txtUsername;
        }

        private void PassData()
        {
            StaffEL.Username = txtUsername.Text;
            StaffEL.Password = txtPassword.Text;
        }

        private void Login()
        {
            if (LoginDL.StaffLogin(StaffEL) > 0)
            {

                MessageBox.Show("Login Successful");

                frmMain frm = new frmMain(StaffEL, this);
                frm.Show();

                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Login Failed");
            }

            ClearFields();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PassData();
            Login();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
