using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageSubCategories : Form
    {
        EL.Registrations.Subcategories SubCategoryInfo = new EL.Registrations.Subcategories();
        EL.Registrations.Categories CategoryInfo = new EL.Registrations.Categories();


        BL.Registrations.Subcategories SubCategoryBL = new BL.Registrations.Subcategories();
        BL.Registrations.Categories CategoryBL = new BL.Registrations.Categories();

        string current = "";

        public frmManageSubCategories()
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

        private void frmManageSubCategories_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
            PopulateControls();
        }

        private void HiddenColumns()
        {
            dgv.Columns["Sub Category ID"].Visible = false;
            dgv.Columns["categoryid"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;
            dgv.Columns["categoriesisdeleted"].Visible = false;
        }

        private void LoadData(string keywords)
        {
            dgv.DataSource = SubCategoryBL.List(keywords);
        }

        private void PopulateControls()
        {

            cbCategoryName.DisplayMember = "Category Name";
            cbCategoryName.ValueMember = "Category ID";
            cbCategoryName.DataSource = CategoryBL.List("");
        }

        private void ManageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;
            dgv.Enabled = !status;
            txtSearch.Enabled = !status;
        }

        private void ClearErrors()
        {
            errorProvider1.SetError(txtSubCategoryName, "");
            errorProvider1.SetError(cbCategoryName, "");
        }

        private void ClearFields()
        {
            txtSubCategoryID.ResetText();
            txtSubCategoryName.ResetText();
            cbCategoryName.ResetText();
        }

        private bool CheckErrors()
        {
            bool status = true;

            if (txtSubCategoryName.Text.Equals(""))
            {
                errorProvider1.SetError(txtSubCategoryName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtSubCategoryName, "");

            if (cbCategoryName.Text.Equals(""))
            {
                errorProvider1.SetError(cbCategoryName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbCategoryName, "");

            return status;
        }

        private void GetDataFromForm()
        {
            SubCategoryInfo.Subcategoryname = txtSubCategoryName.Text;

            SubCategoryInfo.Categoryid = Convert.ToInt32(cbCategoryName.SelectedValue);

        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {

                SubCategoryInfo.Subcategoryid = Convert.ToInt32(row.Cells["Sub Category ID"].Value);
                SubCategoryInfo.Subcategoryname = row.Cells["Sub Category Name"].Value.ToString();
                SubCategoryInfo.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);
                SubCategoryInfo.Isdeleted = Convert.ToInt32(row.Cells["isdeleted"].Value);

                CategoryInfo.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);
                CategoryInfo.Categoryname = row.Cells["Category Name"].Value.ToString();
                CategoryInfo.Isdeleted = Convert.ToInt32(row.Cells["categoriesisdeleted"].Value);

            }

            txtSubCategoryID.Text = SubCategoryInfo.Subcategoryid.ToString();
            txtSubCategoryName.Text = SubCategoryInfo.Subcategoryname.ToString();
            cbCategoryName.SelectedText = CategoryInfo.Categoryname;


        }

        private void Add()
        {
            GetDataFromForm();

            if (SubCategoryBL.Insert(SubCategoryInfo) > 0)
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
            if (SubCategoryBL.Update(SubCategoryInfo))
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
            if (SubCategoryBL.Delete(SubCategoryInfo))
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
            this.ActiveControl = txtSubCategoryName;
            current = "ADD";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtSubCategoryID.Text.Equals(""))
            {
                MessageBox.Show("No selected client. Please select first.");
            }
            else
            {
                ManageForm(true);
                this.ActiveControl = txtSubCategoryName;
                current = "EDIT";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSubCategoryID.Text.Equals(""))
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

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataFromDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }
    }
}
