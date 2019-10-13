using System;
using System.Windows.Forms;

namespace pos.PL
{
    public partial class frmMain : Form
    {
        pos.EL.Transactions.Login StaffEL;


        Transactions.frmLogin Frm;
       


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
                cp.ExStyle |= 0x02000000; 
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt");
        }

        private void smiManageStaffs_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageStaffs objForm = new Registrations.frmManageStaffs();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();

        }

        private void smiManageCustomers_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageCustomers objForm = new Registrations.frmManageCustomers();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();

        }
        private void manageVendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageVendors objForm = new Registrations.frmManageVendors();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }


        private void manageVendorCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmVendorCategories objForm = new Registrations.frmVendorCategories();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }
    }
}
