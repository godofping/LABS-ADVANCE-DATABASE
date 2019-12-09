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
    public partial class frmRegisteredStudents : Form
    {
        EL.Registrations.strands strandEL = new student.EL.Registrations.strands();
        EL.Registrations.students studentEL = new student.EL.Registrations.students();

        BL.Registrations.strands strandBL = new student.BL.Registrations.strands();
        BL.Registrations.students studentBL = new student.BL.Registrations.students();

        string s = "";

        public frmRegisteredStudents()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            methods.ClearTXT(txtLRN, txtLastName, txtFirstName, txtMiddleInitial, txtAddress, txtParentsOrGuardian, txtContactNumber, txtLastSchoolAttended, txtSchoolYear);
            methods.ClearCB(cbPreferredStrand, cbYearLevel);
        }

        private void ShowForm(bool bol)
        {
            pnlMain.Visible = !bol;
            pnlCRUD.Visible = bol;

            ClearControls();
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, studentBL.List(txtSearch.Text));
            methods.DGVHiddenColumns(dgv, "STUDENT ID","STRAND ID", "C");
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


        private void frmRegisteredStudents_Load(object sender, EventArgs e)
        {
            ShowForm(false);
            PopulateDGV();
            methods.DGVAddButtons(dgv);
            PopulateDGV();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtStrand, txtDescription))
            {
                bool bol = false;

                strandEL.Strand = txtStrand.Text;
                strandEL.Stranddescription = txtDescription.Text;

                if (s.Equals("ADD"))
                {
                    bol = strandBL.Insert(strandEL) > 0;
                }
                else if (s.Equals("EDIT"))
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

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
