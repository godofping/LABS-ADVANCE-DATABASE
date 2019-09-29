using System.Data;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmLogin : Form
    {
        pos.BL.Registrations.Users UserBL = new pos.BL.Registrations.Users();
        pos.EL.Registrations.Users UserInfo = new pos.EL.Registrations.Users();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            UserInfo.Username = txtUsername.Text;
            UserInfo.Password = txtPassword.Text;

          
           
            MessageBox.Show(UserBL.Login(UserInfo).ToString());


        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            pos.PL.Registrations.frmCustomers frm = new pos.PL.Registrations.frmCustomers();
            frm.Show();
        }
    }
}
