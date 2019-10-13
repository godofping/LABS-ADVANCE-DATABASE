using System;
using System.Windows.Forms;
using System.Data;

namespace pos.PL
{
    public partial class frmLogin : Form
    {
        EL.Registrations.Staffs StaffInfo = new EL.Registrations.Staffs();
        EL.Registrations.Contactdetails ContactDetailInfo = new EL.Registrations.Contactdetails();
        EL.Registrations.Basicinformations BasicInformationInfo = new EL.Registrations.Basicinformations();
        EL.Registrations.Staffpositions StaffpositionInfo = new EL.Registrations.Staffpositions();
        EL.Registrations.Addresses  AddressInfo = new EL.Registrations.Addresses();

        BL.Registrations.Staffs StaffBL = new BL.Registrations.Staffs();
        BL.Registrations.Contactdetails ContactDetailBL = new BL.Registrations.Contactdetails();
        BL.Registrations.Basicinformations BasicInformationBL = new BL.Registrations.Basicinformations();
        BL.Registrations.Staffpositions StaffpositionBL = new BL.Registrations.Staffpositions();
        BL.Registrations.Addresses AddressBL = new BL.Registrations.Addresses();


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

        private void ClearErrors()
        {
            errorProvider1.SetError(txtUsername, "");
            errorProvider1.SetError(txtPassword, "");
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

        private void GetDataFromDataTable(DataTable Result)
        {
            foreach (DataRow row in Result.Rows)
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

        private void Login()
        {

            GetDataFromForm();

            DataTable Result = StaffBL.Login(StaffInfo);
           
            if (Result.Rows.Count > 0)
            {
                GetDataFromDataTable(Result);

                MessageBox.Show("Login Successful");

                frmMain frm = new frmMain(StaffInfo, ContactDetailInfo, BasicInformationInfo, StaffpositionInfo, AddressInfo, this);
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
            Login();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
