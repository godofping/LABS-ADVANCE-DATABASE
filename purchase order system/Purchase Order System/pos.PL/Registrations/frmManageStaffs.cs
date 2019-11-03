using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageStaffs : Form
    {

        EL.Registrations.Staffs staffEL = new EL.Registrations.Staffs();
        EL.Registrations.ContactDetails contactDetailEL = new EL.Registrations.ContactDetails();
        EL.Registrations.BasicInformations basicInformationEL = new EL.Registrations.BasicInformations();
        EL.Registrations.Addresses addressEL = new EL.Registrations.Addresses();
        EL.Registrations.StaffPositions staffPositionEL = new EL.Registrations.StaffPositions();

        BL.Registrations.Staffs staffBL = new BL.Registrations.Staffs();
        BL.Registrations.ContactDetails contactDetailBL = new BL.Registrations.ContactDetails();
        BL.Registrations.BasicInformations basicInformationBL = new BL.Registrations.BasicInformations();
        BL.Registrations.Addresses adressBL = new BL.Registrations.Addresses();
        BL.Registrations.StaffPositions staffPositionBL = new BL.Registrations.StaffPositions();

        string current = "";

        public frmManageStaffs()
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

        private void frmManageStaffs_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
            txtZipCode.MaxLength = 6;
            PopulateControls();
            ClearFields();
        }

        private void HiddenColumns()
        {
            dgv.Columns["Staff ID"].Visible = false;
            dgv.Columns["contactdetailid"].Visible = false;
            dgv.Columns["basicinformationid"].Visible = false;
            dgv.Columns["addressid"].Visible = false;
            dgv.Columns["staffpositionid"].Visible = false;
            dgv.Columns["password"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;
        }

        private void LoadData(string keywords)
        {
            dgv.DataSource = staffBL.List(keywords);

        }

        private void PopulateControls()
        {

            cbPosition.DisplayMember = "staffposition";
            cbPosition.ValueMember = "staffpositionid";
            cbPosition.DataSource = staffPositionBL.List();
        }

        private void ManageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;
            dgv.Enabled = !status;
            txtSearch.Enabled = !status;
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
            errorProvider1.SetError(cbPosition, "");
            errorProvider1.SetError(txtUsername, "");
            errorProvider1.SetError(txtPassword, "");

        }

        private void ClearFields()
        {
            dgv.ClearSelection();
            txtStaffID.ResetText();
            txtFirstName.ResetText();
            txtMiddleName.ResetText();
            txtLastName.ResetText();
            cbGender.SelectedIndex = -1;
            cbGender.Text = "";
            dtpBirthDate.ResetText();
            txtContactNumber.ResetText();
            txtEmailAddress.ResetText();
            txtAddress.ResetText();
            txtCity.ResetText();
            txtProvince.ResetText();
            txtZipCode.ResetText();
            cbPosition.SelectedIndex = -1;
            cbPosition.Text = "";
            txtUsername.ResetText();
            txtPassword.ResetText();
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


            if (cbPosition.Text.Equals(""))
            {
                errorProvider1.SetError(cbPosition, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbPosition, "");


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

            staffPositionEL.Staffpositionid = Convert.ToInt32(cbPosition.SelectedValue);


            staffEL.Username = txtUsername.Text;
            staffEL.Password = txtPassword.Text;
            staffEL.Staffpositionid = Convert.ToInt32(cbPosition.SelectedValue);



        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                addressEL.Addressid = Convert.ToInt32(row.Cells["addressid"].Value);
                addressEL.Address = row.Cells["Address"].Value.ToString();
                addressEL.City = row.Cells["City"].Value.ToString();
                addressEL.Province = row.Cells["Province"].Value.ToString();
                addressEL.Zipcode = row.Cells["Zip Code"].Value.ToString();

                contactDetailEL.Contactdetailid = Convert.ToInt32(row.Cells["contactdetailid"].Value);
                contactDetailEL.Addressid = Convert.ToInt32(row.Cells["addressid"].Value);
                contactDetailEL.Contactnumber = row.Cells["Contact Number"].Value.ToString();
                contactDetailEL.Emailaddress = row.Cells["Email Address"].Value.ToString();

                basicInformationEL.Basicinformationid = Convert.ToInt32(row.Cells["basicinformationid"].Value);
                basicInformationEL.Firstname = row.Cells["First Name"].Value.ToString();
                basicInformationEL.Middlename = row.Cells["Middle Name"].Value.ToString();
                basicInformationEL.Lastname = row.Cells["Last Name"].Value.ToString();
                basicInformationEL.Gender = row.Cells["Gender"].Value.ToString();
                basicInformationEL.Birthdate = row.Cells["Birth Date"].Value.ToString();

                staffPositionEL.Staffpositionid = Convert.ToInt32(row.Cells["staffpositionid"].Value);
                staffPositionEL.Staffposition = row.Cells["Staff Position"].Value.ToString();

                staffEL.Staffid = Convert.ToInt32(row.Cells["Staff ID"].Value);
                staffEL.Username = row.Cells["Username"].Value.ToString();
                staffEL.Password = row.Cells["password"].Value.ToString();
                staffEL.Staffpositionid = Convert.ToInt32(row.Cells["staffpositionid"].Value);
                staffEL.Contactdetailid = Convert.ToInt32(row.Cells["contactdetailid"].Value);
                staffEL.Basicinformationid = Convert.ToInt32(row.Cells["basicinformationid"].Value);

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

            cbPosition.SelectedIndex = cbPosition.FindString(staffPositionEL.Staffposition);

            txtUsername.Text = staffEL.Username;
            txtPassword.Text = staffEL.Password;

        }

        private void ShowMessageBox(bool condition)
        {
            if (condition)
            {
                LoadData(txtSearch.Text);
                ClearFields();
                MessageBox.Show("Success");

            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void Add()
        {
            GetDataFromForm();

            if (staffBL.CheckUsername(staffEL).Rows.Count == 0)
            {
                contactDetailEL.Addressid = Convert.ToInt32(adressBL.Insert(addressEL));
                staffEL.Contactdetailid = Convert.ToInt32(contactDetailBL.Insert(contactDetailEL));
                staffEL.Basicinformationid = Convert.ToInt32(basicInformationBL.Insert(basicInformationEL));
                staffEL.Staffpositionid = Convert.ToInt32(staffPositionEL.Staffpositionid);
                ShowMessageBox(staffBL.Insert(staffEL) > 0);

                ManageForm(false);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Username is taken. Please change.");
            }
        }

        private void Edit()
        {
            GetDataFromForm();

            if (staffBL.CheckUsername(staffEL, staffEL.Staffid).Rows.Count == 0)
            {
                ShowMessageBox(adressBL.Update(addressEL) & contactDetailBL.Update(contactDetailEL) & basicInformationBL.Update(basicInformationEL) & staffBL.Update(staffEL));
                ManageForm(false);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Username is taken. Please change.");
            }

        }

        private void Delete()
        {
            GetDataFromForm();

            ShowMessageBox(staffBL.Delete(staffEL));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            ManageForm(true);
            this.ActiveControl = txtFirstName;
            current = "ADD";
        }

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStaffID.Text.Equals(""))
            {
                MessageBox.Show("No selected item. Please select first.");
            }
            else
            {
                Delete();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                if (current.Equals("ADD"))
                {
                    Add();
                }
                else if (current.Equals("EDIT"))
                {
                    Edit();
                }


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageForm(false);
            ClearFields();
            ClearErrors();
        }

        private void dgvManageStaffs_SelectionChanged(object sender, EventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgvManageStaffs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgvManageStaffs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

    }
}
