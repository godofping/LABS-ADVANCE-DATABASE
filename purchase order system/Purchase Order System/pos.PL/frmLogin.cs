using System;
using System.Data;
using System.Windows.Forms;

namespace pos.PL
{
    public partial class frmLogin : Form
    {
        EL.Registrations.Staffs StaffInfo = new EL.Registrations.Staffs();
        EL.Registrations.Contactdetails ContactDetailInfo = new EL.Registrations.Contactdetails();
        EL.Registrations.Basicinformations BasicInformationInfo = new EL.Registrations.Basicinformations();
        EL.Registrations.Staffpositions StaffpositionInfo = new EL.Registrations.Staffpositions();
        EL.Registrations.Addresses  AddressInfo = new EL.Registrations.Addresses();
        EL.Registrations.Storeinformation StoreInformationInfo = new EL.Registrations.Storeinformation();

        BL.Registrations.Staffs StaffBL = new BL.Registrations.Staffs();
        BL.Registrations.Contactdetails ContactDetailBL = new BL.Registrations.Contactdetails();
        BL.Registrations.Basicinformations BasicInformationBL = new BL.Registrations.Basicinformations();
        BL.Registrations.Staffpositions StaffpositionBL = new BL.Registrations.Staffpositions();
        BL.Registrations.Addresses AddressBL = new BL.Registrations.Addresses();
        BL.Registrations.Storeinformation StoreInformationBL = new BL.Registrations.Storeinformation();


        public frmLogin()
        {
            InitializeComponent();
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

        private void GetDataFromDataTableStoreInformation()
        {
            foreach (DataRow row in StoreInformationBL.List().Rows)
            {
                AddressInfo.Addressid = Convert.ToInt32(row["addressid"]);
                AddressInfo.Address = row["Address"].ToString();
                AddressInfo.City = row["City"].ToString();
                AddressInfo.Province = row["Province"].ToString();
                AddressInfo.Zipcode = row["Zip Code"].ToString();

                ContactDetailInfo.Contactdetailid = Convert.ToInt32(row["contactdetailid"]);
                ContactDetailInfo.Addressid = Convert.ToInt32(row["addressid"]);
                ContactDetailInfo.Contactnumber = row["Contact Number"].ToString();
                ContactDetailInfo.Emailaddress = row["Email Address"].ToString();

                StoreInformationInfo.Storename = row["Store Name"].ToString();

            }

            UpdateStoreName();
        }

        public void GetDataFromDataTableStaffInformation()
        {
            foreach (DataRow row in StaffBL.Login(StaffInfo).Rows)
            {
                AddressInfo.Addressid = Convert.ToInt32(row["addressid"]);
                AddressInfo.Address = row["Address"].ToString();
                AddressInfo.City = row["City"].ToString();
                AddressInfo.Province = row["Province"].ToString();
                AddressInfo.Zipcode = row["Zip Code"].ToString();

                ContactDetailInfo.Contactdetailid = Convert.ToInt32(row["contactdetailid"]);
                ContactDetailInfo.Addressid = Convert.ToInt32(row["addressid"]);
                ContactDetailInfo.Contactnumber = row["Contact Number"].ToString();
                ContactDetailInfo.Emailaddress = row["Email Address"].ToString();

                BasicInformationInfo.Basicinformationid = Convert.ToInt32(row["basicinformationid"]);
                BasicInformationInfo.Firstname = row["First Name"].ToString();
                BasicInformationInfo.Middlename = row["Middle Name"].ToString();
                BasicInformationInfo.Lastname = row["Last Name"].ToString();
                BasicInformationInfo.Gender = row["Gender"].ToString();
                BasicInformationInfo.Birthdate = row["Birth Date"].ToString();

                StaffpositionInfo.Staffpositionid = Convert.ToInt32(row["staffpositionid"]);
                StaffpositionInfo.Staffposition = row["Staff Position"].ToString();

                StaffInfo.Staffid = Convert.ToInt32(row["Staff ID"]);
                StaffInfo.Username = row["Username"].ToString();
                StaffInfo.Password = row["password"].ToString();
                StaffInfo.Contactdetailid = Convert.ToInt32(row["contactdetailid"]);
                StaffInfo.Basicinformationid = Convert.ToInt32(row["basicinformationid"]);
                StaffInfo.Staffpositionid = Convert.ToInt32(row["staffpositionid"]);
                StaffInfo.Isdeleted = Convert.ToInt32(row["isdeleted"]);

            }
        }


        public void UpdateStoreName()
        {
            lblStoreName.Text = StoreInformationInfo.Storename;
        }

        private void ClearFields()
        {
            txtUsername.ResetText();
            txtPassword.ResetText();
            this.ActiveControl = txtUsername;
        }

        private bool CheckErrors()
        {
            bool status = true;

            if (txtUsername.Text.Equals(""))
            {
                errorProvider1.SetError(txtUsername, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtUsername, "");

            if (txtPassword.Text.Equals(""))
            {
                errorProvider1.SetError(txtPassword, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtPassword, "");

            return status;
        }


        private void GetDataFromForm()
        {
            StaffInfo.Username = txtUsername.Text;
            StaffInfo.Password = txtPassword.Text;
        }


        private void Login()
        {

            GetDataFromForm();


            if (StaffBL.Login(StaffInfo).Rows.Count > 0)
            {
                GetDataFromDataTableStaffInformation();

                MessageBox.Show("Login Successful");

                frmMain frm = new frmMain(StaffInfo, ContactDetailInfo, BasicInformationInfo, StaffpositionInfo, AddressInfo, StoreInformationInfo, this);
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
            if(CheckErrors())
            {
                Login();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            GetDataFromDataTableStoreInformation();
        }
    }
}
