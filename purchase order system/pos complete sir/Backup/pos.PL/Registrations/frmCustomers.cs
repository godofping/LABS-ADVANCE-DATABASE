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
        pos.BL.Registrations.Customers CustomerBL = new pos.BL.Registrations.Customers();
        pos.EL.Registrations.Customers CustomerInfo = new pos.EL.Registrations.Customers();
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            CustomerInfo.Lastname = txtLastName.Text;
            CustomerInfo.Firstname = txtFirstName.Text;
            CustomerInfo.Middleinitial = txtMIddleName.Text;
            CustomerInfo.Age = Convert.ToInt32( txtAge.Text);
            CustomerInfo.Address = txtAddress.Text;
            CustomerInfo.Tribe = txtTribe.Text;
          
            bool isSuccessfull = CustomerBL.Insert(CustomerInfo);
            if (isSuccessfull)
            {
                MessageBox.Show("Record Successfully Addded!");
            }
            else
            {

                MessageBox.Show("Addding Record Failed!");
            }
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            CustomerInfo = new pos.EL.Registrations.Customers();
            dtCustomers.DataSource = CustomerBL.List(CustomerInfo);
        }

        private void dtCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtCustomers.Rows.Count >= 1)
            {
               
               txtCustomerID.Text = dtCustomers.Rows[e.RowIndex].Cells["colCustomerID"].Value.ToString();
               CustomerInfo.Customerid = Convert.ToInt32( txtCustomerID.Text);
               CustomerBL.Select(CustomerInfo);
               txtLastName.Text =  CustomerInfo.Lastname ;
               txtFirstName.Text=  CustomerInfo.Firstname ;
               txtMIddleName.Text=  CustomerInfo.Middleinitial ;
               txtAge.Text = Convert.ToString(CustomerInfo.Age)  ;
               txtAddress.Text=  CustomerInfo.Address ;
               txtTribe.Text =  CustomerInfo.Tribe ;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CustomerInfo.Customerid = Convert.ToInt32(txtCustomerID.Text);
            CustomerInfo.Lastname = txtLastName.Text;
            CustomerInfo.Firstname = txtFirstName.Text;
            CustomerInfo.Middleinitial = txtMIddleName.Text;
            CustomerInfo.Age = Convert.ToInt32(txtAge.Text);
            CustomerInfo.Address = txtAddress.Text;
            CustomerInfo.Tribe = txtTribe.Text;

            bool isSuccessfull = CustomerBL.Update(CustomerInfo);
            if (isSuccessfull)
            {
                MessageBox.Show("Record Successfully Updeted!");
                CustomerInfo = new pos.EL.Registrations.Customers();
                dtCustomers.DataSource = CustomerBL.List(CustomerInfo);
            }
            else
            {

                MessageBox.Show("Addding Record Failed!");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                CustomerInfo.Customerid = Convert.ToInt32(txtCustomerID.Text);
                bool isSuccessfull = CustomerBL.Delete(CustomerInfo);
                if (isSuccessfull)
                {
                    MessageBox.Show("Record Successfully Updeted!");
                    CustomerInfo = new pos.EL.Registrations.Customers();
                    dtCustomers.DataSource = CustomerBL.List(CustomerInfo);
                }
                else
                {

                    MessageBox.Show("Addding Record Failed!");
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
               txtCustomerID.Text = "";
               txtLastName.Text = "" ;
               txtFirstName.Text= "" ;
               txtMIddleName.Text=  "" ;
               txtAge.Text = ""  ;
               txtAddress.Text= "";
               txtTribe.Text =  "";
            
        }
    }
}

