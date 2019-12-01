using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmProducts : Form
    {
        pos.EL.Registrations.products productEL = new pos.EL.Registrations.products();

        pos.BL.Registrations.products productBL = new pos.BL.Registrations.products();

        string s = "";

        public frmProducts()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            txtProductID.ResetText();
            txtProductCode.ResetText();
            txtProductName.ResetText();
            txtPrice.ResetText();
            txtStock.ResetText();

        }

        private void DGVLoad(string keywords)
        {
            dgv.DataSource = productBL.List(keywords);
            dgv.Columns["C"].Visible = false;
        }

        private void EnableForm(bool bol)
        {
            gbInfo.Enabled = bol;
            gbButtons.Enabled = !bol;
            gbDGV.Enabled = !bol;
        }

        private bool Validations()
        {
            bool bol = false;

            if (txtProductCode.Text.Equals("") | txtProductName.Text.Equals("") | txtPrice.Text.Equals("") | txtStock.Text.Equals(""))
            {
                bol = false;
            }
            else
            {
                bol = true;
            }
            return bol;
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            EnableForm(false);
            DGVLoad(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DGVLoad(txtSearch.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                productEL.Productcode = txtProductCode.Text;
                productEL.Productname = txtProductName.Text;
                productEL.Price = Convert.ToSingle(txtPrice.Text);
                productEL.Stock = Convert.ToInt32(txtStock.Text);

                if (s.Equals("ADD"))
                {
                    if (productBL.Insert(productEL) > 0)
                    {
                        ClearForm();
                        EnableForm(false);
                        DGVLoad(txtSearch.Text);
                        MessageBox.Show("SUCCESS");
                    }
                    else
                    {
                        MessageBox.Show("FAILED");
                    }
                }
                else if (s.Equals("EDIT"))
                {
                    productEL.Productid = Convert.ToInt32(txtProductID.Text);
                    if (productBL.Update(productEL))
                    {
                        ClearForm();
                        EnableForm(false);
                        DGVLoad(txtSearch.Text);
                        MessageBox.Show("SUCCESS");
                    }
                    else
                    {
                        MessageBox.Show("FAILED");
                    }
                }
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL THE FIELDS REQUIRED ( * )");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            EnableForm(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                s = "EDIT";
                EnableForm(true);
                txtProductID.Text = dgv.SelectedRows[0].Cells["PRODUCT ID"].Value.ToString();
                txtProductCode.Text = dgv.SelectedRows[0].Cells["PRODUCT CODE"].Value.ToString();
                txtProductName.Text = dgv.SelectedRows[0].Cells["PRODUCT NAME"].Value.ToString();
                txtPrice.Text = dgv.SelectedRows[0].Cells["PRICE"].Value.ToString();
                txtStock.Text = dgv.SelectedRows[0].Cells["STOCK"].Value.ToString();

            }
            else
            {
                MessageBox.Show("NO SELECTED ITEM");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {

                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE TO DELETE THE SELECTED ITEM?", "MESSAGE", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    productEL.Productid = Convert.ToInt32(dgv.SelectedRows[0].Cells["PRODUCT ID"].Value);
                    if (productBL.Delete(productEL))
                    {
                        DGVLoad(txtSearch.Text);
                        MessageBox.Show("SUCCESS");
                    }
                    else
                    {
                        MessageBox.Show("FAILED");
                    }
                }

            }
            else
            {
                MessageBox.Show("NO SELECTED ITEM");
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
