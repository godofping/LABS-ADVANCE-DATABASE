using System;
using System.Windows.Forms;

namespace pos.PL
{
    public partial class frmMain : Form
    {
        pos.EL.Transactions.Login StaffEL;


        Transactions.frmLogin Frm;
        Registrations.frmManageCustomers FormManageCustomers = new Registrations.frmManageCustomers();
        Registrations.frmManageStaffs FormManageStaffs = new Registrations.frmManageStaffs();


        public frmMain(pos.EL.Transactions.Login staffEL, Transactions.frmLogin frm)
        {
            InitializeComponent();
            StaffEL = staffEL;
            Frm = frm;

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm.Show();
        }

        private void smiManageStaffs_Click(object sender, EventArgs e)
        {

        }

        private void smiManageCustomers_Click(object sender, EventArgs e)
        {
            FormManageCustomers.TopLevel = false;
            FormManageCustomers.AutoScroll = true;
            pnlMain.Controls.Add(FormManageCustomers);
            FormManageCustomers.FormBorderStyle = FormBorderStyle.None;
            FormManageCustomers.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt");
        }
    }
}
