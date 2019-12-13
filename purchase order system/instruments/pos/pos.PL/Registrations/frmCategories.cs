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
    public partial class frmCategories : Form
    {

        EL.Registrations.categories categoryEL = new EL.Registrations.categories();

        BL.Registrations.categories categoryBL = new BL.Registrations.categories();

        string s = "";

        public frmCategories()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            methods.ClearTXT(txtCategory);
        }

        private void PopulateDGV()
        {
            dgv.DataSource = categoryBL.List(txtSearch.Text);
        }

        private void ManageDGV()
        {
            methods.DGVBUTTONAddEdit(dgv);
            PopulateDGV();
            methods.DGVHiddenColumns(dgv, "C");
            methods.DGVTheme(dgv);
            methods.DGVFillWeights(dgv, new string[] { "CATEGORY ID", "CATEGORY" }, new int[] { 30,70 });
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

        private void frmCategories_Load(object sender, EventArgs e)
        {
            ShowForm(false);
            ManageDGV();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            lblTitle.Text = "ADD CATEGORY";
            ShowForm(true);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 | e.ColumnIndex == 1)
                categoryEL.Categoryid = Convert.ToInt32(dgv.SelectedRows[0].Cells["CATEGORY ID"].Value);

            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                lblTitle.Text = "UPDATE CATEGORY";
                ShowForm(true);

                categoryEL = categoryBL.Select(categoryEL);
                txtCategory.Text = categoryEL.Category;

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

            if (methods.CheckRequiredTXT(txtCategory))
            {
                categoryEL.Category = txtCategory.Text;

                if (s.Equals("ADD"))
                {
                    bol = categoryBL.Insert(categoryEL) > 0;
                }
                else if (s.Equals("EDIT"))
                {
                    bol = categoryBL.Update(categoryEL);
                }

                ShowResult(bol);
                
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL REQUIRED FIELDS WITH AN ASTERISK");
            }
        }
    }
}
