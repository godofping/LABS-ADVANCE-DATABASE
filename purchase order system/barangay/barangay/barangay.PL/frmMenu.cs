using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barangay.PL
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public class BufferedPanel : Panel
        {
            public BufferedPanel()
            {
                DoubleBuffered = true;
            }
        }

        private void ChangePanelLocation(Panel x, Button y)
        {
            x.Height = y.Height;
            x.Top = y.Top;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            ChangePanelLocation(pnlRedSide, btnHome);
            var frm = new Transactions.frmHome();
            methods.ChangePanelDisplay(frm, pnlMain);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ChangePanelLocation(pnlRedSide, btnHome);
            var frm = new Transactions.frmHome();
            methods.ChangePanelDisplay(frm, pnlMain);
        }

        private void btnResidents_Click(object sender, EventArgs e)
        {
            ChangePanelLocation(pnlRedSide, btnResidents);
            var frm = new Registrations.frmResidents();
            methods.ChangePanelDisplay(frm, pnlMain);
        }

        private void btnHouseholds_Click(object sender, EventArgs e)
        {
            ChangePanelLocation(pnlRedSide, btnHouseholds);
            var frm = new Registrations.frmHouseholds();
            methods.ChangePanelDisplay(frm, pnlMain);
        }

        private void btnAccomplishments_Click(object sender, EventArgs e)
        {
            ChangePanelLocation(pnlRedSide, btnAccomplishments);
            var frm = new Registrations.frmAccomplishments();
            methods.ChangePanelDisplay(frm, pnlMain);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ChangePanelLocation(pnlRedSide, btnReports);
            var frm = new Transactions.frmReports();
            methods.ChangePanelDisplay(frm, pnlMain);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ChangePanelLocation(pnlRedSide, btnSettings);
            var frm = new Registrations.frmSettings();
            methods.ChangePanelDisplay(frm, pnlMain);
        }

        
    }
}
