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
        pos.EL.Registrations.customers customerEL = new pos.EL.Registrations.customers();
        pos.EL.Transactions.orders orderEL = new pos.EL.Transactions.orders();
        pos.EL.Transactions.orderdetails orderdetailEL = new pos.EL.Transactions.orderdetails();

        pos.BL.Registrations.customers customerBL = new pos.BL.Registrations.customers();
        pos.BL.Transactions.orders orderBL = new pos.BL.Transactions.orders();
        pos.BL.Transactions.orderdetails orderdetailBL = new pos.BL.Transactions.orderdetails();

        public frmOrders()
        {
            InitializeComponent();
        }

        private void EnableForm(bool bol)
        {
            gbInfo.Enabled = bol;
            gbButtons.Enabled = !bol;
            gbDGV.Enabled = !bol;
        }

        private void ClearForm()
        {
            txtFullName.ResetText();
            txtAddress.ResetText();
            txtContactNumber.ResetText();
            dgv.Rows.Clear();
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
            EnableForm(false);
            GetTotalAmount();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableForm(true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("NO SELECTED ITEM");
            }
            else
            {
                switch (MessageBox.Show(this, "Are you sure to delete this?", "Confirming", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        dgvCart.Rows.RemoveAt(dgvCart.SelectedRows[0].Index);
                        GetTotalAmount();
                        ClearForm();
                        break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFullName.Equals(""))
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

                    orderEL.Orderid = Convert.ToInt32(orderBL.Insert(orderEL));

                    if (orderEL.Orderid > 0)
                    {

                        bool stat = true;

                        foreach (DataGridViewRow row in dgvCart.Rows)
                        {
                            orderdetailEL.Orderid = orderEL.Orderid;
                            orderdetailEL.Productid = Convert.ToInt32(row.Cells["PRODUCT ID"].Value);
                            orderdetailEL.Quantity = Convert.ToInt32(row.Cells["QUANTITY"].Value);
                            orderdetailEL.Quantity = Convert.ToInt32(row.Cells["PRICE"].Value);


                            if (orderdetailBL.Insert(orderdetailEL) == 0)
                            {
                                stat = false;
                            }
                        }

                        if (stat)
                        {
                            MessageBox.Show("INSERTED");
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
    }
}
