using System;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.REGISTRATIONS
{
    public partial class frmStaffsAccount : Form
    {
        string s = "";
        EL.REGISTRATIONS.staffsaccount staffsaccountEL = new EL.REGISTRATIONS.staffsaccount();
        EL.REGISTRATIONS.staffs staffEL = new EL.REGISTRATIONS.staffs();
        EL.REGISTRATIONS.basicinformations basicinformationEL = new EL.REGISTRATIONS.basicinformations();

        BL.REGISTRATIONS.staffsaccount staffsaccountBL = new BL.REGISTRATIONS.staffsaccount();
        BL.REGISTRATIONS.staffs staffBL = new BL.REGISTRATIONS.staffs();
        BL.REGISTRATIONS.basicinformations basicinformationBL = new BL.REGISTRATIONS.basicinformations();

        public frmStaffsAccount()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            methods.ClearTXT(txtUsername, txtPassword);
        }

        private void FormActive(bool bol)
        {
            pnlCenter.Visible = bol;
            pnlTop.Visible = !bol;
            dgv.Visible = !bol;
            ClearControls();

            if (s.Equals("ADD"))
            {
                methods.VisibilityCB(true, cbStaffName);
                methods.VisibilityLBL(true, lblStaffName);
                methods.VisibilityLBL(false, lblFullname);
                methods.VisibilityTXT(false, txtFullName);
                methods.ReadOnlyTXT(false, txtUsername);
            }
            else if (s.Equals("EDIT"))
            {
                methods.VisibilityCB(!true, cbStaffName);
                methods.VisibilityLBL(!true, lblStaffName);
                methods.VisibilityLBL(!false, lblFullname);
                methods.VisibilityTXT(!false, txtFullName);
                methods.ReadOnlyTXT(!false, txtUsername);
            }

        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, staffsaccountBL.List(txtSearch.Text));
            methods.DGVHiddenColumns(
                dgv,
                "STAFF ACCOUNT ID",
                "BASIC INFORMATION ID",
                "DESIGNATION ID",
                "STAFF ID",
                "PASSWORD",
                "BIRTH DATE",
                "ADDRESS",
                "CONTACT NUMBER",
                "EMAIL ADDRESS",
                "DATE HIRED",
                "FULL NAME"
                );
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbStaffName, staffBL.List(), "FULL NAME", "STAFF ID");
        }

        private void frmStaffsAccount_Load(object sender, EventArgs e)
        {
            FormActive(false);
            PopulateDGV();
            PopulateCB();
            methods.DGVAddButtons(dgv);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            lblTitle.Text = "CREATE";
            FormActive(true);
            PopulateCB();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormActive(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtUsername, txtPassword))
            {
                staffsaccountEL.Username = txtUsername.Text;
                staffsaccountEL.Password = txtPassword.Text;

                if (s.Equals("ADD"))
                {
                    if (staffsaccountBL.CheckUsername(staffsaccountEL).Rows.Count == 0)
                    {
                        staffsaccountEL.Staffid = Convert.ToInt32(cbStaffName.SelectedValue);

                        if (Convert.ToInt32(staffsaccountBL.Insert(staffsaccountEL)) > 0)
                        {
                            MessageBox.Show("INSERTED");
                            FormActive(false);
                            PopulateDGV();
                        }
                        else
                        {
                            MessageBox.Show("FAILED");
                        }
                    }
                    else
                    {
                        MessageBox.Show("USERNAME IS ALREADY TAKEN");
                    }
                }
                else if (s.Equals("EDIT"))
                {
                    if (staffsaccountBL.Update(staffsaccountEL))
                    {
                        MessageBox.Show("UPDATED");
                        FormActive(false);
                        PopulateDGV();
                    }
                    else
                    {
                        MessageBox.Show("FAILED");
                    }
                }


            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL THE REQUIRED FIELDS (*).");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                FormActive(true);
                txtFullName.ReadOnly = true;
                txtFullName.Text = dgv.SelectedRows[0].Cells[14].Value.ToString();
                staffsaccountEL.Staffaccountid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                txtUsername.Text = dgv.SelectedRows[0].Cells[6].Value.ToString();
                txtPassword.Text = dgv.SelectedRows[0].Cells[7].Value.ToString();

                lblTitle.Text = "UPDATE";
            }

            if (e.ColumnIndex == 1)
            {
                switch (MessageBox.Show(this, "Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:


                        staffsaccountEL.Staffaccountid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                        if (staffsaccountBL.Delete(staffsaccountEL))
                        {
                            MessageBox.Show("DELETED");
                            PopulateDGV();
                        }
                        else
                        {
                            MessageBox.Show("FAILED");
                        }
                        break;
                }
            }
        }



    }
}
