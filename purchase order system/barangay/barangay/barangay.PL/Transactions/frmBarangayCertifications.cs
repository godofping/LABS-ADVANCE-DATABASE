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
    public partial class frmBarangayCertifications : Form
    {
        EL.Registrations.Residents residentEL;

        BL.Registrations.Residents residentBL = new BL.Registrations.Residents();
        public frmBarangayCertifications(EL.Registrations.Residents _residentEL)
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

        }

        private void btnResidency_Click(object sender, EventArgs e)
        {
            crResidency crResidency = new crResidency();

            crResidency.Database.Tables["residency_view"].SetDataSource(residentBL.ListResidencyCertification(residentEL.Residentid));

            crv.ReportSource = null;
            crv.ReportSource = crResidency;
            crv.Refresh();
        }

        private void btnCedula_Click(object sender, EventArgs e)
        {
            crCedula crCedula = new crCedula();


            crv.ReportSource = null;
            crv.ReportSource = crCedula;
            crv.Refresh();
        }
    }
}
