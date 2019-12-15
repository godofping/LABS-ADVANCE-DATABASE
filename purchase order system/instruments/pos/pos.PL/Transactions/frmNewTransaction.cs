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

        float totalamount = 0;
        float amounttendered = 0;
        float change = 0;


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

            methods.DGVBUTTONRemove(dgvCart);
            methods.DGVFillWeights(dgvCart, new int[] { 1, 2, 3, 4 }, new int[] { 45, 15, 20, 20});
            

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


        private bool CheckIfHasDuplicate(int id)
        {
            bool bol = false;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == id)
                {
                    bol = true;
                }
            }

            return bol;

        }


        private void CalculateCart()
        {
            lblTotalItems.Text = dgvCart.RowCount.ToString();

            totalamount = dgvCart.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells["PRICE"].Value) * Convert.ToInt32(t.Cells["QTY"].Value));

            lblTotalAmount.Text = methods.ConvertToMoneyFormat(totalamount);
        }

        private void frmNewTransaction_Load(object sender, EventArgs e)
        {
            ShowSelectCustomers(false);
            ManageDGV();
            CalculateCart();

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


        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                productEL.Productid = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["PRODUCT ID"].Value);

                if (CheckIfHasDuplicate(productEL.Productid))
                {
                    MessageBox.Show("ITEM IS ALREADY IN THE CART");
                }
                else
                {
                    productEL = productBL.Select(productEL);

                    if (productEL.Stocks != 0)
                    {
                        string value = "0";

                        if (methods.InputBox("ENTER QUANTITY", "QUANTITY:", ref value) == DialogResult.OK)
                            {
                                if (Convert.ToInt32(value) > 0)
                                {
                                    if (Convert.ToInt32(value) <= productEL.Stocks)
                                    {
                                        dgvCart.Rows.Add(productEL.Productid, productEL.Productname, Convert.ToInt32(value), productEL.Price);
                                        CalculateCart();
                                    }
                                    else
                                    {
                                        MessageBox.Show("NOT ENOUGH STOCKS");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("PLEASE ADD QUANITY GREATER THAN 0");
                                }
                            } 
                        }
                        else
                        {
                            MessageBox.Show("NO STOCKS");
                        }

                }
            }
        }


        private void pnlSelectCustomer_Click(object sender, EventArgs e)
        {
            ShowSelectCustomers(true);
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            ShowSelectCustomers(false);
        }

        private void txtSearchCustomers_TextChanged_1(object sender, EventArgs e)
        {
            PopulateDGVCustomers();
        }

        private void txtSearchProducts_TextChanged(object sender, EventArgs e)
        {
            PopulateDGVProducts();
        }

        private void lblPay_Click(object sender, EventArgs e)
        {
            if (customerEL.Customerid > 0)
            {
                if (dgvCart.RowCount > 0)
                {
                    string value = "0";
                    if (methods.InputBox("ENTER AMOUNT TENDERED", "AMOUNT:", ref value) == DialogResult.OK)
                    {
                        amounttendered = Convert.ToSingle(value);

                        if (amounttendered >= totalamount)
                        {
                            change = amounttendered - totalamount;
                            MessageBox.Show("CHANGE IS " + methods.ConvertToMoneyFormat(change));
                        }
                        else
                        {
                            MessageBox.Show("AMOUNT TENDERED IS INSUFFICIENT OF " + methods.ConvertToMoneyFormat(totalamount - amounttendered));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("NO PRODUCTS IN THE CART");
                }
            }
            else
            {
                MessageBox.Show("PLEASE ADD CUSTOMER");
            }
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (MessageBox.Show(this, "ARE YOU SURE TO REMOVE THIS SELECTED ITEM?", "REMOVING", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    dgvCart.Rows.RemoveAt(dgvCart.SelectedRows[0].Index);
                    CalculateCart();
                    break;
            }
        }
    }
}
