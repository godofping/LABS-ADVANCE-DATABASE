using System;
using System.Data;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageProfile : Form
    {
        EL.Registrations.Staffs StaffInfo;
        EL.Registrations.Contactdetails ContactDetailInfo = new EL.Registrations.Contactdetails();
        EL.Registrations.Basicinformations BasicInformationInfo = new EL.Registrations.Basicinformations();
        EL.Registrations.Addresses AddressInfo = new EL.Registrations.Addresses();
        EL.Registrations.Staffpositions StaffPositionInfo = new EL.Registrations.Staffpositions();

        BL.Registrations.Staffs StaffBL = new BL.Registrations.Staffs();
        BL.Registrations.Contactdetails ContacDetailBL = new BL.Registrations.Contactdetails();
        BL.Registrations.Basicinformations BasicInformationBL = new BL.Registrations.Basicinformations();
        BL.Registrations.Addresses AddressBL = new BL.Registrations.Addresses();
        BL.Registrations.Staffpositions StaffPositionBL = new BL.Registrations.Staffpositions();

        frmMain frmMain;

        string current = "";

        public frmManageProfile(EL.Registrations.Staffs staffInfo, frmMain FrmMain)
        {
            InitializeComponent();
            StaffInfo = staffInfo;
            frmMain = FrmMain;
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

        private void frmManageProfile_Load(object sender, EventArgs e)
        {
       
            readOnlyControls();
            manageForm(false);
            txtZipCode.MaxLength = 6;

            getDataFromDataTable();
        }

        private void readOnlyControls()
        {
            txtPosition.ReadOnly = true;
            txtUsername.ReadOnly = true;
        }

        private void manageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;

        }


        private void clearErrors()
        {
            errorProvider1.SetError(txtFirstName, "");
            errorProvider1.SetError(txtMiddleName, "");
            errorProvider1.SetError(txtLastName, "");
            errorProvider1.SetError(cbGender, "");
            errorProvider1.SetError(dtpBirthDate, "");
            errorProvider1.SetError(txtContactNumber, "");
            errorProvider1.SetError(txtEmailAddress, "");
            errorProvider1.SetError(txtAddress, "");
            errorProvider1.SetError(txtCity, "");
            errorProvider1.SetError(txtProvince, "");
            errorProvider1.SetError(txtZipCode, "");
            errorProvider1.SetError(txtPassword, "");

        }

        private bool checkErrors()
        {
            bool status = true;

            if (txtFirstName.Text.Equals(""))
            {
                errorProvider1.SetError(txtFirstName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtFirstName, "");

            if (txtMiddleName.Text.Equals(""))
            {
                errorProvider1.SetError(txtMiddleName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtMiddleName, "");

            if (txtLastName.Text.Equals(""))
            {
                errorProvider1.SetError(txtLastName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtLastName, "");

            if (cbGender.Text.Equals(""))
            {
                errorProvider1.SetError(cbGender, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbGender, "");

            if (dtpBirthDate.Text.Equals(""))
            {
                errorProvider1.SetError(dtpBirthDate, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(dtpBirthDate, "");

            if (txtContactNumber.Text.Equals(""))
            {
                errorProvider1.SetError(txtContactNumber, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtContactNumber, "");

            if (txtEmailAddress.Text.Equals(""))
            {
                errorProvider1.SetError(txtEmailAddress, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtEmailAddress, "");

            if (txtAddress.Text.Equals(""))
            {
                errorProvider1.SetError(txtAddress, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtAddress, "");

            if (txtCity.Text.Equals(""))
            {
                errorProvider1.SetError(txtCity, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtCity, "");

            if (txtProvince.Text.Equals(""))
            {
                errorProvider1.SetError(txtProvince, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProvince, "");

            if (txtZipCode.Text.Equals(""))
            {
                errorProvider1.SetError(txtZipCode, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtZipCode, "");

            if (txtPassword.Text.Equals(""))
            {
                errorProvider1.SetError(txtPassword, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtPassword, "");

            return status;
        }


        private void getDataFromForm()
        {
            AddressInfo.Address = txtAddress.Text;
            AddressInfo.City = txtCity.Text;
            AddressInfo.Zipcode = txtZipCode.Text;
            AddressInfo.Province = txtProvince.Text;

            ContactDetailInfo.Contactnumber = txtContactNumber.Text;
            ContactDetailInfo.Emailaddress = txtEmailAddress.Text;

            BasicInformationInfo.Firstname = txtFirstName.Text;
            BasicInformationInfo.Middlename = txtMiddleName.Text;
            BasicInformationInfo.Lastname = txtLastName.Text;
            BasicInformationInfo.Gender = cbGender.Text;
            BasicInformationInfo.Birthdate = dtpBirthDate.Text;

            StaffInfo.Password = txtPassword.Text;

        }

        private void getDataFromDataTable()
        {
            foreach (DataRow row in StaffBL.List(StaffInfo.Staffid).Rows)
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

                StaffPositionInfo.Staffposition = row["Staff Position"].ToString();
                
                StaffInfo.Staffid = Convert.ToInt32(row["Staff ID"]);
                StaffInfo.Username = row["Username"].ToString();
                StaffInfo.Password = row["password"].ToString();
                StaffInfo.Contactdetailid = Convert.ToInt32(row["contactdetailid"]);
                StaffInfo.Basicinformationid = Convert.ToInt32(row["basicinformationid"]);


            }

            txtStaffID.Text = StaffInfo.Staffid.ToString();
            txtFirstName.Text = BasicInformationInfo.Firstname;
            txtMiddleName.Text = BasicInformationInfo.Middlename;
            txtLastName.Text = BasicInformationInfo.Lastname;
            cbGender.Text = BasicInformationInfo.Gender;
            dtpBirthDate.Text = BasicInformationInfo.Birthdate;
            txtContactNumber.Text = ContactDetailInfo.Contactnumber;
            txtEmailAddress.Text = ContactDetailInfo.Emailaddress;
            txtAddress.Text = AddressInfo.Address;
            txtCity.Text = AddressInfo.City;
            txtProvince.Text = AddressInfo.Province;
            txtZipCode.Text = AddressInfo.Zipcode;
            txtPosition.Text = StaffPositionInfo.Staffposition;
            txtUsername.Text = StaffInfo.Username;
            txtPassword.Text = StaffInfo.Password;

        }

        private void showMessageBox(bool condition)
        {
            if (condition)
            {

                MessageBox.Show("Success");

            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void edit()
        {
            getDataFromForm();

            showMessageBox(AddressBL.Update(AddressInfo) & ContacDetailBL.Update(ContactDetailInfo) & BasicInformationBL.Update(BasicInformationInfo) & StaffBL.Update(StaffInfo));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtStaffID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                manageForm(true);
                this.ActiveControl = txtFirstName;
                current = "EDIT";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkErrors())
            {
                getDataFromForm();
                if (current.Equals("EDIT"))
                {
                    edit();
                    frmMain.UpdateInfo();
                }

                manageForm(false);

                getDataFromDataTable();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            manageForm(false);

            clearErrors();
            getDataFromDataTable();
        }

        private void txtZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
