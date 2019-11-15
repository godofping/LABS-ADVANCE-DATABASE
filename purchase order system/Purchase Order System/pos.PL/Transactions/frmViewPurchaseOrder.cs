using System;
using System.Data;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmViewPurchaseOrder : Form
    {
        EL.Transactions.PurchaseOrders purchaseOrderEL;
        EL.Transactions.PurchaseOrderDetails purchaseOrderDetailEL = new EL.Transactions.PurchaseOrderDetails();
        EL.Registrations.Suppliers supplierEL = new EL.Registrations.Suppliers();
        EL.Registrations.ShippingMethods shippingMethodEL = new EL.Registrations.ShippingMethods();
        EL.Registrations.PaymentMethods paymentMethodEL = new EL.Registrations.PaymentMethods();
        EL.Registrations.Staffs staffEL = new EL.Registrations.Staffs();
        EL.Registrations.BasicInformations basicInformationEL = new EL.Registrations.BasicInformations();
        EL.Registrations.Products productEL = new EL.Registrations.Products();
        EL.Transactions.Inventories inventoryEL = new EL.Transactions.Inventories();

        BL.Transactions.PurchaseOrders purchaseOrderBL = new BL.Transactions.PurchaseOrders();
        BL.Transactions.PurchaseOrderDetails purchaseOrderDetailBL = new BL.Transactions.PurchaseOrderDetails();
        BL.Registrations.Products productBL = new BL.Registrations.Products();
        BL.Transactions.Inventories inventoryBL = new BL.Transactions.Inventories();


        frmManagePurchaseOrders frmManagePurchaseOrders;
        public frmViewPurchaseOrder(frmManagePurchaseOrders _frmManagePurchaseOrders, EL.Transactions.PurchaseOrders _purchaseOrderEL)
        {
            InitializeComponent();
            frmManagePurchaseOrders = _frmManagePurchaseOrders;
            purchaseOrderEL = _purchaseOrderEL;
        }

        private void ReadOnlyControls()
        {
            txtPurchaseOrderID.ReadOnly = true;
            txtTotalAmount.ReadOnly = true;
            txtPurchaseOrderBy.ReadOnly = true;
            txtSupplierName.ReadOnly = true;
            txtPurchaseOrderName.ReadOnly = true;
            txtPaymentMethod.ReadOnly = true;
            txtShippingMethod.ReadOnly = true;
            txtDateRequested.ReadOnly = true;
            txtComment.ReadOnly = true;
            txtStatus.ReadOnly = true;
            txtDateReceived.ReadOnly = true;
        }

        private void HiddenColumns()
        {
            dgv.Columns["Product ID"].Visible = false;
            dgv.Columns["Purchase Order ID"].Visible = false;
            dgv.Columns["Purchase Order Detail ID"].Visible = false;
            dgv.Columns["Product Description"].Visible = false;
            dgv.Columns["Sub Category ID"].Visible = false;
            dgv.Columns["Produck SKU"].Visible = false;
            dgv.Columns["Product Price"].Visible = false;
            dgv.Columns["Product Is Deleted"].Visible = false;
            dgv.Columns["Sub Category Name"].Visible = false;
            dgv.Columns["Category ID"].Visible = false;
            dgv.Columns["Sub Categories Is Deleted"].Visible = false;
            dgv.Columns["Category Is Deleted"].Visible = false;
            dgv.Columns["Staff ID"].Visible = false;
            dgv.Columns["Purchase Order Name"].Visible = false;
            dgv.Columns["Purchase Order Supplier ID"].Visible = false;
            dgv.Columns["Payment Method ID"].Visible = false;
            dgv.Columns["Shipping Method ID"].Visible = false;
            dgv.Columns["Purchase Order Status"].Visible = false;
            dgv.Columns["Purchase Order Amount Paid"].Visible = false;
            dgv.Columns["Purchase Total Order Amount"].Visible = false;
            dgv.Columns["Date Received"].Visible = false;
            dgv.Columns["Date Requested"].Visible = false;
            dgv.Columns["Purchase Order Comment"].Visible = false;
            dgv.Columns["Purchase Order Is Deleted"].Visible = false;
            dgv.Columns["Supplier"].Visible = false;
            dgv.Columns["Supplier Contact Detail ID"].Visible = false;
            dgv.Columns["Supplier Is Deleted"].Visible = false;
            dgv.Columns["Staff Username"].Visible = false;
            dgv.Columns["Staff Password"].Visible = false;
            dgv.Columns["Staff Contact Detail ID"].Visible = false;
            dgv.Columns["Staff Basic Information ID"].Visible = false;
            dgv.Columns["Staff Position ID"].Visible = false;
            dgv.Columns["Staff Position"].Visible = false;
            dgv.Columns["First Name"].Visible = false;
            dgv.Columns["Middle Name"].Visible = false;
            dgv.Columns["Last Name"].Visible = false;
            dgv.Columns["Gender"].Visible = false;
            dgv.Columns["Birth Date"].Visible = false;
            dgv.Columns["Payment Method"].Visible = false;
            dgv.Columns["Shipping Method"].Visible = false;
        }

        private void getDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                purchaseOrderEL.Purchaseorderid = Convert.ToInt32(row.Cells["Purchase Order ID"].Value);
                supplierEL.Supplier = row.Cells["Supplier"].Value.ToString();
                purchaseOrderEL.Purchaseordername = row.Cells["Purchase Order Name"].Value.ToString();
                paymentMethodEL.Paymentmethod = row.Cells["Payment Method"].Value.ToString();
                shippingMethodEL.Shippingmethod = row.Cells["Shipping Method"].Value.ToString();
                purchaseOrderEL.Purchaseorderdaterequested = row.Cells["Date Requested"].Value.ToString();
                purchaseOrderEL.Purchaseorderdatereceived = row.Cells["Date Received"].Value.ToString();
                purchaseOrderEL.Purchaseordercomment = row.Cells["Purchase Order Comment"].Value.ToString();
                purchaseOrderEL.Purchasetotalorderamount = Convert.ToSingle(row.Cells["Purchase Total Order Amount"].Value);
                purchaseOrderEL.Purchaseorderamountpaid = Convert.ToSingle(row.Cells["Purchase Order Amount Paid"].Value);
                purchaseOrderEL.Purchaseorderstatus = row.Cells["Purchase Order Status"].Value.ToString();
                basicInformationEL.Firstname = row.Cells["First Name"].Value.ToString();
                basicInformationEL.Middlename = row.Cells["Middle Name"].Value.ToString();
                basicInformationEL.Lastname = row.Cells["Last Name"].Value.ToString();
            }

            txtPurchaseOrderID.Text = purchaseOrderEL.Purchaseorderid.ToString();
            txtTotalAmount.Text = purchaseOrderEL.Purchasetotalorderamount.ToString();
            txtPurchaseOrderBy.Text = basicInformationEL.Firstname + " " + basicInformationEL.Middlename + basicInformationEL.Lastname;
            txtSupplierName.Text = supplierEL.Supplier;
            txtPurchaseOrderName.Text = purchaseOrderEL.Purchaseordername;
            txtPaymentMethod.Text = paymentMethodEL.Paymentmethod;
            txtShippingMethod.Text = shippingMethodEL.Shippingmethod;
            txtDateRequested.Text = Convert.ToDateTime(purchaseOrderEL.Purchaseorderdaterequested).ToString("yyyy-MM-dd");
            txtDateReceived.Text = Convert.ToDateTime(purchaseOrderEL.Purchaseorderdatereceived).ToString("yyyy-MM-dd");
            txtComment.Text = purchaseOrderEL.Purchaseordercomment;
            txtTotalAmountPaid.Text = purchaseOrderEL.Purchaseorderamountpaid.ToString();
            txtStatus.Text = purchaseOrderEL.Purchaseorderstatus;

            if(txtDateReceived.Text.Equals("0001-01-01"))
            {
                txtDateReceived.ResetText();
            }

            



        }

        private void GetDataFromForm()
        {
            purchaseOrderEL.Purchaseorderamountpaid = Convert.ToSingle(txtTotalAmountPaid.Text);
        }

        private bool CheckErrors()
        {
            bool status = true;



            if (txtTotalAmountPaid.Text.Equals(""))
            {
                errorProvider1.SetError(txtTotalAmountPaid, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtTotalAmountPaid, "");

            return status;
        }

        private void LoadData()
        {
            dgv.DataSource = purchaseOrderDetailBL.List(purchaseOrderEL.Purchaseorderid);
        }

        private void ManageButtons()
        {
            if(purchaseOrderEL.Purchaseorderstatus.Equals("PENDING"))
            {
                btnReceive.Enabled = true;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                btnReceive.Enabled = false;
                btnCancel.Enabled = false;
                btnSave.Enabled = true;
            }
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

        private void frmViewPurchaseOrder_Load(object sender, EventArgs e)
        {
            ReadOnlyControls();
            LoadData();
            HiddenColumns();
            getDataFromDataGridView();
            ManageButtons();

        }

        private void ShowMessageBox(bool condition)
        {
            if (condition)
            {
                MessageBox.Show("Success");
                frmManagePurchaseOrders.LoadData(frmManagePurchaseOrders.txtSearch.Text);
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }


        private void UpdateStocks()
        {
            foreach (DataGridViewRow roow in dgv.Rows)
            {
                purchaseOrderDetailEL.Purchaseorderdetailid = Convert.ToInt32(roow.Cells["Purchase Order Detail ID"].Value);
                purchaseOrderDetailEL.Purchaseorderdetailquantity = Convert.ToInt32(roow.Cells["Quantity"].Value);
                purchaseOrderDetailEL.Productid = Convert.ToInt32(roow.Cells["Product ID"].Value);

                foreach (DataRow row in inventoryBL.List(purchaseOrderDetailEL.Productid).Rows)
                {
                    inventoryEL.Inventoryid = Convert.ToInt32(row["Inventory ID"]);
                    inventoryEL.Inventorylastupdated = DateTime.Now.ToString("yyyy-MM-dd");
                    inventoryEL.Quantityinstocks = Convert.ToInt32(row["Quantity In Stocks"]) + purchaseOrderDetailEL.Purchaseorderdetailquantity;
                    inventoryBL.UpdateStocks(inventoryEL);
                }
            }
        }

        private void Edit()
        {
            ShowMessageBox(purchaseOrderBL.Update(purchaseOrderEL));
        }

        private void Receive()
        {
            switch (MessageBox.Show(this, "Are you sure you received this purchase order?", "Confirming", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:

                    purchaseOrderEL.Purchaseorderstatus = "RECEIVED";
                    purchaseOrderEL.Purchaseorderdatereceived = DateTime.Now.ToString("yyyy-MM-dd");

                    if (purchaseOrderBL.Canceled(purchaseOrderEL))
                    {
             
                        frmManagePurchaseOrders.LoadData(frmManagePurchaseOrders.txtSearch.Text);
                        LoadData();
                        getDataFromDataGridView();
                        ManageButtons();
                        MessageBox.Show("Success.");
                    }
                    else
                    {
                        MessageBox.Show("Failed.");
                    }
                    break;
            }
        }

        private void Cancel()
        {
            switch (MessageBox.Show(this, "Are you sure you want to cancel this purchase order?", "Confirming", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:

                    purchaseOrderEL.Purchaseorderstatus = "CANCELED";


                    if (purchaseOrderBL.Received(purchaseOrderEL))
                    {
                        frmManagePurchaseOrders.LoadData(frmManagePurchaseOrders.txtSearch.Text);
                        LoadData();
                        getDataFromDataGridView();
                        ManageButtons();
                        MessageBox.Show("Success.");
                    }
                    else
                    {
                        MessageBox.Show("Failed.");
                    }
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                Edit();
            }
        }

        private void txtTotalAmountPaid_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            Receive();
        }

        private void btnCancele_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
