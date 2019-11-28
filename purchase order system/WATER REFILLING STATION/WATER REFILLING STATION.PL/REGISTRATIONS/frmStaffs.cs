using System;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.REGISTRATIONS
{
    public partial class frmStaffs : Form
    {
        string s;
        EL.REGISTRATIONS.staffs staffEL = new EL.REGISTRATIONS.staffs();
        EL.REGISTRATIONS.staffsaccount staffsaccountEL = new EL.REGISTRATIONS.staffsaccount();
        EL.REGISTRATIONS.basicinformations basicinformationEL = new EL.REGISTRATIONS.basicinformations();
        EL.REGISTRATIONS.designations designationEL = new EL.REGISTRATIONS.designations();

        BL.REGISTRATIONS.staffs staffBL = new BL.REGISTRATIONS.staffs();
        BL.REGISTRATIONS.staffsaccount staffsaccountBL = new BL.REGISTRATIONS.staffsaccount();
        BL.REGISTRATIONS.basicinformations basicinformationBL = new BL.REGISTRATIONS.basicinformations();
        BL.REGISTRATIONS.designations designationBL = new BL.REGISTRATIONS.designations();

        public frmStaffs()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            methods.ClearTXT(txtLastName, txtFirstName, txtMiddleInitial, txtAddress, txtContactNumber, txtEmailAddress);
            methods.ClearDTP(dtpBirthDate, dtpDateHired);
            methods.ClearCB(cbDesignation);
        }

        private void FormActive(bool bol)
        {
            pnlCenter.Visible = bol;
            pnlTop.Visible = !bol;
            dgv.Visible = !bol;
            ClearControls();
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, staffBL.List(txtSearch.Text));
            methods.DGVHiddenColumns(
                dgv, 
                "STAFF ID", 
                "BASIC INFORMATION ID", 
                "DESIGNATION ID", 
                "FULL NAME"
                );
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbDesignation, designationBL.List(), "designation", "designationid");
        }


        private void frmStaffs_Load(object sender, EventArgs e)
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormActive(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (
                methods.CheckRequiredTXT(txtLastName, txtFirstName, txtMiddleInitial, txtAddress, txtContactNumber) &
                methods.CheckRequiredDTP(dtpBirthDate, dtpDateHired) &
                methods.CheckRequiredCB(cbDesignation)
                )
            {

                basicinformationEL.Lastname = txtLastName.Text;
                basicinformationEL.Firstname = txtFirstName.Text;
                basicinformationEL.Middleinitial = txtMiddleInitial.Text;
                basicinformationEL.Birthdate = dtpBirthDate.Value.ToString("yy-MM-dd");
                basicinformationEL.Address = txtAddress.Text;
                basicinformationEL.Contactnumber = txtContactNumber.Text;
                basicinformationEL.Emailaddress = txtEmailAddress.Text;
                staffEL.Designationid = Convert.ToInt32(cbDesignation.SelectedValue);
                staffEL.Datehired = dtpDateHired.Value.ToString("yy-MM-dd");


                if (s.Equals("ADD"))
                {
                    if ((staffEL.Basicinformationid = Convert.ToInt32(basicinformationBL.Insert(basicinformationEL))) > 0)
                    {
                        if (staffBL.Insert(staffEL) > 0)
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
                        MessageBox.Show("FAILED");
                    }
                }
                else if (s.Equals("EDIT"))
                {
                    if (basicinformationBL.Update(basicinformationEL) & staffBL.Update(staffEL))
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
                MessageBox.Show("PLEASE COMPLETE ALL THE REQUIRED FIELDS (*)");
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

                FormActive(true);

                staffEL.Staffid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                basicinformationEL.Basicinformationid = Convert.ToInt32(dgv.SelectedRows[0].Cells[3].Value);
                txtLastName.Text = dgv.SelectedRows[0].Cells[5].Value.ToString();
                txtFirstName.Text = dgv.SelectedRows[0].Cells[6].Value.ToString();
                txtMiddleInitial.Text = dgv.SelectedRows[0].Cells[7].Value.ToString();
                dtpBirthDate.Text = dgv.SelectedRows[0].Cells[8].Value.ToString();
                txtAddress.Text = dgv.SelectedRows[0].Cells[9].Value.ToString();
                txtContactNumber.Text = dgv.SelectedRows[0].Cells[10].Value.ToString();
                txtEmailAddress.Text = dgv.SelectedRows[0].Cells[11].Value.ToString();
                cbDesignation.SelectedIndex = cbDesignation.FindString(dgv.SelectedRows[0].Cells[12].Value.ToString());
                dtpBirthDate.Text = dgv.SelectedRows[0].Cells[13].Value.ToString();


                s = "EDIT";
                lblTitle.Text = "UPDATE";
            }

            if (e.ColumnIndex == 1)
            {
                switch (MessageBox.Show(this, "Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        staffEL.Staffid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                        if (staffBL.Delete(staffEL))
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
