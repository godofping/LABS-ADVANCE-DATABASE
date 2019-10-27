using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.Transactions.Purchase_Orders
{
    public partial class frmViewPurchaseOrder : Form
    {
        BL.Transactions.PurchaseOrders purchaseOrderBL = new BL.Transactions.PurchaseOrders();
        BL.Transactions.PurchaseOrderDetails purchaseOrderDetailBL = new BL.Transactions.PurchaseOrderDetails();
        BL.Registrations.Supplies supplyBL = new BL.Registrations.Supplies();

        EL.Transactions.PurchaseOrders purchaseOrderInfo;
        EL.Registrations.Suppliers supplierInfo = new EL.Registrations.Suppliers();
        EL.Registrations.Accounts accountInfo = new EL.Registrations.Accounts();
        EL.Transactions.PurchaseOrderDetails purchaseOrderDetailInfo = new EL.Transactions.PurchaseOrderDetails();
        EL.Registrations.Supplies supplyInfo = new EL.Registrations.Supplies();


        frmPurchaseOrders frmPurchaseOrders;

        public frmViewPurchaseOrder(EL.Transactions.PurchaseOrders PurchaseOrderInfo, frmPurchaseOrders FrmPurchaseOrders)
        {
            InitializeComponent();
            purchaseOrderInfo = PurchaseOrderInfo;
            frmPurchaseOrders = FrmPurchaseOrders;
        }

        private void hiddenColumns()
        {
            dgv.Columns["Purchase Order Detail ID"].Visible = false;
            dgv.Columns["Purchase Order ID"].Visible = false;
            dgv.Columns["Supply ID"].Visible = false;
            dgv.Columns["Supplier ID"].Visible = false;
            dgv.Columns["Account ID"].Visible = false;
            dgv.Columns["Purchase Order Name"].Visible = false;
            dgv.Columns["Purchase Order Request Date"].Visible = false;
            dgv.Columns["Purchase Order Delivery Date"].Visible = false;
            dgv.Columns["Purchase Order Status"].Visible = false;
            dgv.Columns["Purchase Order Total Amount"].Visible = false;
            dgv.Columns["Supplier Name"].Visible = false;
            dgv.Columns["Supplier Contact Number"].Visible = false;
            dgv.Columns["Supplier Address"].Visible = false;
            dgv.Columns["Account Username"].Visible = false;
            dgv.Columns["Account password"].Visible = false;
            dgv.Columns["Account Full Name"].Visible = false;
            dgv.Columns["Supply Unit Price"].Visible = false;
            dgv.Columns["Supply Stocks"].Visible = false;
      
        }

        public void loadData(int id)
        {
            dgv.DataSource = purchaseOrderDetailBL.List(id);
        }

        private void getDataFromDatabase()
        {
            foreach (DataRow row in purchaseOrderBL.List(purchaseOrderInfo.Purchaseorderid).Rows)
            {
                purchaseOrderInfo.Purchaseorderid = Convert.ToInt32(row["Purchase Order ID"]);
                supplierInfo.Suppliername = row["Supplier Name"].ToString();
                purchaseOrderInfo.Purchaseordername = row["Purchase Order Name"].ToString();

                purchaseOrderInfo.Purchaseordertotalamount = Convert.ToSingle(row["Purchase Order Total Amount"]);
                accountInfo.Accountfullname = row["Prepared By"].ToString();
                purchaseOrderInfo.Purchaseorderstatus = row["Purchase Order Status"].ToString();
            }

            lblPurchaseOrderID.Text = purchaseOrderInfo.Purchaseorderid.ToString();
            lblSupplierName.Text = supplierInfo.Suppliername;
            lblPurchaseName.Text = purchaseOrderInfo.Purchaseordername;
            lblRequestDate.Text = DateTime.Parse(purchaseOrderInfo.Purchaseorderrequestdate).ToString("yyyy-MM-dd");
            lblDeliveryDate.Text = DateTime.Parse(purchaseOrderInfo.Purchaseorderdeliverydate).ToString("yyyy-MM-dd");
            lblTotalAmount.Text = purchaseOrderInfo.Purchaseordertotalamount.ToString();
            lblPreparedBy.Text = accountInfo.Accountfullname;
            lblPurchaseOrderStatus.Text = purchaseOrderInfo.Purchaseorderstatus;

            if(purchaseOrderInfo.Purchaseorderstatus.Equals("RECIEVED"))
            {
                btnRecieved.Enabled = false;
            }

        }

        private void updateStocks()
        {
            foreach (DataGridViewRow roow in dgv.Rows)
            {
                purchaseOrderDetailInfo.Purchaseorderdetailid = Convert.ToInt32(roow.Cells["Purchase Order Detail ID"].Value);
                purchaseOrderDetailInfo.Purchaseorderdetailquantity = Convert.ToInt32(roow.Cells["Purchase Order Supply Quantity"].Value);
                purchaseOrderDetailInfo.Supplyid = Convert.ToInt32(roow.Cells["Supply ID"].Value);

                foreach (DataRow row in supplyBL.List(purchaseOrderDetailInfo.Supplyid).Rows)
                {
                    supplyInfo.Supplyid = Convert.ToInt32(row["Supply ID"]);
                    supplyInfo.Supplyname = row["Supply Name"].ToString();
                    supplyInfo.Supplyunit = row["Supply Unit"].ToString();
                    supplyInfo.Supplyunitprice = Convert.ToSingle(row["Supply Unit Price"]);
                    supplyInfo.Supplystocks = Convert.ToInt32(row["Supply Stocks"]) + purchaseOrderDetailInfo.Purchaseorderdetailquantity;

                    supplyBL.Edit(supplyInfo);

                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Printing...");
        }

       

        private void frmViewPurchaseOrder_Load(object sender, EventArgs e)
        {
            getDataFromDatabase();
            loadData(purchaseOrderInfo.Purchaseorderid);
            hiddenColumns();
        }

        private void btnRecieved_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Confirming to update the Purchase Order Status to 'RECIEVED'. This changes is final.", "Confirming", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
     
                    if (purchaseOrderBL.SetRecieved(purchaseOrderInfo.Purchaseorderid))
                    {
                        getDataFromDatabase();
                        updateStocks();
                        frmPurchaseOrders.loadData(frmPurchaseOrders.txtSearch.Text);
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
    }
}
