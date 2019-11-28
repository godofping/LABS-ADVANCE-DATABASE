using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.REGISTRATIONS
{
    public partial class frmProducts : Form
    {
        string s;

        EL.REGISTRATIONS.products productEL = new EL.REGISTRATIONS.products();
        EL.REGISTRATIONS.productcategories productcategoryEL = new EL.REGISTRATIONS.productcategories();
        EL.REGISTRATIONS.particulars particularEL = new EL.REGISTRATIONS.particulars();
        EL.REGISTRATIONS.containertypes containertypeEL = new EL.REGISTRATIONS.containertypes();

        BL.REGISTRATIONS.products productBL = new BL.REGISTRATIONS.products();
        BL.REGISTRATIONS.productcategories productcategoryBL = new BL.REGISTRATIONS.productcategories();
        BL.REGISTRATIONS.particulars particularBL = new BL.REGISTRATIONS.particulars();
        BL.REGISTRATIONS.containertypes containertypeBL = new BL.REGISTRATIONS.containertypes();

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
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, productBL.List(txtSearch.Text));
            methods.DGVHiddenColumns(dgv,
                "PRODUCT ID",
                "PRODUCT CATEGORY ID",
                "PARTICULAR ID",
                "CONTAINER TYPE ID"
                );
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbProductCategory, productcategoryBL.List(), "PRODUCT CATEGORY", "PRODUCT CATEGORY ID");
            methods.LoadCB(cbParticular, particularBL.List(), "PARTICULAR", "PARTICULAR ID");
            methods.LoadCB(cbContainerType, containertypeBL.List(), "CONTAINER TYPE", "CONTAINER TYPE ID");
        }

        private void PopulateCB(bool bol)
        {
            methods.LoadCB(cbParticular, particularBL.List(), "PARTICULAR", "PARTICULAR ID");
            methods.LoadCB(cbContainerType, containertypeBL.List(), "CONTAINER TYPE", "CONTAINER TYPE ID");
        }


        private void frmProducts_Load(object sender, EventArgs e)
        {
            FormActive(false);
            PopulateDGV();
            PopulateCB();
            methods.DGVAddButtons(dgv);
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
            if (
                methods.CheckRequiredTXT(txtPrice) &
                methods.CheckRequiredCB(cbProductCategory, cbParticular, cbContainerType)
                )
            {
                productEL.Productcategoryid = Convert.ToInt32(cbProductCategory.SelectedValue);
                productEL.Particularid = Convert.ToInt32(cbParticular.SelectedValue);
                productEL.Containertypeid = Convert.ToInt32(cbContainerType.SelectedValue);
                productEL.Price = Convert.ToSingle(txtPrice.Text);
                
                if(productBL.IsExisting(productEL).Rows.Count == 0)
                {
                    if (s.Equals("ADD"))
                    {
                        productEL.Productid = 0;
                        if (Convert.ToInt32(productBL.Insert(productEL)) > 0)
                        {
                            MessageBox.Show("INSERTED");
                            FormActive(false);
                            PopulateDGV();
                        }
                        else
                        {
                            MessageBox.Show("FAILED");
                        }
                    }
                    else if (s.Equals("EDIT"))
                    {
                        if (productBL.Update(productEL))
                        {
                            MessageBox.Show("UPDATED");
                            FormActive(false);
                            PopulateDGV();
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

                FormActive(true);

                productEL.Productid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                cbProductCategory.SelectedIndex = cbProductCategory.FindString(dgv.SelectedRows[0].Cells[6].Value.ToString());
                cbParticular.SelectedIndex = cbParticular.FindString(dgv.SelectedRows[0].Cells[7].Value.ToString());
                cbContainerType.SelectedIndex = cbContainerType.FindString(dgv.SelectedRows[0].Cells[8].Value.ToString());
                txtPrice.Text = dgv.SelectedRows[0].Cells[9].Value.ToString();


                s = "EDIT";
                lblTitle.Text = "UPDATE";
            }

            if (e.ColumnIndex == 1)
            {
                switch (MessageBox.Show(this, "Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        productEL.Productid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
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


    }
}
