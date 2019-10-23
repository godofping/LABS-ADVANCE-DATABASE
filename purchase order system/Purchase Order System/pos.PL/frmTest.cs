using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos.PL
{
    public partial class frmTest : Form
    {

        EL.Registrations.Supplierproducts SupplierProductInfo = new EL.Registrations.Supplierproducts();
        EL.Registrations.Products ProductInfo = new EL.Registrations.Products();
        EL.Registrations.Suppliers SupplierInfo = new EL.Registrations.Suppliers();
        EL.Transactions.Inventories InventoryInfo = new EL.Transactions.Inventories();
        EL.Registrations.Categories CategoryInfo = new EL.Registrations.Categories();
        EL.Registrations.Subcategories SubCategoryInfo = new EL.Registrations.Subcategories();

        BL.Registrations.Supplierproducts SupplierProductBL = new BL.Registrations.Supplierproducts();
        BL.Registrations.Products ProductBL = new BL.Registrations.Products();
        BL.Registrations.Suppliers SupplierBL = new BL.Registrations.Suppliers();
        BL.Transactions.Inventories InventoryBL = new BL.Transactions.Inventories();
        BL.Registrations.Categories CategoryBL = new BL.Registrations.Categories();
        BL.Registrations.Subcategories SubCategoryBL = new BL.Registrations.Subcategories();


        string current = "";

     


        public frmTest()
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

        private void HiddenColumns()
        {
            dgv.Columns["Inventory ID"].Visible = false;
            dgv.Columns["Product ID"].Visible = false;
            dgv.Columns["categoryid"].Visible = false;
            dgv.Columns["subcategoriesisdeleted"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;
            dgv.Columns["subcategoryid"].Visible = false;
            dgv.Columns["categoriesisdeleted"].Visible = false;
        }


        private void frmTest_Load(object sender, EventArgs e)
        {
            PopulateControls();
            ReadOnlyControls();

          
        }

        private void ReadOnlyControls()
        {
            txtProductSKU.ReadOnly = true;
            txtProductPrice.ReadOnly = true;
            txtProductDescription.ReadOnly = true;

        }

        private void PopulateControls()
        {
            cbCategoryName.DisplayMember = "Category Name";
            cbCategoryName.ValueMember = "Category ID";
            cbCategoryName.DataSource = CategoryBL.List("");

            cbSupplierName.DisplayMember = "Supplier";
            cbSupplierName.ValueMember = "Supplier ID";
            cbSupplierName.DataSource = SupplierBL.List("");
        }


        private void PopulateControlsSubCategory()
        {
            cbSubCategoryName.DisplayMember = "Sub Category Name";
            cbSubCategoryName.ValueMember = "Sub Category ID";
            cbSubCategoryName.DataSource = SubCategoryBL.List(Convert.ToInt32(cbCategoryName.SelectedValue));
        }

        private void PopulateControlsProducts()
        {
            cbProductName.DisplayMember = "Product Name";
            cbProductName.ValueMember = "Product ID";
            cbProductName.DataSource = InventoryBL.List(Convert.ToInt32(cbSubCategoryName.SelectedValue));
        }

        private void GetProductInfo()
        {
            if (!cbProductName.Text.Equals(""))
            {
                foreach (DataRow row in ProductBL.List(Convert.ToInt32(cbProductName.SelectedValue.ToString())).Rows)
                {
                    ProductInfo.Productid = Convert.ToInt32(row["Product ID"]);
                    ProductInfo.Productname = row["Product Name"].ToString();
                    ProductInfo.Productdescription = row["Product Description"].ToString();
                    ProductInfo.Subcategoryid = Convert.ToInt32(row["subcategoryid"]);
                    ProductInfo.Productsku = row["Product SKU"].ToString();
                    ProductInfo.Productprice = Convert.ToSingle(row["Product Price"]);
                    ProductInfo.Isdeleted = Convert.ToInt32(row["isdeleted"]);

                    CategoryInfo.Categoryid = Convert.ToInt32(row["categoryid"]);
                    CategoryInfo.Categoryname = row["Category Name"].ToString();
                    CategoryInfo.Isdeleted = Convert.ToInt32(row["categoriesisdeleted"]);

                    SubCategoryInfo.Subcategoryid = Convert.ToInt32(row["subcategoryid"]);
                    SubCategoryInfo.Subcategoryname = row["Sub Category Name"].ToString();
                    SubCategoryInfo.Isdeleted = Convert.ToInt32(row["subcategoriesisdeleted"]);

                }

                txtProductSKU.Text = ProductInfo.Productsku;
                txtProductPrice.Text = ProductInfo.Productprice.ToString();
                txtProductDescription.Text = ProductInfo.Productdescription;
            }
            else
            {
                ClearExtendedFields();
            }

        }

        private void ClearFields()
        {
      
            txtSupplierID.ResetText();
            cbSupplierName.SelectedIndex = -1;
            cbCategoryName.SelectedIndex = -1;
            cbSubCategoryName.SelectedIndex = -1;
            cbProductName.SelectedIndex = -1;
            ClearExtendedFields();

        }

        private void ClearExtendedFields()
        {
            txtProductSKU.ResetText();
            txtProductPrice.ResetText();
            txtProductDescription.ResetText();
        }


        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateControlsSubCategory();
        }

        private void cbSubCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateControlsProducts();
        }

        private void cbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.Rows.Add(ProductInfo.Productname, ProductInfo.Productsku,11 , 250, 3310 );

            label1.Text = dgv.Rows.Cast<DataGridViewRow>()
                                   .AsEnumerable()
                                   .Sum(x => int.Parse(x.Cells[4].Value.ToString()))
                                   .ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
         
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
