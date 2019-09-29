using System;
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            
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
                loaddata();
            }
            else
            {

                MessageBox.Show("Adding Record Failed!");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
    
            CustomerInfo.Customerid = Convert.ToInt32(txtCustomersID.Text);
            CustomerInfo.Lastname = txtLastName.Text;
            CustomerInfo.Firstname = txtLastName.Text;
            CustomerInfo.Middleinitial = txtMiddleInitial.Text;
            CustomerInfo.Age = Convert.ToInt32(txtAge.Text);
            CustomerInfo.Address = txtAddress.Text;
            CustomerInfo.Tribe = txtTribe.Text;


            pos.BL.Registrations.Customers CustomerBL = new pos.BL.Registrations.Customers();
            bool isSuccessfull = CustomerBL.Update(CustomerInfo);
            if (isSuccessfull)
            {
                MessageBox.Show("Record Successfully Updated!");
                loaddata();
            }
            else
            {

                MessageBox.Show("Updating Record Failed!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

           
            CustomerInfo.Customerid = Convert.ToInt32(txtCustomersID.Text);

            pos.BL.Registrations.Customers CustomerBL = new pos.BL.Registrations.Customers();
            bool isSuccessfull = CustomerBL.Delete(CustomerInfo);
            if (isSuccessfull)
            {
                MessageBox.Show("Record Successfully Deleted!");
                loaddata();
            }
            else
            {

                MessageBox.Show("Deleting Record Failed!");
            }
        }

        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void loaddata()
        {
            CustomerInfo = new pos.EL.Registrations.Customers();
            dtCustomers.DataSource = CustomerBL.List(CustomerInfo);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtCustomers.Rows.Count >= 1)
            {

                txtCustomersID.Text = dtCustomers.Rows[e.RowIndex].Cells["customerid"].Value.ToString();
                CustomerInfo.Customerid = Convert.ToInt32(txtCustomersID.Text);

                CustomerBL.Select(CustomerInfo);

                txtLastName.Text = CustomerInfo.Lastname;
                txtFirstName.Text = CustomerInfo.Firstname;
                txtMiddleInitial.Text = CustomerInfo.Middleinitial;
                txtAge.Text = Convert.ToString(CustomerInfo.Age);
                txtAddress.Text = CustomerInfo.Address;
                txtTribe.Text = CustomerInfo.Tribe;
            }
        }
    }
}
