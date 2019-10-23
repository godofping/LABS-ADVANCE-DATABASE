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
    public partial class frmEditSupply : Form
    {
        EL.Registrations.Supplies supplyInfo;

        BL.Registrations.Supplies supplyBL = new BL.Registrations.Supplies();

        frmSupplies frmSupplies;

        public frmEditSupply(frmSupplies FrmSupplies, EL.Registrations.Supplies SupplyInfo)
        {
            InitializeComponent();

            frmSupplies = FrmSupplies;
            supplyInfo = SupplyInfo;
        }

        private void populateControls()
        {
            txtSupplyName.Text = supplyInfo.Supplyname;
            cbSupplyUnit.SelectedIndex = cbSupplyUnit.FindString(supplyInfo.Supplyunit);
            txtSupplyUnitPrice.Text = supplyInfo.Supplyunitprice.ToString();
        }

        private void clearControls()
        {

            txtSupplyName.ResetText();
            cbSupplyUnit.SelectedIndex = -1;
            txtSupplyUnitPrice.ResetText();
 
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



            return status;
        }

        private void getDataFromForm()
        {
            supplyInfo.Supplyname = txtSupplyName.Text;
            supplyInfo.Supplyunit = cbSupplyUnit.Text;
            supplyInfo.Supplyunitprice = Convert.ToSingle(txtSupplyUnitPrice.Text);
  
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


        private void frmEditSupply_Load(object sender, EventArgs e)
        {
            clearControls();
            populateControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (validations())
            {
                getDataFromForm();
                if (supplyBL.Edit(supplyInfo))
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
            else
            {
                MessageBox.Show("Please complete the required fields.");
            }

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
