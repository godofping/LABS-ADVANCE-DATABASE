using System;
using System.Data;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageStoreInformation : Form
    {
        EL.Registrations.Storeinformation StoreInformationInfo;
        EL.Registrations.Contactdetails ContactDetailInfo = new EL.Registrations.Contactdetails();
        EL.Registrations.Addresses AddressInfo = new EL.Registrations.Addresses();

        BL.Registrations.Storeinformation StoreInformationBL = new BL.Registrations.Storeinformation();
        BL.Registrations.Contactdetails ContacDetailBL = new BL.Registrations.Contactdetails();
        BL.Registrations.Addresses AddressBL = new BL.Registrations.Addresses();

        PL.frmMain frmMain;

        string current = "";

        public frmManageStoreInformation(EL.Registrations.Storeinformation storeInformationInfo, PL.frmMain FrmMain)
        {
            InitializeComponent();
            StoreInformationInfo = storeInformationInfo;
            frmMain = FrmMain;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public class BufferedPanel : Panel
        {
            public BufferedPanel()
            {
                DoubleBuffered = true;
            }
        }

        private void frmManageStoreInformation_Load(object sender, System.EventArgs e)
        {
            manageForm(false);
            txtZipCode.MaxLength = 6;
          
            getDataFromDataTable();
        }

        private void manageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;

        }

        private void clearErrors()
        {

            errorProvider1.SetError(txtStoreName, "");
            errorProvider1.SetError(txtContactNumber, "");
            errorProvider1.SetError(txtEmailAddress, "");
            errorProvider1.SetError(txtAddress, "");
            errorProvider1.SetError(txtCity, "");
            errorProvider1.SetError(txtProvince, "");
            errorProvider1.SetError(txtZipCode, "");

        }


        private bool checkErrors()
        {
            bool status = true;

            if (txtStoreName.Text.Equals(""))
            {
                errorProvider1.SetError(txtStoreName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtStoreName, "");


            if (txtContactNumber.Text.Equals(""))
            {
                errorProvider1.SetError(txtContactNumber, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtContactNumber, "");

            if (txtEmailAddress.Text.Equals(""))
            {
                errorProvider1.SetError(txtEmailAddress, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtEmailAddress, "");

            if (txtAddress.Text.Equals(""))
            {
                errorProvider1.SetError(txtAddress, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtAddress, "");

            if (txtCity.Text.Equals(""))
            {
                errorProvider1.SetError(txtCity, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtCity, "");

            if (txtProvince.Text.Equals(""))
            {
                errorProvider1.SetError(txtProvince, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtProvince, "");

            if (txtZipCode.Text.Equals(""))
            {
                errorProvider1.SetError(txtZipCode, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtZipCode, "");


            return status;
        }

        private void getDataFromForm()
        {
            AddressInfo.Address = txtAddress.Text;
            AddressInfo.City = txtCity.Text;
            AddressInfo.Zipcode = txtZipCode.Text;
            AddressInfo.Province = txtProvince.Text;

            ContactDetailInfo.Contactnumber = txtContactNumber.Text;
            ContactDetailInfo.Emailaddress = txtEmailAddress.Text;

            StoreInformationInfo.Storename = txtStoreName.Text;
        }

        private void getDataFromDataTable()
        {
            foreach (DataRow row in StoreInformationBL.List().Rows)
            {
                AddressInfo.Addressid = Convert.ToInt32(row["addressid"]);
                AddressInfo.Address = row["Address"].ToString();
                AddressInfo.City = row["City"].ToString();
                AddressInfo.Province = row["Province"].ToString();
                AddressInfo.Zipcode = row["Zip Code"].ToString();

                ContactDetailInfo.Contactdetailid = Convert.ToInt32(row["contactdetailid"]);
                ContactDetailInfo.Addressid = Convert.ToInt32(row["addressid"]);
                ContactDetailInfo.Contactnumber = row["Contact Number"].ToString();
                ContactDetailInfo.Emailaddress = row["Email Address"].ToString();

                StoreInformationInfo.Storename = row["Store Name"].ToString();
       

            }

            txtStoreName.Text = StoreInformationInfo.Storename;
            txtContactNumber.Text = ContactDetailInfo.Contactnumber;
            txtEmailAddress.Text = ContactDetailInfo.Emailaddress;
            txtAddress.Text = AddressInfo.Address;
            txtCity.Text = AddressInfo.City;
            txtProvince.Text = AddressInfo.Province;
            txtZipCode.Text = AddressInfo.Zipcode;

        }

        private void showMessageBox(bool condition)
        {
            if (condition)
            {
      
                MessageBox.Show("Success");

            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void edit()
        {
            getDataFromForm();
            showMessageBox(AddressBL.Update(AddressInfo) & ContacDetailBL.Update(ContactDetailInfo) & StoreInformationBL.Update(StoreInformationInfo));
        }


        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            manageForm(true);
            this.ActiveControl = txtStoreName;
            current = "EDIT";
        }


        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (checkErrors())
            {
                getDataFromForm();
                if (current.Equals("EDIT"))
                {
                    edit();
                    frmMain.UpdateInfo();
                }

                manageForm(false);
        
                getDataFromDataTable();


            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            manageForm(false);
 
            clearErrors();
            getDataFromDataTable();
        }

        private void txtZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }


        private void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        
    }
}
