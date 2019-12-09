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
        }


        private void PopulateCB()
        {
            methods.LoadCB(cbPreferredStrand, strandBL.List(""),"STRAND", "STRAND ID");
       
        }

        private void ManageDGV()
        {
            
            methods.DGVHiddenColumns(dgv, "STUDENT ID", "STRAND ID", "C", "FIRST NAME", "MIDDLE INITIAL", "LAST NAME", "ADDRESS", "PARENTS OR GUARDIAN", "CONTACT NUMBER", "LAST SCHOOL ATTENDED", "SCHOOL YEAR", "DESCRIPTION");
            methods.DGVTheme(dgv);
            methods.DGVFillWeights(dgv, new string[] { "LRN", "FULL NAME", "STRAND", "YEAR LEVEL", "DATE ADDED" }, new int[] { 20, 35, 15, 25, 15 });
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


        private void frmRegisteredStudents_Load(object sender, EventArgs e)
        {
            PopulateDGV();
            ShowForm(false);
            ManageDGV();
            PopulateCB();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtLRN, txtLastName, txtFirstName, txtMiddleInitial, txtAddress, txtParentsOrGuardian, txtContactNumber, txtLastSchoolAttended, txtSchoolYear) & methods.CheckRequiredCB(cbPreferredStrand, cbYearLevel))
            {
                bool bol = false;

                studentEL.Strandid = Convert.ToInt32(cbPreferredStrand.SelectedValue);
                studentEL.Lrn = txtLRN.Text;
                studentEL.Lastname = txtLastName.Text;
                studentEL.Firstname = txtFirstName.Text;
                studentEL.Middleinitial = txtMiddleInitial.Text;
                studentEL.Address = txtAddress.Text;
                studentEL.Parentsorguardian = txtParentsOrGuardian.Text;
                studentEL.Contactnumber = txtContactNumber.Text;
                studentEL.Lastschoolattended = txtLastSchoolAttended.Text;
                studentEL.Schoolyear = txtSchoolYear.Text;
                studentEL.Yearlevel = cbYearLevel.Text;
                studentEL.Dateadded = DateTime.Now.ToString("yyyy-MM-dd");


                if (s.Equals("ADD"))
                {
                    bol = studentBL.Insert(studentEL) > 0;
                }
                else if (s.Equals("EDIT"))
                {
                    bol = studentBL.Update(studentEL);
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
            studentEL.Studentid = Convert.ToInt32(dgv.SelectedRows[0].Cells["STUDENT ID"].Value);

            if (e.ColumnIndex == 0)
            {
                lblTitle.Text = "EDIT STUDENT INFORMATION";
                s = "EDIT";
                ShowForm(true);

                studentEL = studentBL.Select(studentEL);
                strandEL.Strandid = studentEL.Strandid;
                strandEL = strandBL.Select(strandEL);

                txtLRN.Text = studentEL.Lrn;
                txtLastName.Text = studentEL.Lastname;
                txtFirstName.Text = studentEL.Firstname;
                txtMiddleInitial.Text = studentEL.Middleinitial;
                txtAddress.Text = studentEL.Address;
                txtParentsOrGuardian.Text = studentEL.Parentsorguardian;
                txtContactNumber.Text = studentEL.Contactnumber;
                txtLastSchoolAttended.Text = studentEL.Lastschoolattended;
                txtSchoolYear.Text = studentEL.Schoolyear;
                cbPreferredStrand.SelectedIndex = cbPreferredStrand.FindString(strandEL.Strand);
                cbYearLevel.SelectedIndex = cbYearLevel.FindString(studentEL.Yearlevel);
            }

            if (e.ColumnIndex == 1)
            {
                switch (MessageBox.Show(this, "ARE YOU SURE TO DELETE THIS SELECTED ITEM?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        ShowResult(studentBL.Delete(studentEL));
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
            lblTitle.Text = "ADD STUDENT INFORMATION";
            s = "ADD";
            ShowForm(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }



    }
}
