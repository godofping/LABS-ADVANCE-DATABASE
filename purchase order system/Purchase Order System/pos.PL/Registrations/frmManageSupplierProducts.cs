using System;
using System.Data;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageSupplierProducts : Form
    {
        EL.Registrations.SupplierProducts supplierProductEL = new EL.Registrations.SupplierProducts();
        EL.Registrations.Products productEL = new EL.Registrations.Products();
        EL.Registrations.Suppliers supplierEL = new EL.Registrations.Suppliers();
        EL.Transactions.Inventories inventoryEL = new EL.Transactions.Inventories();
        EL.Registrations.Categories categoryEL = new EL.Registrations.Categories();
        EL.Registrations.SubCategories subCategoryEL = new EL.Registrations.SubCategories();

        BL.Registrations.SupplierProducts supplierProductBL = new BL.Registrations.SupplierProducts();
        BL.Registrations.Products productBL = new BL.Registrations.Products();
        BL.Registrations.Suppliers supplierBL = new BL.Registrations.Suppliers();
        BL.Transactions.Inventories inventoryBL = new BL.Transactions.Inventories();
        BL.Registrations.Categories categoryBL = new BL.Registrations.Categories();
        BL.Registrations.SubCategories subCategoryBL = new BL.Registrations.SubCategories();

        string current = "";

        public frmManageSupplierProducts()
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
            PopulateControls();
            ClearFields();
            ReadOnlyControls();
        }

        private void ReadOnlyControls()
        {
            txtProductSKU.ReadOnly = true;
            txtProductPrice.ReadOnly = true;
            txtProductDescription.ReadOnly = true;

        }

        private void HiddenColumns()
        {
            dgv.Columns["Supplier Product ID"].Visible = false;
            dgv.Columns["subcategoryid"].Visible = false;
            dgv.Columns["contactdetailid"].Visible = false;
            dgv.Columns["productsisdeleted"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;
            dgv.Columns["productid"].Visible = false;
            dgv.Columns["supplierid"].Visible = false;
            dgv.Columns["categoryid"].Visible = false;
            dgv.Columns["subcategoriesisdeleted"].Visible = false;
            dgv.Columns["categoriesisdeleted"].Visible = false;

        }

        private void LoadData(string keywords)
        {
            dgv.DataSource = supplierProductBL.List(keywords);
        }

        private void PopulateControls()
        {
            cbCategoryName.DisplayMember = "Category Name";
            cbCategoryName.ValueMember = "Category ID";
            cbCategoryName.DataSource = categoryBL.List("");

            cbSupplierName.DisplayMember = "Supplier";
            cbSupplierName.ValueMember = "Supplier ID";
            cbSupplierName.DataSource = supplierBL.List("");
        }


        private void PopulateControlsSubCategory()
        {
            cbSubCategoryName.DisplayMember = "Sub Category Name";
            cbSubCategoryName.ValueMember = "Sub Category ID";
            cbSubCategoryName.DataSource = subCategoryBL.List(Convert.ToInt32(cbCategoryName.SelectedValue));
        }

        private void PopulateControlsProducts()
        {
            cbProductName.DisplayMember = "Product Name";
            cbProductName.ValueMember = "Product ID";
            cbProductName.DataSource = inventoryBL.List(Convert.ToInt32(cbSubCategoryName.SelectedValue));
        }

        private void GetProductInfo()
        {
            if (!cbProductName.Text.Equals(""))
            {
                foreach (DataRow row in productBL.List(Convert.ToInt32(cbProductName.SelectedValue.ToString())).Rows)
                {
                    productEL.Productsku = row["Product SKU"].ToString();
                    productEL.Productprice = Convert.ToInt32(row["Product Price"]);
                    productEL.Productdescription = row["Product Description"].ToString();
                }

                txtProductSKU.Text = productEL.Productsku;
                txtProductPrice.Text = productEL.Productprice.ToString();
                txtProductDescription.Text = productEL.Productdescription;
            }
            else
            {
                ClearExtendedFields();
            }

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
            errorProvider1.SetError(cbSupplierName, "");
            errorProvider1.SetError(cbProductName, "");
            errorProvider1.SetError(cbSubCategoryName, "");
            errorProvider1.SetError(cbProductName, "");
        }

        private void ClearFields()
        {
            dgv.ClearSelection();
            txtSupplierProductID.ResetText();

            cbSupplierName.SelectedIndex = -1;
      
            cbCategoryName.SelectedIndex = -1;
            cbCategoryName.ResetText();

            cbSubCategoryName.SelectedIndex = -1;
            cbSubCategoryName.ResetText();
            cbSubCategoryName.DataSource = null;
            cbSubCategoryName.Items.Clear();

            cbProductName.SelectedIndex = -1;
            cbProductName.ResetText();
            cbProductName.DataSource = null;
            cbProductName.Items.Clear();



            ClearExtendedFields();
        }

        private void ClearExtendedFields()
        {
            txtProductSKU.ResetText();
            txtProductPrice.ResetText();
            txtProductDescription.ResetText();
        }

        private bool CheckErrors()
        {
            bool status = true;

            if (cbSupplierName.Text.Equals(""))
            {
                errorProvider1.SetError(cbSupplierName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbSupplierName, "");


            if (cbCategoryName.Text.Equals(""))
            {
                errorProvider1.SetError(cbCategoryName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbCategoryName, "");


            if (cbSubCategoryName.Text.Equals(""))
            {
                errorProvider1.SetError(cbSubCategoryName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbSubCategoryName, "");

            if (cbProductName.Text.Equals(""))
            {
                errorProvider1.SetError(cbProductName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbProductName, "");

            return status;
        }

        private void GetDataFromForm()
        {
            supplierProductEL.Productid = Convert.ToInt32(cbProductName.SelectedValue);
            supplierProductEL.Supplierid = Convert.ToInt32(cbSupplierName.SelectedValue);
        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                categoryEL.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);
                categoryEL.Categoryname = row.Cells["Category Name"].Value.ToString();

                subCategoryEL.Subcategoryid = Convert.ToInt32(row.Cells["subcategoryid"].Value);
                subCategoryEL.Subcategoryname = row.Cells["Sub Category Name"].Value.ToString();
                subCategoryEL.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);


                productEL.Productid = Convert.ToInt32(row.Cells["productid"].Value);
                productEL.Productname = row.Cells["Product Name"].Value.ToString();
                productEL.Productdescription = row.Cells["Product Description"].Value.ToString();
                productEL.Productsku = row.Cells["Product SKU"].Value.ToString();
                productEL.Productprice = Convert.ToInt32(row.Cells["Product Price"].Value);
                productEL.Isdeleted = Convert.ToInt32(row.Cells["productsisdeleted"].Value);

                supplierEL.Supplierid = Convert.ToInt32(row.Cells["supplierid"].Value);
                supplierEL.Supplier = row.Cells["Supplier"].Value.ToString();
                supplierEL.Supplierid = Convert.ToInt32(row.Cells["isdeleted"].Value);

                supplierProductEL.Supplierproductid = Convert.ToInt32(row.Cells["Supplier Product ID"].Value);
                supplierProductEL.Supplierid = Convert.ToInt32(row.Cells["supplierid"].Value);
                supplierProductEL.Productid = Convert.ToInt32(row.Cells["productid"].Value);
            }

            txtSupplierProductID.Text = supplierProductEL.Supplierproductid.ToString();
            cbSupplierName.SelectedIndex = cbSupplierName.FindString(supplierEL.Supplier);
            cbCategoryName.SelectedIndex = cbCategoryName.FindString(categoryEL.Categoryname);
            cbSubCategoryName.SelectedIndex = cbSubCategoryName.FindString(subCategoryEL.Subcategoryname);
            cbProductName.SelectedIndex = cbProductName.FindString(productEL.Productname);

            txtProductSKU.Text = productEL.Productsku;
            txtProductPrice.Text = productEL.Productprice.ToString();
            txtProductDescription.Text = productEL.Productdescription;

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
            ShowMessageBox(supplierProductBL.Insert(supplierProductEL) > 0);
        }

        private void Edit()
        {
            ShowMessageBox(supplierProductBL.Update(supplierProductEL));
        }

        private void Delete()
        {
            ShowMessageBox(supplierProductBL.Delete(supplierProductEL));
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            ManageForm(true);
            this.ActiveControl = cbSubCategoryName;
            current = "ADD";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtSupplierProductID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                ManageForm(true);
                this.ActiveControl = cbSubCategoryName;
                current = "EDIT";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSupplierProductID.Text.Equals(""))
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

                if (supplierProductBL.CheckIfExisting(supplierProductEL).Rows.Count == 0)
                {
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
                else
                {
                    MessageBox.Show("Already existing.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageForm(false);
            ClearFields();
            ClearErrors();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateControlsSubCategory();
        }

        private void cbSubCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateControlsProducts();
        }

        private void cbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductInfo();
        }
    }
}
