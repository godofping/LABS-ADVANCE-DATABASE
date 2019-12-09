using System;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.REGISTRATIONS
{
    public partial class frmParticulars : Form
    {
        string s;
        EL.REGISTRATIONS.particulars particularEL = new EL.REGISTRATIONS.particulars();

        BL.REGISTRATIONS.particulars particularBL = new BL.REGISTRATIONS.particulars();

        public frmParticulars()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            methods.ClearTXT(txtParticular);
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
            methods.LoadDGV(dgv, particularBL.List(txtSearch.Text));
            methods.DGVHiddenColumns(dgv, "PARTICULAR ID");
        }

        private void frmParticulars_Load(object sender, EventArgs e)
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
                methods.CheckRequiredTXT(txtParticular)
                )
            {
                particularEL.Particular = txtParticular.Text;

                if (s.Equals("ADD"))
                {
                    if (Convert.ToInt32(particularBL.Insert(particularEL)) > 0)
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
                    if (particularBL.Update(particularEL))
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
                particularEL.Particularid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                txtParticular.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();

                lblTitle.Text = "UPDATE";
            }

            if (e.ColumnIndex == 1)
            {
                switch (MessageBox.Show(this, "Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        particularEL.Particularid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                        if (particularBL.Delete(particularEL))
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
