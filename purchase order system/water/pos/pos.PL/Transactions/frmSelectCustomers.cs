using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmSelectCustomers : Form
    {
        pos.EL.Registrations.customers customerEL;

        pos.BL.Registrations.customers customerBL = new pos.BL.Registrations.customers();

        frmOrders frmOrders;

        public frmSelectCustomers(frmOrders _frmOrders, pos.EL.Registrations.customers _customerEL)
        {
            InitializeComponent();
            frmOrders = _frmOrders;
            customerEL = _customerEL;
        }

        private void DGVLoad(string keywords)
        {
            dgv.DataSource = customerBL.List(keywords);
            dgv.Columns["C"].Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DGVLoad(txtSearch.Text);
        }

        private void frmSelectCustomers_Load(object sender, EventArgs e)
        {
            DGVLoad(txtSearch.Text);
            dgv.Focus();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            customerEL.Customerid = Convert.ToInt32(dgv.SelectedRows[0].Cells["CUSTOMER ID"].Value);
            customerEL.Firstname = dgv.SelectedRows[0].Cells["FIRST NAME"].Value.ToString();
            customerEL.Middlename = dgv.SelectedRows[0].Cells["MIDDLE NAME"].Value.ToString();
            customerEL.Lastname = dgv.SelectedRows[0].Cells["LAST NAME"].Value.ToString();
            customerEL.Contactnumber = dgv.SelectedRows[0].Cells["CONTACT NUMBER"].Value.ToString();
            customerEL.Address = dgv.SelectedRows[0].Cells["ADDRESS"].Value.ToString();

            frmOrders.txtFullName.Text = customerEL.Firstname + " " + customerEL.Middlename + " " + customerEL.Lastname;
            frmOrders.txtContactNumber.Text = customerEL.Contactnumber;
            frmOrders.txtAddress.Text = customerEL.Address;
            

            this.Close();
        }

        
    }
}
