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

        #region "Variables"

        EL.Registrations.Categories categoryEL = new EL.Registrations.Categories();
        EL.Registrations.SubCategories subCategoryEL = new EL.Registrations.SubCategories();
        EL.Registrations.Products productEL = new EL.Registrations.Products();
        EL.Transactions.PurchaseOrderDetails purchaseOrderDetailEL = new EL.Transactions.PurchaseOrderDetails();
        EL.Transactions.Inventories inventoryEL = new EL.Transactions.Inventories();
        BL.Registrations.Categories categoryBL = new BL.Registrations.Categories();
        BL.Registrations.SubCategories subCategoryBL = new BL.Registrations.SubCategories();
        BL.Registrations.Products productBL = new BL.Registrations.Products();
        BL.Transactions.PurchaseOrderDetails purchaseOrderDetailBL = new BL.Transactions.PurchaseOrderDetails();
        BL.Registrations.SupplierProducts supplierProductBL = new BL.Registrations.SupplierProducts();
        BL.Transactions.Inventories inventoryBL = new BL.Transactions.Inventories();
        frmManagePurchaseOrders frmManagePurchaseOrders;
        string current = "";

        #endregion

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

        #region "Methods"
        private void ReadOnlyControls()
        {
            txtProductSKU.ReadOnly = true;
            txtProductDescription.ReadOnly = true;
            txtCurrentStock.ReadOnly = true;
            txtReorderLevel.ReadOnly = true;

        }

        private void PopulateControls()
        {
            cbCategoryName.DisplayMember = "Category Name";
            cbCategoryName.ValueMember = "categoryid";
            cbCategoryName.DataSource = supplierProductBL.List(Convert.ToInt32(frmManagePurchaseOrders.cbSupplierName.SelectedValue));
        }


        private void PopulateControlsSubCategory()
        {
            cbSubCategoryName.DisplayMember = "Sub Category Name";
            cbSubCategoryName.ValueMember = "subcategoryid";
            cbSubCategoryName.DataSource = supplierProductBL.Lists(Convert.ToInt32(frmManagePurchaseOrders.cbSupplierName.SelectedValue), Convert.ToInt32(cbCategoryName.SelectedValue));
        }

        private void PopulateControlsProducts()
        {
            cbProductName.DisplayMember = "Product Name";
            cbProductName.ValueMember = "productid";
            cbProductName.DataSource = supplierProductBL.List(Convert.ToInt32(frmManagePurchaseOrders.cbSupplierName.SelectedValue), Convert.ToInt32(cbSubCategoryName.SelectedValue));
        }

        private void GetProductInfo()
        {
            if (!cbProductName.Text.Equals(""))
            {
                foreach (DataRow row in inventoryBL.List(Convert.ToInt32(cbProductName.SelectedValue.ToString())).Rows)
                {
                    productEL.Productsku = row["Product SKU"].ToString();
                    productEL.Productprice = Convert.ToInt32(row["Product Price"]);
                    productEL.Productdescription = row["Product Description"].ToString();
                    inventoryEL.Quantityinstocks = Convert.ToInt32(row["Quantity In Stocks"]);
                    inventoryEL.Reorderlevel = Convert.ToInt32(row["Reorder Level"]);
                }

                txtProductSKU.Text = productEL.Productsku;
                txtProductPrice.Text = productEL.Productprice.ToString();
                txtProductDescription.Text = productEL.Productdescription;
                txtCurrentStock.Text = inventoryEL.Quantityinstocks.ToString();
                txtReorderLevel.Text = inventoryEL.Reorderlevel.ToString();
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

            if (current.Equals("EDIT"))
            {
                cbCategoryName.Enabled = false;
                cbSubCategoryName.Enabled = false;
                cbProductName.Enabled = false;
            }
            else
            {
                cbCategoryName.Enabled = true;
                cbSubCategoryName.Enabled = true;
                cbProductName.Enabled = true;
            }
        }

        private void ClearErrors()
        {
            errorProvider1.SetError(cbCategoryName, "");
            errorProvider1.SetError(cbSubCategoryName, "");
            errorProvider1.SetError(cbProductName, "");
            errorProvider1.SetError(txtProductPrice, "");
            errorProvider1.SetError(txtQuantity, "");
        }

        private void ClearFields()
        {
            dgv.ClearSelection();

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

            txtProductPrice.ResetText();
            txtQuantity.ResetText();


            ClearExtendedFields();
        }

        private void ClearExtendedFields()
        {
            txtProductSKU.ResetText();
            txtProductPrice.ResetText();
            txtProductDescription.ResetText();
            txtCurrentStock.ResetText();
            txtReorderLevel.ResetText();
        }

        private bool CheckErrors()
        {
            bool status = true;

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

            if (txtProductPrice.Text.Equals(""))
            {
                errorProvider1.SetError(txtProductPrice, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProductPrice, "");

            if (txtQuantity.Text.Equals(""))
            {
                errorProvider1.SetError(txtQuantity, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtQuantity, "");

            return status;
        }

        private void GetDataFromForm()
        {
            purchaseOrderDetailEL.Productid = Convert.ToInt32(cbProductName.SelectedValue);
            purchaseOrderDetailEL.Purchaseorderdetailquantity = Convert.ToInt32(txtQuantity.Text);
            purchaseOrderDetailEL.Purchaseorderdetailprice = Convert.ToSingle(txtProductPrice.Text);
            productEL.Productname = cbProductName.Text;
            categoryEL.Categoryname = cbCategoryName.Text;
            subCategoryEL.Subcategoryname = cbSubCategoryName.Text;
        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                purchaseOrderDetailEL.Productid = Convert.ToInt32(row.Cells["productid"].Value);
                purchaseOrderDetailEL.Purchaseorderdetailquantity = Convert.ToInt32(row.Cells["purchaseorderdetailquantity"].Value);
                purchaseOrderDetailEL.Purchaseorderdetailprice = Convert.ToSingle(row.Cells["purchaseorderdetailprice"].Value);
                categoryEL.Categoryname = row.Cells["categoryname"].Value.ToString();
                subCategoryEL.Subcategoryname = row.Cells["subcategoryname"].Value.ToString();
                productEL.Productname = row.Cells["subcategoryname"].Value.ToString();
            }

            cbCategoryName.Text = categoryEL.Categoryname;
            cbSubCategoryName.Text = subCategoryEL.Subcategoryname;
            cbProductName.Text = productEL.Productname;

            txtProductPrice.Text = purchaseOrderDetailEL.Purchaseorderdetailprice.ToString();
            txtQuantity.Text = purchaseOrderDetailEL.Purchaseorderdetailquantity.ToString();

        }

        private bool CheckIfHasDuplicate()
        {
            bool bol = false;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == purchaseOrderDetailEL.Productid)
                {
                    bol = true;
                }
            }

            return bol;

        }

        private void GetTotalAmount()
        {
            lblTotalAmount.Text = dgv.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();
            frmManagePurchaseOrders.txtTotalAmount.Text = dgv.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();
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

        private void ShowMessageBox(bool condition)
        {
            if (condition)
            {
                ClearFields();
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
        #endregion











        #region "Events"
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmManagePurchaseOrderProducts_Load(object sender, EventArgs e)
        {

            ManageForm(false);
            PopulateControls();
            ClearFields();
            ReadOnlyControls();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                if (current.Equals("ADD"))
                {
                    if (CheckIfHasDuplicate())
                    {
                        MessageBox.Show("This item is already added.");
                    }
                    else
                    {
                        ShowMessageBox(dgv.Rows.Add(purchaseOrderDetailEL.Productid, productEL.Productname, purchaseOrderDetailEL.Purchaseorderdetailprice, purchaseOrderDetailEL.Purchaseorderdetailquantity, purchaseOrderDetailEL.Purchaseorderdetailprice * purchaseOrderDetailEL.Purchaseorderdetailquantity, categoryEL.Categoryname, subCategoryEL.Subcategoryname) != -1);
                    }
                }
                else if (current.Equals("EDIT"))
                {
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                    {
                        row.Cells["purchaseorderdetailprice"].Value = purchaseOrderDetailEL.Purchaseorderdetailprice;
                        row.Cells["purchaseorderdetailquantity"].Value = purchaseOrderDetailEL.Purchaseorderdetailquantity;
                        row.Cells["amount"].Value = purchaseOrderDetailEL.Purchaseorderdetailprice * purchaseOrderDetailEL.Purchaseorderdetailquantity;
                    }
                }

                ManageForm(false);
                ClearFields();
                GetTotalAmount();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageForm(false);
            ClearFields();
            ClearErrors();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            current = "ADD";
            ClearFields();
            ManageForm(true);
            this.ActiveControl = cbCategoryName;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("No selected item.");
            }
            else
            {
                current = "EDIT";
                ManageForm(true);
                this.ActiveControl = cbCategoryName;

            }
        }

      


        private void txtProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumWithSinglePoint(sender, e);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumWithSinglePoint(sender, e);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            GetDataFromDataGridView();
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
                        dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                        GetTotalAmount();
                        ClearFields();
                        break;
                }
            }
        }


        #endregion


    }
}
