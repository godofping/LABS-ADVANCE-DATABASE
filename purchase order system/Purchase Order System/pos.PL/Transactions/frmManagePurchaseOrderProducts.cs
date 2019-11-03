using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmManagePurchaseOrderProducts : Form
    {

        EL.Registrations.Categories categoryEL = new EL.Registrations.Categories();
        EL.Registrations.SubCategories subCategoryEL = new EL.Registrations.SubCategories();
        EL.Registrations.Products productEL = new EL.Registrations.Products();
        EL.Transactions.PurchaseOrderDetails purchaseOrderDetailEL = new EL.Transactions.PurchaseOrderDetails();

        BL.Registrations.Categories categoryBL = new BL.Registrations.Categories();
        BL.Registrations.SubCategories subCategoryBL = new BL.Registrations.SubCategories();
        BL.Registrations.Products productBL = new BL.Registrations.Products();
        BL.Transactions.PurchaseOrderDetails purchaseOrderDetailBL = new BL.Transactions.PurchaseOrderDetails();
        BL.Registrations.SupplierProducts supplierProductBL = new BL.Registrations.SupplierProducts();

        frmManagePurchaseOrders frmManagePurchaseOrders;

        string current = "";

        public frmManagePurchaseOrderProducts(frmManagePurchaseOrders _frmManagePurchaseOrders)
        {
            InitializeComponent();
            frmManagePurchaseOrders = _frmManagePurchaseOrders;
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

        private void PopulateControlsProducts()
        {
            cbProductName.DisplayMember = "Product Name";
            cbProductName.ValueMember = "Product ID";
            cbProductName.DataSource = supplierProductBL.List(Convert.ToInt32(frmManagePurchaseOrders.cbSupplierName.SelectedValue), Convert.ToInt32(cbSubCategoryName.SelectedValue));
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
            GetDataFromForm();

            ShowMessageBox(supplierProductBL.Insert(supplierProductEL) > 0);
        }

        private void Edit()
        {
            GetDataFromForm();

            ShowMessageBox(supplierProductBL.Update(supplierProductEL));
        }

        private void Delete()
        {
            GetDataFromForm();

            ShowMessageBox(supplierProductBL.Delete(supplierProductEL));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmManagePurchaseOrderProducts_Load(object sender, EventArgs e)
        {
            ReadOnlyControls();
            PopulateControls();
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

        }
    }
}
