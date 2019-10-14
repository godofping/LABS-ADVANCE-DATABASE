using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageCustomers : Form
    {


        EL.Registrations.Customers CustomerInfo = new EL.Registrations.Customers();
        EL.Registrations.Contactdetails ContactDetailInfo = new EL.Registrations.Contactdetails();
        EL.Registrations.Basicinformations BasicInformationInfo = new EL.Registrations.Basicinformations();
        EL.Registrations.Addresses AddressInfo = new EL.Registrations.Addresses();

        BL.Registrations.Customers CustomerBL = new BL.Registrations.Customers();
        BL.Registrations.Contactdetails ContacDetailBL = new BL.Registrations.Contactdetails();
        BL.Registrations.Basicinformations BasicInformationBL = new BL.Registrations.Basicinformations();
        BL.Registrations.Addresses AddressBL = new BL.Registrations.Addresses();

        string current = "";

        public frmManageCustomers()
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

        private void frmManageCustomers_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
            txtZipCode.MaxLength = 6;
        }

        private void HiddenColumns()
        {
            dgv.Columns["Customer ID"].Visible = false;
            dgv.Columns["contactdetailid"].Visible = false;
            dgv.Columns["basicinformationid"].Visible = false;
            dgv.Columns["addressid"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;

        }

        private void LoadData(string keywords)
        {
            dgv.DataSource = CustomerBL.List(keywords);
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

        }

        private void ClearFields()
        {
            dgv.ClearSelection();
            txtCustomerID.ResetText();
            txtFirstName.ResetText();
            txtMiddleName.ResetText();
            txtLastName.ResetText();
            cbGender.ResetText();
            dtpBirthDate.ResetText();
            txtContactNumber.ResetText();
            txtEmailAddress.ResetText();
            txtAddress.ResetText();
            txtCity.ResetText();
            txtProvince.ResetText();
            txtZipCode.ResetText();
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


            return status;
        }

        private void GetDataFromForm()
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
        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                AddressInfo.Addressid = Convert.ToInt32(row.Cells["addressid"].Value);
                AddressInfo.Address = row.Cells["Address"].Value.ToString();
                AddressInfo.City = row.Cells["City"].Value.ToString();
                AddressInfo.Province = row.Cells["Province"].Value.ToString();
                AddressInfo.Zipcode = row.Cells["Zip Code"].Value.ToString();

                ContactDetailInfo.Contactdetailid = Convert.ToInt32(row.Cells["contactdetailid"].Value);
                ContactDetailInfo.Addressid = Convert.ToInt32(row.Cells["addressid"].Value);
                ContactDetailInfo.Contactnumber = row.Cells["Contact Number"].Value.ToString();
                ContactDetailInfo.Emailaddress = row.Cells["Email Address"].Value.ToString();

                BasicInformationInfo.Basicinformationid = Convert.ToInt32(row.Cells["basicinformationid"].Value);
                BasicInformationInfo.Firstname = row.Cells["First Name"].Value.ToString();
                BasicInformationInfo.Middlename = row.Cells["Middle Name"].Value.ToString();
                BasicInformationInfo.Lastname = row.Cells["Last Name"].Value.ToString();
                BasicInformationInfo.Gender = row.Cells["Gender"].Value.ToString();
                BasicInformationInfo.Birthdate = row.Cells["Birth Date"].Value.ToString();

                CustomerInfo.Customerid = Convert.ToInt32(row.Cells["Customer ID"].Value);
                CustomerInfo.Contactdetailid = Convert.ToInt32(row.Cells["contactdetailid"].Value);
                CustomerInfo.Basicinformationid = Convert.ToInt32(row.Cells["basicinformationid"].Value);

            }

            txtCustomerID.Text = CustomerInfo.Customerid.ToString();
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

            ContactDetailInfo.Addressid = Convert.ToInt32(AddressBL.Insert(AddressInfo));
            CustomerInfo.Contactdetailid = Convert.ToInt32(ContacDetailBL.Insert(ContactDetailInfo));
            CustomerInfo.Basicinformationid = Convert.ToInt32(BasicInformationBL.Insert(BasicInformationInfo));

            ShowMessageBox(CustomerBL.Insert(CustomerInfo) > 0);
        }

        private void Edit()
        {
            GetDataFromForm();
            ShowMessageBox(AddressBL.Update(AddressInfo) & ContacDetailBL.Update(ContactDetailInfo) & BasicInformationBL.Update(BasicInformationInfo));
        }

        private void Delete()
        {
            GetDataFromForm();
            ShowMessageBox(CustomerBL.Delete(CustomerInfo));
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
            if (txtCustomerID.Text.Equals(""))
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
            if (txtCustomerID.Text.Equals(""))
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

                ManageForm(false);
                ClearFields();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageForm(false);
            ClearFields();
            ClearErrors();
        }

        private void dgvManageCustomers_SelectionChanged(object sender, EventArgs e)
        {

            GetDataFromDataGridView();
        }

        private void dgvManageCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgvManageCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
