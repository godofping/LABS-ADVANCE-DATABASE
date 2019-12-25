using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            methods.ClearTXT(txtBarangayIDNumber, txtLastName, txtFirstName, txtMiddleName, txtBirthPlace, txtHeight, txtWeight, txtCourse, txtHouseNumber, txtStreet, txtSubdivision, txtMunicipality, txtProvince, txtPrecintNumber, txtPhoneNumber, txtCellphoneNumber, txtEmailAddress, txtCTCNumber, txtHousehold, txtYearGraduated);
            methods.ClearCB(cbCitizenship, cbReligion, cbSex, cbCivilStatus, cbEducationalAttainment, cbProfessionOrOccupation, cbPurok, cbHouseholdMember);
            methods.ClearDTP(dtpBirthDate, dtpDateAccomplished);
            cbIsPwd.Checked = false;
            lblTitle.Text = "";
        }

        private void PopulateDGV()
        {
            if (rbNone.Checked == true)
            {
                methods.LoadDGV(dgv, residentBL.List(txtSearch.Text));
            }
            if (rbHouseholdHeads.Checked == true)
            {
                methods.LoadDGV(dgv, residentBL.ListByHouseholdHeads(txtSearch.Text));
            }
            if (rbOutOfSchoolYouth.Checked == true)
            {
                methods.LoadDGV(dgv, residentBL.ListByOutOfSchoolYouth(txtSearch.Text));
            }
            if (rbSeniorCitizen.Checked == true)
            {
                methods.LoadDGV(dgv, residentBL.ListBySeniorCitizen(txtSearch.Text));
            }
            if (rbWomen.Checked == true)
            {
                methods.LoadDGV(dgv, residentBL.ListByWomen(txtSearch.Text));
            }
            if (rbPWD.Checked == true)
            {
                methods.LoadDGV(dgv, residentBL.ListByPWD(txtSearch.Text));
            }


        }

        private void PopulateDGVHousehold()
        {
            methods.LoadDGV(dgvHousehold, householdBL.List(txtSearchHousehold.Text));
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbCitizenship, citizenshipBL.List(), "citizenship", "citizenshipid");
            methods.LoadCB(cbReligion, religionBL.List(), "religion", "religionid");
            methods.LoadCB(cbSex, sexBL.List(), "sex", "sexid");
            methods.LoadCB(cbCivilStatus, civilstatusBL.List(), "civilstatus", "civilstatusid");
            methods.LoadCB(cbEducationalAttainment, educationalattainmentBL.List(), "educationalattainment", "educationalattainmentid");
            methods.LoadCB(cbProfessionOrOccupation, occupationBL.List(), "occupation", "occupationid");
            methods.LoadCB(cbPurok, purokBL.List(), "purok", "purokid");
            methods.LoadCB(cbHouseholdMember, householdmemberBL.List(), "householdmember", "householdmemberid");
        }

        private void DGVManage()
        {
            PopulateDGV();
            methods.DGVHiddenColumns(dgv, "residentid", "ispwd", "age", "educationalattainment", "birthdate", "sex", "household", "purok", "householdid");
            methods.DGVRenameColumns(dgv, "residentid", "Household Number", "Household Member", "Last Name", "First Name", "Middle Name");
            methods.DGVTheme(dgv);
            methods.DGVBUTTONViewEditDelete(dgv);

            PopulateDGVHousehold();
            methods.DGVHiddenColumns(dgvHousehold, "householdid");
            methods.DGVRenameColumns(dgvHousehold, "householdid", "Household", "Household Number");
            methods.DGVTheme(dgvHousehold);
            methods.DGVBUTTONSelect(dgvHousehold);
        }

        private void ShowAddEdit()
        {
            pnlMain.Visible = false;
            pnlView.Visible = false;
            pnlAddEditStep1.Visible = true;
            pnlAddEditStep2.Visible = false;
            pnlAddEditStep3.Visible = false;
            ClearForm();
        }

        private void ShowMain()
        {
            pnlMain.Visible = true;
            pnlView.Visible = false;
            pnlAddEditStep1.Visible = false;
            pnlAddEditStep2.Visible = false;
            pnlAddEditStep3.Visible = false;
            ClearForm();
            lblTitle.Text = "List of Residents";
        }

        private void ShowView()
        {
            pnlMain.Visible = false;
            pnlView.Visible = true;
            pnlAddEditStep1.Visible = false;
            pnlAddEditStep2.Visible = false;
            pnlAddEditStep3.Visible = false;
        }

        

        private void ShowHouseholds(bool bol)
        {
            gbCaptureImage.Visible = !bol;
            gbSearchHousehold.Visible = bol;

            txtSearchHousehold.ResetText();
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("SUCCESS");
                PopulateDGV();
                ShowMain();
            }
            else
            {
                MessageBox.Show("FAILED");
            }
        }

        private void frmResidents_Load(object sender, EventArgs e)
        {
            ShowMain();
            PopulateCB();
            DGVManage();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowAddEdit();
            ShowHouseholds(false);
            lblTitle.Text = "Adding Resident";
        }


        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0 | e.ColumnIndex == 1 | e.ColumnIndex == 2) 
            {
                residentEL.Residentid = Convert.ToInt32(dgv.SelectedRows[0].Cells["residentid"].Value);
                educationEL.Residentid = residentEL.Residentid;
                residentreligionEL.Residentid = residentEL.Residentid;
                residentcivilstatusEL.Residentid = residentEL.Residentid;
                residentsexEL.Residentid = residentEL.Residentid;
                residentcitizenshipEL.Residentid = residentEL.Residentid;
                residentoccupationEL.Residentid = residentEL.Residentid;
                homeaddressEL.Residentid = residentEL.Residentid;
                residenthouseholdEL.Residentid = residentEL.Residentid;
                provincialaddressEL.Residentid = residentEL.Residentid;
                contactdetailEL.Residentid = residentEL.Residentid;
                birthinformationEL.Residentid = residentEL.Residentid;
            }


            if (e.ColumnIndex == 0)
            {
                s = "VIEW";
                ShowView();
                ShowHouseholds(false);
                lblTitle.Text = "View Resident Profile";

                residentEL = residentBL.Select(residentEL);
                educationEL = educationBL.Select(educationEL);
                residentreligionEL = residentreligionBL.Select(residentreligionEL);
                residentcivilstatusEL = residentcivilstatusBL.Select(residentcivilstatusEL);
                residentsexEL = residentsexBL.Select(residentsexEL);
                residentcitizenshipEL = residentcitizenshipBL.Select(residentcitizenshipEL);
                residentoccupationEL = residentoccupationBL.Select(residentoccupationEL);
                homeaddressEL = homeaddressBL.Select(homeaddressEL);
                residenthouseholdEL = residenthouseholdBL.Select(residenthouseholdEL);
                provincialaddressEL = provincialaddressBL.Select(provincialaddressEL);
                contactdetailEL = contactdetailBL.Select(contactdetailEL);
                birthinformationEL = birthinformationBL.Select(birthinformationEL);
                purokEL.Purokid = homeaddressEL.Purokid;
                purokEL = purokBL.Select(purokEL);
                citizenshipEL.Citizenshipid = residentcitizenshipEL.Citizenshipid;
                citizenshipEL = citizenshipBL.Select(citizenshipEL);
                householdEL.Householdid = residenthouseholdEL.Householdid;
                householdEL = householdBL.Select(householdEL);
                religionEL.Religionid = residentreligionEL.Religionid;
                religionEL = religionBL.Select(religionEL);
                sexEL.Sexid = residentsexEL.Sexid;
                sexEL = sexBL.Select(sexEL);
                civilstatusEL.Civilstatusid = residentcivilstatusEL.Civilstatusid;
                civilstatusEL = civilstatusBL.Select(civilstatusEL);
                educationalattainmentEL.Educationalattainmentid = educationEL.Educationalattainmentid;
                educationalattainmentEL = educationalattainmentBL.Select(educationalattainmentEL);
                occupationEL.Occupationid = residentoccupationEL.Occupationid;
                occupationEL = occupationBL.Select(occupationEL);

                lblBarangayIDNumber.Text = residentEL.Barangayidnumber;
                lblFullName.Text = residentEL.Firstname + " " + residentEL.Middlename + " " + residentEL.Lastname;
                lblHouseholdControl.Text = "Household Member Control: " + householdEL.Householdnumber  + " " + householdEL.Household;
                lblAddress.Text = homeaddressEL.Housenumber + ", " + homeaddressEL.Street + ", " + homeaddressEL.Subdivision + ", " + purokEL.Purok + ", Barangay Bukay Pait, " + provincialaddressEL.Municipality + ", " + provincialaddressEL.Province; 
                lblDateRecorded.Text = "Date Recorded: " + Convert.ToDateTime(residentEL.Daterecorded).ToString("MMMM dd, yyyy");


                lblBarangayIDNumber1.Text = residentEL.Barangayidnumber;
                lblLastName.Text = residentEL.Lastname;
                lblFirstName.Text = residentEL.Firstname;
                lblMiddleName.Text = residentEL.Middlename;
                lblCitizenship.Text = citizenshipEL.Citizenship;
                lblReligion.Text = religionEL.Religion;
                lblBirthPlace.Text = birthinformationEL.Birthplace;
                lblBirthday.Text = Convert.ToDateTime(birthinformationEL.Birthdate).ToString("MMMM dd, yyyy");
                lblGender.Text = sexEL.Sex;
                lblHeight.Text = residentEL.Height + " cm";
                lblWeight.Text = residentEL.Weight + " kg";
                lblCivilStatus.Text = civilstatusEL.Civilstatus;
                lblEducationalAttainment.Text = educationalattainmentEL.Educationalattainment;
                lblCourse.Text = educationEL.Course;
                lblYear.Text = educationEL.Yeargraduated;
                lblOccupation.Text = occupationEL.Occupation;

                lblHouseNumber.Text = homeaddressEL.Housenumber;
                lblStreet.Text = homeaddressEL.Street;
                lblSubdivision.Text = homeaddressEL.Subdivision;
                lblPurok.Text = purokEL.Purok;

                lblMunicipality.Text = provincialaddressEL.Municipality;
                lblProvince.Text = provincialaddressEL.Province;

                lblPrecintNumber.Text = residentEL.Precintnumber;
                lblEmailAddress.Text = contactdetailEL.Emailaddress;
                lblPhoneNumber.Text = contactdetailEL.Phonenumber;
                lblCellphoneNumber.Text = contactdetailEL.Cellphonenumber;

                lblCTCNumber.Text = residentEL.Ctcnumber;
                lblDateAccomplished.Text = Convert.ToDateTime(residentEL.Dateaccomplished).ToString("MMMM dd, yyyy");


            }
            else if (e.ColumnIndex == 1)
            {
                s = "EDIT";
                ShowAddEdit();
                ShowHouseholds(false);
                lblTitle.Text = "Updating Resident";

                residentEL = residentBL.Select(residentEL);
                educationEL = educationBL.Select(educationEL);
                residentreligionEL = residentreligionBL.Select(residentreligionEL);
                residentcivilstatusEL = residentcivilstatusBL.Select(residentcivilstatusEL);
                residentsexEL = residentsexBL.Select(residentsexEL);
                residentcitizenshipEL = residentcitizenshipBL.Select(residentcitizenshipEL);
                residentoccupationEL = residentoccupationBL.Select(residentoccupationEL);
                homeaddressEL = homeaddressBL.Select(homeaddressEL);
                residenthouseholdEL = residenthouseholdBL.Select(residenthouseholdEL);
                provincialaddressEL = provincialaddressBL.Select(provincialaddressEL);
                contactdetailEL = contactdetailBL.Select(contactdetailEL);
                birthinformationEL = birthinformationBL.Select(birthinformationEL);
                


                txtBarangayIDNumber.Text = residentEL.Barangayidnumber;
                txtLastName.Text = residentEL.Lastname;
                txtFirstName.Text = residentEL.Firstname;
                txtMiddleName.Text = residentEL.Middlename;
                txtHeight.Text = residentEL.Height;
                txtWeight.Text = residentEL.Weight;
                txtPrecintNumber.Text = residentEL.Precintnumber;
                txtCTCNumber.Text = residentEL.Ctcnumber;
                dtpDateAccomplished.Text = residentEL.Dateaccomplished;
                cbIsPwd.Checked = Convert.ToBoolean(residentEL.Ispwd);

                cbEducationalAttainment.SelectedValue = educationEL.Educationalattainmentid.ToString();
                txtCourse.Text = educationEL.Course;
                txtYearGraduated.Text = educationEL.Yeargraduated;

                cbReligion.SelectedValue = residentreligionEL.Religionid.ToString();

                cbCivilStatus.SelectedValue = residentcivilstatusEL.Civilstatusid;

                cbSex.SelectedValue = residentsexEL.Sexid;

                cbCitizenship.SelectedValue = residentcitizenshipEL.Citizenshipid;

                cbProfessionOrOccupation.SelectedValue = residentoccupationEL.Occupationid;

                cbPurok.SelectedValue = homeaddressEL.Purokid;
                txtHouseNumber.Text = homeaddressEL.Housenumber;
                txtStreet.Text = homeaddressEL.Street;
                txtSubdivision.Text = homeaddressEL.Subdivision;

                householdEL.Householdid = residenthouseholdEL.Householdid;
                householdEL = householdBL.Select(householdEL);
                txtHousehold.Text = householdEL.Household + " (" + householdEL.Householdnumber + ")";

                cbHouseholdMember.SelectedValue = residenthouseholdEL.Householdmemberid;

                txtProvince.Text = provincialaddressEL.Province;
                txtMunicipality.Text = provincialaddressEL.Municipality;

                txtEmailAddress.Text = contactdetailEL.Emailaddress;
                txtPhoneNumber.Text = contactdetailEL.Phonenumber;
                txtCellphoneNumber.Text = contactdetailEL.Cellphonenumber;

                txtBirthPlace.Text = birthinformationEL.Birthplace;
                dtpBirthDate.Text = birthinformationEL.Birthdate;

            }
            else if (e.ColumnIndex == 2)
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE TO DELETE THIS SELECTED ITEM?", "DELETING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult((birthinformationBL.Delete(birthinformationEL)) &
                        (educationBL.Delete(educationEL)) &
                        (residentreligionBL.Delete(residentreligionEL)) &
                        (residentcivilstatusBL.Delete(residentcivilstatusEL)) &
                        (residentsexBL.Delete(residentsexEL)) &
                        (residentcitizenshipBL.Delete(residentcitizenshipEL)) &
                        (residentoccupationBL.Delete(residentoccupationEL)) &
                        (homeaddressBL.Delete(homeaddressEL)) &
                        (residenthouseholdBL.Delete(residenthouseholdEL)) &
                        (provincialaddressBL.Delete(provincialaddressEL)) &
                        (contactdetailBL.Delete(contactdetailEL)) &
                        (residentBL.Delete(residentEL)));
                   
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            CalculateAfterStopTypingDGV();
        }

        private void txtSearchHousehold_TextChanged(object sender, EventArgs e)
        {
            CalculateAfterStopTypingDGVHousehold();
        }

        Thread delayedCalculationThreadDGV;
        Thread delayedCalculationThreadDGVHousehold;

        int delay = 0;
        int delay1 = 0;
        private void CalculateAfterStopTypingDGV()
        {
            delay += 200;
            if (delayedCalculationThreadDGV != null && delayedCalculationThreadDGV.IsAlive)
                return;

            delayedCalculationThreadDGV = new Thread(() =>
            {
                while (delay >= 200)
                {
                    delay = delay - 200;
                    try
                    {
                        Thread.Sleep(200);
                    }
                    catch (Exception) { }
                }
                Invoke(new Action(() =>
                {
                    PopulateDGV();
                }));
            });

            delayedCalculationThreadDGV.Start();
        }

        private void CalculateAfterStopTypingDGVHousehold()
        {
            delay1 += 200;
            if (delayedCalculationThreadDGVHousehold != null && delayedCalculationThreadDGVHousehold.IsAlive)
                return;

            delayedCalculationThreadDGVHousehold = new Thread(() =>
            {
                while (delay1 >= 200)
                {
                    delay1 = delay1 - 200;
                    try
                    {
                        Thread.Sleep(200);
                    }
                    catch (Exception) { }
                }
                Invoke(new Action(() =>
                {
                    PopulateDGVHousehold();
                }));
            });

            delayedCalculationThreadDGVHousehold.Start();
        }

        private void btnNextStep1_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtBarangayIDNumber, txtLastName, txtFirstName, txtMiddleName, txtBirthPlace, txtHeight, txtHeight, txtCourse, txtYearGraduated) &
                methods.CheckRequiredCB(cbSex, cbCivilStatus, cbCitizenship, cbReligion, cbEducationalAttainment, cbProfessionOrOccupation) &
                methods.CheckRequiredDTP(dtpBirthDate))
            {
                pnlAddEditStep1.Visible = false;
                pnlAddEditStep2.Visible = true;
                pnlAddEditStep3.Visible = false;
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL REQUIRED FIELDS WITH AN ASTERISK");
            }

        }

        private void btnNextStep2_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtHouseNumber, txtStreet, txtMunicipality, txtProvince, txtPrecintNumber, txtEmailAddress, txtPhoneNumber, txtCellphoneNumber, txtCTCNumber) &
                methods.CheckRequiredCB(cbPurok) &
                methods.CheckRequiredDTP(dtpDateAccomplished))
            {
                pnlAddEditStep1.Visible = false;
                pnlAddEditStep2.Visible = false;
                pnlAddEditStep3.Visible = true;
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL REQUIRED FIELDS WITH AN ASTERISK");
            }
        }

        private void btnPreviousStep2_Click(object sender, EventArgs e)
        {
            pnlAddEditStep1.Visible = true;
            pnlAddEditStep2.Visible = false;
            pnlAddEditStep3.Visible = false;
        }

        private void btnPreviousStep3_Click(object sender, EventArgs e)
        {
            pnlAddEditStep1.Visible = false;
            pnlAddEditStep2.Visible = true;
            pnlAddEditStep3.Visible = false;
        }

            
        private void btnCloseStep1_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void btnCloseStep3_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void btnCloseStep2_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtHousehold) & methods.CheckRequiredCB(cbHouseholdMember))
            {
                bool bol = false;

                residentEL.Barangayidnumber = txtBarangayIDNumber.Text;
                residentEL.Lastname = txtLastName.Text;
                residentEL.Firstname = txtFirstName.Text;
                residentEL.Middlename = txtMiddleName.Text;
                residentEL.Height = txtHeight.Text;
                residentEL.Weight = txtWeight.Text;
                residentEL.Precintnumber = txtPrecintNumber.Text;
                residentEL.Ctcnumber = txtCTCNumber.Text;
                residentEL.Dateaccomplished = dtpDateAccomplished.Text;
                residentEL.Daterecorded = DateTime.Now.ToString("yyyy-MM-dd");
                residentEL.Ispwd = Convert.ToInt32(cbIsPwd.Checked);

                educationEL.Educationalattainmentid = Convert.ToInt32(cbEducationalAttainment.SelectedValue);
                educationEL.Course = txtCourse.Text;
                educationEL.Yeargraduated = txtYearGraduated.Text;

                residentreligionEL.Religionid = Convert.ToInt32(cbReligion.SelectedValue);

                residentcivilstatusEL.Civilstatusid = Convert.ToInt32(cbCivilStatus.SelectedValue);

                residentsexEL.Sexid = Convert.ToInt32(cbSex.SelectedValue);

                residentcitizenshipEL.Citizenshipid = Convert.ToInt32(cbCitizenship.SelectedValue);

                residentoccupationEL.Occupationid = Convert.ToInt32(cbProfessionOrOccupation.SelectedValue);

                homeaddressEL.Purokid = Convert.ToInt32(cbPurok.SelectedValue);
                homeaddressEL.Housenumber = txtHouseNumber.Text;
                homeaddressEL.Street = txtStreet.Text;
                homeaddressEL.Subdivision = txtSubdivision.Text;

                residenthouseholdEL.Householdid = householdEL.Householdid;
                residenthouseholdEL.Householdmemberid = Convert.ToInt32(cbHouseholdMember.SelectedValue);

                provincialaddressEL.Province = txtProvince.Text;
                provincialaddressEL.Municipality = txtMunicipality.Text;

                contactdetailEL.Emailaddress = txtEmailAddress.Text;
                contactdetailEL.Phonenumber = txtPhoneNumber.Text;
                contactdetailEL.Cellphonenumber = txtCellphoneNumber.Text;

                birthinformationEL.Birthplace = txtBirthPlace.Text;
                birthinformationEL.Birthdate = dtpBirthDate.Text;

                if (s.Equals("ADD"))
                {
                    residentEL.Residentid = Convert.ToInt32(residentBL.Insert(residentEL));

                    if (residentEL.Residentid > 0)
                    {
                        educationEL.Residentid = residentEL.Residentid;
                        residentreligionEL.Residentid = residentEL.Residentid;
                        residentcivilstatusEL.Residentid = residentEL.Residentid;
                        residentsexEL.Residentid = residentEL.Residentid;
                        residentcitizenshipEL.Residentid = residentEL.Residentid;
                        residentoccupationEL.Residentid = residentEL.Residentid;
                        homeaddressEL.Residentid = residentEL.Residentid;
                        residenthouseholdEL.Residentid = residentEL.Residentid;
                        provincialaddressEL.Residentid = residentEL.Residentid;
                        contactdetailEL.Residentid = residentEL.Residentid;
                        birthinformationEL.Residentid = residentEL.Residentid;


                        bol = ((educationBL.Insert(educationEL) > 0) &
                            (residentreligionBL.Insert(residentreligionEL) > 0) &
                            (residentcivilstatusBL.Insert(residentcivilstatusEL) > 0) &
                            (residentsexBL.Insert(residentsexEL) > 0) &
                            (residentcitizenshipBL.Insert(residentcitizenshipEL) > 0) &
                            (residentoccupationBL.Insert(residentoccupationEL) > 0) &
                            (homeaddressBL.Insert(homeaddressEL) > 0) &
                            (residenthouseholdBL.Insert(residenthouseholdEL) > 0) &
                            (provincialaddressBL.Insert(provincialaddressEL) > 0) &
                            (contactdetailBL.Insert(contactdetailEL) > 0) &
                            (birthinformationBL.Insert(birthinformationEL) > 0));
                    }
                }
                else if (s.Equals("EDIT"))
                {
                    bol = ((residentBL.Update(residentEL)) &
                            (educationBL.Update(educationEL)) &
                            (residentreligionBL.Update(residentreligionEL)) &
                            (residentcivilstatusBL.Update(residentcivilstatusEL)) &
                            (residentsexBL.Update(residentsexEL)) &
                            (residentcitizenshipBL.Update(residentcitizenshipEL)) &
                            (residentoccupationBL.Update(residentoccupationEL)) &
                            (homeaddressBL.Update(homeaddressEL)) &
                            (residenthouseholdBL.Update(residenthouseholdEL)) &
                            (provincialaddressBL.Update(provincialaddressEL)) &
                            (contactdetailBL.Update(contactdetailEL)) &
                            (birthinformationBL.Update(birthinformationEL)));
                }

                ShowResult(bol);
            }
            else
            {
                MessageBox.Show("PLEASE COMPLETE ALL REQUIRED FIELDS WITH AN ASTERISK");
            }

        }

        private void btnSelectHousehold_Click(object sender, EventArgs e)
        {
            ShowHouseholds(true);
        }

        private void btnCancelSearchHousehold_Click(object sender, EventArgs e)
        {
            ShowHouseholds(false);
        }

        private void dgvHousehold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                householdEL.Householdid = Convert.ToInt32(dgvHousehold.SelectedRows[0].Cells["householdid"].Value);
                householdEL = householdBL.Select(householdEL);
                txtHousehold.Text = householdEL.Household + " (" + householdEL.Householdnumber + ")";
                ShowHouseholds(false);
            }
        }


        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void rbHouseholdHeads_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void rbOutOfSchoolYouth_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void rbSeniorCitizen_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void rbPWD_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void rbWomen_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void btnCloseView_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void btnBarangayCertifications_Click(object sender, EventArgs e)
        {
            Transactions.frmBarangayCertifications frmBarangayCertification = new Transactions.frmBarangayCertifications(residentEL);
            frmBarangayCertification.ShowDialog();
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            methods.OnlyNumTXT(sender, e);
        }

        private void tbWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            methods.OnlyNumTXT(sender, e);
        }
    }
}
