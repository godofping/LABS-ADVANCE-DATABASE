using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmCustomers : Form
    {
        pos.EL.Registrations.customers customerEL = new pos.EL.Registrations.customers();

        pos.BL.Registrations.customers customerBL = new pos.BL.Registrations.customers();

        string s = "";

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            txtCustomerID.ResetText();
            txtFirstName.ResetText();
            txtMiddleName.ResetText();
            txtLastName.ResetText();
            txtContactNumber.ResetText();
            txtAddress.ResetText();
        }

        private void DGVLoad(string keywords)
        {
            dgv.DataSource = customerBL.List(keywords);
            dgv.Columns["C"].Visible = false;
        }

        private void EnableForm(bool bol)
        {
            gbInfo.Enabled = bol;
            gbButtons.Enabled = !bol;
            gbDGV.Enabled = !bol;   
        }

        private bool Validations()
        {
            bool bol = false;

            if(txtFirstName.Text.Equals("") | txtMiddleName.Text.Equals("") | txtLastName.Text.Equals("") | txtContactNumber.Text.Equals("") | txtAddress.Text.Equals(""))
            {
                bol = false;
            }
            else
            {
                bol = true;
            }
            return bol;
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            EnableForm(false);
            DGVLoad(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DGVLoad(txtSearch.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                customerEL.Firstname = txtFirstName.Text;
                customerEL.Middlename = txtMiddleName.Text;
                customerEL.Lastname = txtLastName.Text;
                customerEL.Contactnumber = txtContactNumber.Text;
                customerEL.Address = txtAddress.Text;

                if (s.Equals("ADD"))
                {
                    if (customerBL.Insert(customerEL) > 0)
                    {
                        ClearForm();
                        EnableForm(false);
                        DGVLoad(txtSearch.Text);
                        MessageBox.Show("SUCCESS");
                    }
                    else
                    {
                        MessageBox.Show("FAILED");
                    }
                }
                else if (s.Equals("EDIT"))
                {
                    customerEL.Customerid = Convert.ToInt32(txtCustomerID.Text);
                    if (customerBL.Update(customerEL))
                    {
                        ClearForm();
                        EnableForm(false);
                        DGVLoad(txtSearch.Text);
                        MessageBox.Show("SUCCESS");
                    }
                    else
                    {
                        MessageBox.Show("FAILED");
                    }
                }
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL THE REQUIRED FIELDS ( * )");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            EnableForm(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgv.SelectedRows.Count > 0)
            {
                s = "EDIT";
                EnableForm(true);
                txtCustomerID.Text = dgv.SelectedRows[0].Cells["CUSTOMER ID"].Value.ToString();
                txtFirstName.Text = dgv.SelectedRows[0].Cells["FIRST NAME"].Value.ToString();
                txtMiddleName.Text = dgv.SelectedRows[0].Cells["MIDDLE NAME"].Value.ToString();
                txtLastName.Text = dgv.SelectedRows[0].Cells["LAST NAME"].Value.ToString();
                txtContactNumber.Text = dgv.SelectedRows[0].Cells["CONTACT NUMBER"].Value.ToString();
                txtAddress.Text = dgv.SelectedRows[0].Cells["ADDRESS"].Value.ToString();
            }
            else
            {
                MessageBox.Show("NO SELECTED ITEM");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {

                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE TO DELETE THE SELECTED ITEM?", "MESSAGE", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    customerEL.Customerid = Convert.ToInt32(dgv.SelectedRows[0].Cells["CUSTOMER ID"].Value);
                    if (customerBL.Delete(customerEL))
                    {
                        DGVLoad(txtSearch.Text);
                        MessageBox.Show("SUCCESS");
                    }
                    else
                    {
                        MessageBox.Show("FAILED");
                    }
                }
    
            }
            else
            {
                MessageBox.Show("NO SELECTED ITEM");
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            DGVLoad(txtSearch.Text);
        }
    }
}
