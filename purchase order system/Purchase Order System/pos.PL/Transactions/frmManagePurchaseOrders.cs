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
    public partial class frmManagePurchaseOrders : Form
    {

        EL.Registrations.Suppliers SupplierInfo = new EL.Registrations.Suppliers();
        EL.Transactions.Purchaseorders PurchaseOrderInfo = new EL.Transactions.Purchaseorders();
        EL.Transactions.Purchaseorderdetails PurchaseOrderDetailInfo = new EL.Transactions.Purchaseorderdetails();

        BL.Registrations.Suppliers SupplierBL = new BL.Registrations.Suppliers();
        BL.Transactions.Purchaseorders PurchaseOrderBL = new BL.Transactions.Purchaseorders();
        BL.Transactions.Purchaseorderdetails PurchaseOrderDetailBL = new BL.Transactions.Purchaseorderdetails();

        frmManagePurchaseOrderProducts frmManagePurchaseOrderProducts;


        public frmManagePurchaseOrders()
        {
            InitializeComponent();
            frmManagePurchaseOrderProducts = new frmManagePurchaseOrderProducts(this);
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
            dgv.DataSource = PurchaseOrderBL.List(keywords);
        }

        public void manageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;
            dgv.Enabled = !status;
            txtSearch.Enabled = !status;
        }

        private void clearErrors()
        {
            errorProvider1.SetError(txtPurchaseOrderName, "");
            errorProvider1.SetError(cbPaymentMethod, "");
            errorProvider1.SetError(cbShippingMethod, "");
            errorProvider1.SetError(dtpDeliveryDate, "");
            errorProvider1.SetError(txtPurchaseOrderComment, "");
            errorProvider1.SetError(btnManagePurchaseOrderProducts, "");
        }


        private void disabledControls()
        {
            cbSupplierName.Enabled = false;
            txtTotalAmount.Enabled = false;
        }

        private void clearFields()
        {
            dgv.ClearSelection();
            txtPurchaseOrderID.ResetText();

            cbSupplierName.SelectedIndex = -1;
            cbSupplierName.Text = "";

            txtPurchaseOrderName.ResetText();

            cbPaymentMethod.SelectedIndex = -1;
            cbPaymentMethod.Text = "";

            cbShippingMethod.SelectedIndex = -1;
            cbShippingMethod.Text = "";

            dtpDeliveryDate.ResetText();
            txtPurchaseOrderComment.ResetText();

            txtTotalAmount.ResetText();

            
        }

        private bool checkErrors()
        {
            bool status = true;

            if (txtPurchaseOrderName.Text.Equals(""))
            {
                errorProvider1.SetError(txtPurchaseOrderName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtPurchaseOrderName, "");


            if (cbPaymentMethod.Text.Equals(""))
            {
                errorProvider1.SetError(cbPaymentMethod, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbPaymentMethod, "");


            if (cbShippingMethod.Text.Equals(""))
            {
                errorProvider1.SetError(cbShippingMethod, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbShippingMethod, "");

            if (dtpDeliveryDate.Text.Equals(""))
            {
                errorProvider1.SetError(dtpDeliveryDate, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(dtpDeliveryDate, "");


            if (txtPurchaseOrderComment.Text.Equals(""))
            {
                errorProvider1.SetError(txtPurchaseOrderComment, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtPurchaseOrderComment, "");


            if (frmManagePurchaseOrderProducts.dgv.Rows.Count == 0)
            {
                errorProvider1.SetError(btnManagePurchaseOrderProducts, "No selected products. Please add.");
                status = false;
            }
            else
                errorProvider1.SetError(btnManagePurchaseOrderProducts, "");

            return status;
        }

        private void getDataFromForm()
        {
            PurchaseOrderInfo.Purchaseordername = txtPurchaseOrderName.Text;
            PurchaseOrderInfo.Paymentmethodid = Convert.ToInt32(cbPaymentMethod.SelectedValue);
            PurchaseOrderInfo.Shippingmethodid = Convert.ToInt32(cbShippingMethod.SelectedValue);
            PurchaseOrderInfo.Purchaseorderdatedelivered = dtpDeliveryDate.Value.ToString("yyyy-MM-dd");
            PurchaseOrderInfo.Purchaseordercomment = txtPurchaseOrderComment.Text;

        }

        //private void getDataFromDataGridView()
        //{
        //    foreach (DataGridViewRow row in dgv.SelectedRows)
        //    {
        //        CategoryInfo.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);
        //        CategoryInfo.Categoryname = row.Cells["Category Name"].Value.ToString();

        //        SubCategoryInfo.Subcategoryid = Convert.ToInt32(row.Cells["subcategoryid"].Value);
        //        SubCategoryInfo.Subcategoryname = row.Cells["Sub Category Name"].Value.ToString();
        //        SubCategoryInfo.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);


        //        ProductInfo.Productid = Convert.ToInt32(row.Cells["productid"].Value);
        //        ProductInfo.Productname = row.Cells["Product Name"].Value.ToString();
        //        ProductInfo.Productdescription = row.Cells["Product Description"].Value.ToString();
        //        ProductInfo.Productsku = row.Cells["Product SKU"].Value.ToString();
        //        ProductInfo.Productprice = Convert.ToInt32(row.Cells["Product Price"].Value);
        //        ProductInfo.Isdeleted = Convert.ToInt32(row.Cells["productsisdeleted"].Value);

        //        SupplierInfo.Supplierid = Convert.ToInt32(row.Cells["supplierid"].Value);
        //        SupplierInfo.Supplier = row.Cells["Supplier"].Value.ToString();
        //        SupplierInfo.Supplierid = Convert.ToInt32(row.Cells["isdeleted"].Value);

        //        SupplierProductInfo.Supplierproductid = Convert.ToInt32(row.Cells["Supplier Product ID"].Value);
        //        SupplierProductInfo.Supplierid = Convert.ToInt32(row.Cells["supplierid"].Value);
        //        SupplierProductInfo.Productid = Convert.ToInt32(row.Cells["productid"].Value);
        //    }

        //    txtSupplierProductID.Text = SupplierProductInfo.Supplierproductid.ToString();
        //    cbSupplierName.SelectedIndex = cbSupplierName.FindString(SupplierInfo.Supplier);
        //    cbCategoryName.SelectedIndex = cbCategoryName.FindString(CategoryInfo.Categoryname);
        //    cbSubCategoryName.SelectedIndex = cbSubCategoryName.FindString(SubCategoryInfo.Subcategoryname);
        //    cbProductName.SelectedIndex = cbProductName.FindString(ProductInfo.Productname);

        //    txtProductSKU.Text = ProductInfo.Productsku;
        //    txtProductPrice.Text = ProductInfo.Productprice.ToString();
        //    txtProductDescription.Text = ProductInfo.Productdescription;

        //}

        private void showMessageBox(bool condition)
        {
            if (condition)
            {
                //loadData(txtSearch.Text);
                clearFields();
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void populateControls()
        {

            cbSupplierName.DisplayMember = "Supplier";
            cbSupplierName.ValueMember = "Supplier ID";
            cbSupplierName.DataSource = SupplierBL.List("");
        }

        private void btnManagePurchaseOrderProducts_Click(object sender, EventArgs e)
        {
            frmManagePurchaseOrderProducts.ShowDialog();
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSelectSupplier frmSelectSupplier = new frmSelectSupplier(this, SupplierInfo);
            frmSelectSupplier.ShowDialog();
        }

        private void frmManagePurchaseOrders_Load(object sender, EventArgs e)
        {
            disabledControls();
            populateControls();
            manageForm(false);
            clearFields();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            manageForm(false);
            clearFields();
            clearErrors();
        }


    }
}
