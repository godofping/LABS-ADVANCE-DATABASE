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
    public partial class frmHouseholds : Form
    {
        EL.Registrations.Households householdEL = new EL.Registrations.Households();
        EL.Registrations.Residents residentEL = new EL.Registrations.Residents();

        BL.Registrations.Households householdBL = new BL.Registrations.Households();
        BL.Registrations.Residents residentBL = new BL.Registrations.Residents();

        string s = "";

        public frmHouseholds()
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
            methods.ClearTXT(txtHousehold, txtHouseholdNumber);
            lblTitle.Text = "";
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, householdBL.List(txtSearch.Text));
        }

        private void DGVManage()
        {
            PopulateDGV();
            methods.DGVHiddenColumns(dgv, "householdid");
            methods.DGVRenameColumns(dgv, "householdid", "Household", "Household Number");
            methods.DGVTheme(dgv);
            methods.DGVBUTTONViewEditDelete(dgv);
            
        }

        private void ShowForm(bool bol)
        {
            pnlMain.Visible = !bol;
            pnlForm.Visible = bol;

            ClearForm();
        }

        private void ShowView(bool bol)
        {
            pnlMain.Visible = !bol;
            pnlForm.Visible = !bol;
            pnlView.Visible = bol;
            
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("SUCCESS");
                PopulateDGV();
                ShowForm(false);
            }
            else
            {
                MessageBox.Show("FAILED");
            }
        }

        private void frmHouseholds_Load(object sender, EventArgs e)
        {
            DGVManage();
            ShowForm(false);
            ShowView(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowForm(true);
            lblTitle.Text = "Adding Household";
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bol = false;

            if (methods.CheckRequiredTXT(txtHousehold, txtHouseholdNumber))
            {
                householdEL.Household = txtHousehold.Text;
                householdEL.Householdnumber = txtHouseholdNumber.Text;

                if (s.Equals("ADD"))
                {
                    bol =  householdBL.Insert(householdEL) > 0;
                }
                else if (s.Equals("EDIT"))
                {
                    bol = householdBL.Update(householdEL);
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
            ShowForm(false);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 | e.ColumnIndex == 1 | e.ColumnIndex == 2)
            householdEL.Householdid = Convert.ToInt32(dgv.SelectedRows[0].Cells["householdid"].Value);

            if (e.ColumnIndex == 0)
            {
                s = "VIEW";
                ShowForm(false);
                ShowView(true);
                lblTitle.Text = "View Household";

                householdEL = householdBL.Select(householdEL);

                lblHousehold.Text = householdEL.Household;
                lblHouseHoldNumber.Text = householdEL.Householdnumber;

                methods.LoadDGV(dgvHouseholdmembers, residentBL.ListByHousehold(householdEL.Householdid));
                methods.DGVRenameColumns(dgvHouseholdmembers, "Household Member", "Last Name", "First Name", "Middle Name");
                methods.DGVTheme(dgvHouseholdmembers);


            }
            else if (e.ColumnIndex == 1)
            {
                s = "EDIT";
                ShowForm(true);
                lblTitle.Text = "Updating Household";
                
                householdEL = householdBL.Select(householdEL);
                txtHousehold.Text = householdEL.Household;
                txtHouseholdNumber.Text = householdEL.Householdnumber;
            }
            else if (e.ColumnIndex == 2)
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE TO DELETE THIS SELECTED ITEM?", "DELETING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(householdBL.Delete(householdEL));
                }
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CalculateAfterStopTypingDGV();
        }

        Thread delayedCalculationThreadDGV;
        int delay = 0;

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

        private void btnCloseView_Click(object sender, EventArgs e)
        {
            ShowView(false);
        }
    }
}
