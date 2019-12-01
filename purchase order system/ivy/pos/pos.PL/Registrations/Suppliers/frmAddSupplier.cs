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
    public partial class frmAddSupplier : Form
    {
        BL.Registrations.Suppliers supplierBL = new BL.Registrations.Suppliers();

        EL.Registrations.Suppliers supplierInfo = new EL.Registrations.Suppliers();

        frmSuppliers frmSuppliers;

        public frmAddSupplier(frmSuppliers FrmSuppliers)
        {
            InitializeComponent();
            frmSuppliers = FrmSuppliers;
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validations())
            {
                getDataFromForm();
                if (supplierBL.Insert(supplierInfo) > 0)
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
