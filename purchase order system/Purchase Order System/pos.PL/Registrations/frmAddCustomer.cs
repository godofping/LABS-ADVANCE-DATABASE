using System;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmAddCustomer : Form
    {

        EL.Registrations.Customers CustomerInfo = new EL.Registrations.Customers();
        EL.Registrations.Contactdetails ContactDetailInfo = new EL.Registrations.Contactdetails();
        EL.Registrations.Basicinformations BasicInformationInfo = new EL.Registrations.Basicinformations();
        EL.Registrations.Addresses AddressInfo = new EL.Registrations.Addresses();

        BL.Registrations.Customers CustomerBL = new BL.Registrations.Customers();
        BL.Registrations.Contactdetails ContacDetailBL = new BL.Registrations.Contactdetails();
        BL.Registrations.Basicinformations BasicInformationBL = new BL.Registrations.Basicinformations();
        BL.Registrations.Addresses AddressBL = new BL.Registrations.Addresses();


        frmManageCustomers FrmManageCustomers;
        public frmAddCustomer(frmManageCustomers frmManageCustomers)
        {
            InitializeComponent();
            FrmManageCustomers = frmManageCustomers;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save()
        {

            AddressInfo.Address = txtAddress.Text;
            AddressInfo.City = txtCity.Text;
            AddressInfo.Zipcode = txtZipCode.Text;
            AddressInfo.Province = txtProvince.Text;

            ContactDetailInfo.Addressid = Convert.ToInt32(AddressBL.Insert(AddressInfo));
            ContactDetailInfo.Contactnumber = txtContactNumber.Text;
            ContactDetailInfo.Emailaddress = txtEmailAddress.Text;

            BasicInformationInfo.Firstname = txtFirstName.Text;
            BasicInformationInfo.Middlename = txtMiddleName.Text;
            BasicInformationInfo.Lastname = txtLastName.Text;
            BasicInformationInfo.Gender = cbGender.Text;
            BasicInformationInfo.Birthdate = dtpBirthDate.Text;

            CustomerInfo.Contactdetailid = Convert.ToInt32(ContacDetailBL.Insert(ContactDetailInfo));
            CustomerInfo.Basicinformationid = Convert.ToInt32(BasicInformationBL.Insert(BasicInformationInfo));

            if (CustomerBL.Insert(CustomerInfo) > 0)
            {
                FrmManageCustomers.LoadData();
                MessageBox.Show("Success");
                this.Close();
                

            }
            else
            {
                MessageBox.Show("Failed");
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
