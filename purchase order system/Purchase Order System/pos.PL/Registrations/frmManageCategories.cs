using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageCategories : Form
    {

        #region "Variables"

        EL.Registrations.Categories categoryEL = new EL.Registrations.Categories();
        BL.Registrations.Categories categoryBL = new BL.Registrations.Categories();
        string current = "";

        #endregion



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


        #region "Methods"

        private void HiddenColumns()
        {
            dgv.Columns["Category ID"].Visible = false;
        }

        private void LoadData(string keywords)
        {
            dgv.DataSource = categoryBL.List(keywords);
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
            errorProvider1.SetError(txtCategoryName, "");

        }

        private void ClearFields()
        {
            dgv.ClearSelection();
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
            categoryEL.Categoryname = txtCategoryName.Text;

        }

        private void GetDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {

                categoryEL.Categoryid = Convert.ToInt32(row.Cells["Category ID"].Value);
                categoryEL.Categoryname = row.Cells["Category Name"].Value.ToString();
            }

            txtCategoryName.Text = categoryEL.Categoryname.ToString();

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

        #endregion














        #region "Events"

        private void frmCategories_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
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
            if (dgv.SelectedRows.Count == 0)
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
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("No selected item. Please select first.");
            }
            else
            {
                switch (MessageBox.Show(this, "Are you sure to delete this?", "Confirming", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        ShowMessageBox(categoryBL.Delete(categoryEL));
                        break;
                }  
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                if (current.Equals("ADD"))
                {
                    ShowMessageBox(categoryBL.Insert(categoryEL) > 0);
                }
                else if (current.Equals("EDIT"))
                {
                    ShowMessageBox(categoryBL.Update(categoryEL));
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

        #endregion




    }
}
