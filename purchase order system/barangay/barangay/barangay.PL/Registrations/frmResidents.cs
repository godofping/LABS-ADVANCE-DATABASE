using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barangay.PL.Registrations
{
    public partial class frmResidents : Form
    {
        EL.Registrations.Birthinformations birthinformationEL = new EL.Registrations.Birthinformations();
        EL.Registrations.Citizenships citizenshipEL = new EL.Registrations.Citizenships();
        EL.Registrations.Civilstatuses civilstatusEL = new EL.Registrations.Civilstatuses();
        EL.Registrations.Contactdetails contactdetailEL = new EL.Registrations.Contactdetails();
        EL.Registrations.Educationalattainments educationalattainmentEL = new EL.Registrations.Educationalattainments();
        EL.Registrations.Educations educationEL = new EL.Registrations.Educations();
        EL.Registrations.Homeaddressess homeaddressEL = new EL.Registrations.Homeaddressess();
        EL.Registrations.Householdmembers householdmemberEL = new EL.Registrations.Householdmembers();
        EL.Registrations.Households householdEL = new EL.Registrations.Households();
        EL.Registrations.Imagelocations imagelocationEL = new EL.Registrations.Imagelocations();
        EL.Registrations.Occupations occupationEL = new EL.Registrations.Occupations();
        EL.Registrations.Provincialaddresses provincialaddressEL = new EL.Registrations.Provincialaddresses();
        EL.Registrations.Puroks purokEL = new EL.Registrations.Puroks();
        EL.Registrations.Religions religionEL = new EL.Registrations.Religions();
        EL.Registrations.Residents residentEL = new EL.Registrations.Residents();
        EL.Registrations.Residentscitizenship residentcitizenshipEL = new EL.Registrations.Residentscitizenship();
        EL.Registrations.Residentscivilstatus residentcivilstatusEL = new EL.Registrations.Residentscivilstatus();
        EL.Registrations.Residentshousehold residenthouseholdEL = new EL.Registrations.Residentshousehold();
        EL.Registrations.Residentshouseholdmember residenthouseholdmemberEL = new EL.Registrations.Residentshouseholdmember();
        EL.Registrations.Residentsoccupation residentoccupationEL = new EL.Registrations.Residentsoccupation();
        EL.Registrations.Residentsreligion residentreligionEL = new EL.Registrations.Residentsreligion();
        EL.Registrations.Residentssex residentsexEL = new EL.Registrations.Residentssex();
        EL.Registrations.Sexes sexEL = new EL.Registrations.Sexes();

        BL.Registrations.Birthinformations birthinformationBL = new BL.Registrations.Birthinformations();
        BL.Registrations.Citizenships citizenshipBL = new BL.Registrations.Citizenships();
        BL.Registrations.Civilstatuses civilstatusBL = new BL.Registrations.Civilstatuses();
        BL.Registrations.Contactdetails contactdetailBL = new BL.Registrations.Contactdetails();
        BL.Registrations.Educationalattainments educationalattainmentBL = new BL.Registrations.Educationalattainments();
        BL.Registrations.Educations educationBL = new BL.Registrations.Educations();
        BL.Registrations.Homeaddressess homeaddressBL = new BL.Registrations.Homeaddressess();
        BL.Registrations.Householdmembers householdmemberBL = new BL.Registrations.Householdmembers();
        BL.Registrations.Households householdBL = new BL.Registrations.Households();
        BL.Registrations.Imagelocations imagelocationBL = new BL.Registrations.Imagelocations();
        BL.Registrations.Occupations occupationBL = new BL.Registrations.Occupations();
        BL.Registrations.Provincialaddresses provincialaddressBL = new BL.Registrations.Provincialaddresses();
        BL.Registrations.Puroks purokBL = new BL.Registrations.Puroks();
        BL.Registrations.Religions religionBL = new BL.Registrations.Religions();
        BL.Registrations.Residents residentBL = new BL.Registrations.Residents();
        BL.Registrations.Residentscitizenship residentcitizenshipBL = new BL.Registrations.Residentscitizenship();
        BL.Registrations.Residentscivilstatus residentcivilstatusBL = new BL.Registrations.Residentscivilstatus();
        BL.Registrations.Residentshousehold residenthouseholdBL = new BL.Registrations.Residentshousehold();
        BL.Registrations.Residentshouseholdmember residenthouseholdmemberBL = new BL.Registrations.Residentshouseholdmember();
        BL.Registrations.Residentsoccupation residentoccupationBL = new BL.Registrations.Residentsoccupation();
        BL.Registrations.Residentsreligion residentreligionBL = new BL.Registrations.Residentsreligion();
        BL.Registrations.Residentssex residentsexBL = new BL.Registrations.Residentssex();
        BL.Registrations.Sexes sexBL = new BL.Registrations.Sexes();


        string s = "";

        public frmResidents()
        {
            InitializeComponent();
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

        private void ClearForm()
        {
            methods.ClearTXT(txtBarangayIDNumber, txtLastName, txtFirstName, txtMiddleName, txtBirthPlace, txtHeight, txtYearGraduated, txtCourse);
            methods.ClearCB(cbCitizenship, cbReligion, cbSex, cbCivilStatus, cbEducationalAttainment, cbProfessionOrOccupation);
            methods.ClearDTP(dtpBirthDate);
            lblTitle.Text = "";
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, householdBL.List(txtSearch.Text));
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbCitizenship, citizenshipBL.List(), "citizenship", "citizenshipid");
            methods.LoadCB(cbReligion, religionBL.List(), "religion", "religionid");
            methods.LoadCB(cbSex, sexBL.List(), "sex", "sexid");
            methods.LoadCB(cbCivilStatus, civilstatusBL.List(), "civilstatus", "civilstatusid");
            methods.LoadCB(cbEducationalAttainment, educationalattainmentBL.List(), "educationalattainment", "educationalattainmentid");
            methods.LoadCB(cbProfessionOrOccupation, occupationBL.List(), "occupation", "occupationid");
        }

        private void DGVManage()
        {
            PopulateDGV();
            methods.DGVHiddenColumns(dgv, "householdid");
            methods.DGVRenameColumns(dgv, "householdid", "Household", "Household Number");
            methods.DGVTheme(dgv);
            methods.DGVBUTTONAddEdit(dgv);
        }

        private void ShowForm(bool bol)
        {
            pnlMain.Visible = !bol;
            pnlForm.Visible = bol;

            ClearForm();
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("SUCCESS");
                PopulateDGV();
                ShowForm(false);
            }
            else
            {
                MessageBox.Show("FAILED");
            }
        }

        private void frmResidents_Load(object sender, EventArgs e)
        {
            ShowForm(false);
            PopulateCB();
            DGVManage();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowForm(true);
            lblTitle.Text = "Adding Resident";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bol = false;

            if (methods.CheckRequiredTXT(txtBarangayIDNumber, txtLastName))
            {
                householdEL.Household = txtBarangayIDNumber.Text;
                householdEL.Householdnumber = txtLastName.Text;

                if (s.Equals("ADD"))
                {
                    bol = householdBL.Insert(householdEL) > 0;
                }
                else if (s.Equals("EDIT"))
                {
                    bol = householdBL.Update(householdEL);
                }

                ShowResult(bol);
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL REQUIRED FIELDS WITH AN ASTERISK");
            }
        }


        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            householdEL.Householdid = Convert.ToInt32(dgv.SelectedRows[0].Cells["householdid"].Value);

            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                ShowForm(true);
                lblTitle.Text = "Updating Household";



                householdEL = householdBL.Select(householdEL);
                txtBarangayIDNumber.Text = householdEL.Household;
                txtLastName.Text = householdEL.Householdnumber;


            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE TO DELETE THIS SELECTED ITEM?", "DELETING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(householdBL.Delete(householdEL));
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void btnNextStep1_Click(object sender, EventArgs e)
        {
            pnlFormGroupStep1.Visible = false;
            pnlFormGroupStep2.Visible = true;
        }


        private void btnPreviousStep2_Click(object sender, EventArgs e)
        {
            pnlFormGroupStep1.Visible = true;
            pnlFormGroupStep2.Visible = false;
        }

        
    }
}
