using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.Registrations.Accounts
{
    public partial class frmAccounts : Form
    {

        BL.Registrations.Accounts accountBL = new BL.Registrations.Accounts();

        EL.Registrations.Accounts accountInfo = new EL.Registrations.Accounts();

        public frmAccounts()
        {
            InitializeComponent();
        }

        private void hiddenColumns()
        {
            dgv.Columns["Account ID"].Visible = false;
            dgv.Columns["Account Password"].Visible = false;
        }

        public void loadData(string keywords)
        {
            dgv.DataSource = accountBL.List(keywords);
        }

        private void getDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                accountInfo.Accountid = Convert.ToInt32(row.Cells["Account ID"].Value);
                accountInfo.Accountusername = row.Cells["Account Username"].Value.ToString();
                accountInfo.Accountpassword = row.Cells["Account Password"].Value.ToString();
                accountInfo.Accountfullname = row.Cells["Account Full Name"].Value.ToString();
            }

        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            loadData(txtSearch.Text);
            hiddenColumns();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadData(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddAccount frmAddAccount = new frmAddAccount(this);
            frmAddAccount.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                getDataFromDataGridView();
                frmEditAccount frmEditAccount = new frmEditAccount(this, accountInfo);
                frmEditAccount.ShowDialog();
            }
            else
            {
                MessageBox.Show("No selected rows.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                getDataFromDataGridView();

                switch (MessageBox.Show(this, "Are you sure you want to delete this record?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        if (accountBL.Delete(accountInfo))
                        {
                            loadData(txtSearch.Text);
                            MessageBox.Show("success");
                        }
                        else
                        {
                            MessageBox.Show("failed");
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("No selected rows.");
            }
        }

        
    }
}
