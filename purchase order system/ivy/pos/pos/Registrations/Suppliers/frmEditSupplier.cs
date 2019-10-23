using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.Registrations.Suppliers
{
    public partial class frmEditSupplier : Form
    {
        BL.Registrations.Suppliers supplierBL = new BL.Registrations.Suppliers();

        EL.Registrations.Suppliers supplierInfo;

        frmSuppliers frmSuppliers;

        public frmEditSupplier(frmSuppliers FrmSuppliers, EL.Registrations.Suppliers SupplierInfo)
        {
            InitializeComponent();

            frmSuppliers = FrmSuppliers;
            supplierInfo = SupplierInfo;
        }


        private void populateControls()
        {
            txtSupplierName.Text = supplierInfo.Suppliername;
            txtSupplierContactNumber.Text = supplierInfo.Suppliercontactnumber;
            txtSupplierAddress.Text = supplierInfo.Supplieraddress;
        }

        private void clearControls()
        {

            txtSupplierName.ResetText();
            txtSupplierContactNumber.ResetText();
            txtSupplierAddress.ResetText();

            this.ActiveControl = txtSupplierName;
        }

        private bool validations()
        {
            bool status = true;

            if (txtSupplierName.Text.Equals(""))
            {
                errorProvider1.SetError(txtSupplierName, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSupplierName, "");

            if (txtSupplierContactNumber.Text.Equals(""))
            {
                errorProvider1.SetError(txtSupplierContactNumber, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSupplierContactNumber, "");

            if (txtSupplierAddress.Text.Equals(""))
            {
                errorProvider1.SetError(txtSupplierAddress, "Please fill out this field.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSupplierAddress, "");

            return status;
        }


        private void getDataFromForm()
        {
            supplierInfo.Suppliername = txtSupplierName.Text;
            supplierInfo.Suppliercontactnumber = txtSupplierContactNumber.Text;
            supplierInfo.Supplieraddress = txtSupplierAddress.Text;
        }

        private void frmEditSupplier_Load(object sender, EventArgs e)
        {
            clearControls();
            populateControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validations())
            {
                getDataFromForm();
                if (supplierBL.Edit(supplierInfo))
                {
                    frmSuppliers.loadData(frmSuppliers.txtSearch.Text);
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
