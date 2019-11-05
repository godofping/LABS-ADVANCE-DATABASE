using System;
using System.Data;
using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageStoreInformation : Form
    {
        EL.Registrations.StoreInformation storeInformationEL;
        EL.Registrations.ContactDetails contactDetailEL = new EL.Registrations.ContactDetails();
        EL.Registrations.Addresses addressEL = new EL.Registrations.Addresses();

        BL.Registrations.StoreInformation storeInformationBL = new BL.Registrations.StoreInformation();
        BL.Registrations.ContactDetails contactDetailBL = new BL.Registrations.ContactDetails();
        BL.Registrations.Addresses addressBL = new BL.Registrations.Addresses();

        PL.frmMain frmMain;

        string current = "";

        public frmManageStoreInformation(EL.Registrations.StoreInformation _storeInformationEL, PL.frmMain _frmMain)
        {
            InitializeComponent();
            storeInformationEL = _storeInformationEL;
            frmMain = _frmMain;
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
            ManageForm(false);
            txtZipCode.MaxLength = 6;
          
            GetDataFromDataTable();
        }

        private void ManageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;

        }

        private void ClearErrors()
        {

            errorProvider1.SetError(txtStoreName, "");
            errorProvider1.SetError(txtContactNumber, "");
            errorProvider1.SetError(txtEmailAddress, "");
            errorProvider1.SetError(txtAddress, "");
            errorProvider1.SetError(txtCity, "");
            errorProvider1.SetError(txtProvince, "");
            errorProvider1.SetError(txtZipCode, "");

        }


        private bool CheckErrors()
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

        private void GetDataFromForm()
        {
            addressEL.Address = txtAddress.Text;
            addressEL.City = txtCity.Text;
            addressEL.Zipcode = txtZipCode.Text;
            addressEL.Province = txtProvince.Text;

            contactDetailEL.Contactnumber = txtContactNumber.Text;
            contactDetailEL.Emailaddress = txtEmailAddress.Text;

            storeInformationEL.Storename = txtStoreName.Text;
        }

        private void GetDataFromDataTable()
        {
            foreach (DataRow row in storeInformationBL.List().Rows)
            {
                addressEL.Addressid = Convert.ToInt32(row["addressid"]);
                addressEL.Address = row["Address"].ToString();
                addressEL.City = row["City"].ToString();
                addressEL.Province = row["Province"].ToString();
                addressEL.Zipcode = row["Zip Code"].ToString();

                contactDetailEL.Contactdetailid = Convert.ToInt32(row["contactdetailid"]);
                contactDetailEL.Addressid = Convert.ToInt32(row["addressid"]);
                contactDetailEL.Contactnumber = row["Contact Number"].ToString();
                contactDetailEL.Emailaddress = row["Email Address"].ToString();

                storeInformationEL.Storename = row["Store Name"].ToString();
       

            }

            txtStoreName.Text = storeInformationEL.Storename;
            txtContactNumber.Text = contactDetailEL.Contactnumber;
            txtEmailAddress.Text = contactDetailEL.Emailaddress;
            txtAddress.Text = addressEL.Address;
            txtCity.Text = addressEL.City;
            txtProvince.Text = addressEL.Province;
            txtZipCode.Text = addressEL.Zipcode;

        }

        private void ShowMessageBox(bool condition)
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

        private void Edit()
        {
            ShowMessageBox(addressBL.Update(addressEL) & contactDetailBL.Update(contactDetailEL) & storeInformationBL.Update(storeInformationEL));
        }


        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            ManageForm(true);
            this.ActiveControl = txtStoreName;
            current = "EDIT";
        }


        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                if (current.Equals("EDIT"))
                {
                    Edit();
                    frmMain.UpdateInfo();
                }

                ManageForm(false);
        
                GetDataFromDataTable();


            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            ManageForm(false);
 
            ClearErrors();
            GetDataFromDataTable();
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
