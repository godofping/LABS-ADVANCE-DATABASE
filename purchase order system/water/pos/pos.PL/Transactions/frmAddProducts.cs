using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmAddProducts : Form
    {
        pos.EL.Registrations.products productEL = new pos.EL.Registrations.products();

        pos.BL.Registrations.products productBL = new pos.BL.Registrations.products();

        frmOrders frmOrders;

        public frmAddProducts(frmOrders _frmOrders)
        {
            InitializeComponent();
            frmOrders = _frmOrders;
        }



        private void DGVLoad(string keywords)
        {
            dgv.DataSource = productBL.List(keywords);
            dgv.Columns["C"].Visible = false;
        }

        private void frmAddProducts_Load(object sender, EventArgs e)
        {
            DGVLoad(txtSearch.Text);
            txtQuantity.Focus();
        }

        private void GetData()
        {

            if (dgv.SelectedRows.Count > 0)
            {
                productEL.Productid = Convert.ToInt32(dgv.SelectedRows[0].Cells["PRODUCT ID"].Value);
                productEL.Productcode = dgv.SelectedRows[0].Cells["PRODUCT CODE"].Value.ToString();
                productEL.Productname = dgv.SelectedRows[0].Cells["PRODUCT NAME"].Value.ToString();
                productEL.Price = Convert.ToSingle(dgv.SelectedRows[0].Cells["PRICE"].Value);
                productEL.Stock = Convert.ToInt32(dgv.SelectedRows[0].Cells["STOCK"].Value);

                txtProductID.Text = productEL.Productid.ToString();
                txtProductCode.Text = productEL.Productcode;
                txtProductName.Text = productEL.Productname;
                txtPrice.Text = productEL.Price.ToString();
                txtRemainingStock.Text = productEL.Stock.ToString();
            }


            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DGVLoad(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text.Equals(""))
            {
                MessageBox.Show("NO SELECTED ITEM");
            }
            else
            {

                bool bol = false;

                foreach (DataGridViewRow row in frmOrders.dgvCart.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == productEL.Productid)
                    {
                        bol = true;
                    }
                }

                if (bol)
                {
                    MessageBox.Show("PRODUCT IS ALREADY IN THE CART");
                }
                else
                {
                    if (txtQuantity.Text.Equals(""))
                    {
                        MessageBox.Show("PLEASE COMPLETE ALL THE REQUIRED FIELDS ( * )");
                    }
                    else
                    {
                        if (Convert.ToInt32(txtRemainingStock.Text) == 0)
                        {
                            MessageBox.Show("CANNOT ADD PRODUCT, NO STOCK");
                        }
                        else
                        {
                            if ( Convert.ToInt32(txtQuantity.Text) > Convert.ToInt32(txtRemainingStock.Text))
                            {
                                MessageBox.Show("QUANTITY IS ABOVE THE REMAINING STOCKS");
                            }
                            else
                            {
                                frmOrders.dgvCart.Rows.Add(productEL.Productid, productEL.Productcode, productEL.Productname, productEL.Price, txtQuantity.Text, (productEL.Price * Convert.ToInt32(txtQuantity.Text)));
                                this.Close();
                                frmOrders.GetTotalAmount();
                                MessageBox.Show("ADDED");
                            }
                        }
                    }
                }
            }

        }




        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetData();
        }

        

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetData();
        }


        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetData();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            GetData();
        }


    }
}
