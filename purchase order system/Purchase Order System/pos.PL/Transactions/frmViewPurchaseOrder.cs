using System;
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



        BL.Transactions.PurchaseOrders purchaseOrderBL = new BL.Transactions.PurchaseOrders();
        BL.Transactions.PurchaseOrderDetails purchaseOrderDetailBL = new BL.Transactions.PurchaseOrderDetails();

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
            txtRequestDate.ReadOnly = true;
            txtDeliveryDate.ReadOnly = true;
            txtComment.ReadOnly = true;
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
            dgv.Columns["Purchase Order Date Delivered"].Visible = false;
            dgv.Columns["Purchase Order Date Requested"].Visible = false;
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
                purchaseOrderEL.Purchaseorderdaterequested = row.Cells["Purchase Order Date Requested"].Value.ToString();
                purchaseOrderEL.Purchaseorderdatedelivered = row.Cells["Purchase Order Date Delivered"].Value.ToString();
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
            txtRequestDate.Text = purchaseOrderEL.Purchaseorderdaterequested;
            txtDeliveryDate.Text = purchaseOrderEL.Purchaseorderdaterequested;
            txtComment.Text = purchaseOrderEL.Purchaseordercomment;

           
        }

        private void LoadData()
        {
            dgv.DataSource = purchaseOrderDetailBL.List(purchaseOrderEL.Purchaseorderid);
        }

        private void frmViewPurchaseOrder_Load(object sender, EventArgs e)
        {
            ReadOnlyControls();
            LoadData();
            HiddenColumns();
            getDataFromDataGridView();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
