using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageCustomers : Form
    {

        #region "Variables"

        EL.Registrations.Customers customerEL = new EL.Registrations.Customers();
        EL.Registrations.ContactDetails contactDetailEL = new EL.Registrations.ContactDetails();
        EL.Registrations.BasicInformations basicInformationEL = new EL.Registrations.BasicInformations();
        EL.Registrations.Addresses addressEL = new EL.Registrations.Addresses();
        BL.Registrations.Customers customerBL = new BL.Registrations.Customers();
        BL.Registrations.ContactDetails contactDetailBL = new BL.Registrations.ContactDetails();
        BL.Registrations.BasicInformations basicInformationBL = new BL.Registrations.BasicInformations();
        BL.Registrations.Addresses addressBL = new BL.Registrations.Addresses();
        string current = "";

        #endregion


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

        #region "Methods"
        private void HiddenColumns()
        {
            dgv.Columns["Customer ID"].Visible = false;
            dgv.Columns["contactdetailid"].Visible = false;
            dgv.Columns["basicinformationid"].Visible = false;
            dgv.Columns["addressid"].Visible = false;
        }

        private void LoadData(string keywords)
        {
            dgv.DataSource = customerBL.List(keywords);
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

                customerEL.Customerid = Convert.ToInt32(row.Cells["Customer ID"].Value);
                customerEL.Contactdetailid = Convert.ToInt32(row.Cells["contactdetailid"].Value);
                customerEL.Basicinformationid = Convert.ToInt32(row.Cells["basicinformationid"].Value);

            }

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
        private void frmManageCustomers_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
            txtZipCode.MaxLength = 6;
            ClearFields();
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
            if (dgv.SelectedRows.Count == 0)
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
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("No selected item. Please select first.");
            }
            else
            {
                switch (MessageBox.Show(this, "Are you sure to delete this?", "Confirming", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        ShowMessageBox(customerBL.Delete(customerEL));
                        break;
                }
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                if (current.Equals("ADD"))
                {
                    contactDetailEL.Addressid = Convert.ToInt32(addressBL.Insert(addressEL));
                    customerEL.Contactdetailid = Convert.ToInt32(contactDetailBL.Insert(contactDetailEL));
                    customerEL.Basicinformationid = Convert.ToInt32(basicInformationBL.Insert(basicInformationEL));
                    ShowMessageBox(customerBL.Insert(customerEL) > 0);
                }
                else if (current.Equals("EDIT"))
                {
                    ShowMessageBox(addressBL.Update(addressEL) & contactDetailBL.Update(contactDetailEL) & basicInformationBL.Update(basicInformationEL));
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
            OnlyNumWithSinglePoint(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        #endregion

    }
}
