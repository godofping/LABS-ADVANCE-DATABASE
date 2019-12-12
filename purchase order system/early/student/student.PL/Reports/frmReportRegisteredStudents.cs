using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace student.PL.Reports
{
    public partial class frmReportRegisteredStudents : Form
    {
        EL.Registrations.strands strandEL = new student.EL.Registrations.strands();
        EL.Registrations.students studentEL = new student.EL.Registrations.students();

        BL.Registrations.strands strandBL = new student.BL.Registrations.strands();
        BL.Registrations.students studentBL = new student.BL.Registrations.students();

        public frmReportRegisteredStudents()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
  
            methods.ClearCB(cbPreferredStrand, cbYearLevel);
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbPreferredStrand, strandBL.List(""), "STRAND", "STRAND ID");
        }

        private void LoadReport(EL.Registrations.students studentEL)
        {
            

            var crvStudents = new crvStudents();

            crvStudents.Database.Tables["students_view"].SetDataSource(studentBL.List(studentEL));


            crv.ReportSource = null;
            crv.ReportSource = crvStudents;
            crv.Refresh();
        }

        private void frmRegisteredStudents_Load(object sender, EventArgs e)
        {

            PopulateCB();
            ClearControls();

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredCB(cbPreferredStrand, cbYearLevel))
            {
                studentEL.Strandid = Convert.ToInt32(cbPreferredStrand.SelectedValue);
                studentEL.Yearlevel = cbYearLevel.Text;

                LoadReport(studentEL);
            }
            else
            {
                MessageBox.Show("PLEASE FILL OUT THE FIELDS MARKED WITH AN ASTERISK");
            }
        }
    }
}
