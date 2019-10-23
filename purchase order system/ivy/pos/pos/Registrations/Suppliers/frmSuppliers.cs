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
    public partial class frmSuppliers : Form
    {

        BL.Registrations.Suppliers supplierBL = new BL.Registrations.Suppliers();

        EL.Registrations.Suppliers supplierInfo = new EL.Registrations.Suppliers();

        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void hiddenColumns()
        {
            dgv.Columns["Supplier ID"].Visible = false;
        }

        public void loadData(string keywords)
        {
            dgv.DataSource = supplierBL.List(keywords);
        }

        private void getDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                supplierInfo.Supplierid = Convert.ToInt32(row.Cells["Supplier ID"].Value);
                supplierInfo.Suppliername = row.Cells["Supplier Name"].Value.ToString();
                supplierInfo.Suppliercontactnumber = row.Cells["Supplier Contact Number"].Value.ToString();
                supplierInfo.Supplieraddress = row.Cells["Supplier Address"].Value.ToString();

            }

        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            loadData(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadData(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddSupplier frmAddSupplier = new frmAddSupplier(this);
            frmAddSupplier.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                getDataFromDataGridView();
                frmEditSupplier frmEditSupplier = new frmEditSupplier(this, supplierInfo);
                frmEditSupplier.ShowDialog();
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
                        if (supplierBL.Delete(supplierInfo))
                        {
                            loadData(txtSearch.Text);
                            MessageBox.Show("success");
                        }
                        else
                        {
                            MessageBox.Show("failed");
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("No selected rows.");
            }
        }

        
    }
}
