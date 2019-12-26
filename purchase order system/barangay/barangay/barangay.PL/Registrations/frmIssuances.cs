using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barangay.PL.Registrations
{
    public partial class frmIssuances : Form
    {
        EL.Registrations.Issuances issuanceEL = new EL.Registrations.Issuances();
        EL.Registrations.Residents residentEL = new EL.Registrations.Residents();
        EL.Registrations.Certifications certificationEL = new EL.Registrations.Certifications();


        BL.Registrations.Issuances issuanceBL = new BL.Registrations.Issuances();
        BL.Registrations.Residents residentBL = new BL.Registrations.Residents();
        BL.Registrations.Certifications certificationBL = new BL.Registrations.Certifications();

        string s = "";

        public frmIssuances()
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

        private void ClearForm()
        {
            methods.ClearTXT(txtResident, txtSearchResident);
            methods.ClearCB(cbCertificate);
            lblTitle.Text = "";
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, issuanceBL.List(txtSearch.Text));
        }

        private void PopulateDGVResidents()
        {
            methods.LoadDGV(dgvResidents, residentBL.ListNames(txtSearchResident.Text));
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbCertificate, certificationBL.List(), "certification", "certificationid");
        }

        private void DGVManage()
        {
            PopulateDGV();
            methods.DGVHiddenColumns(dgv, "issuanceid", "residentid", "certificationid");
            methods.DGVRenameColumns(dgv, "issuanceid", "residentid", "certificationid", "Last Name", "First Name", "Middle Name", "Certification", "Issuance Date and time");
            methods.DGVTheme(dgv);
            methods.DGVBUTTONViewEditDelete(dgv);

            PopulateDGVResidents();
            methods.DGVHiddenColumns(dgvResidents, "residentid");
            methods.DGVRenameColumns(dgvResidents, "residentid", "Last Name", "First Name", "Middle Name");
            methods.DGVTheme(dgvResidents);
            methods.DGVBUTTONSelect(dgvResidents);

        }

        private void ShowAddEdit()
        {
            pnlMain.Visible = false;
            pnlView.Visible = false;
            pnlAddEdit.Visible = true;
            ClearForm();
        }

        private void ShowMain()
        {
            pnlMain.Visible = true;
            pnlView.Visible = false;
            pnlAddEdit.Visible = false;
            ClearForm();
            lblTitle.Text = "List of Households";
        }

        private void ShowView()
        {
            pnlMain.Visible = false;
            pnlView.Visible = true;
            pnlAddEdit.Visible = false;
        }

        private void ShowResidents(bool bol)
        {
            gbSearchResident.Visible = bol;

            btnSelectResident.Visible = !bol;
            btnCancelSearchResident.Visible = bol;

            txtSearchResident.ResetText();
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("SUCCESS");
                PopulateDGV();
                ShowMain();
            }
            else
            {
                MessageBox.Show("FAILED");
            }
        }

        private void frmIssuances_Load(object sender, EventArgs e)
        {
            PopulateCB();
            DGVManage();
            ShowMain();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowAddEdit();
            ShowResidents(false);
            lblTitle.Text = "Adding Household";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bol = false;

            if (methods.CheckRequiredTXT(txtResident))
            {
                issuanceEL.Residentid = residentEL.Residentid;
                issuanceEL.Certificationid = Convert.ToInt32(cbCertificate.SelectedValue);
                issuanceEL.Issuancedateandtime = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");

                if (s.Equals("ADD"))
                {
                    bol = issuanceBL.Insert(issuanceEL) > 0;
                }
                else if (s.Equals("EDIT"))
                {
                    bol = issuanceBL.Update(issuanceEL);
                }

                ShowResult(bol);
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL REQUIRED FIELDS WITH AN ASTERISK");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 | e.ColumnIndex == 1 | e.ColumnIndex == 2)
            {
                issuanceEL.Issuanceid = Convert.ToInt32(dgv.SelectedRows[0].Cells["issuanceid"].Value);

                issuanceEL = issuanceBL.Select(issuanceEL);

                residentEL.Residentid = issuanceEL.Residentid;
                residentEL = residentBL.Select(residentEL);
                certificationEL.Certificationid = issuanceEL.Certificationid;
                certificationEL = certificationBL.Select(certificationEL);

            }

            if (e.ColumnIndex == 0)
            {
                s = "VIEW";
                ShowView();
                lblTitle.Text = "View Issuance";



                lblResident.Text = residentEL.Lastname + ", " + residentEL.Firstname + " " + residentEL.Middlename;
                lblCertificate.Text = certificationEL.Certification;
                lblIssuanceDateAndtime.Text = issuanceEL.Issuancedateandtime;



            }
            else if (e.ColumnIndex == 1)
            {
                s = "EDIT";
                ShowAddEdit();
                ShowResidents(false);
                lblTitle.Text = "Updating Issuance";

                txtResident.Text = residentEL.Lastname + ", " + residentEL.Firstname + " " + residentEL.Middlename;
                cbCertificate.SelectedValue = certificationEL.Certificationid;
            }
            else if (e.ColumnIndex == 2)
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE TO DELETE THIS SELECTED ITEM?", "DELETING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(issuanceBL.Delete(issuanceEL));
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CalculateAfterStopTypingDGV();
        }

        private void txtSearchResident_TextChanged(object sender, EventArgs e)
        {
            CalculateAfterStopTypingDGVResidents();
        }

        Thread delayedCalculationThreadDGV;
        Thread delayedCalculationThreadDGVResidents;
        int delay = 0;
        int delay1 = 0;

        private void CalculateAfterStopTypingDGV()
        {
            delay += 200;
            if (delayedCalculationThreadDGV != null && delayedCalculationThreadDGV.IsAlive)
                return;

            delayedCalculationThreadDGV = new Thread(() =>
            {
                while (delay >= 200)
                {
                    delay = delay - 200;
                    try
                    {
                        Thread.Sleep(200);
                    }
                    catch (Exception) { }
                }
                Invoke(new Action(() =>
                {
                    PopulateDGV();
                }));
            });

            delayedCalculationThreadDGV.Start();
        }

        private void CalculateAfterStopTypingDGVResidents()
        {
            delay1 += 200;
            if (delayedCalculationThreadDGVResidents != null && delayedCalculationThreadDGVResidents.IsAlive)
                return;

            delayedCalculationThreadDGVResidents = new Thread(() =>
            {
                while (delay1 >= 200)
                {
                    delay1 = delay1 - 200;
                    try
                    {
                        Thread.Sleep(200);
                    }
                    catch (Exception) { }
                }
                Invoke(new Action(() =>
                {
                    PopulateDGVResidents();
                }));
            });

            delayedCalculationThreadDGVResidents.Start();
        }

        private void btnCloseView_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void btnSelectResident_Click(object sender, EventArgs e)
        {
            ShowResidents(true);
        }

        private void btnCancelSearchResident_Click(object sender, EventArgs e)
        {
            ShowResidents(false);
        }

        private void dgvResidents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                residentEL.Residentid = Convert.ToInt32(dgvResidents.SelectedRows[0].Cells["residentid"].Value);
                residentEL = residentBL.Select(residentEL);
                txtResident.Text = residentEL.Lastname + ", " + residentEL.Firstname + " " + residentEL.Middlename;
                ShowResidents(false);
            }
        }
    }
}
