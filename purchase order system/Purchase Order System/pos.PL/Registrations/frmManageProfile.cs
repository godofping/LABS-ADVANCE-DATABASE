using System;
using System.Data;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageProfile : Form
    {

        #region "Variables"

        EL.Registrations.Staffs staffEL;
        EL.Registrations.ContactDetails contactDetailEL = new EL.Registrations.ContactDetails();
        EL.Registrations.BasicInformations basicInformationEL = new EL.Registrations.BasicInformations();
        EL.Registrations.Addresses addressEL = new EL.Registrations.Addresses();
        EL.Registrations.StaffPositions staffPositionEL = new EL.Registrations.StaffPositions();
        BL.Registrations.Staffs staffBL = new BL.Registrations.Staffs();
        BL.Registrations.ContactDetails contactDetailBL = new BL.Registrations.ContactDetails();
        BL.Registrations.BasicInformations basicInformationBL = new BL.Registrations.BasicInformations();
        BL.Registrations.Addresses addressBL = new BL.Registrations.Addresses();
        BL.Registrations.StaffPositions staffPositionBL = new BL.Registrations.StaffPositions();
        frmMain frmMain;
        string current = "";

        #endregion



        public frmManageProfile(EL.Registrations.Staffs _staffEL, frmMain _frmMain)
        {
            InitializeComponent();
            staffEL = _staffEL;
            frmMain = _frmMain;
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
        private void frmManageProfile_Load(object sender, EventArgs e)
        {
            ReadOnlyControls();
            ManageForm(false);
            txtZipCode.MaxLength = 6;
            GetDataFromDataTable();
        }

        private void ReadOnlyControls()
        {
            txtPosition.ReadOnly = true;
            txtUsername.ReadOnly = true;
        }

        private void ManageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;

        }

        private void ClearErrors()
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

        private bool CheckErrors()
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


        private void GetDataFromForm()
        {
            addressEL.Address = txtAddress.Text;
            addressEL.City = txtCity.Text;
            addressEL.Zipcode = txtZipCode.Text;
            addressEL.Province = txtProvince.Text;

            contactDetailEL.Contactnumber = txtContactNumber.Text;
            contactDetailEL.Emailaddress = txtEmailAddress.Text;

            basicInformationEL.Firstname = txtFirstName.Text;
            basicInformationEL.Middlename = txtMiddleName.Text;
            basicInformationEL.Lastname = txtLastName.Text;
            basicInformationEL.Gender = cbGender.Text;
            basicInformationEL.Birthdate = dtpBirthDate.Text;

            staffEL.Password = txtPassword.Text;

        }

        private void GetDataFromDataTable()
        {
            foreach (DataRow row in staffBL.List(staffEL.Staffid).Rows)
            {
                addressEL.Addressid = Convert.ToInt32(row["addressid"]);
                addressEL.Address = row["Address"].ToString();
                addressEL.City = row["City"].ToString();
                addressEL.Province = row["Province"].ToString();
                addressEL.Zipcode = row["Zip Code"].ToString();

                contactDetailEL.Contactdetailid = Convert.ToInt32(row["contactdetailid"]);
                contactDetailEL.Addressid = Convert.ToInt32(row["addressid"]);
                contactDetailEL.Contactnumber = row["Contact Number"].ToString();
                contactDetailEL.Emailaddress = row["Email Address"].ToString();

                basicInformationEL.Basicinformationid = Convert.ToInt32(row["basicinformationid"]);
                basicInformationEL.Firstname = row["First Name"].ToString();
                basicInformationEL.Middlename = row["Middle Name"].ToString();
                basicInformationEL.Lastname = row["Last Name"].ToString();
                basicInformationEL.Gender = row["Gender"].ToString();
                basicInformationEL.Birthdate = row["Birth Date"].ToString();

                staffPositionEL.Staffposition = row["Staff Position"].ToString();

                staffEL.Staffid = Convert.ToInt32(row["Staff ID"]);
                staffEL.Username = row["Username"].ToString();
                staffEL.Password = row["password"].ToString();
                staffEL.Contactdetailid = Convert.ToInt32(row["contactdetailid"]);
                staffEL.Basicinformationid = Convert.ToInt32(row["basicinformationid"]);


            }

            txtStaffID.Text = staffEL.Staffid.ToString();
            txtFirstName.Text = basicInformationEL.Firstname;
            txtMiddleName.Text = basicInformationEL.Middlename;
            txtLastName.Text = basicInformationEL.Lastname;
            cbGender.Text = basicInformationEL.Gender;
            dtpBirthDate.Text = basicInformationEL.Birthdate;
            txtContactNumber.Text = contactDetailEL.Contactnumber;
            txtEmailAddress.Text = contactDetailEL.Emailaddress;
            txtAddress.Text = addressEL.Address;
            txtCity.Text = addressEL.City;
            txtProvince.Text = addressEL.Province;
            txtZipCode.Text = addressEL.Zipcode;
            txtPosition.Text = staffPositionEL.Staffposition;
            txtUsername.Text = staffEL.Username;
            txtPassword.Text = staffEL.Password;

        }

        private void ShowMessageBox(bool condition)
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

        private void OnlyNumWithSinglePoint(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        #endregion











        #region "Events"
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtStaffID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                ManageForm(true);
                this.ActiveControl = txtFirstName;
                current = "EDIT";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                if (current.Equals("EDIT"))
                {
                    ShowMessageBox(addressBL.Update(addressEL) & contactDetailBL.Update(contactDetailEL) & basicInformationBL.Update(basicInformationEL) & staffBL.Update(staffEL));
                    frmMain.UpdateInfo();
                }

                ManageForm(false);

                GetDataFromDataTable();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageForm(false);

            ClearErrors();
            GetDataFromDataTable();
        }

        private void txtZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumWithSinglePoint(sender, e);
        }

        #endregion

    }
}
