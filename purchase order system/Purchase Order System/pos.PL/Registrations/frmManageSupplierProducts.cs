using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageSupplierProducts : Form
    {
        EL.Registrations.Supplierproducts SupplierProductInfo = new EL.Registrations.Supplierproducts();
        EL.Registrations.Products ProductInfo = new EL.Registrations.Products();
        EL.Registrations.Suppliers SupplierInfo = new EL.Registrations.Suppliers();

        BL.Registrations.Supplierproducts SupplierProductBL = new BL.Registrations.Supplierproducts();
        BL.Registrations.Products ProductBL = new BL.Registrations.Products();
        BL.Registrations.Suppliers SupplierBL = new BL.Registrations.Suppliers();

        string current = "";

        public frmManageSupplierProducts()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public class BufferedPanel : Panel
        {
            public BufferedPanel()
            {
                DoubleBuffered = true;
            }
        }

        private void frmManageStaffs_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
            PopulateControls();
            ClearFields();
        }

        private void HiddenColumns()
        {
            dgv.Columns["Supplier Product ID"].Visible = false;
            dgv.Columns["subcategoryid"].Visible = false;
            dgv.Columns["productprice"].Visible = false;
            dgv.Columns["productsisdeleted"].Visible = false;
            dgv.Columns["contactdetailid"].Visible = false;
            dgv.Columns["productid"].Visible = false;
            dgv.Columns["supplierid"].Visible = false;
            dgv.Columns["suppliersisdeleted"].Visible = false;
        }

        private void LoadData(string keywords)
        {
            dgv.DataSource = SupplierProductBL.List(keywords);
        }

        private void PopulateControls()
        {
            cbProductName.DisplayMember = "Product Name";
            cbProductName.ValueMember = "Product ID";
            cbProductName.DataSource = ProductBL.List("");

            cbSupplierName.DisplayMember = "Supplier";
            cbSupplierName.ValueMember = "Supplier ID";
            cbSupplierName.DataSource = SupplierBL.List("");
        }

        private void ManageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;
            dgv.Enabled = !status;
            txtSearch.Enabled = !status;
        }

        private void ClearErrors()
        {
            errorProvider1.SetError(cbProductName, "");
            errorProvider1.SetError(cbSupplierName, "");
        }

        private void ClearFields()
        {
            dgv.ClearSelection();
            cbProductName.SelectedIndex = -1;
            cbSupplierName.SelectedIndex = -1;
        }


        private bool CheckErrors()
        {
            bool status = true;

            if (cbProductName.Text.Equals(""))
            {
                errorProvider1.SetError(cbProductName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbProductName, "");


            if (cbSupplierName.Text.Equals(""))
            {
                errorProvider1.SetError(cbSupplierName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbSupplierName, "");

            return status;
        }

        private void GetDataFromForm()
        {   
            SupplierProductInfo.Productid = Convert.ToInt32(cbProductName.SelectedValue);
            SupplierProductInfo.Supplierid = Convert.ToInt32(cbSupplierName.SelectedValue);
        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                ProductInfo.Productid = Convert.ToInt32(row.Cells["productid"].Value);
                ProductInfo.Productname = row.Cells["Product Name"].Value.ToString();
                ProductInfo.Productdescription = row.Cells["Product Description"].Value.ToString();
                ProductInfo.Productsku = row.Cells["Product SKU"].Value.ToString();

                SupplierInfo.Supplierid = Convert.ToInt32(row.Cells["supplierid"].Value);
                SupplierInfo.Supplier = row.Cells["Supplier"].Value.ToString();

                SupplierProductInfo.Supplierproductid = Convert.ToInt32(row.Cells["Supplier Product ID"].Value);
                SupplierProductInfo.Supplierid = Convert.ToInt32(row.Cells["supplierid"].Value);
                SupplierProductInfo.Productid = Convert.ToInt32(row.Cells["productid"].Value);
            }

            txtSupplierProductID.Text = SupplierProductInfo.Supplierproductid.ToString();
            cbProductName.SelectedIndex = cbProductName.FindString(ProductInfo.Productname);
            cbSupplierName.SelectedIndex = cbSupplierName.FindString(SupplierInfo.Supplier);

        }

        private void ShowMessageBox(bool condition)
        {
            if (condition)
            {
                LoadData(txtSearch.Text);
                ClearFields();
                MessageBox.Show("Success");

            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void Add()
        {
            GetDataFromForm();

            ShowMessageBox(SupplierProductBL.Insert(SupplierProductInfo) > 0);
        }

        private void Edit()
        {
            GetDataFromForm();

            ShowMessageBox(SupplierProductBL.Update(SupplierProductInfo));
        }

        private void Delete()
        {
            GetDataFromForm();

            ShowMessageBox(SupplierProductBL.Delete(SupplierProductInfo));
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            ManageForm(true);
            this.ActiveControl = cbProductName;
            current = "ADD";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtSupplierProductID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                ManageForm(true);
                this.ActiveControl = cbProductName;
                current = "EDIT";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSupplierProductID.Text.Equals(""))
            {
                MessageBox.Show("No selected item. Please select first.");
            }
            else
            {
                Delete();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                if (current.Equals("ADD"))
                {
                    Add();
                }
                else if (current.Equals("EDIT"))
                {
                    Edit();
                }

                ManageForm(false);
                ClearFields();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageForm(false);
            ClearFields();
            ClearErrors();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }
    }
}
