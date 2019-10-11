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
    public partial class frmManageCustomers : Form
    {
        BL.Registrations.Customers CustomerBL = new BL.Registrations.Customers();

        public frmManageCustomers()
        {
            InitializeComponent();
        }

        private void HiddenColumns()
        {
            dgvManageCustomers.Columns["contactdetailid"].Visible = false;
            dgvManageCustomers.Columns["basicinformationid"].Visible = false;
            dgvManageCustomers.Columns["addressid"].Visible = false;
        }

         public void LoadData()
        {
            dgvManageCustomers.DataSource = CustomerBL.List();
        }

        private void frmManageCustomers_Load(object sender, EventArgs e)
        {
            LoadData();
            HiddenColumns();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer FormAddCustomer = new frmAddCustomer(this);
            FormAddCustomer.Show();
        }
    }
}
