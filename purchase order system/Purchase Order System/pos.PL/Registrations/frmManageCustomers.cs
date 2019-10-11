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
        BL.Registrations.ManageCustomers ManageCustomersBL = new BL.Registrations.ManageCustomers();

        public frmManageCustomers()
        {
            InitializeComponent();
        }

        private void HiddenColumns()
        {
            dgvManageCustomers.Columns["contactdetailid"].Visible = false;
            dgvManageCustomers.Columns["basicinformationid"].Visible = false;
            dgvManageCustomers.Columns["addressid"].Visible = false;
            dgvManageCustomers.Columns["genderid"].Visible = false;
            dgvManageCustomers.Columns["birthdate"].Visible = false;
        }

        private void LoadData()
        {
            dgvManageCustomers.DataSource = ManageCustomersBL.List();
        }

        private void frmManageCustomers_Load(object sender, EventArgs e)
        {
            LoadData();
            HiddenColumns();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer FormAddCustomer = new frmAddCustomer();
            FormAddCustomer.Show();
        }
    }
}
