using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace student.PL.Registrations
{
    public partial class frmStrands : Form
    {
        EL.Registrations.strands strandEL = new student.EL.Registrations.strands();

        BL.Registrations.strands strandBL = new student.BL.Registrations.strands();

        string s = "";

        public frmStrands()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            methods.ClearTXT(txtStrand, txtDescription);
        }

        private void ShowForm(bool bol)
        {
            pnlMain.Visible = !bol;
            pnlCRUD.Visible = bol;

            ClearControls();
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, strandBL.List(txtSearch.Text));
        }

        private void ManageDGV()
        {

            methods.DGVHiddenColumns(dgv, "STRAND ID", "C");
            methods.DGVTheme(dgv);
            methods.DGVFillWeights(dgv, new string[] { "STRAND" , "DESCRIPTION" }, new int[] { 20 ,80 });
            methods.DGVAddButtons(dgv);
            PopulateDGV();
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                PopulateDGV();
                MessageBox.Show("SUCCESS");
            }
            else
            {
                MessageBox.Show("FAILED");
            }
        }



        private void frmStrands_Load(object sender, EventArgs e)
        {
            PopulateDGV();
            ShowForm(false);
            ManageDGV();

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtStrand, txtDescription))
            {
                bool bol = false;

                strandEL.Strand = txtStrand.Text;
                strandEL.Stranddescription = txtDescription.Text;

                if(s.Equals("ADD"))
                {
                    bol = strandBL.Insert(strandEL) > 0;
                }
                else if(s.Equals("EDIT"))
                {
                    bol = strandBL.Update(strandEL);
                }

                ShowForm(false);
                ShowResult(bol);
                
                
            }
            else 
            {
                MessageBox.Show("PLEASE FILL OUT THE FIELDS MARKED WITH AN ASTERISK");
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            strandEL.Strandid = Convert.ToInt32(dgv.SelectedRows[0].Cells["STRAND ID"].Value);

            if (e.ColumnIndex == 0)
            {
                lblTitle.Text = "EDIT STRAND";
                s = "EDIT";
                ShowForm(true);

                strandEL = strandBL.Select(strandEL);

                txtStrand.Text = strandEL.Strand;
                txtDescription.Text = strandEL.Stranddescription;
            }

            if (e.ColumnIndex == 1)
            {
                switch (MessageBox.Show(this, "ARE YOU SURE TO DELETE THIS SELECTED ITEM?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        ShowResult(strandBL.Delete(strandEL));
                        break;
                }
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "ADD STRAND";
            s = "ADD";
            ShowForm(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }
    }
}
