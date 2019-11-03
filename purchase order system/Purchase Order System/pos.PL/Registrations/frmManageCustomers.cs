using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageCustomers : Form
    {


        EL.Registrations.Customers CustomerInfo = new EL.Registrations.Customers();
        EL.Registrations.ContactDetails ContactDetailInfo = new EL.Registrations.ContactDetails();
        EL.Registrations.BasicInformations BasicInformationInfo = new EL.Registrations.BasicInformations();
        EL.Registrations.Addresses AddressInfo = new EL.Registrations.Addresses();

        BL.Registrations.Customers CustomerBL = new BL.Registrations.Customers();
        BL.Registrations.ContactDetails ContacDetailBL = new BL.Registrations.ContactDetails();
        BL.Registrations.BasicInformations BasicInformationBL = new BL.Registrations.BasicInformations();
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
            loadData(txtSearch.Text);
            hiddenColumns();
            manageForm(false);
            txtZipCode.MaxLength = 6;
            clearFields();
        }

        private void hiddenColumns()
        {
            dgv.Columns["Customer ID"].Visible = false;
            dgv.Columns["contactdetailid"].Visible = false;
            dgv.Columns["basicinformationid"].Visible = false;
            dgv.Columns["addressid"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;

        }

        private void loadData(string keywords)
        {
            dgv.DataSource = CustomerBL.List(keywords);
        }

        private void manageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;
            dgv.Enabled = !status;
            txtSearch.Enabled = !status;
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

        }

        private void clearFields()
        {
            dgv.ClearSelection();
            txtCustomerID.ResetText();
            txtFirstName.ResetText();
            txtMiddleName.ResetText();
            txtLastName.ResetText();
            cbGender.SelectedIndex = -1;
            dtpBirthDate.ResetText();
            txtContactNumber.ResetText();
            txtEmailAddress.ResetText();
            txtAddress.ResetText();
            txtCity.ResetText();
            txtProvince.ResetText();
            txtZipCode.ResetText();
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
        }

        private void getDataFromDataGridView()
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

        private void showMessageBox(bool condition)
        {
            if (condition)
            {
                loadData(txtSearch.Text);
                clearFields();
                MessageBox.Show("Success");

            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void add()
        {
            getDataFromForm();

            ContactDetailInfo.Addressid = Convert.ToInt32(AddressBL.Insert(AddressInfo));
            CustomerInfo.Contactdetailid = Convert.ToInt32(ContacDetailBL.Insert(ContactDetailInfo));
            CustomerInfo.Basicinformationid = Convert.ToInt32(BasicInformationBL.Insert(BasicInformationInfo));

            showMessageBox(CustomerBL.Insert(CustomerInfo) > 0);
        }

        private void edit()
        {
            getDataFromForm();
            showMessageBox(AddressBL.Update(AddressInfo) & ContacDetailBL.Update(ContactDetailInfo) & BasicInformationBL.Update(BasicInformationInfo));
        }

        private void delete()
        {
            getDataFromForm();
            showMessageBox(CustomerBL.Delete(CustomerInfo));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearFields();
            manageForm(true);
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
                manageForm(true);
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
                delete();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkErrors())
            {
                getDataFromForm();
                if (current.Equals("ADD"))
                {
                    add();
                }
                else if (current.Equals("EDIT"))
                {
                    edit();
                }

                manageForm(false);
                clearFields();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            manageForm(false);
            clearFields();
            clearErrors();
        }

        private void dgvManageCustomers_SelectionChanged(object sender, EventArgs e)
        {
           getDataFromDataGridView();
        }

        private void dgvManageCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDataGridView();
        }

        private void dgvManageCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDataGridView();
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
            loadData(txtSearch.Text);
        }


    }
}
