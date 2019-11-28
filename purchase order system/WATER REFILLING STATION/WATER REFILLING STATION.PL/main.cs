using System;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL
{
    public partial class main : Form
    {
        login login;
        public main(login _login)
        {
            InitializeComponent();
            login = _login;
        }




        private void main_Load(object sender, EventArgs e)
        {

            if (login.designationEL.Designation.Equals("MANAGER"))
            {
                var frm = new PL.OTHERS.MENU_MANAGER(login);
                methods.ChangePanelDisplay(frm, pnlMenu);
            }
            else if (login.designationEL.Designation.Equals("CASHIER"))
            {
                var frm = new PL.OTHERS.MENU_CASHIER(login);
                methods.ChangePanelDisplay(frm, pnlMenu);
            }



            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("hh:mm tt dddd, dd MMMM yyyy");
        }

        
    }
}
