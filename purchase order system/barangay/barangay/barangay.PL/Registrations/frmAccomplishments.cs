﻿using System;
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
    public partial class frmAccomplishments : Form
    {
        EL.Registrations.Accomplishments accomplishmentEL = new EL.Registrations.Accomplishments();
        EL.Registrations.Filelocations filelocationEL = new EL.Registrations.Filelocations();

        BL.Registrations.Accomplishments accomplishmentBL = new BL.Registrations.Accomplishments();
        BL.Registrations.Filelocations filelocationBL = new BL.Registrations.Filelocations();

        string s = "";
        public frmAccomplishments()
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
            methods.ClearTXT(txtTitle, txtFile);
            methods.ClearDTP(dtpDateAccomplished);
            lblTitle.Text = "";
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, accomplishmentBL.List(txtSearch.Text));
        }

        private void DGVManage()
        {
            PopulateDGV();
            methods.DGVHiddenColumns(dgv, "accomplishmentid");
            methods.DGVRenameColumns(dgv, "accomplishmentid", "Title", "Date Accomplished");
            methods.DGVTheme(dgv);
            methods.DGVBUTTONViewEditDelete(dgv);
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

        private void frmAccomplishments_Load(object sender, EventArgs e)
        {
            DGVManage();
            ShowMain();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowAddEdit();
            lblTitle.Text = "Adding Accomplishment";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bol = false;

            if (methods.CheckRequiredTXT(txtTitle, txtFile) & methods.CheckRequiredDTP(dtpDateAccomplished))
            {
                accomplishmentEL.Title = txtTitle.Text;
                accomplishmentEL.Dateaccomplished = dtpDateAccomplished.Text;

                if (s.Equals("ADD"))
                {
                    filelocationEL.Accomplishmentid = Convert.ToInt32(accomplishmentBL.Insert(accomplishmentEL));
                    if (filelocationEL.Accomplishmentid > 0)
                    {
                        filelocationEL.Filelocation = txtFile.Text;

                        bol = filelocationBL.Insert(filelocationEL) > 0;
                    }

                   
                }
                else if (s.Equals("EDIT"))
                {
                    bol = accomplishmentBL.Update(accomplishmentEL);
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
                accomplishmentEL.Accomplishmentid = Convert.ToInt32(dgv.SelectedRows[0].Cells["accomplishmentid"].Value);
                filelocationEL.Accomplishmentid = accomplishmentEL.Accomplishmentid;
            }

            if (e.ColumnIndex == 0)
            {
                s = "VIEW";
                ShowView();
                lblTitle.Text = "View Accomplishment";

                accomplishmentEL = accomplishmentBL.Select(accomplishmentEL);
                lblTitleAccomplishment.Text = accomplishmentEL.Title;
                lblDateAccomplished.Text = Convert.ToDateTime(accomplishmentEL.Dateaccomplished).ToString("mmmm dd, yyyy");

                filelocationEL = filelocationBL.Select(filelocationEL);
                lblFile.Text = filelocationEL.Filelocation;


            }
            else if (e.ColumnIndex == 1)
            {
                s = "EDIT";
                ShowAddEdit();
                lblTitle.Text = "Updating Accomplishment";

                accomplishmentEL = accomplishmentBL.Select(accomplishmentEL);
                txtTitle.Text = accomplishmentEL.Title;
                dtpDateAccomplished.Text = accomplishmentEL.Dateaccomplished;

                filelocationEL = filelocationBL.Select(filelocationEL);
                txtFile.Text = filelocationEL.Filelocation;


            }
            else if (e.ColumnIndex == 2)
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE TO DELETE THIS SELECTED ITEM?", "DELETING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(filelocationBL.Delete(filelocationEL) & accomplishmentBL.Delete(accomplishmentEL));
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
            ShowMain();
        }
    }
}
