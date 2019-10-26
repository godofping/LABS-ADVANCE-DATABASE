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
    public partial class frmPurchaseOrders : Form
    {
        BL.Transactions.PurchaseOrders purchaseOrderBL = new BL.Transactions.PurchaseOrders();
        BL.Transactions.PurchaseOrderDetails purchaseOrderDetailBL = new BL.Transactions.PurchaseOrderDetails();

        EL.Transactions.PurhcaseOrders purchaseOrderInfo = new EL.Transactions.PurhcaseOrders();
        EL.Transactions.PurchaseOrderDetails purchaseOrderDetailInfo = new EL.Transactions.PurchaseOrderDetails();

        EL.Registrations.Accounts accountInfo;

        public frmPurchaseOrders(EL.Registrations.Accounts AccountInfo)
        {
            InitializeComponent();
            accountInfo = AccountInfo;
        }

        private void hiddenColumns()
        {
            dgv.Columns["Supplier ID"].Visible = false;
            dgv.Columns["Account ID"].Visible = false;
            dgv.Columns["Account Username"].Visible = false;
            dgv.Columns["Account Password"].Visible = false;
        }

        public void loadData(string keywords)
        {
            dgv.DataSource = purchaseOrderBL.List(keywords);
        }

        private void getDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                purchaseOrderInfo.Purchaseorderid =  Convert.ToInt32(row.Cells["Purchase Order ID"].Value);
                purchaseOrderInfo.Supplierid  = Convert.ToInt32(row.Cells["supplier ID"].Value);
                purchaseOrderInfo.Accountid = Convert.ToInt32(row.Cells["Account ID"].Value);
                purchaseOrderInfo.Purchaseordername = row.Cells["Purchase Order Name"].Value.ToString();
                purchaseOrderInfo.Purchaseorderrequestdate = row.Cells["Purchase Order Request Date"].Value.ToString();
                purchaseOrderInfo.Purchaseorderdeliverydate = row.Cells["Purchase Order Delivery Date"].Value.ToString();
                purchaseOrderInfo.Purchaseorderstatus = row.Cells["Purchase Order Status"].Value.ToString();
                purchaseOrderInfo.Purchaseordertotalamount = Convert.ToSingle(row.Cells["Purchase Order Total Amount"].Value);
            }
        }

        private void frmPurchaseOrders_Load(object sender, EventArgs e)
        {
            loadData(txtSearch.Text);
            hiddenColumns();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Transactions.Purchase_Orders.frmAddPurchaseOrder frmAddPurchaseOrder = new frmAddPurchaseOrder(accountInfo, this);
            frmAddPurchaseOrder.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                getDataFromDataGridView();
                frmEditPurchaseOrder frmEditPurchaseOrder = new frmEditPurchaseOrder(accountInfo, purchaseOrderInfo, this);
                frmEditPurchaseOrder.ShowDialog();
            }
            else
            {
                MessageBox.Show("No selected rows.");
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                getDataFromDataGridView();

                switch (MessageBox.Show(this, "Are you sure you want to delete this record?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        if (purchaseOrderInfo.Purchaseorderstatus.Equals("RECIEVED"))
                        {
                            MessageBox.Show("Unable to delete RECIEVED purchase order.");
                        }
                        else
                        {
                            if (purchaseOrderBL.Delete(purchaseOrderInfo))
                            {
                                loadData(txtSearch.Text);
                                MessageBox.Show("Success.");
                            }
                            else
                            {
                                MessageBox.Show("Failed.");
                            }
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("No selected rows.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadData(txtSearch.Text);
        }

        
    }
}
