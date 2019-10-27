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
    public partial class frmAddPurchaseOrder : Form
    {

        BL.Transactions.PurchaseOrders purchaseOrderBL = new BL.Transactions.PurchaseOrders();
        BL.Transactions.PurchaseOrderDetails purchaseOrderDetailBL = new BL.Transactions.PurchaseOrderDetails();
        BL.Registrations.Suppliers supplierBL = new BL.Registrations.Suppliers();

        EL.Transactions.PurchaseOrders purchaseOrderInfo = new EL.Transactions.PurchaseOrders();
        EL.Transactions.PurchaseOrderDetails purchaseOrderDetailInfo = new EL.Transactions.PurchaseOrderDetails();
        EL.Registrations.Suppliers supplierInfo = new EL.Registrations.Suppliers();
        EL.Registrations.Accounts accountInfo;

        frmPurchaseOrders frmPurchaseOrders;

        public frmAddPurchaseOrder(EL.Registrations.Accounts AccountInfo, frmPurchaseOrders FrmPurchaseOrders)
        {
            InitializeComponent();
            accountInfo = AccountInfo;
            frmPurchaseOrders = FrmPurchaseOrders;
        }

        private void readOnlyControls()
        {
            txtTotalAmount.ReadOnly = true;

        }

        private void populateControls()
        {
            cbSupplierName.DisplayMember = "Supplier Name";
            cbSupplierName.ValueMember = "Supplier ID";
            cbSupplierName.DataSource = supplierBL.List("");
        }


        private void clearControls()
        {

            cbSupplierName.SelectedIndex = -1;
            txtPurchaseOrderName.ResetText();
            dtpDeliveryDate.ResetText();
            txtTotalAmount.ResetText();
            this.ActiveControl = cbSupplierName;
        }

        private bool validations()
        {
            bool status = true;

            if (cbSupplierName.Text.Equals(""))
            {
                errorProvider1.SetError(cbSupplierName, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(cbSupplierName, "");

            if (txtPurchaseOrderName.Text.Equals(""))
            {
                errorProvider1.SetError(txtPurchaseOrderName, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtPurchaseOrderName, "");

            if (dtpDeliveryDate.Text.Equals(""))
            {
                errorProvider1.SetError(dtpDeliveryDate, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(dtpDeliveryDate, "");


            return status;
        }

        private void getDataFromForm()
        {
            purchaseOrderInfo.Supplierid = Convert.ToInt32(cbSupplierName.SelectedValue);
            purchaseOrderInfo.Accountid = accountInfo.Accountid;
            purchaseOrderInfo.Purchaseordername = txtPurchaseOrderName.Text;
            purchaseOrderInfo.Purchaseorderrequestdate = DateTime.Now.ToString("yyyy-MM-dd");
            purchaseOrderInfo.Purchaseorderdeliverydate = dtpDeliveryDate.Value.ToString("yyyy-MM-dd");
            purchaseOrderInfo.Purchaseordertotalamount = Convert.ToSingle(txtTotalAmount.Text);
            purchaseOrderInfo.Purchaseorderstatus = "PENDING";
        }

        public void getTotalAmount()
        {
            txtTotalAmount.Text =  dgv.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[5].Value)).ToString();
        }


        private void frmAddPurchaseOrder_Load(object sender, EventArgs e)
        {
            readOnlyControls();
            populateControls();
            clearControls();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Transactions.Purchase_Order_Details.frmAddSupplyPurchaseOrderDetail frmAddSupplyPurchaseOrder = new Transactions.Purchase_Order_Details.frmAddSupplyPurchaseOrderDetail(this);
            frmAddSupplyPurchaseOrder.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {

                switch (MessageBox.Show(this, "Are you sure you want to delete this record?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                        getTotalAmount();
                        break;
                }
            }
            else
            {
                MessageBox.Show("No selected rows.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                Transactions.Purchase_Order_Details.frmEditSupplyPurchaseOrderDetail frmEditSupplyPurchaseOrder = new Transactions.Purchase_Order_Details.frmEditSupplyPurchaseOrderDetail(this);
                frmEditSupplyPurchaseOrder.Show();
            }
            else
            {
                MessageBox.Show("No selected rows.");
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(dgv.Rows.Count == 0)
            {
                MessageBox.Show("No supplies selected.");
            }
            else
            {
                if (validations())
                {
                    getDataFromForm();

                    long purchaseOrderID;
                    if ((purchaseOrderID = purchaseOrderBL.Insert(purchaseOrderInfo)) > 0)
                    {

                        bool stat = true;

                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            purchaseOrderDetailInfo.Purchaseorderid = Convert.ToInt32(purchaseOrderID);
                            purchaseOrderDetailInfo.Supplyid = Convert.ToInt32(row.Cells[0].Value);
                            purchaseOrderDetailInfo.Purchaseorderdetailquantity = Convert.ToInt32(row.Cells[4].Value);
                            purchaseOrderDetailInfo.Purchaseorderdetailunitprice = Convert.ToInt32(row.Cells[3].Value);
                            if (purchaseOrderDetailBL.Insert(purchaseOrderDetailInfo) == 0)
                            {
                                stat = false;
                            }
                        }

                        if(stat)
                        {
                            MessageBox.Show("Success.");
                            clearControls();
                            this.Close();
                            frmPurchaseOrders.loadData(frmPurchaseOrders.txtSearch.Text);
                        }
                        else
                        {
                            MessageBox.Show("Failed.");
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("Failed.");
                    }
                }
            }
        }   

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
