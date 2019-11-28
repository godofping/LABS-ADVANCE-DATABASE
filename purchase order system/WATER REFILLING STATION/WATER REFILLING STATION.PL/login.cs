using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL
{
    public partial class login : Form
    {

        public static EL.REGISTRATIONS.basicinformations basicinformationEL = new EL.REGISTRATIONS.basicinformations();
        public static EL.REGISTRATIONS.staffsaccount staffsaccountEL = new EL.REGISTRATIONS.staffsaccount();
        public static EL.REGISTRATIONS.staffs staffEL = new EL.REGISTRATIONS.staffs();
        public static EL.REGISTRATIONS.designations designationEL = new EL.REGISTRATIONS.designations();
        

        BL.REGISTRATIONS.staffsaccount staffsaccountBL = new BL.REGISTRATIONS.staffsaccount();
        main main;

        public login()
        {
            InitializeComponent();
        }


        private void ClearControls()
        {
            methods.ClearTXT(txtUsername, txtPassword);
        }

        public void LogOut()
        {
            main.Close();
            ClearControls();
            this.Show();
            txtUsername.Focus();
        }

        private void login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(
                methods.CheckRequiredTXT(txtUsername, txtPassword)
                )
            {
                staffsaccountEL.Username = txtUsername.Text;
                staffsaccountEL.Password = txtPassword.Text;

                DataTable dt = staffsaccountBL.Login(staffsaccountEL);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    staffEL.Staffid = Convert.ToInt32(row["STAFF ID"]);
                    staffsaccountEL.Staffaccountid = Convert.ToInt32(row["STAFF ACCOUNT ID"]);
                    basicinformationEL.Basicinformationid = Convert.ToInt32(row["BASIC INFORMATION ID"]);
                    designationEL.Designation = row["DESIGNATION"].ToString();

                    main = new main(this);
                    

                    main.lblName.Text = "WELCOME " + designationEL.Designation + ": " + row["FULL NAME"].ToString();
                    this.Hide();
                    main.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("LOGIN FAILED");
                    ClearControls();
                    txtUsername.Focus();
                   
                }
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL THE REQUIRED FIELDS (*)");
                txtUsername.Focus();
            }
        }

       
    }
}
