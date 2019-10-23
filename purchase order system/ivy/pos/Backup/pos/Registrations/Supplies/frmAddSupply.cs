using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.Registrations.Supplies
{
    public partial class frmAddSupply : Form
    {

        EL.Registrations.Supplies supplyInfo = new EL.Registrations.Supplies();

        BL.Registrations.Supplies supplyBL = new BL.Registrations.Supplies();

        frmSupplies frmSupplies = new frmSupplies();

        public frmAddSupply(frmSupplies FrmSupplies)
        {
            InitializeComponent();
            frmSupplies = FrmSupplies;
        }

        private void clearControls()
        {

            txtSupplyName.ResetText();
            cbSupplyUnit.SelectedIndex = -1;
            txtSupplyUnitPrice.ResetText();
            txtSupplyInitialStocks.ResetText();
            this.ActiveControl = txtSupplyName;
        }

        private bool validations()
        {
            bool status = true;

            if (txtSupplyName.Text.Equals(""))
            {
                errorProvider1.SetError(txtSupplyName, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSupplyName, "");

            if (cbSupplyUnit.Text.Equals(""))
            {
                errorProvider1.SetError(cbSupplyUnit, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(cbSupplyUnit, "");

            if (txtSupplyUnitPrice.Text.Equals(""))
            {
                errorProvider1.SetError(txtSupplyUnitPrice, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSupplyUnitPrice, "");

            if (txtSupplyInitialStocks.Text.Equals(""))
            {
                errorProvider1.SetError(txtSupplyInitialStocks, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSupplyInitialStocks, "");

            return status;
        }

        private void getDataFromForm()
        {
            supplyInfo.Supplyname = txtSupplyName.Text;
            supplyInfo.Supplyunit = cbSupplyUnit.Text;
            supplyInfo.Supplyunitprice = Convert.ToSingle(txtSupplyUnitPrice.Text);
            supplyInfo.Supplystocks = Convert.ToInt32(txtSupplyInitialStocks.Text);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validations())
            {
                getDataFromForm();
                if(supplyBL.Insert(supplyInfo) > 0)
                {
                    MessageBox.Show("success");
                    clearControls();
                    frmSupplies.loadData(frmSupplies.txtSearch.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("failed");
                }


            }

        }

        private void txtSupplyUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txtSupplyInitialStocks_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

     
    }
}
