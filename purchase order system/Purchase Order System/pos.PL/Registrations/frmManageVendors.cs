using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageVendors : Form
    {
        EL.Registrations.Suppliers VendorInfo = new EL.Registrations.Suppliers();
        EL.Registrations.Contactdetails ContactDetailInfo = new EL.Registrations.Contactdetails();
        EL.Registrations.Vendorcategories VendorCategoryInfo = new EL.Registrations.Vendorcategories();
        EL.Registrations.Addresses AddressInfo = new EL.Registrations.Addresses();

        BL.Registrations.Suppliers VendorBL = new BL.Registrations.Suppliers();
        BL.Registrations.Contactdetails ContacDetailBL = new BL.Registrations.Contactdetails();
        BL.Registrations.Vendorcategories VendorCategoryBL = new BL.Registrations.Vendorcategories();
        BL.Registrations.Addresses AddressBL = new BL.Registrations.Addresses();

        string current = "";

        public frmManageVendors()
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

        private void HiddenColumns()
        {
            dgvManageVendors.Columns["Vendor ID"].Visible = false;
            dgvManageVendors.Columns["contactdetailid"].Visible = false;
            dgvManageVendors.Columns["vendorcategoryid"].Visible = false;
            dgvManageVendors.Columns["addressid"].Visible = false;
            dgvManageVendors.Columns["isdeleted"].Visible = false;

        }

        private void LoadData(string keywords)
        {
            dgvManageVendors.DataSource = VendorBL.List(keywords);
        }

        private void PopulateControls()
        {

            cbVendorCategory.DisplayMember = "Vendor Category";
            cbVendorCategory.ValueMember = "Vendor Category ID";
            cbVendorCategory.DataSource = VendorCategoryBL.List("");
        }

        private void ManageForm(bool status)
        {
            gbCustomerInformation.Enabled = status;
            gbControls.Enabled = !status;
            dgvManageVendors.Enabled = !status;
            txtSearch.Enabled = !status;
        }

        private void ClearErrors()
        {
            errorProvider1.SetError(txtVendor, ""); ;
            errorProvider1.SetError(cbVendorCategory, "");
            errorProvider1.SetError(txtContactNumber, "");
            errorProvider1.SetError(txtEmailAddress, "");
            errorProvider1.SetError(txtAddress, "");
            errorProvider1.SetError(txtCity, "");
            errorProvider1.SetError(txtProvince, "");
            errorProvider1.SetError(txtZipCode, "");

        }

        private void clearBoxes()
        {
            txtVendorID.ResetText();
            txtVendor.ResetText();
            cbVendorCategory.ResetText();
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

            if (txtVendor.Text.Equals(""))
            {
                errorProvider1.SetError(txtVendor, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtVendor, "");


            if (cbVendorCategory.Text.Equals(""))
            {
                errorProvider1.SetError(cbVendorCategory, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbVendorCategory, "");


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
            AddressInfo.Province = txtProvince.Text;
            AddressInfo.Zipcode = txtZipCode.Text;

            ContactDetailInfo.Contactnumber = txtContactNumber.Text;
            ContactDetailInfo.Emailaddress = txtEmailAddress.Text;

            VendorInfo.Supplier = txtVendor.Text;
            VendorInfo.Vendorcategoryid = Convert.ToInt32(cbVendorCategory.SelectedValue);
        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgvManageVendors.SelectedRows)
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

                VendorCategoryInfo.Vendorcategoryid = Convert.ToInt32(row.Cells["vendorcategoryid"].Value);
                VendorCategoryInfo.Vendorcategory = row.Cells["Vendor Category"].Value.ToString();


                VendorInfo.Supplierid = Convert.ToInt32(row.Cells["Vendor ID"].Value);
                VendorInfo.Supplier = row.Cells["Vendor"].Value.ToString();
                VendorInfo.Vendorcategoryid = Convert.ToInt32(row.Cells["vendorcategoryid"].Value);

            }

            txtVendorID.Text = VendorInfo.Supplierid.ToString();
            txtVendor.Text = VendorInfo.Supplier;
            cbVendorCategory.Text = VendorCategoryInfo.Vendorcategory;
            txtContactNumber.Text = ContactDetailInfo.Contactnumber;
            txtEmailAddress.Text = ContactDetailInfo.Emailaddress;
            txtAddress.Text = AddressInfo.Address;
            txtCity.Text = AddressInfo.City;
            txtProvince.Text = AddressInfo.Province;
            txtZipCode.Text = AddressInfo.Zipcode;

        }

        private void Add()
        {
            GetDataFromForm();

            ContactDetailInfo.Addressid = Convert.ToInt32(AddressBL.Insert(AddressInfo));
            VendorInfo.Contactdetailid = Convert.ToInt32(ContacDetailBL.Insert(ContactDetailInfo));

            if (VendorBL.Insert(VendorInfo) > 0)
            {
                LoadData(txtSearch.Text);
                MessageBox.Show("Success");

            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void Edit()
        {
            GetDataFromForm();
            if (AddressBL.Update(AddressInfo) & ContacDetailBL.Update(ContactDetailInfo) & VendorBL.Update(VendorInfo))
            {
                LoadData(txtSearch.Text);
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void Delete()
        {
            GetDataFromForm();
            if (VendorBL.Delete(VendorInfo))
            {
                LoadData(txtSearch.Text);
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
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

        private void frmManageVendors_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
            txtZipCode.MaxLength = 6;
            PopulateControls();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearBoxes();
            ManageForm(true);
            this.ActiveControl = txtVendor;
            current = "ADD";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void dgvManageVendors_SelectionChanged(object sender, EventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgvManageVendors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
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
                clearBoxes();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageForm(false);
            clearBoxes();
            ClearErrors();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtVendorID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                ManageForm(true);
                this.ActiveControl = txtVendor;
                current = "EDIT";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtVendorID.Text.Equals(""))
            {
                MessageBox.Show("No selected item. Please select first.");
            }
            else
            {
                Delete();
            }
        }

        
    }
}
