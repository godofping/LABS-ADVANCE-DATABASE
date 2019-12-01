using System;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.TRANSACTIONS
{
    public partial class frmNewOrder : Form
    {
        EL.REGISTRATIONS.productcategories productcategoryEL = new EL.REGISTRATIONS.productcategories();
        EL.REGISTRATIONS.products productEL = new EL.REGISTRATIONS.products();

        BL.REGISTRATIONS.productcategories productcategoryBL = new BL.REGISTRATIONS.productcategories();
        BL.REGISTRATIONS.products productBL = new BL.REGISTRATIONS.products();
        BL.REGISTRATIONS.customertypes customertypeBL = new BL.REGISTRATIONS.customertypes();
        BL.REGISTRATIONS.deliverymodetypes deliverymodetypeBL = new BL.REGISTRATIONS.deliverymodetypes();

        string s = "";

        public frmNewOrder()
        {
            InitializeComponent();
        }


        private void PopulateDGV()
        {
            methods.LoadDGV(dgvProducts, productBL.List(txtSearch.Text));
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbCustomerType, customertypeBL.List(), "CUSTOMER TYPE", "CUSTOMER TYPE ID");
            methods.LoadCB(cbDeliveryMode, deliverymodetypeBL.List(), "MODE TYPE", "DELIVERY MODE TYPE ID");
        }

        private void ManageDGV()
        {
            methods.DGVHiddenColumns(
                dgvProducts,
                "PRODUCT ID",
                "PRODUCT CATEGORY ID",
                "PARTICULAR ID",
                "CONTAINER TYPE ID",
                "STOCK ID"
                );

            methods.DGVFillWeights(
                dgvProducts,
                new string[] { "PRODUCT CATEGORY", "PARTICULAR", "CONTAINER TYPE", "PRICE", "STOCK" },
                new int[] { 25, 17, 35, 10, 13 }
                );

            methods.DGVTheme(dgvProducts);
            methods.DGVAddButton(dgvProducts);
        }

        private void frmNewOrder_Load(object sender, EventArgs e)
        {
            PopulateDGV();
            PopulateCB();
            ManageDGV();
          

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string value = "0";
            if (methods.InputBox("ENTER SPECIFIC QUANTITY", "QUANTITY:", ref value) == DialogResult.OK)
            {
                MessageBox.Show(value);
            }

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
