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
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void btnResidency_Click(object sender, EventArgs e)
        {
            frmPopulationSummary frmPopulationSummary = new frmPopulationSummary();
            frmPopulationSummary.ShowDialog();
        }

        private void btnCedula_Click(object sender, EventArgs e)
        {
            frmIssuances frmIssuances = new frmIssuances();
            frmIssuances.ShowDialog();
        }
    }
}
