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
    public partial class frmOrders : Form
    {
        pos.EL.Registrations.customers customerEL;
        pos.EL.Transactions.orders orderEL = new pos.EL.Transactions.orders();
        pos.EL.Transactions.orderdetails orderdetailEL = new pos.EL.Transactions.orderdetails();
        pos.EL.Registrations.products productEL = new pos.EL.Registrations.products();

        pos.BL.Registrations.customers customerBL = new pos.BL.Registrations.customers();
        pos.BL.Transactions.orders orderBL = new pos.BL.Transactions.orders();
        pos.BL.Transactions.orderdetails orderdetailBL = new pos.BL.Transactions.orderdetails();
        pos.BL.Registrations.products productBL = new pos.BL.Registrations.products();

        public frmOrders()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            txtFullName.ResetText();
            txtAddress.ResetText();
            txtContactNumber.ResetText();
            dgvCart.Rows.Clear();
            lblTotalAmount.Text = "0";
        }

        private void DGVLoad(string keywords)
        {
            dgv.DataSource = orderBL.List(keywords);
            dgv.Columns["CUSTOMER ID"].Visible = false;
            dgv.Columns["C"].Visible = false;
        }

        private void EnableForm(bool bol)
        {
            gbInfo.Enabled = bol;
            gbButtons.Enabled = !bol;
            gbDGV.Enabled = !bol;
        }

       
        public void GetTotalAmount()
        {
            lblTotalAmount.Text = dgvCart.Rows.Cast<DataGridViewRow>().Sum(t => Math.Round(Convert.ToSingle(t.Cells[5].Value),2)).ToString();
            
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            Transactions.frmSelectCustomers frm = new Transactions.frmSelectCustomers(this, customerEL);
            frm.ShowDialog();
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            Transactions.frmAddProducts frm = new Transactions.frmAddProducts(this);
            frm.ShowDialog();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            DGVLoad(txtSearch.Text);
            EnableForm(false);
            GetTotalAmount();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableForm(true);
            customerEL = new pos.EL.Registrations.customers();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dgvCart.Rows.RemoveAt(dgvCart.SelectedRows[0].Index);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(customerEL.Customerid > 0))
            {
                MessageBox.Show("NO SELECTED CUSTOMER");
            }
            else 
            {
                if (dgvCart.Rows.Count == 0)
                {
                    MessageBox.Show("NO PRODUCTS IN THE CART. PLEASE ADD");
                }
                else 
                {

                    orderEL.Customerid = customerEL.Customerid;
                    orderEL.Totalamount = Convert.ToSingle(lblTotalAmount.Text);
                    orderEL.Dateandtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    orderEL.Orderid = Convert.ToInt32(orderBL.Insert(orderEL));

                    if (orderEL.Orderid > 0)
                    {

                        bool stat = true;

                        foreach (DataGridViewRow row in dgvCart.Rows)
                        {
                            orderdetailEL.Orderid = orderEL.Orderid;
                            orderdetailEL.Productid = Convert.ToInt32(row.Cells["productid"].Value);
                            orderdetailEL.Quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                            orderdetailEL.Price = Convert.ToInt32(row.Cells["price"].Value);

                            DataTable dt = productBL.Select(orderdetailEL.Productid);
                            productEL.Productid = Convert.ToInt32(orderdetailEL.Productid);
                            productEL.Productcode = dt.Rows[0]["PRODUCT CODE"].ToString();
                            productEL.Productname = dt.Rows[0]["PRODUCT NAME"].ToString();
                            productEL.Price = Convert.ToSingle(dt.Rows[0]["PRICE"]);
                            productEL.Stock = Convert.ToInt32(dt.Rows[0]["STOCK"]) - Convert.ToInt32(row.Cells["quantity"].Value);



                            if (orderdetailBL.Insert(orderdetailEL) == 0 & !productBL.Update(productEL))
                            {
                                stat = false;
                            }
                        }

                        if (stat)
                        {
                            ClearForm();
                            EnableForm(false);
                            DGVLoad(txtSearch.Text);
                            MessageBox.Show("ORDER SAVED");
                        }
                        else
                        {
                            MessageBox.Show("FAILED");
                        }

                    }
                    else
                    {
                        MessageBox.Show("FAILED");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                Transactions.frmViewOrder frm = new Transactions.frmViewOrder(Convert.ToInt32(dgv.SelectedRows[0].Cells["ORDER ID"].Value));
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("NO SELECTED ITEM");
            }
        }
    }
}
