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
    public partial class frmViewPurchaseOrder : Form
    {
        EL.Transactions.PurchaseOrders purchaseOrderEL = new EL.Transactions.PurchaseOrders();

        public frmViewPurchaseOrder(EL.Transactions.PurchaseOrders _purchaseOrderEL)
        {
            InitializeComponent();
            purchaseOrderEL = _purchaseOrderEL;
        }

        private void ReadOnlyControls()
        {
            txtPurchaseOrderID.ReadOnly = true;
            txtSupplierName.ReadOnly = true;
            txtPurchaseOrderName.ReadOnly = true;
            txtPaymentMethod.ReadOnly = true;
            txtShippingMethod.ReadOnly = true;
            txtRequestDate.ReadOnly = true;
            txtDeliveryDate.ReadOnly = true;
            txtComment.ReadOnly = true;
        }

        private void frmViewPurchaseOrder_Load(object sender, EventArgs e)
        {
            ReadOnlyControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
