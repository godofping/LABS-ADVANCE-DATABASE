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
        frmLogin frmLogin;
        public frmMenu(frmLogin _frmLogin)
        {
            InitializeComponent();
            frmLogin = _frmLogin;
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
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            ChangePanelLocation(pnlRedSide, btnHome);
            var frm = new Transactions.frmHome();
            methods.ChangePanelDisplay(frm, pnlMain);

            pleaseWait.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            ChangePanelLocation(pnlRedSide, btnHome);
            var frm = new Transactions.frmHome();
            methods.ChangePanelDisplay(frm, pnlMain);

            pleaseWait.Close();
        }

        private void btnResidents_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            ChangePanelLocation(pnlRedSide, btnResidents);
            var frm = new Registrations.frmResidents();
            methods.ChangePanelDisplay(frm, pnlMain);

            pleaseWait.Close();
        }

        private void btnHouseholds_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            ChangePanelLocation(pnlRedSide, btnHouseholds);
            var frm = new Registrations.frmHouseholds();
            methods.ChangePanelDisplay(frm, pnlMain);

            pleaseWait.Close();
        }

        private void btnAccomplishments_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            ChangePanelLocation(pnlRedSide, btnAccomplishments);
            var frm = new Registrations.frmAccomplishments();
            methods.ChangePanelDisplay(frm, pnlMain);

            pleaseWait.Close();
        }

        private void btnIssuances_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            ChangePanelLocation(pnlRedSide, btnIssuances);
            var frm = new Registrations.frmIssuances();
            methods.ChangePanelDisplay(frm, pnlMain);

            pleaseWait.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            ChangePanelLocation(pnlRedSide, btnReports);
            var frm = new Transactions.frmReports();
            methods.ChangePanelDisplay(frm, pnlMain);

            pleaseWait.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            ChangePanelLocation(pnlRedSide, btnSettings);
            var frm = new Registrations.frmSettings();
            methods.ChangePanelDisplay(frm, pnlMain);

            pleaseWait.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin.Show();
        }

        
    }
}
