using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.Transactions.Reports
{
    public partial class frmReportPurchaseOrder : Form
    {
        BL.Transactions.PurchaseOrderDetails purchaseOrderDetailBL;

        EL.Transactions.PurchaseOrders purchaseOrderInfo;

        public frmReportPurchaseOrder(BL.Transactions.PurchaseOrderDetails PurchaseOrderDetailBL, EL.Transactions.PurchaseOrders PurchaseOrderInfo)
        {
            InitializeComponent();
            purchaseOrderDetailBL = PurchaseOrderDetailBL;
            purchaseOrderInfo = PurchaseOrderInfo;
        }

        private void viewReport()
        {
            Transactions.Reports.crPurchaseOrder crPurchaseOrder = new Transactions.Reports.crPurchaseOrder();
            Transactions.Reports.dsPurchaseOrder dsPurchaseOrder = new Transactions.Reports.dsPurchaseOrder();

            crPurchaseOrder.Database.Tables["purchaseorderdetails_view"].SetDataSource(purchaseOrderDetailBL.List(purchaseOrderInfo.Purchaseorderid));

            crvPurchaseOrder.ReportSource = null;
            crvPurchaseOrder.ReportSource = crPurchaseOrder;
            crvPurchaseOrder.Refresh();
        }

        private void frmReportPurchaseOrder_Load(object sender, EventArgs e)
        {
        viewReport();
        }
    }
}
