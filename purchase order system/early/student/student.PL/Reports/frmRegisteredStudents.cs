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
    public partial class frmRegisteredStudents : Form
    {
        EL.Registrations.strands strandEL = new student.EL.Registrations.strands();
        EL.Registrations.students studentEL = new student.EL.Registrations.students();

        BL.Registrations.strands strandBL = new student.BL.Registrations.strands();
        BL.Registrations.students studentBL = new student.BL.Registrations.students();

        public frmRegisteredStudents()
        {
            InitializeComponent();
        }

        private void frmRegisteredStudents_Load(object sender, EventArgs e)
        {
            var crvStudents = new crvStudents();



            crvStudents.Database.Tables["students_view"].SetDataSource(studentBL.List(""));


            crv.ReportSource = null;
            crv.ReportSource = crvStudents;
            crv.Refresh();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }
    }
}
