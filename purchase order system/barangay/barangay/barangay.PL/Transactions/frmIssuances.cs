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
    public partial class frmIssuances : Form
    {
        EL.Registrations.Issuances issuanceEL = new EL.Registrations.Issuances();

        BL.Registrations.Issuances issuanceBL = new BL.Registrations.Issuances();

        public frmIssuances()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            crIssuances crIssuances = new crIssuances();

            crIssuances.Database.Tables["issuancesreports_view"].SetDataSource(issuanceBL.ListForReports(dtpYearAndMonth.Text));


            crv.ReportSource = null;
            crv.ReportSource = crIssuances;
            crv.Refresh();
        }

        private void btnCloseView_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
