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
    public partial class frmManageCategories : Form
    {
        EL.Registrations.Categories CategoryInfo = new EL.Registrations.Categories();

        BL.Registrations.Categories CategoryBL = new BL.Registrations.Categories();

        string current = "";

        public frmManageCategories()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public class BufferedPanel : Panel
        {
            public BufferedPanel()
            {
                DoubleBuffered = true;
            }
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
        }

        private void HiddenColumns()
        {
            dgvManageCategories.Columns["Category ID"].Visible = false;
            dgvManageCategories.Columns["isdeleted"].Visible = false;
        }

        private void LoadData(string keywords)
        {
            dgvManageCategories.DataSource = CategoryBL.List(keywords);
        }

        private void ManageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;
            dgvManageCategories.Enabled = !status;
            txtSearch.Enabled = !status;
        }

        private void ClearErrors()
        {
            errorProvider1.SetError(txtCategoryName, "");

        }

        private void ClearFields()
        {
            txtCategoryID.ResetText();
            txtCategoryName.ResetText();
        }

        private bool CheckErrors()
        {
            bool status = true;

            if (txtCategoryName.Text.Equals(""))
            {
                errorProvider1.SetError(txtCategoryName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtCategoryName, "");

            return status;
        }

        private void GetDataFromForm()
        {
            CategoryInfo.Categoryname = txtCategoryName.Text;

        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgvManageCategories.SelectedRows)
            {
             
                CategoryInfo.Categoryid = Convert.ToInt32(row.Cells["Category ID"].Value);
                CategoryInfo.Categoryname = row.Cells["Category Name"].Value.ToString();
                CategoryInfo.Isdeleted = Convert.ToInt32(row.Cells["isdeleted"].Value);

            }

            txtCategoryID.Text = CategoryInfo.Categoryid.ToString();
            txtCategoryName.Text = CategoryInfo.Categoryname.ToString();


        }

        private void Add()
        {
            GetDataFromForm();

            if (CategoryBL.Insert(CategoryInfo) > 0)
            {
                LoadData(txtSearch.Text);
                MessageBox.Show("Success");

            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void Edit()
        {
            GetDataFromForm();
            if (CategoryBL.Update(CategoryInfo))
            {
                LoadData(txtSearch.Text);
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void Delete()
        {
            GetDataFromForm();
            if (CategoryBL.Delete(CategoryInfo))
            {
                LoadData(txtSearch.Text);
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            ManageForm(true);
            this.ActiveControl = txtCategoryName;
            current = "ADD";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtCategoryID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                ManageForm(true);
                this.ActiveControl = txtCategoryName;
                current = "EDIT";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCategoryID.Text.Equals(""))
            {
                MessageBox.Show("No selected item. Please select first.");
            }
            else
            {
                Delete();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                if (current.Equals("ADD"))
                {
                    Add();
                }
                else if (current.Equals("EDIT"))
                {
                    Edit();
                }

                ManageForm(false);
                ClearFields();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageForm(false);
            ClearFields();
            ClearErrors();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void dgvManageCategories_SelectionChanged(object sender, EventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgvManageCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgvManageCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }


    }
}
