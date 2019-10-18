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
            dgv.DataSource = SupplierProductBL.List(keywords);
        }

        private void PopulateControls()
        {
            cbCategoryName.DisplayMember = "Category Name";
            cbCategoryName.ValueMember = "Category ID";
            cbCategoryName.DataSource = CategoryBL.List("");

            cbSupplierName.DisplayMember = "Supplier";
            cbSupplierName.ValueMember = "Supplier ID";
            cbSupplierName.DataSource = SupplierBL.List("");
        }


        private void PopulateControlsSubCategory()
        {
            cbSubCategoryName.DisplayMember = "Sub Category Name";
            cbSubCategoryName.ValueMember = "Sub Category ID";
            cbSubCategoryName.DataSource = SubCategoryBL.List(Convert.ToInt32(cbCategoryName.SelectedValue));
        }

        private void PopulateControlsProducts()
        {
            cbProductName.DisplayMember = "Product Name";
            cbProductName.ValueMember = "Product ID";
            cbProductName.DataSource = InventoryBL.List(Convert.ToInt32(cbSubCategoryName.SelectedValue));
        }

        private void GetProductInfo()
        {
            if(!cbProductName.Text.Equals(""))
            {
                foreach (DataRow row in ProductBL.List(Convert.ToInt32(cbProductName.SelectedValue.ToString())).Rows)
                {
                    ProductInfo.Productsku = row["Product SKU"].ToString();
                    ProductInfo.Productprice = Convert.ToInt32(row["Product Price"].ToString());
                    ProductInfo.Productdescription = row["Product Description"].ToString();
                }

                txtProductSKU.Text = ProductInfo.Productsku;
                txtProductPrice.Text = ProductInfo.Productprice.ToString();
                txtProductDescription.Text = ProductInfo.Productdescription;
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
            cbSubCategoryName.SelectedIndex = -1;
            cbProductName.SelectedIndex = -1;
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
            SupplierProductInfo.Productid = Convert.ToInt32(cbSubCategoryName.SelectedValue);
            SupplierProductInfo.Supplierid = Convert.ToInt32(cbSupplierName.SelectedValue);
        }

        private void GetDataFromDataGridView()
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

            ShowMessageBox(SupplierProductBL.Insert(SupplierProductInfo) > 0);
        }

        private void Edit()
        {
            GetDataFromForm();

            ShowMessageBox(SupplierProductBL.Update(SupplierProductInfo));
        }

        private void Delete()
        {
            GetDataFromForm();

            ShowMessageBox(SupplierProductBL.Delete(SupplierProductInfo));
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

                if(SupplierProductBL.CheckIfExisting(SupplierProductInfo).Rows.Count == 0)
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
