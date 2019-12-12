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
    public partial class frmStrandsPopulations : Form
    {
        EL.Registrations.strands strandEL = new student.EL.Registrations.strands();

        BL.Registrations.strands strandBL = new student.BL.Registrations.strands();

        public frmStrandsPopulations()
        {
            InitializeComponent();
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, strandBL.Populations());
        }

        private void ManageDGV()
        {
            PopulateDGV();
            methods.DGVHiddenColumns(dgv, "STRAND ID");
            methods.DGVTheme(dgv);
            methods.DGVFillWeights(dgv, new string[] { "STRAND", "DESCRIPTION", "GRADE 11 POPULATION", "GRADE 12 POPULATION", "TOTAL POPULATION" }, new int[] { 15, 40, 15 ,15 ,15 });
            
        }

        private void frmStrandsPopulations_Load(object sender, EventArgs e)
        {
            ManageDGV();
        }
    }
}
