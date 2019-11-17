using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageProducts : Form
    {

        #region "Variables"

        EL.Registrations.Products productEL = new EL.Registrations.Products();
        EL.Registrations.SubCategories subCategoryEL = new EL.Registrations.SubCategories();
        EL.Registrations.Categories categoryEL = new EL.Registrations.Categories();
        EL.Transactions.Inventories inventoryEL = new EL.Transactions.Inventories();
        BL.Registrations.Products productBL = new BL.Registrations.Products();
        BL.Registrations.SubCategories subCategoryBL = new BL.Registrations.SubCategories();
        BL.Registrations.Categories categoryBL = new BL.Registrations.Categories();
        BL.Transactions.Inventories inventoryBL = new BL.Transactions.Inventories();
        string current = "";

        #endregion



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

        #region "Methods"
        private void HiddenColumns()
        {
            dgv.Columns["Inventory ID"].Visible = false;
            dgv.Columns["Product ID"].Visible = false;
            dgv.Columns["categoryid"].Visible = false;
            dgv.Columns["subcategoriesisdeleted"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;
            dgv.Columns["subcategoryid"].Visible = false;
            dgv.Columns["categoriesisdeleted"].Visible = false;
        }

        private void LoadData(string keywords)
        {
            dgv.DataSource = inventoryBL.List(keywords);
        }

        private void PopulateControls()
        {
            cbCategoryName.DisplayMember = "Category Name";
            cbCategoryName.ValueMember = "Category ID";
            cbCategoryName.DataSource = categoryBL.List("");
        }

        private void PopulateControlsSubCategory()
        {
            cbSubCategoryName.DisplayMember = "Sub Category Name";
            cbSubCategoryName.ValueMember = "Sub Category ID";
            cbSubCategoryName.DataSource = subCategoryBL.List(Convert.ToInt32(cbCategoryName.SelectedValue));
        }

        private void ManageForm(bool status)
        {
            ManageFields(status);
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;
            dgv.Enabled = !status;
            txtSearch.Enabled = !status;

        }

        private void ManageFields(bool status)
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

        private void ClearErrors()
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

        private void ClearFields()
        {
            dgv.ClearSelection();
            txtProductID.ResetText();
            txtProductName.ResetText();
            txtProductDescription.ResetText();
            cbCategoryName.SelectedIndex = -1;
            cbSubCategoryName.ResetText();
            cbSubCategoryName.SelectedIndex = -1;
            cbSubCategoryName.DataSource = null;
            cbSubCategoryName.Items.Clear();
            txtProductSKU.ResetText();
            txtProductPrice.ResetText();
            txtReorderLevel.ResetText();
            txtInitialStock.ResetText();
        }

        private bool CheckErrors()
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

        private void GetDataFromForm()
        {
            productEL.Productname = txtProductName.Text;
            productEL.Productdescription = txtProductDescription.Text;
            productEL.Subcategoryid = Convert.ToInt32(cbSubCategoryName.SelectedValue);
            productEL.Productsku = txtProductSKU.Text;
            productEL.Productprice = Convert.ToSingle(txtProductPrice.Text);
            inventoryEL.Reorderlevel = Convert.ToInt32(txtReorderLevel.Text);
            inventoryEL.Quantityinstocks = Convert.ToInt32(txtInitialStock.Text);
        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                categoryEL.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);
                categoryEL.Categoryname = row.Cells["Category Name"].Value.ToString();

                subCategoryEL.Subcategoryid = Convert.ToInt32(row.Cells["subcategoryid"].Value);
                subCategoryEL.Subcategoryname = row.Cells["Sub Category Name"].Value.ToString();

                productEL.Productid = Convert.ToInt32(row.Cells["Product ID"].Value);
                productEL.Productname = row.Cells["Product Name"].Value.ToString();
                productEL.Productdescription = row.Cells["Product Description"].Value.ToString();
                productEL.Productsku = row.Cells["Product SKU"].Value.ToString();
                productEL.Productprice = Convert.ToSingle(row.Cells["Product Price"].Value);
                productEL.Isdeleted = Convert.ToInt32(row.Cells["isdeleted"].Value);

                inventoryEL.Inventoryid = Convert.ToInt32(row.Cells["Inventory ID"].Value);
                inventoryEL.Reorderlevel = Convert.ToInt32(row.Cells["Reorder Level"].Value);
                inventoryEL.Quantityinstocks = Convert.ToInt32(row.Cells["Quantity In Stocks"].Value);
            }

            txtProductID.Text = productEL.Productid.ToString();
            txtProductName.Text = productEL.Productname;
            txtProductDescription.Text = productEL.Productdescription;
            cbCategoryName.SelectedIndex = cbCategoryName.FindString(categoryEL.Categoryname);
            cbSubCategoryName.SelectedIndex = cbSubCategoryName.FindString(subCategoryEL.Subcategoryname);
            txtProductSKU.Text = productEL.Productsku;
            txtProductPrice.Text = productEL.Productprice.ToString();
            txtReorderLevel.Text = inventoryEL.Reorderlevel.ToString();
            txtInitialStock.Text = inventoryEL.Quantityinstocks.ToString();


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
        private void frmManageStaffs_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
            PopulateControls();
            ClearFields();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            current = "ADD";
            ClearFields();
            ManageForm(true);
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
                ManageForm(true);
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
                ShowMessageBox(productBL.Delete(productEL));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                if (current.Equals("ADD"))
                {
                    inventoryEL.Productid = Convert.ToInt32(productBL.Insert(productEL));
                    ShowMessageBox(inventoryBL.Insert(inventoryEL) > 0);
                }
                else if (current.Equals("EDIT"))
                {
                    ShowMessageBox(productBL.Update(productEL) & inventoryBL.Update(inventoryEL));
                }

                ManageForm(false);
                ClearFields();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            current = "";
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

        private void txtProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumWithSinglePoint(sender, e);
        }

        private void txtReorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumWithSinglePoint(sender, e);
        }

        private void txtInitialStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumWithSinglePoint(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateControlsSubCategory();
        }

        #endregion























    }
}
