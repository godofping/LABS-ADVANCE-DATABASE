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

        pos.BL.Registrations.Categories CategoryBL = new pos.BL.Registrations.Categories();
        pos.EL.Registrations.Categories CategoryInfo = new pos.EL.Registrations.Categories();

        public frmCategories()
        {
            InitializeComponent();
        }



     

        private void loaddata()
        {
            CategoryInfo = new pos.EL.Registrations.Categories();
            dtCategories.DataSource = CategoryBL.List(CategoryInfo);
        }

       
        private void BtnAdd_Click_1(object sender, EventArgs e)
        {
            CategoryInfo.Categoryname = txtCategoryName.Text;


            bool isSuccessfull = CategoryBL.Insert(CategoryInfo);
            if (isSuccessfull)
            {
                MessageBox.Show("Record Successfully Addded!");
                loaddata();
            }
            else
            {
                MessageBox.Show("Adding Record Failed!");
            }
        }

        private void BtnEdit_Click_1(object sender, EventArgs e)
        {

            CategoryInfo.Categoryid = Convert.ToInt32(txtCategoryID.Text);
            CategoryInfo.Categoryname = txtCategoryName.Text;

            bool isSuccessfull = CategoryBL.Update(CategoryInfo);
            if (isSuccessfull)
            {
                MessageBox.Show("Record Successfully Updated!");
                loaddata();
            }
            else
            {

                MessageBox.Show("Updating Record Failed!");
            }
        }

        private void BtnDelete_Click_1(object sender, EventArgs e)
        {
            CategoryInfo.Categoryid = Convert.ToInt32(txtCategoryID.Text);


            bool isSuccessfull = CategoryBL.Delete(CategoryInfo);
            if (isSuccessfull)
            {
                MessageBox.Show("Record Successfully Deleted!");
                loaddata();
            }
            else
            {

                MessageBox.Show("Deleting Record Failed!");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void DtCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (dtCategories.Rows.Count >= 1)
            //{

            //    txtCategoryID.Text = dtCategories.Rows[e.RowIndex].Cells["categoryid"].Value.ToString();
            //    CategoryInfo.Categoryid = Convert.ToInt32(txtCategoryID.Text);
            //    txtCategoryName.Text = dtCategories.Rows[e.RowIndex].Cells["categoryname"].Value.ToString();
            //    CategoryInfo.Categoryname = txtCategoryName.Text;

            //}
           
        }

        private void DtCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtCategories_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtCategories.SelectedRows)
            {
                txtCategoryID.Text = row.Cells["categoryid"].Value.ToString();
                CategoryInfo.Categoryid = Convert.ToInt32(txtCategoryID.Text);
                txtCategoryName.Text = row.Cells["categoryname"].Value.ToString();
            }
        }
    }
}
