using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageProducts : Form
    {
        EL.Registrations.Products ProductInfo = new EL.Registrations.Products();
        EL.Registrations.Subcategories SubCategoryInfo = new EL.Registrations.Subcategories();
        EL.Registrations.Categories CategoryInfo = new EL.Registrations.Categories();
        EL.Transactions.Inventories InventoryInfo = new EL.Transactions.Inventories();

        BL.Registrations.Products ProductBL = new BL.Registrations.Products();
        BL.Registrations.Subcategories SubCategoryBL = new BL.Registrations.Subcategories();
        BL.Registrations.Categories CategoryBL = new BL.Registrations.Categories();
        BL.Transactions.Inventories InventoryBL = new BL.Transactions.Inventories();

        string current = "";

        public frmManageProducts()
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
        }

        private void hiddenColumns()
        {
            dgv.Columns["Inventory ID"].Visible = false;
            dgv.Columns["Product ID"].Visible = false;
            dgv.Columns["categoryid"].Visible = false;
            dgv.Columns["subcategoriesisdeleted"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;
            dgv.Columns["subcategoryid"].Visible = false;
            dgv.Columns["categoriesisdeleted"].Visible = false;
        }

        private void loadData(string keywords)
        {
            dgv.DataSource = InventoryBL.List(keywords);
        }

        private void populateControls()
        {
            cbCategoryName.DisplayMember = "Category Name";
            cbCategoryName.ValueMember = "Category ID";
            cbCategoryName.DataSource = CategoryBL.List("");
        }

        private void populateControlsSubCategory()
        {
            cbSubCategoryName.DisplayMember = "Sub Category Name";
            cbSubCategoryName.ValueMember = "Sub Category ID";
            cbSubCategoryName.DataSource = SubCategoryBL.List(Convert.ToInt32(cbCategoryName.SelectedValue));
        }

        private void manageForm(bool status)
        {
            manageFields(status);
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;
            dgv.Enabled = !status;
            txtSearch.Enabled = !status;
            
        }

        private void manageFields(bool status)
        {
            if (current.Equals("ADD"))
            {
                lblInitialStocks.Visible = status;
                txtInitialStock.Visible = status;

                lblReorderLevel.Visible = status;
                txtReorderLevel.Visible = status;
            }
            else if (current.Equals("EDIT"))
            {
                lblInitialStocks.Visible = !status;
                txtInitialStock.Visible = !status;

                lblReorderLevel.Visible = status;
                txtReorderLevel.Visible = status;
            }
            else if (current.Equals(""))
            {
                lblInitialStocks.Visible = status;
                txtInitialStock.Visible = status;

                lblReorderLevel.Visible = status;
                txtReorderLevel.Visible = status;
            }



        }

            private void clearErrors()
        {
            errorProvider1.SetError(txtProductName, "");
            errorProvider1.SetError(txtProductDescription, "");
            errorProvider1.SetError(cbCategoryName, "");
            errorProvider1.SetError(cbSubCategoryName, "");
            errorProvider1.SetError(txtProductSKU, "");
            errorProvider1.SetError(txtProductPrice, "");
            errorProvider1.SetError(txtReorderLevel, "");
            errorProvider1.SetError(txtInitialStock, "");

        }

        private void clearFields()
        {
            dgv.ClearSelection();
            txtProductID.ResetText();
            txtProductName.ResetText();
            txtProductDescription.ResetText();
            cbCategoryName.SelectedIndex = -1;
            cbSubCategoryName.SelectedIndex = -1;
            txtProductSKU.ResetText();
            txtProductPrice.ResetText();
            txtReorderLevel.ResetText();
            txtInitialStock.ResetText();
        }

        private bool checkErrors()
        {
            bool status = true;

            if (txtProductName.Text.Equals(""))
            {
                errorProvider1.SetError(txtProductName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProductName, "");


            if (txtProductDescription.Text.Equals(""))
            {
                errorProvider1.SetError(txtProductDescription, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProductDescription, "");


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


            if (txtProductSKU.Text.Equals(""))
            {
                errorProvider1.SetError(txtProductSKU, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProductSKU, "");


            if (txtProductPrice.Text.Equals(""))
            {
                errorProvider1.SetError(txtProductPrice, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProductPrice, "");


            if (txtReorderLevel.Text.Equals("") & txtReorderLevel.Visible)
            {
                errorProvider1.SetError(txtReorderLevel, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtReorderLevel, "");

            if (txtInitialStock.Text.Equals("") & txtInitialStock.Visible)
            {
                errorProvider1.SetError(txtInitialStock, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtInitialStock, "");

            return status;
        }

        private void getDataFromForm()
        {
            ProductInfo.Productname = txtProductName.Text;
            ProductInfo.Productdescription = txtProductDescription.Text;
            ProductInfo.Subcategoryid = Convert.ToInt32(cbSubCategoryName.SelectedValue);
            ProductInfo.Productsku = txtProductSKU.Text;
            ProductInfo.Productprice = Convert.ToSingle(txtProductPrice.Text);
            InventoryInfo.Reorderlevel = Convert.ToInt32(txtReorderLevel.Text);
            InventoryInfo.Quantityinstocks = Convert.ToInt32(txtInitialStock.Text);
        }

        private void getDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                CategoryInfo.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);
                CategoryInfo.Categoryname = row.Cells["Category Name"].Value.ToString();

                SubCategoryInfo.Subcategoryid = Convert.ToInt32(row.Cells["subcategoryid"].Value);
                SubCategoryInfo.Subcategoryname = row.Cells["Sub Category Name"].Value.ToString();

                ProductInfo.Productid = Convert.ToInt32(row.Cells["Product ID"].Value);
                ProductInfo.Productname = row.Cells["Product Name"].Value.ToString();
                ProductInfo.Productdescription = row.Cells["Product Description"].Value.ToString();
                ProductInfo.Productsku = row.Cells["Product SKU"].Value.ToString();
                ProductInfo.Productprice = Convert.ToSingle(row.Cells["Product Price"].Value);
                ProductInfo.Isdeleted = Convert.ToInt32(row.Cells["isdeleted"].Value);

                InventoryInfo.Inventoryid = Convert.ToInt32(row.Cells["Inventory ID"].Value);
                InventoryInfo.Reorderlevel = Convert.ToInt32(row.Cells["Reorder Level"].Value);
                InventoryInfo.Quantityinstocks = Convert.ToInt32(row.Cells["Quantity In Stocks"].Value);
            }

            txtProductID.Text = ProductInfo.Productid.ToString();
            txtProductName.Text = ProductInfo.Productname;
            txtProductDescription.Text = ProductInfo.Productdescription;
            cbCategoryName.SelectedIndex = cbCategoryName.FindString(CategoryInfo.Categoryname);
            cbSubCategoryName.SelectedIndex = cbSubCategoryName.FindString(SubCategoryInfo.Subcategoryname);
            txtProductSKU.Text = ProductInfo.Productsku;
            txtProductPrice.Text = ProductInfo.Productprice.ToString();
            txtReorderLevel.Text = InventoryInfo.Reorderlevel.ToString();
            txtInitialStock.Text = InventoryInfo.Quantityinstocks.ToString();


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

            InventoryInfo.Productid = Convert.ToInt32(ProductBL.Insert(ProductInfo));
            showMessageBox(InventoryBL.Insert(InventoryInfo) > 0);
        }

        private void edit()
        {
            getDataFromForm();

            showMessageBox(ProductBL.Update(ProductInfo) & InventoryBL.Update(InventoryInfo));
        }

        private void delete()
        {
            getDataFromForm();

            showMessageBox(ProductBL.Delete(ProductInfo));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            current = "ADD";
            clearFields();
            manageForm(true);
            this.ActiveControl = txtProductName;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                current = "EDIT";
                manageForm(true);
                this.ActiveControl = txtProductName;
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text.Equals(""))
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
            current = "";
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

        private void txtProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txtReorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txtInitialStock_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateControlsSubCategory();

        }

       
    }
}
