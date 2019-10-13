using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmVendorCategories : Form
    {
        EL.Registrations.Vendorcategories VendorCategoryInfo = new EL.Registrations.Vendorcategories();
        BL.Registrations.Vendorcategories VendorCategoryBL = new BL.Registrations.Vendorcategories();

        string current = "";

        public frmVendorCategories()
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
            dgvManageVendorCategories.Columns["Vendor Category ID"].Visible = false;
            dgvManageVendorCategories.Columns["isdeleted"].Visible = false;

        }


        private void LoadData(string keywords)
        {
            dgvManageVendorCategories.DataSource = VendorCategoryBL.List(keywords);
        }

        private void ManageForm(bool status)
        {
            gbCustomerInformation.Enabled = status;
            gbControls.Enabled = !status;
            dgvManageVendorCategories.Enabled = !status;
            txtSearch.Enabled = !status;
        }


        private void ClearErrors()
        {
            errorProvider1.SetError(txtVendorCategory, "");

        }

        private void clearBoxes()
        {
            txtVendorCategoryID.ResetText();
            txtVendorCategory.ResetText();
        }

        private bool CheckErrors()
        {
            bool status = true;

            if (txtVendorCategory.Text.Equals(""))
            {
                errorProvider1.SetError(txtVendorCategory, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtVendorCategory, "");

            return status;
        }

        private void GetDataFromForm()
        {
            VendorCategoryInfo.Vendorcategory = txtVendorCategory.Text;
        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgvManageVendorCategories.SelectedRows)
            {

                VendorCategoryInfo.Vendorcategoryid = Convert.ToInt32(row.Cells["Vendor Category ID"].Value);
                VendorCategoryInfo.Vendorcategory = row.Cells["Vendor Category"].Value.ToString();
             

            }

            txtVendorCategoryID.Text = VendorCategoryInfo.Vendorcategoryid.ToString();
            txtVendorCategory.Text = VendorCategoryInfo.Vendorcategory;
        }

        private void Add()
        {
            GetDataFromForm();

            if (VendorCategoryBL.Insert(VendorCategoryInfo) > 0)
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
            if (VendorCategoryBL.Update(VendorCategoryInfo))
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
            if (VendorCategoryBL.Delete(VendorCategoryInfo))
            {
                LoadData(txtSearch.Text);
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void frmVendorCategories_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearBoxes();
            ManageForm(true);
            this.ActiveControl = txtVendorCategory;
            current = "ADD";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void dgvManageVendorCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgvManageVendorCategories_SelectionChanged(object sender, EventArgs e)
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
            if (txtVendorCategoryID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                ManageForm(true);
                this.ActiveControl = txtVendorCategory;
                current = "EDIT";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtVendorCategoryID.Text.Equals(""))
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
