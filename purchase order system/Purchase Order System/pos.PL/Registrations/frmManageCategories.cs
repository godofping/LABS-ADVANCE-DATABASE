using System;
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
            loadData(txtSearch.Text);
            hiddenColumns();
            manageForm(false);
        }

        private void hiddenColumns()
        {
            dgv.Columns["Category ID"].Visible = false;
            dgv.Columns["isdeleted"].Visible = false;
        }

        private void loadData(string keywords)
        {
            dgv.DataSource = CategoryBL.List(keywords);
        }

        private void manageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;
            dgv.Enabled = !status;
            txtSearch.Enabled = !status;
        }

        private void clearErrors()
        {
            errorProvider1.SetError(txtCategoryName, "");

        }

        private void clearFields()
        {
            dgv.ClearSelection();
            txtCategoryID.ResetText();
            txtCategoryName.ResetText();
        }

        private bool checkErrors()
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

        private void getDataFromForm()
        {
            CategoryInfo.Categoryname = txtCategoryName.Text;

        }

        private void getDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {

                CategoryInfo.Categoryid = Convert.ToInt32(row.Cells["Category ID"].Value);
                CategoryInfo.Categoryname = row.Cells["Category Name"].Value.ToString();
                CategoryInfo.Isdeleted = Convert.ToInt32(row.Cells["isdeleted"].Value);

            }

            txtCategoryID.Text = CategoryInfo.Categoryid.ToString();
            txtCategoryName.Text = CategoryInfo.Categoryname.ToString();


        }

        private void showMessageBox(bool condition)
        {
            if (condition)
            {
                loadData(txtSearch.Text);
                clearFields();
                MessageBox.Show("Success");

            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void add()
        {
            getDataFromForm();
            showMessageBox(CategoryBL.Insert(CategoryInfo) > 0);
        }

        private void edit()
        {
            getDataFromForm();
            showMessageBox(CategoryBL.Update(CategoryInfo));
        }

        private void delete()
        {
            getDataFromForm();
            showMessageBox(CategoryBL.Delete(CategoryInfo));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearFields();
            manageForm(true);
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
                manageForm(true);
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
                delete();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkErrors())
            {
                getDataFromForm();
                if (current.Equals("ADD"))
                {
                    add();
                }
                else if (current.Equals("EDIT"))
                {
                    edit();
                }

                manageForm(false);
                clearFields();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            manageForm(false);
            clearFields();
            clearErrors();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadData(txtSearch.Text);
        }

        private void dgvManageCategories_SelectionChanged(object sender, EventArgs e)
        {
            getDataFromDataGridView();
        }

        private void dgvManageCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDataGridView();
        }

        private void dgvManageCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDataGridView();
        }


    }
}
