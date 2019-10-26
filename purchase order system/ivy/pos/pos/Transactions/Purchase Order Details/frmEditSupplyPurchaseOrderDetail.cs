using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.Transactions.Purchase_Order_Details
{
    public partial class frmEditSupplyPurchaseOrderDetail : Form
    {
        BL.Registrations.Supplies supplyBL = new BL.Registrations.Supplies();

        EL.Registrations.Supplies supplyInfo = new EL.Registrations.Supplies();


        Transactions.Purchase_Orders.frmAddPurchaseOrder frmAddPurchaseOrder;
        int supplyID;

        public frmEditSupplyPurchaseOrderDetail(Transactions.Purchase_Orders.frmAddPurchaseOrder FrmAddPurchaseOrder)
        {
            InitializeComponent();
            frmAddPurchaseOrder = FrmAddPurchaseOrder;
        }

        private void getSelectedDataFromDataGridView()
        {
            supplyInfo.Supplyid = Convert.ToInt32(frmAddPurchaseOrder.dgv.SelectedCells[0].Value);
            supplyInfo.Supplyname = frmAddPurchaseOrder.dgv.SelectedCells[1].Value.ToString();
            supplyInfo.Supplyunit = frmAddPurchaseOrder.dgv.SelectedCells[2].Value.ToString();
            supplyInfo.Supplyunitprice = Convert.ToSingle(frmAddPurchaseOrder.dgv.SelectedCells[3].Value);
            supplyInfo.Supplystocks = Convert.ToInt32(frmAddPurchaseOrder.dgv.SelectedCells[4].Value);

            cbSupplyName.SelectedIndex = cbSupplyName.FindString(supplyInfo.Supplyname);
            txtSupplyUnit.Text = supplyInfo.Supplyunit;
            txtSupplyUnitPrice.Text = supplyInfo.Supplyunitprice.ToString();
            txtSupplyStocks.Text = supplyInfo.Supplystocks.ToString();

            supplyID = supplyInfo.Supplyid;

        }

        private void readOnlyControls()
        {
            txtSupplyUnit.ReadOnly = true;
            txtSupplyUnitPrice.ReadOnly = true;
            txtAmount.ReadOnly = true;
        }

        private void populateControls()
        {
            cbSupplyName.DisplayMember = "Supply Name";
            cbSupplyName.ValueMember = "Supply ID";
            cbSupplyName.DataSource = supplyBL.List("");
        }


        private void getDataFromDatabase()
        {
            foreach (DataRow row in supplyBL.List(Convert.ToInt32(cbSupplyName.SelectedValue)).Rows)
            {
                supplyInfo.Supplyid = Convert.ToInt32(row["Supply ID"]);
                supplyInfo.Supplyname = row["Supply Name"].ToString();
                supplyInfo.Supplyunit = row["Supply Unit"].ToString();
                supplyInfo.Supplyunitprice = Convert.ToSingle(row["Supply Unit Price"]);
            

            }

            txtSupplyUnit.Text = supplyInfo.Supplyunit;
            txtSupplyUnitPrice.Text = supplyInfo.Supplyunitprice.ToString();


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
                if (Convert.ToInt32(row.Cells[0].Value) == supplyInfo.Supplyid & supplyID != supplyInfo.Supplyid)
                {
                    bol = true;
                }
            }

            return bol;

        }

        private void calculateAmount()
        {
            if (!(String.IsNullOrEmpty(txtSupplyUnitPrice.Text)) & !(String.IsNullOrEmpty(txtSupplyStocks.Text)))
            {
                txtAmount.Text = (Convert.ToSingle(txtSupplyUnitPrice.Text) * Convert.ToInt32(txtSupplyStocks.Text)).ToString();
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

        private void frmEditSupplyPurchaseOrder_Load(object sender, EventArgs e)
        {
            readOnlyControls();
            populateControls();
            clearControls();
            getSelectedDataFromDataGridView();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validations())
            {
                getDataFromForm();

                if (checkIfHasDuplicate())
                {
                    MessageBox.Show("This item is already added.");
                }
                else
                {
                   

                    if (frmAddPurchaseOrder.dgv.Rows[frmAddPurchaseOrder.dgv.CurrentCell.RowIndex].SetValues(supplyInfo.Supplyid, supplyInfo.Supplyname, supplyInfo.Supplyunit, supplyInfo.Supplyunitprice, supplyInfo.Supplystocks, supplyInfo.Supplyunitprice * supplyInfo.Supplystocks))
                    {
                        MessageBox.Show("Success.");
                        clearControls();
                        this.Close();
                        frmAddPurchaseOrder.getTotalAmount();
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

        private void txtSupplyStocks_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            onlynumwithsinglepoint(sender, e);
        }

        private void cbSupplyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataFromDatabase();
            txtSupplyStocks.ResetText();
        }

        private void txtSupplyStocks_TextChanged(object sender, EventArgs e)
        {
            calculateAmount();
        }
    }
}
