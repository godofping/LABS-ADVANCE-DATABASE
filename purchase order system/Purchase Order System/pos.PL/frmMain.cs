using System;
using System.Windows.Forms;

namespace pos.PL
{
    public partial class frmMain : Form
    {
        #region "Variables"

        EL.Registrations.Staffs staffEL;
        EL.Registrations.ContactDetails contactDetailEL;
        EL.Registrations.BasicInformations basicInformationEL;
        EL.Registrations.StaffPositions staffPositionEL;
        EL.Registrations.Addresses addressEL;
        EL.Registrations.StoreInformation storeInformationEL;
        frmLogin frmLogin;

        #endregion


        public frmMain(EL.Registrations.Staffs _staffEL, EL.Registrations.ContactDetails _contactDetailEL, EL.Registrations.BasicInformations _basicInformationEL, EL.Registrations.StaffPositions _staffPositionEL, EL.Registrations.Addresses _addressEL, EL.Registrations.StoreInformation _storeInformationEL, frmLogin _frmLogin)
        {
            InitializeComponent();
            staffEL = _staffEL;
            contactDetailEL = _contactDetailEL;
            basicInformationEL = _basicInformationEL;
            staffPositionEL = _staffPositionEL;
            addressEL = _addressEL;
            storeInformationEL = _storeInformationEL;
            this.frmLogin = _frmLogin;
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


        #region "Methods"
        public void UpdateInfo()
        {
            frmLogin.UpdateStoreName();
            frmLogin.GetDataFromDataTableStaffInformation();
            lblName.Text = "Welcome, " + basicInformationEL.Firstname + " " + basicInformationEL.Middlename + " " + basicInformationEL.Lastname;
            lblStoreName.Text = storeInformationEL.Storename;
        }
        
        private void Restriction()
        {
            if(staffPositionEL.Staffposition.Equals("Manager"))
            {
                smiStaffs.Visible = true;
                smiStoreInformation.Visible = true;
                smiProductCategories.Visible = true;
                smiProductSubCategories.Visible = true;
            }

            if (staffPositionEL.Staffposition.Equals("Staff"))
            {
                smiStaffs.Visible = false;
                smiStoreInformation.Visible = false;
                smiProductCategories.Visible = false;
                smiProductSubCategories.Visible = false;
            }
        }


        #endregion









        #region "Events"
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            UpdateInfo();
            pnlMain.Controls.Clear();
            Transactions.frmManagePurchaseOrders objForm = new Transactions.frmManagePurchaseOrders(staffEL);
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();

        }

 

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt");
            Restriction();
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

  
        private void storeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageStoreInformation objForm = new Registrations.frmManageStoreInformation(storeInformationEL, this);
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }




        private void smiLogout_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure to logout?", "Confirming", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    this.Close();
                    frmLogin.Show();
                    break;
            }
        }

        private void smiExit_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure to exit this application?", "Confirming", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    Application.Exit();
                    break;
            }
        }

        private void smiProductCategories_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageCategories objForm = new Registrations.frmManageCategories();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void smiProductSubCategories_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageSubCategories objForm = new Registrations.frmManageSubCategories();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void smiManagePurchaseOrders_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Transactions.frmManagePurchaseOrders objForm = new Transactions.frmManagePurchaseOrders(staffEL);
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void smiMyProfile_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageProfile objForm = new Registrations.frmManageProfile(staffEL, this);
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void smiManageSuppliers_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageSuppliers objForm = new Registrations.frmManageSuppliers();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void smiManageSupplierProducts_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageSupplierProducts objForm = new Registrations.frmManageSupplierProducts();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void smiManageProducts_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Registrations.frmManageProducts objForm = new Registrations.frmManageProducts();
            objForm.TopLevel = false;
            objForm.AutoScroll = true;
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }


        #endregion


    }
}
