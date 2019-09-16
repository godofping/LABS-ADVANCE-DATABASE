using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            pos.EL.Registrations.Customers CustomerInfo = new pos.EL.Registrations.Customers();
            CustomerInfo.Lastname = txtLastName.Text;
            CustomerInfo.Firstname = txtLastName.Text;
            CustomerInfo.Middleinitial = txtMiddleInitial.Text;
            CustomerInfo.Age = Convert.ToInt32(txtAge.Text);
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
