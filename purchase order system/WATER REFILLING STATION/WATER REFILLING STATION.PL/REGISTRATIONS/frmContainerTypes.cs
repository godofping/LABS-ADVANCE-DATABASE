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
    public partial class frmContainerTypes : Form
    {
        string s;

        EL.REGISTRATIONS.containertypes containertypeEL = new EL.REGISTRATIONS.containertypes();

        BL.REGISTRATIONS.containertypes containertypeBL = new BL.REGISTRATIONS.containertypes();

        public frmContainerTypes()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            methods.ClearTXT(txtContainer);
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
            methods.LoadDGV(dgv, containertypeBL.List(txtSearch.Text));
            methods.DGVHiddenColumns(dgv, "CONTAINER TYPE ID");
        }

        private void frmContainers_Load(object sender, EventArgs e)
        {
            FormActive(false);
            PopulateDGV();
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
                methods.CheckRequiredTXT(txtContainer)
                )
            {
                containertypeEL.Containertype = txtContainer.Text;

                if (s.Equals("ADD"))
                {
                    if (Convert.ToInt32(containertypeBL.Insert(containertypeEL)) > 0)
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
                    if (containertypeBL.Update(containertypeEL))
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
                s = "EDIT";
                FormActive(true);
                containertypeEL.Containertypeid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                txtContainer.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();

                lblTitle.Text = "UPDATE";
            }

            if (e.ColumnIndex == 1)
            {
                switch (MessageBox.Show(this, "Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        containertypeEL.Containertypeid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                        if (containertypeBL.Delete(containertypeEL))
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

        

        
    }
}
