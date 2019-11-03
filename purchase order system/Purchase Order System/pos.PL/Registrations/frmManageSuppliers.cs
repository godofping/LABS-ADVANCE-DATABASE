using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageSuppliers : Form
    {
        EL.Registrations.Suppliers SupplierInfo = new EL.Registrations.Suppliers();
        EL.Registrations.ContactDetails ContactDetailInfo = new EL.Registrations.ContactDetails();
        EL.Registrations.Addresses AddressInfo = new EL.Registrations.Addresses();

        BL.Registrations.Suppliers SupplierBL = new BL.Registrations.Suppliers();
        BL.Registrations.ContactDetails ContacDetailBL = new BL.Registrations.ContactDetails();
        BL.Registrations.Addresses AddressBL = new BL.Registrations.Addresses();

        string current = "";

        public frmManageSuppliers()
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

        private void frmManageVendors_Load(object sender, EventArgs e)
        {
            loadData(txtSearch.Text);
            hiddenColumns();
            manageForm(false);
            txtZipCode.MaxLength = 6;


        }

        private void hiddenColumns()
        {
            dgv.Columns["Supplier ID"].Visible = false;
            dgv.Columns["contactdetailid"].Visible = false;
            dgv.Columns["addressid"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;

        }

        private void loadData(string keywords)
        {
            dgv.DataSource = SupplierBL.List(keywords);
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
            errorProvider1.SetError(txtSupplier, ""); ;
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
            txtSupplierID.ResetText();
            txtSupplier.ResetText();
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

            if (txtSupplier.Text.Equals(""))
            {
                errorProvider1.SetError(txtSupplier, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSupplier, "");


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
            AddressInfo.Province = txtProvince.Text;
            AddressInfo.Zipcode = txtZipCode.Text;

            ContactDetailInfo.Contactnumber = txtContactNumber.Text;
            ContactDetailInfo.Emailaddress = txtEmailAddress.Text;

            SupplierInfo.Supplier = txtSupplier.Text;
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

                SupplierInfo.Supplierid = Convert.ToInt32(row.Cells["Supplier ID"].Value);
                SupplierInfo.Supplier = row.Cells["Supplier"].Value.ToString();
                SupplierInfo.Contactdetailid = Convert.ToInt32(row.Cells["contactdetailid"].Value);
                SupplierInfo.Isdeleted = Convert.ToInt32(row.Cells["isdeleted"].Value);

            }

            txtSupplierID.Text = SupplierInfo.Supplierid.ToString();
            txtSupplier.Text = SupplierInfo.Supplier;
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
            SupplierInfo.Contactdetailid = Convert.ToInt32(ContacDetailBL.Insert(ContactDetailInfo));

            showMessageBox(SupplierBL.Insert(SupplierInfo) > 0);
        }

        private void edit()
        {
            getDataFromForm();

            showMessageBox(AddressBL.Update(AddressInfo) & ContacDetailBL.Update(ContactDetailInfo) & SupplierBL.Update(SupplierInfo));
        }

        private void delete()
        {
            getDataFromForm();
            showMessageBox(SupplierBL.Delete(SupplierInfo));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearFields();
            manageForm(true);
            this.ActiveControl = txtSupplier;
            current = "ADD";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtSupplierID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                manageForm(true);
                this.ActiveControl = txtSupplier;
                current = "EDIT";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSupplierID.Text.Equals(""))
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

        private void dgvManageVendors_SelectionChanged(object sender, EventArgs e)
        {
            getDataFromDataGridView();
        }

        private void dgvManageVendors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDataGridView();
        }

        private void dgvManageSuppliers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
