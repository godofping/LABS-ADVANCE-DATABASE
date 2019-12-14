using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmNewTransaction : Form
    {
        EL.Registrations.customers customerEL = new EL.Registrations.customers();
        EL.Registrations.products productEL = new EL.Registrations.products();

        BL.Registrations.customers customerBL = new BL.Registrations.customers();
        BL.Registrations.products productBL = new BL.Registrations.products();

        public frmNewTransaction()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
         
        }

        private void PopulateDGVCustomers()
        {
            dgvCustomers.DataSource = customerBL.List(txtSearchCustomers.Text);
        }

        private void PopulateDGVProducts()
        {
            dgvProducts.DataSource = productBL.List(txtSearchProducts.Text);
        }

        private void ManageDGV()
        {
            methods.DGVBUTTONSelect(dgvCustomers);
            PopulateDGVCustomers();
            methods.DGVHiddenColumns(dgvCustomers, "C");
            methods.DGVTheme(dgvCustomers);
            methods.DGVFillWeights(dgvCustomers, new string[] { "CUSTOMER ID", "FULL NAME", "CONTACT NUMBER" }, new int[] { 20, 50, 30 });

            methods.DGVBUTTONAdd(dgvProducts);
            PopulateDGVProducts();
            methods.DGVHiddenColumns(dgvProducts, "CATEGORY ID","DESCRIPTION","C");
            methods.DGVTheme(dgvProducts);
            methods.DGVFillWeights(dgvProducts, new string[] { "PRODUCT ID", "PRODUCT NAME", "PRICE", "STOCKS", "CATEGORY" }, new int[] { 15, 35, 15, 15, 20 });

            methods.DGVTheme(dgvCart);

        }

        private void ShowSelectCustomers(bool bol)
        {
            pnlCustomers.Visible = bol;
            pnlLeft.Visible = !bol;
            pnlRight.Visible = !bol;
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("SUCCESS");
                PopulateDGVCustomers();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void frmNewTransaction_Load(object sender, EventArgs e)
        {
            ShowSelectCustomers(false);
            ManageDGV();

        }

        private void txtSearchCustomers_TextChanged(object sender, EventArgs e)
        {
            PopulateDGVCustomers();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                customerEL.Customerid = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CUSTOMER ID"].Value);
                customerEL = customerBL.Select(customerEL);
                lblNameAndNumber.Text = customerEL.Fullname + Environment.NewLine + customerEL.Contactnumber;

                ShowSelectCustomers(false);
            }
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            ShowSelectCustomers(true);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ShowSelectCustomers(false);
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                


            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show(customerEL.Customerid.ToString());
        }
    }
}
