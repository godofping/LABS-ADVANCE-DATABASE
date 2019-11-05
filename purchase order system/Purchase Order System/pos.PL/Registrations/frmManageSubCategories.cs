using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageSubCategories : Form
    {
        EL.Registrations.SubCategories subCategoryEL = new EL.Registrations.SubCategories();
        EL.Registrations.Categories categoryEL = new EL.Registrations.Categories();


        BL.Registrations.SubCategories subCategoryBL = new BL.Registrations.SubCategories();
        BL.Registrations.Categories categoryBL = new BL.Registrations.Categories();

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
            ClearFields();
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
            dgv.DataSource = subCategoryBL.List(keywords);
        }

        private void PopulateControls()
        {

            cbCategoryName.DisplayMember = "Category Name";
            cbCategoryName.ValueMember = "Category ID";
            cbCategoryName.DataSource = categoryBL.List("");
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
            dgv.ClearSelection();
            txtSubCategoryID.ResetText();
            txtSubCategoryName.ResetText();
            cbCategoryName.SelectedIndex = -1;
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
            subCategoryEL.Subcategoryname = txtSubCategoryName.Text;

            subCategoryEL.Categoryid = Convert.ToInt32(cbCategoryName.SelectedValue);

        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {

                subCategoryEL.Subcategoryid = Convert.ToInt32(row.Cells["Sub Category ID"].Value);
                subCategoryEL.Subcategoryname = row.Cells["Sub Category Name"].Value.ToString();
                subCategoryEL.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);
                subCategoryEL.Isdeleted = Convert.ToInt32(row.Cells["isdeleted"].Value);

                categoryEL.Categoryid = Convert.ToInt32(row.Cells["categoryid"].Value);
                categoryEL.Categoryname = row.Cells["Category Name"].Value.ToString();
                categoryEL.Isdeleted = Convert.ToInt32(row.Cells["categoriesisdeleted"].Value);

            }

            txtSubCategoryID.Text = subCategoryEL.Subcategoryid.ToString();
            txtSubCategoryName.Text = subCategoryEL.Subcategoryname.ToString();
            cbCategoryName.SelectedIndex = cbCategoryName.FindString(categoryEL.Categoryname);

        }

        private void ShowMessageBox(bool condition)
        {
            if (condition)
            {
                LoadData(txtSearch.Text);
                ClearFields();
                MessageBox.Show("Success");

            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void Add()
        {
            ShowMessageBox(subCategoryBL.Insert(subCategoryEL) > 0);
        }

        private void Edit()
        {
            ShowMessageBox(subCategoryBL.Update(subCategoryEL));
        }

        private void Delete()
        {
            ShowMessageBox(subCategoryBL.Delete(subCategoryEL));
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
