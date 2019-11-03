using System;
using System.Data;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageSupplierProducts : Form
    {
        EL.Registrations.Supplierproducts SupplierProductInfo = new EL.Registrations.Supplierproducts();
        EL.Registrations.Products ProductInfo = new EL.Registrations.Products();
        EL.Registrations.Suppliers SupplierInfo = new EL.Registrations.Suppliers();
        EL.Transactions.Inventories InventoryInfo = new EL.Transactions.Inventories();
        EL.Registrations.Categories CategoryInfo = new EL.Registrations.Categories();
        EL.Registrations.Subcategories SubCategoryInfo = new EL.Registrations.Subcategories();

        BL.Registrations.Supplierproducts SupplierProductBL = new BL.Registrations.Supplierproducts();
        BL.Registrations.Products ProductBL = new BL.Registrations.Products();
        BL.Registrations.Suppliers SupplierBL = new BL.Registrations.Suppliers();
        BL.Transactions.Inventories InventoryBL = new BL.Transactions.Inventories();
        BL.Registrations.Categories CategoryBL = new BL.Registrations.Categories();
        BL.Registrations.Subcategories SubCategoryBL = new BL.Registrations.Subcategories();

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
            loadData(txtSearch.Text);
            hiddenColumns();
            manageForm(false);
            populateControls();
            clearFields();
            readOnlyControls();
        }

        private void readOnlyControls()
        {
            txtProductSKU.ReadOnly = true;
            txtProductPrice.ReadOnly = true;
            txtProductDescription.ReadOnly = true;

        }

        private void hiddenColumns()
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

        private void loadData(string keywords)
        {
            dgv.DataSource = SupplierProductBL.List(keywords);
        }

        private void populateControls()
        {
            cbCategoryName.DisplayMember = "Category Name";
            cbCategoryName.ValueMember = "Category ID";
            cbCategoryName.DataSource = CategoryBL.List("");

            cbSupplierName.DisplayMember = "Supplier";
            cbSupplierName.ValueMember = "Supplier ID";
            cbSupplierName.DataSource = SupplierBL.List("");
        }


        private void populateControlsSubCategory()
        {
            cbSubCategoryName.DisplayMember = "Sub Category Name";
            cbSubCategoryName.ValueMember = "Sub Category ID";
            cbSubCategoryName.DataSource = SubCategoryBL.List(Convert.ToInt32(cbCategoryName.SelectedValue));
        }

        private void populateControlsProducts()
        {
            cbProductName.DisplayMember = "Product Name";
            cbProductName.ValueMember = "Product ID";
            cbProductName.DataSource = InventoryBL.List(Convert.ToInt32(cbSubCategoryName.SelectedValue));
        }

        private void getProductInfo()
        {
            if (!cbProductName.Text.Equals(""))
            {
                foreach (DataRow row in ProductBL.List(Convert.ToInt32(cbProductName.SelectedValue.ToString())).Rows)
                {
                    ProductInfo.Productsku = row["Product SKU"].ToString();
                    ProductInfo.Productprice = Convert.ToInt32(row["Product Price"]);
                    ProductInfo.Productdescription = row["Product Description"].ToString();
                }

                txtProductSKU.Text = ProductInfo.Productsku;
                txtProductPrice.Text = ProductInfo.Productprice.ToString();
                txtProductDescription.Text = ProductInfo.Productdescription;
            }
            else
            {
                clearExtendedFields();
            }

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
            errorProvider1.SetError(cbSupplierName, "");
            errorProvider1.SetError(cbProductName, "");
            errorProvider1.SetError(cbSubCategoryName, "");
            errorProvider1.SetError(cbProductName, "");
        }

        private void clearFields()
        {
            dgv.ClearSelection();
            txtSupplierProductID.ResetText();
            cbSupplierName.SelectedIndex = -1;
            cbCategoryName.SelectedIndex = -1;
            cbSubCategoryName.SelectedIndex = -1;
            cbProductName.SelectedIndex = -1;
            clearExtendedFields();
        }

        private void clearExtendedFields()
        {
            txtProductSKU.ResetText();
            txtProductPrice.ResetText();
            txtProductDescription.ResetText();
        }

        private bool checkErrors()
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

        private void getDataFromForm()
        {
            SupplierProductInfo.Productid = Convert.ToInt32(cbProductName.SelectedValue);
            SupplierProductInfo.Supplierid = Convert.ToInt32(cbSupplierName.SelectedValue);
        }

        private void getDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                CategoryInfo.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);
                CategoryInfo.Categoryname = row.Cells["Category Name"].Value.ToString();

                SubCategoryInfo.Subcategoryid = Convert.ToInt32(row.Cells["subcategoryid"].Value);
                SubCategoryInfo.Subcategoryname = row.Cells["Sub Category Name"].Value.ToString();
                SubCategoryInfo.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);


                ProductInfo.Productid = Convert.ToInt32(row.Cells["productid"].Value);
                ProductInfo.Productname = row.Cells["Product Name"].Value.ToString();
                ProductInfo.Productdescription = row.Cells["Product Description"].Value.ToString();
                ProductInfo.Productsku = row.Cells["Product SKU"].Value.ToString();
                ProductInfo.Productprice = Convert.ToInt32(row.Cells["Product Price"].Value);
                ProductInfo.Isdeleted = Convert.ToInt32(row.Cells["productsisdeleted"].Value);

                SupplierInfo.Supplierid = Convert.ToInt32(row.Cells["supplierid"].Value);
                SupplierInfo.Supplier = row.Cells["Supplier"].Value.ToString();
                SupplierInfo.Supplierid = Convert.ToInt32(row.Cells["isdeleted"].Value);

                SupplierProductInfo.Supplierproductid = Convert.ToInt32(row.Cells["Supplier Product ID"].Value);
                SupplierProductInfo.Supplierid = Convert.ToInt32(row.Cells["supplierid"].Value);
                SupplierProductInfo.Productid = Convert.ToInt32(row.Cells["productid"].Value);
            }

            txtSupplierProductID.Text = SupplierProductInfo.Supplierproductid.ToString();
            cbSupplierName.SelectedIndex = cbSupplierName.FindString(SupplierInfo.Supplier);
            cbCategoryName.SelectedIndex = cbCategoryName.FindString(CategoryInfo.Categoryname);
            cbSubCategoryName.SelectedIndex = cbSubCategoryName.FindString(SubCategoryInfo.Subcategoryname);
            cbProductName.SelectedIndex = cbProductName.FindString(ProductInfo.Productname);

            txtProductSKU.Text = ProductInfo.Productsku;
            txtProductPrice.Text = ProductInfo.Productprice.ToString();
            txtProductDescription.Text = ProductInfo.Productdescription;

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

            showMessageBox(SupplierProductBL.Insert(SupplierProductInfo) > 0);
        }

        private void edit()
        {
            getDataFromForm();

            showMessageBox(SupplierProductBL.Update(SupplierProductInfo));
        }

        private void delete()
        {
            getDataFromForm();

            showMessageBox(SupplierProductBL.Delete(SupplierProductInfo));
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearFields();
            manageForm(true);
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
                manageForm(true);
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
                delete();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkErrors())
            {
                getDataFromForm();

                if (SupplierProductBL.CheckIfExisting(SupplierProductInfo).Rows.Count == 0)
                {
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
                else
                {
                    MessageBox.Show("Already existing.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            manageForm(false);
            clearFields();
            clearErrors();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            getDataFromDataGridView();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDataGridView();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadData(txtSearch.Text);
        }

        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateControlsSubCategory();
        }

        private void cbSubCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateControlsProducts();
        }

        private void cbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            getProductInfo();
        }
    }
}
