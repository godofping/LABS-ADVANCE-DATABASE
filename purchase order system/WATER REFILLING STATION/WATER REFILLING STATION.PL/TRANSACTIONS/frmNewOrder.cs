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
        string s;
        public frmNewOrder()
        {
            InitializeComponent();
        }


        private void PopulateDGV()
        {
            methods.LoadDGV(dgvProducts, productBL.List(txtSearch.Text));
            methods.DGVHiddenColumns(
                dgvProducts,
                "PRODUCT ID",
                "PRODUCT CATEGORY ID",
                "PARTICULAR ID",
                "CONTAINER TYPE ID"
                );
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbCustomerType, productcategoryBL.List(), "PRODUCT CATEGORY", "PRODUCT CATEGORY ID");
        }

        private void ManageDGV()
        {
            methods.DGVFillWeights(
                dgvProducts, 
                new int[] {4,     5,      6,      7,    8   }, 
                new int[] {25,    17,     35,     10,   13  }
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


    }
}
