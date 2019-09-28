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
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pos.EL.Registrations.Customers CustomerInfo = new pos.EL.Registrations.Customers();
            CustomerInfo.Lastname = txtLastName.Text;
            CustomerInfo.Firstname = txtFirstName.Text;
            CustomerInfo.Middleinitial = txtMIddleName.Text;
            CustomerInfo.Age = Convert.ToInt32( txtAge.Text);
            CustomerInfo.Address = txtAddress.Text;
            CustomerInfo.Tribe = txtTribe.Text;
            pos.BL.Registrations.Customers CustomerBL = new pos.BL.Registrations.Customers();
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
    }
}

