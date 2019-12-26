using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barangay.PL.Transactions
{
    public partial class frmPopulationSummary : Form
    {

        EL.Registrations.Residents residentEL;

        BL.Registrations.Residents residentBL = new BL.Registrations.Residents();

        public frmPopulationSummary()
        {
            InitializeComponent();
        }


        private void btnCloseView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPopulationSummary_Load(object sender, EventArgs e)
        {
            crPopulationSummary crPopulationSummary = new crPopulationSummary();

            crPopulationSummary.Database.Tables["populationsummary_view"].SetDataSource(residentBL.ListPopulationSummary());
            crPopulationSummary.Database.Tables["purokspopulation_view"].SetDataSource(residentBL.ListPerPurokPopulations());

            crv.ReportSource = null;
            crv.ReportSource = crPopulationSummary;
            crv.Refresh();
        }
    }
}
