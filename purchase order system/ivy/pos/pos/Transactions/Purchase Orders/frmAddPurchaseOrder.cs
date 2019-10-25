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
        BL.Transactions.PurchaseOrderDetails purhcaseOrderDetailBL = new BL.Transactions.PurchaseOrderDetails();

        EL.Transactions.PurhcaseOrders purchaseOrderInfo = new EL.Transactions.PurhcaseOrders();
        EL.Transactions.PurchaseOrderDetails purchaseOrderDetailInfo = new EL.Transactions.PurchaseOrderDetails();

        public frmAddPurchaseOrder()
        {
            InitializeComponent();
        }

        private void readOnlyControls()
        {
            txtTotalAmount.ReadOnly = true;
        }

        private void populateControls()
        {
            cbSupplyName.DisplayMember = "Supploier Name";
            cbSupplyName.ValueMember = "Supply ID";
            cbSupplyName.DataSource = supplyBL.List("");
        }


        private void clearControls()
        {

            cbSupplyName.SelectedIndex = -1;
            txtSupplyUnit.ResetText();
            txtSupplyUnitPrice.ResetText();
            txtSupplyStocks.ResetText();
            this.ActiveControl = cbSupplyName;
        }

        private bool validations()
        {
            bool status = true;

            if (cbSupplyName.Text.Equals(""))
            {
                errorProvider1.SetError(cbSupplyName, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(cbSupplyName, "");

            if (txtSupplyUnit.Text.Equals(""))
            {
                errorProvider1.SetError(txtSupplyUnit, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSupplyUnit, "");

            if (txtSupplyUnitPrice.Text.Equals(""))
            {
                errorProvider1.SetError(txtSupplyUnitPrice, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSupplyUnitPrice, "");

            if (txtSupplyStocks.Text.Equals(""))
            {
                errorProvider1.SetError(txtSupplyStocks, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSupplyStocks, "");

            return status;
        }

        private void getDataFromForm()
        {
            supplyInfo.Supplyname = cbSupplyName.Text;
            supplyInfo.Supplyunit = txtSupplyUnit.Text;
            supplyInfo.Supplyunitprice = Convert.ToSingle(txtSupplyUnitPrice.Text);
            supplyInfo.Supplystocks = Convert.ToInt32(txtSupplyStocks.Text);
        }

        private bool checkIfHasDuplicate()
        {

            bool bol = false;

            foreach (DataGridViewRow row in frmAddPurchaseOrder.dgv.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == supplyInfo.Supplyid)
                {
                    bol = true;
                }
            }

            return bol;

        }


        private void frmAddPurchaseOrder_Load(object sender, EventArgs e)
        {
            readOnlyControls();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddSupplyPurchaseOrder frmAddSupplyPurchaseOrder = new frmAddSupplyPurchaseOrder(this);
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
                frmEditSupplyPurchaseOrder frmEditSupplyPurchaseOrder = new frmEditSupplyPurchaseOrder(this);
                frmEditSupplyPurchaseOrder.Show();
            }
            else
            {
                MessageBox.Show("No selected rows.");
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validations())
            {
                getDataFromForm();
                if (supplyBL.Insert(supplyInfo) > 0)
                {
                    frmSupplies.loadData(frmSupplies.txtSearch.Text);
                    MessageBox.Show("Success.");
                    clearControls();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
