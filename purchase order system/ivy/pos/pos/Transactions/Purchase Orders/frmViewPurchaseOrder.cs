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

        EL.Transactions.PurhcaseOrders purchaseOrderInfo;

        public frmViewPurchaseOrder(EL.Transactions.PurhcaseOrders PurchaseOrderInfo)
        {
            InitializeComponent();
            purchaseOrderInfo = PurchaseOrderInfo;
        }

        private void getDataFromDatabase()
        {
            foreach (DataRow row in purchaseOrderBL.List(purchaseOrderInfo.Purchaseorderid).Rows)
            {
                lblPurchaseOrderID.Text = row["Purchase Order ID"].ToString();
                lblSupplierName.Text = row["Supplier Name"].ToString();
                lblPurchaseName.Text = row["Purchase Order Name"].ToString();
                lblRequestDate.Text = Convert.ToDateTime(row["Purchase Order Request Date"].ToString()).ToShortDateString();
                lblDeliveryDate.Text = Convert.ToDateTime(row["Purchase Order Delivery Date"].ToString()).ToShortDateString();
                lblTotalAmount.Text = row["Purchase Order Total Amount"].ToString();
                lblPreparedBy.Text = row["Prepared By"].ToString();
                lblPurchaseOrderStatus.Text = row["Purchase Order Status"].ToString();

            }


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Printing...");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewPurchaseOrder_Load(object sender, EventArgs e)
        {
            getDataFromDatabase();
        }
    }
}
