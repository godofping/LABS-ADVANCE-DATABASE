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
    public partial class frmPrintables : Form
    {
        EL.Registrations.Residents residentEL;

        BL.Registrations.Residents residentBL = new BL.Registrations.Residents();
        public frmPrintables(EL.Registrations.Residents _residentEL)
        {
            InitializeComponent();
            residentEL = _residentEL;
        }

        private void btnCloseView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBarangayCertifications_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Printables for " + residentEL.Firstname + " " + residentEL.Middlename + " " + residentEL.Lastname;
        }

        private void btnResidency_Click(object sender, EventArgs e)
        {
            crResidency crResidency = new crResidency();

            crResidency.Database.Tables["residency_view"].SetDataSource(residentBL.ListResidencyCertification(residentEL.Residentid));

            crv.ReportSource = null;
            crv.ReportSource = crResidency;
            crv.Refresh();
        }

        private void btnIdentificationCard_Click(object sender, EventArgs e)
        {
            crIdentificationCard crIdentificationCard = new crIdentificationCard();

            crIdentificationCard.Database.Tables["identificationcard_view"].SetDataSource(residentBL.ListIdentificationCard(residentEL.Residentid));

            crv.ReportSource = null;
            crv.ReportSource = crIdentificationCard;
            crv.Refresh();
        }
    }
}
