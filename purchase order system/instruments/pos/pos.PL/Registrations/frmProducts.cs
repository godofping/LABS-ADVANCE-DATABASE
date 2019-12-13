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
    public partial class frmProducts : Form
    {
        EL.Registrations.products productEL = new EL.Registrations.products();
        EL.Registrations.categories categoryEL = new EL.Registrations.categories();

        BL.Registrations.products productBL = new BL.Registrations.products();
        BL.Registrations.categories categoryBL = new BL.Registrations.categories();

        string s = "";

        public frmProducts()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            txtProductName.ResetText();
        }

        private void PopulateDGV()
        {
            dgv.DataSource = productBL.List(txtSearch.Text);
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbCategory, categoryBL.List(""),"CATEGORY", "CATEGORY ID");
        }

        private void ManageDGV()
        {
            methods.DGVBUTTONAddEdit(dgv);
            PopulateDGV();
            methods.DGVHiddenColumns(dgv,"CATEGORY ID" ,"C");
            methods.DGVTheme(dgv);
            methods.DGVFillWeights(dgv, new string[] { "PRODUCT ID", "PRODUCT NAME", "DESCRIPTION", "PRICE", "STOCKS", "CATEGORY" }, new int[] { 10, 20, 30, 10 ,10, 20 });
        }

        private void ShowForm(bool bol)
        {
            ResetForm();
            pnlAddEdit.Visible = bol;
            pnlMain.Visible = !bol;
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("SUCCESS");
                ShowForm(false);
                PopulateDGV();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            ShowForm(false);
            ManageDGV();
            PopulateCB();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            lblTitle.Text = "ADD PRODUCT";
            ShowForm(true);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 | e.ColumnIndex == 1)
                productEL.Productid = Convert.ToInt32(dgv.SelectedRows[0].Cells["PRODUCT ID"].Value);

            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                lblTitle.Text = "UPDATE CATEGORY";
                ShowForm(true);

                productEL = productBL.Select(productEL);
                categoryEL.Categoryid = productEL.Categoryid;
                categoryEL = categoryBL.Select(categoryEL);

                txtProductName.Text = productEL.Productname;
                cbCategory.SelectedIndex = cbCategory.FindString(categoryEL.Category);
                txtDescription.Text = productEL.Description;
                txtPrice.Text = productEL.Price.ToString();
                txtStocks.Text = productEL.Stocks.ToString();
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE TO DELETE THIS SELECTED ITEM?", "DELETING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(categoryBL.Delete(categoryEL));
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bol = false;

            if (methods.CheckRequiredTXT(txtProductName, txtDescription, txtPrice, txtStocks) & methods.CheckRequiredCB(cbCategory))
            {

                productEL.Productname = txtProductName.Text;
                productEL.Categoryid = Convert.ToInt32(cbCategory.SelectedValue);
                productEL.Description = txtDescription.Text;
                productEL.Price = Convert.ToSingle(txtPrice.Text);
                productEL.Stocks = Convert.ToInt32(txtStocks.Text);


                if (s.Equals("ADD"))
                {
                    bol = productBL.Insert(productEL) > 0;
                }
                else if (s.Equals("EDIT"))
                {
                    bol = productBL.Update(productEL);
                }

                ShowResult(bol);

            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL REQUIRED FIELDS WITH AN ASTERISK");
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            methods.OnlyDecimalTXT(sender, e);
        }

        private void txtStocks_KeyPress(object sender, KeyPressEventArgs e)
        {
            methods.OnlyIntTXT(sender, e);
        }
    }
}
