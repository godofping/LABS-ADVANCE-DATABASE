using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            txtUsername.ResetText();
            txtPassword.ResetText();
        }

        private void FormActive(bool bol)
        {
            pnlCenter.Visible = bol;
            pnlTop.Visible = !bol;
            dgv.Visible = !bol;
            ClearControls();
            
            if (s.Equals("ADD"))
            {
                lblStaffName.Visible = true;
                cbStaffName.Visible = true;
                lblFullname.Visible = false;
                txtFullName.Visible = false;
                txtUsername.ReadOnly = false;
            }
            else if (s.Equals("EDIT"))
            {
                lblStaffName.Visible = false;
                cbStaffName.Visible = false;
                lblFullname.Visible = true;
                txtFullName.Visible = true;
                txtUsername.ReadOnly = true;
            }
            
        }

        private void PopulateDGV()
        {
            dgv.DataSource = staffsaccountBL.List(txtSearch.Text);
            dgv.Columns["STAFF ACCOUNT ID"].Visible = false;
            dgv.Columns["BASIC INFORMATION ID"].Visible = false;
            dgv.Columns["DESIGNATION ID"].Visible = false;
            dgv.Columns["STAFF ID"].Visible = false;
            dgv.Columns["PASSWORD"].Visible = false;
            dgv.Columns["BIRTH DATE"].Visible = false;
            dgv.Columns["ADDRESS"].Visible = false;
            dgv.Columns["CONTACT NUMBER"].Visible = false;
            dgv.Columns["EMAIL ADDRESS"].Visible = false;
            dgv.Columns["DATE HIRED"].Visible = false;
            dgv.Columns["FULL NAME"].Visible = false;
        }

        private void PopulateCB()
        {
            cbStaffName.DataSource = staffBL.List();
            cbStaffName.DisplayMember = "FULL NAME";
            cbStaffName.ValueMember = "STAFF ID";
        }

        private bool RequiredFields()
        {
            bool bol = true;
            if
                (
                txtUsername.Text.Equals("") |
                txtPassword.Text.Equals("")
                )
            {
                bol = false;
            }
            return bol;
        }

        private void frmStaffsAccount_Load(object sender, EventArgs e)
        {
            FormActive(false);
            PopulateDGV();
            PopulateCB();
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
            if (RequiredFields())
            {
                staffsaccountEL.Username = txtUsername.Text;
                staffsaccountEL.Password = txtPassword.Text;

                if (s.Equals("ADD"))
                {
                    if(staffsaccountBL.CheckUsername(staffsaccountEL).Rows.Count == 0)
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
