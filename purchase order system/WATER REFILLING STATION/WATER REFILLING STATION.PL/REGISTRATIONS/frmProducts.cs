using System;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.REGISTRATIONS
{
    public partial class frmProducts : Form
    {
        string s = "";

        EL.REGISTRATIONS.products productEL = new EL.REGISTRATIONS.products();
        EL.REGISTRATIONS.productcategories productcategoryEL = new EL.REGISTRATIONS.productcategories();
        EL.REGISTRATIONS.particulars particularEL = new EL.REGISTRATIONS.particulars();
        EL.REGISTRATIONS.containertypes containertypeEL = new EL.REGISTRATIONS.containertypes();
        EL.REGISTRATIONS.stocks stockEL = new EL.REGISTRATIONS.stocks();

        BL.REGISTRATIONS.products productBL = new BL.REGISTRATIONS.products();
        BL.REGISTRATIONS.productcategories productcategoryBL = new BL.REGISTRATIONS.productcategories();
        BL.REGISTRATIONS.particulars particularBL = new BL.REGISTRATIONS.particulars();
        BL.REGISTRATIONS.containertypes containertypeBL = new BL.REGISTRATIONS.containertypes();
        BL.REGISTRATIONS.stocks stockBL = new BL.REGISTRATIONS.stocks();

        public frmProducts()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            methods.ClearTXT(txtPrice);
            methods.ClearCB(cbProductCategory, cbParticular, cbContainerType);
        }

        private void FormActive(bool bol)
        {
            pnlCenter.Visible = bol;
            pnlTop.Visible = !bol;
            dgv.Visible = !bol;
            ClearControls();

            if(s.Equals("ADD"))
            {
                methods.EnabledCB(true, cbProductCategory, cbParticular, cbContainerType);
            }
            else if (s.Equals("EDIT"))
            {
                methods.EnabledCB(false, cbProductCategory, cbParticular, cbContainerType);
            }
            
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, productBL.List(txtSearch.Text));
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbProductCategory, productcategoryBL.List(), "PRODUCT CATEGORY", "PRODUCT CATEGORY ID");
            methods.LoadCB(cbParticular, particularBL.List(), "PARTICULAR", "PARTICULAR ID");
            methods.LoadCB(cbContainerType, containertypeBL.List(), "CONTAINER TYPE", "CONTAINER TYPE ID");
        }

        private void ManageDGV()
        {
            methods.DGVHiddenColumns(dgv,
                "PRODUCT ID",
                "PRODUCT CATEGORY ID",
                "PARTICULAR ID",
                "CONTAINER TYPE ID",
                "STOCK ID"
                );

            methods.DGVFillWeights(
                dgv,
                new string[] { "PRODUCT CATEGORY", "PARTICULAR", "CONTAINER TYPE", "PRICE", "STOCK" },
                new int[] { 25, 17, 35, 10, 13 }
                );

            methods.DGVTheme(dgv);
            methods.DGVAddButtons(dgv);
        }


        private void frmProducts_Load(object sender, EventArgs e)
        {
            PopulateDGV();
            PopulateCB();
            ManageDGV();
            FormActive(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            lblTitle.Text = "CREATE";
            FormActive(true);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormActive(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bol;

            if (cbProductCategory.Text.Equals("NEW CONTAINER ONLY"))
            {
                bol = methods.CheckRequiredTXT(txtPrice, txtStock) &
                 methods.CheckRequiredCB(cbProductCategory, cbParticular, cbContainerType);
                stockEL.Stock = Convert.ToInt32(txtStock.Text);

            }
            else
            {
                bol = methods.CheckRequiredTXT(txtPrice) &
                methods.CheckRequiredCB(cbProductCategory, cbParticular, cbContainerType);
            }


            if (bol)
            {

                productEL.Productcategoryid = Convert.ToInt32(cbProductCategory.SelectedValue);
                productEL.Particularid = Convert.ToInt32(cbParticular.SelectedValue);
                productEL.Containertypeid = Convert.ToInt32(cbContainerType.SelectedValue);
                productEL.Price = Convert.ToSingle(txtPrice.Text);


                if (productBL.IsExisting(productEL).Rows.Count == 0)
                {

                    if (s.Equals("ADD"))
                    {
                        productEL.Productid = Convert.ToInt32(productBL.Insert(productEL));
                        if (productEL.Productid > 0)
                        {

                            if (cbProductCategory.Text.Equals("NEW CONTAINER ONLY"))
                            {
                                stockEL.Productid = productEL.Productid;
                                stockEL.Stock = Convert.ToInt32(txtStock.Text);

                                stockEL.Stockid = Convert.ToInt32(stockBL.Insert(stockEL));
                            }
                            else
                            {
                                stockEL.Stockid = 1;
                            }


                            if (productEL.Productid > 0 & stockEL.Stockid > 0)
                            {
                                FormActive(false);
                                PopulateDGV();
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
                    else if (s.Equals("EDIT"))
                    {

                        if (cbProductCategory.Text.Equals("NEW CONTAINER ONLY"))
                        {
                            bol = stockBL.Update(stockEL) & productBL.Update(productEL);
                        }
                        else
                        {
                            bol = false;
                        }

                        if (bol)
                        {
                            FormActive(false);
                            PopulateDGV();
                            MessageBox.Show("UPDATED");
                        }
                        else
                        {
                            MessageBox.Show("FAILED");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("PRODUCT IS ALREADY EXISTING");
                }

            }
            else
            {

                MessageBox.Show("PLEASE COMPLETE ALL THE REQUIRED FIELDS (*)");
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                lblTitle.Text = "UPDATE";


                FormActive(true);

                productEL.Productid = Convert.ToInt32(dgv.SelectedRows[0].Cells["PRODUCT ID"].Value);
                cbProductCategory.SelectedIndex = cbProductCategory.FindString(dgv.SelectedRows[0].Cells["PRODUCT CATEGORY"].Value.ToString());
                cbParticular.SelectedIndex = cbParticular.FindString(dgv.SelectedRows[0].Cells["PARTICULAR"].Value.ToString());
                cbContainerType.SelectedIndex = cbContainerType.FindString(dgv.SelectedRows[0].Cells["CONTAINER TYPE"].Value.ToString());
                txtPrice.Text = dgv.SelectedRows[0].Cells["PRICE"].Value.ToString();

                if (cbProductCategory.Text.Equals("NEW CONTAINER ONLY"))
                {
                    stockEL.Stockid = Convert.ToInt32(dgv.SelectedRows[0].Cells["STOCK ID"].Value);
                    txtStock.Text = dgv.SelectedRows[0].Cells["STOCK"].Value.ToString();
                }

            }

            if (e.ColumnIndex == 1)
            {
                switch (MessageBox.Show(this, "Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        productEL.Productid = Convert.ToInt32(dgv.SelectedRows[0].Cells["PRODUCT ID"].Value);
                        if (productBL.Delete(productEL))
                        {
                            MessageBox.Show("DELETED");
                            PopulateDGV();
                        }
                        else
                        {
                            MessageBox.Show("FAILED");
                        }
                        break;
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            methods.OnlyDecimalTXT(sender, e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            methods.OnlyIntTXT(sender, e);
        }

        private void cbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProductCategory.Text.Equals("NEW CONTAINER ONLY"))
            {
                lblStock.Visible = true;
                txtStock.Visible = true;
                cbParticular.SelectedIndex = cbParticular.FindString("NOT AVAILABLE");
                methods.EnabledCB(false, cbParticular);
            }
            else
            {
                lblStock.Visible = false;
                txtStock.Visible = false;

                if(s.Equals("ADD"))
                {
                    cbParticular.SelectedIndex = -1;
                    methods.EnabledCB(true, cbParticular);
                }
                
            }
        }
    }
}
