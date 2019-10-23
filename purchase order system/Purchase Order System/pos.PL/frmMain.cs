using System;
using System.Windows.Forms;

namespace pos.PL
{
    public partial class frmMain : Form
    {
        EL.Registrations.Staffs StaffInfo;
        EL.Registrations.Contactdetails ContactDetailInfo;
        EL.Registrations.Basicinformations BasicInformationInfo;
        EL.Registrations.Staffpositions StaffpositionInfo;
        EL.Registrations.Addresses AddressInfo;
        EL.Registrations.Storeinformation StoreInformationInfo;

        frmLogin FrmLogin;


      
        public frmMain(EL.Registrations.Staffs staffInfo, EL.Registrations.Contactdetails contactDetailInfo, EL.Registrations.Basicinformations basicInformationInfo, EL.Registrations.Staffpositions staffpositionInfo, EL.Registrations.Addresses addressInfo, EL.Registrations.Storeinformation storeInformationInfo, frmLogin frmLogin)
        {
            InitializeComponent();
            StaffInfo = staffInfo;
            ContactDetailInfo = contactDetailInfo;
            BasicInformationInfo = basicInformationInfo;
            StaffpositionInfo = staffpositionInfo;
            AddressInfo = addressInfo;
            StoreInformationInfo = storeInformationInfo;
            FrmLogin = frmLogin;


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
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            FrmLogin.UpdateStoreName();
            FrmLogin.GetDataFromDataTableStaffInformation();
            lblName.Text = "Welcome, " + BasicInformationInfo.Firstname + " " + BasicInformationInfo.Middlename + " " + BasicInformationInfo.Lastname;
            lblStoreName.Text = StoreInformationInfo.Storename;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin.Show();
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
     


        private void manageSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageSuppliers objForm = new Registrations.frmManageSuppliers();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void productsCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageCategories objForm = new Registrations.frmManageCategories();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void productsSubcategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageSubCategories objForm = new Registrations.frmManageSubCategories();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void manageProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageProducts objForm = new Registrations.frmManageProducts();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();

        }

        private void manageSupplierProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageSupplierProducts objForm = new Registrations.frmManageSupplierProducts();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void storeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageStoreInformation objForm = new Registrations.frmManageStoreInformation(StoreInformationInfo, this);
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageProfile objForm = new Registrations.frmManageProfile(StaffInfo, this);
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void managePurchaseOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Transactions.frmManagePurchaseOrders objForm = new Transactions.frmManagePurchaseOrders();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }
    }
}
