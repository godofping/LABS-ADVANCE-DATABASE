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
    public partial class frmCrystalReportViewerPurchaseOrder : Form
    {
        BL.Transactions.PurchaseOrderDetails purchaseOrderDetailBL = new BL.Transactions.PurchaseOrderDetails();
        BL.Registrations.StoreInformation storeInformationBL = new BL.Registrations.StoreInformation();

        EL.Transactions.PurchaseOrders purchaseOrderEL;
        EL.Transactions.PurchaseOrderDetails purchaseOrderDetailEL = new EL.Transactions.PurchaseOrderDetails();
        EL.Registrations.StoreInformation storeInformationEL = new EL.Registrations.StoreInformation();

        public frmCrystalReportViewerPurchaseOrder(EL.Transactions.PurchaseOrders _purchaseOrderEL)
        {
            InitializeComponent();
            purchaseOrderEL = _purchaseOrderEL;
        }

        private void LoadReport()
        {        
            crPurchaseOrder crPurchaseOrder = new crPurchaseOrder();
            dsPurchaseOrder dsPurchaseOrder = new dsPurchaseOrder();


            crPurchaseOrder.Database.Tables["dtPurchaseorderdetails_view"].SetDataSource(purchaseOrderDetailBL.List(purchaseOrderEL.Purchaseorderid));
            crPurchaseOrder.Database.Tables["dtStoreinformation_view"].SetDataSource(storeInformationBL.List());

            crvPurchaseOrder.ReportSource = null;
            crvPurchaseOrder.ReportSource = crPurchaseOrder;
            crvPurchaseOrder.Refresh();
        }

        private void frmCrystalReportViewerPurchaseOrder_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
