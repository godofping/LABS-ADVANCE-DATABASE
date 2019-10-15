using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageProducts : Form
    {
        EL.Registrations.Products ProductInfo = new EL.Registrations.Products();
        EL.Registrations.Subcategories SubCategoryInfo = new EL.Registrations.Subcategories();
        EL.Registrations.Categories CategoryInfo = new EL.Registrations.Categories();

        BL.Registrations.Products ProductBL = new BL.Registrations.Products();
        BL.Registrations.Subcategories SubCategoryBL = new BL.Registrations.Subcategories();
        BL.Registrations.Categories CategoryBL = new BL.Registrations.Categories();

        string current = "";

        public frmManageProducts()
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
            dgv.Columns["Product ID"].Visible = false;
            dgv.Columns["categoryid"].Visible = false;
            dgv.Columns["subcategoriesisdeleted"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;
            dgv.Columns["subcategoryid"].Visible = false;
            dgv.Columns["categoriesisdeleted"].Visible = false;
        }

        private void LoadData(string keywords)
        {
            dgv.DataSource = ProductBL.List(keywords);
        }

        private void PopulateControls()
        {
            cbCategoryName.DisplayMember = "Category Name";
            cbCategoryName.ValueMember = "Category ID";
            cbCategoryName.DataSource = CategoryBL.List("");
        }

        private void PopulateControlsSub()
        {
            cbSubCategoryName.DisplayMember = "Sub Category Name";
            cbSubCategoryName.ValueMember = "Sub Category ID";
            cbSubCategoryName.DataSource = SubCategoryBL.List(Convert.ToInt32(cbCategoryName.SelectedValue));
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
            errorProvider1.SetError(txtProductName, "");
            errorProvider1.SetError(txtProductDescription, "");
            errorProvider1.SetError(cbCategoryName, "");
            errorProvider1.SetError(cbSubCategoryName, "");
            errorProvider1.SetError(txtProductSKU, "");
            errorProvider1.SetError(txtProductPrice, "");
           
        }

        private void ClearFields()
        {
            dgv.ClearSelection();
            txtProductID.ResetText();
            txtProductName.ResetText();
            txtProductDescription.ResetText();
            cbCategoryName.SelectedIndex = -1;
            cbSubCategoryName.SelectedIndex = -1;
            txtProductSKU.ResetText();
            txtProductPrice.ResetText();
        }

        private bool CheckErrors()
        {
            bool status = true;

            if (txtProductName.Text.Equals(""))
            {
                errorProvider1.SetError(txtProductName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProductName, "");


            if (txtProductDescription.Text.Equals(""))
            {
                errorProvider1.SetError(txtProductDescription, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProductDescription, "");


            if (cbCategoryName.Text.Equals(""))
            {
                errorProvider1.SetError(cbCategoryName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbCategoryName, "");


            if (cbSubCategoryName.Text.Equals(""))
            {
                errorProvider1.SetError(cbSubCategoryName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbSubCategoryName, "");


            if (txtProductSKU.Text.Equals(""))
            {
                errorProvider1.SetError(txtProductSKU, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProductSKU, "");


            if (txtProductPrice.Text.Equals(""))
            {
                errorProvider1.SetError(txtProductPrice, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProductPrice, "");

            return status;
        }

        private void GetDataFromForm()
        {
            ProductInfo.Productname = txtProductName.Text;
            ProductInfo.Productdescription = txtProductDescription.Text;
            ProductInfo.Subcategoryid = Convert.ToInt32(cbSubCategoryName.SelectedValue);
            ProductInfo.Productsku = txtProductSKU.Text;
            ProductInfo.Productprice = Convert.ToSingle(txtProductPrice.Text) ;
        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                CategoryInfo.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);
                CategoryInfo.Categoryname = row.Cells["Category Name"].Value.ToString();

                SubCategoryInfo.Subcategoryid = Convert.ToInt32(row.Cells["subcategoryid"].Value);
                SubCategoryInfo.Subcategoryname = row.Cells["Sub Category Name"].Value.ToString();

                ProductInfo.Productid = Convert.ToInt32(row.Cells["Product ID"].Value);
                ProductInfo.Productname = row.Cells["Product Name"].Value.ToString();
                ProductInfo.Productdescription = row.Cells["Product Description"].Value.ToString();
                ProductInfo.Productsku = row.Cells["Product SKU"].Value.ToString();
                ProductInfo.Productprice = Convert.ToSingle(row.Cells["Product Price"].Value);
                ProductInfo.Isdeleted = Convert.ToInt32(row.Cells["isdeleted"].Value);
            }

            txtProductID.Text = ProductInfo.Productid.ToString();
            txtProductName.Text = ProductInfo.Productname;
            txtProductDescription.Text = ProductInfo.Productdescription;
            cbCategoryName.SelectedIndex = cbCategoryName.FindString(CategoryInfo.Categoryname);
            cbSubCategoryName.SelectedIndex = cbSubCategoryName.FindString(SubCategoryInfo.Subcategoryname);
            txtProductSKU.Text = ProductInfo.Productsku;
            txtProductPrice.Text = ProductInfo.Productprice.ToString();


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

            ShowMessageBox(ProductBL.Insert(ProductInfo) > 0);
        }

        private void Edit()
        {
            GetDataFromForm();

            ShowMessageBox(ProductBL.Update(ProductInfo));
        }

        private void Delete()
        {
            GetDataFromForm();

            ShowMessageBox(ProductBL.Delete(ProductInfo));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            ManageForm(true);
            this.ActiveControl = txtProductName;
            current = "ADD";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                ManageForm(true);
                this.ActiveControl = txtProductName;
                current = "EDIT";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text.Equals(""))
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

        private void txtProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateControlsSub();

        }

       
    }
}
