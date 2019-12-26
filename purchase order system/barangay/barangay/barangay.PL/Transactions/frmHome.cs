using System;
using System.Data;
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
    public partial class frmHome : Form
    {

        EL.Registrations.Residents residentEL;

        BL.Registrations.Residents residentBL = new BL.Registrations.Residents();

        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

            var dt = residentBL.ListPopulationSummary();
            lblHouseholds.Text = dt.Rows[0]["Household"].ToString();
            lblPopulation.Text = dt.Rows[0]["Population"].ToString();
            lblMale.Text = dt.Rows[0]["Male"].ToString();
            lblFemale.Text = dt.Rows[0]["Female"].ToString();
            lblPWD.Text = dt.Rows[0]["PWD"].ToString();
            lblOutofSchoolYouth.Text = dt.Rows[0]["Out of School Youth"].ToString();

        }

        private void lblOutofSchoolYouth_Click(object sender, EventArgs e)
        {

        }

        private void lblPWD_Click(object sender, EventArgs e)
        {

        }

        private void lblFemale_Click(object sender, EventArgs e)
        {

        }

        private void lblMale_Click(object sender, EventArgs e)
        {

        }

        private void lblPopulation_Click(object sender, EventArgs e)
        {

        }
    }
}
