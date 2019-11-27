using System;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.REGISTRATIONS
{
    public partial class frmCustomers : Form
    {
        string s;
        EL.REGISTRATIONS.customers customerEL = new EL.REGISTRATIONS.customers();
        EL.REGISTRATIONS.basicinformations basicinformationEL = new EL.REGISTRATIONS.basicinformations();

        BL.REGISTRATIONS.customers customerBL = new BL.REGISTRATIONS.customers();
        BL.REGISTRATIONS.basicinformations basicinformationBL = new BL.REGISTRATIONS.basicinformations();


        public frmCustomers()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            methods.ClearTXT(txtLastName, txtMiddleInitial, txtFirstName, txtAddress, txtContactNumber, txtEmailAddress);
            methods.ClearDTP(dtpBirthDate);
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
            methods.LoadDGV(dgv, customerBL.List(txtSearch.Text));
            methods.DGVHiddenColumns(dgv, "CUSTOMER ID", "BASIC INFORMATION ID");
        }


        private void frmCustomers_Load(object sender, EventArgs e)
        {
            FormActive(false);
            PopulateDGV();
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
            if
                (
                methods.CheckRequiredTXT(txtLastName, txtFirstName, txtMiddleInitial, txtAddress, txtContactNumber) &
                methods.CheckRequiredDTP(dtpBirthDate)
                )
            {

                basicinformationEL.Lastname = txtLastName.Text;
                basicinformationEL.Firstname = txtFirstName.Text;
                basicinformationEL.Middleinitial = txtMiddleInitial.Text;
                basicinformationEL.Birthdate = dtpBirthDate.Value.ToString("yy-MM-dd");
                basicinformationEL.Address = txtAddress.Text;
                basicinformationEL.Contactnumber = txtContactNumber.Text;
                basicinformationEL.Emailaddress = txtEmailAddress.Text;


                if (s.Equals("ADD"))
                {
                    if ((customerEL.Basicinformationid = Convert.ToInt32(basicinformationBL.Insert(basicinformationEL))) > 0)
                    {
                        if (customerBL.Insert(customerEL) > 0)
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
                    if (basicinformationBL.Update(basicinformationEL))
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
                FormActive(true);

                customerEL.Customerid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                basicinformationEL.Basicinformationid = Convert.ToInt32(dgv.SelectedRows[0].Cells[3].Value);
                txtLastName.Text = dgv.SelectedRows[0].Cells[4].Value.ToString();
                txtFirstName.Text = dgv.SelectedRows[0].Cells[5].Value.ToString();
                txtMiddleInitial.Text = dgv.SelectedRows[0].Cells[6].Value.ToString();
                dtpBirthDate.Text = dgv.SelectedRows[0].Cells[7].Value.ToString();
                txtAddress.Text = dgv.SelectedRows[0].Cells[8].Value.ToString();
                txtContactNumber.Text = dgv.SelectedRows[0].Cells[9].Value.ToString();
                txtEmailAddress.Text = dgv.SelectedRows[0].Cells[10].Value.ToString();

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

                        customerEL.Customerid = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
                        if (customerBL.Delete(customerEL))
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
