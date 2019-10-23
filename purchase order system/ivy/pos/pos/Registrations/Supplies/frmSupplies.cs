using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.Registrations.Supplies
{
    public partial class frmSupplies : Form
    {

        BL.Registrations.Supplies supplyBL = new BL.Registrations.Supplies();

        EL.Registrations.Supplies supplyInfo = new EL.Registrations.Supplies();

        public frmSupplies()
        {
            InitializeComponent();
        }

        private void hiddenColumns()
        {
            dgv.Columns["Supply ID"].Visible = false;
        }

        public void loadData(string keywords)
        {
            dgv.DataSource = supplyBL.List(keywords);
        }

        private void getDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                supplyInfo.Supplyid = Convert.ToInt32(row.Cells["Supply ID"].Value);
                supplyInfo.Supplyname = row.Cells["Supply Name"].Value.ToString();
                supplyInfo.Supplyunit = row.Cells["Supply Unit"].Value.ToString();
                supplyInfo.Supplyunitprice = Convert.ToSingle(row.Cells["Supply Unit Price"].Value);
                supplyInfo.Supplystocks = Convert.ToInt32(row.Cells["Supply ID"].Value);
               
            }

        }

        private void frmSupplies_Load(object sender, EventArgs e)
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
            frmAddSupply frmAddSupply = new frmAddSupply(this);
            frmAddSupply.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            if(dgv.SelectedRows.Count > 0)
            {
                getDataFromDataGridView();
                frmEditSupply frmEditSupply = new frmEditSupply(this, supplyInfo);
                frmEditSupply.ShowDialog();
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
                        if (supplyBL.Delete(supplyInfo))
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
