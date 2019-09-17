using System;
using System.Windows.Forms;

namespace LABORATORY_2_RONCESVALLES
{
    public partial class MainForm : Form
    {

        string strEmaployeeName;
        string strPosition;

        double dblHourlyWage;
        double dblNoOfHoursWorked;
        double dblTotalNoOfHoursOvertime;
        double dblNoOfDaysWorked;
        double dblSSS;
        double dblPhilHealth;
        double dblPagIBIG;
        double dblIncomeTaxPercent;
        double dblPersonalExpenses;
        double dblOtherExpenses;

        double dblTotalSalary;
        double dblTotalSalaryDeductions;
        double dblTotalExpenses;
        double dblNetSalary;
        double dblContingencyFunds;
        double dblTotalTakeHomePay;
        double dblMonthlySavings;
        double dblAnnualSavings;

        public MainForm()
        {
            InitializeComponent();
        }


        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void calculate()
        {
            getData();

            dblTotalSalary = ((dblHourlyWage * dblNoOfHoursWorked) * dblNoOfDaysWorked) + (dblTotalNoOfHoursOvertime * (dblHourlyWage * 1.30));
            lblTotalSalary.Text = "₱" + String.Format("{0:n}", dblTotalSalary);

            dblTotalSalaryDeductions = dblSSS + dblPhilHealth + dblPagIBIG + (dblTotalSalary * dblIncomeTaxPercent / 100);
            lblTotalSalarayDeductions.Text = "₱" + String.Format("{0:n}", dblTotalSalaryDeductions);

            dblTotalExpenses = dblPersonalExpenses + dblOtherExpenses;
            lblTotalExpenses.Text = "₱" + String.Format("{0:n}", dblTotalExpenses);

            dblNetSalary = dblTotalSalary - dblTotalSalaryDeductions;
            lblNetSalary.Text = "₱" + String.Format("{0:n}", dblNetSalary);

            dblContingencyFunds = dblNetSalary * 0.10;
            lblContingencyFunds.Text = "₱" + String.Format("{0:n}", dblContingencyFunds);

            dblTotalTakeHomePay = dblNetSalary - dblContingencyFunds;
            lblTotalTakeHomePay.Text = "₱" + String.Format("{0:n}", dblTotalTakeHomePay);

            dblMonthlySavings = dblTotalTakeHomePay - dblTotalExpenses;
            lblMonthlySavings.Text = "₱" + String.Format("{0:n}", dblMonthlySavings);

            dblAnnualSavings = dblMonthlySavings * 12;
            lblAnnualSavings.Text = "₱" + String.Format("{0:n}", dblAnnualSavings);

        }

        public static double toNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

            if (isNum == true)
            {
                return retNum;
            }
            else
            {
                return 0;
            }
        }

        private void getData()
        {
            dblHourlyWage = toNumeric(txtHourlyWage.Text);
            dblNoOfHoursWorked = toNumeric(txtNoOfHoursWorked.Text);
            dblTotalNoOfHoursOvertime = toNumeric(txtTotalNoOfHoursOvertime.Text);
            dblNoOfDaysWorked = toNumeric(txtNoOfDaysWorked.Text);
            dblSSS = toNumeric(txtSSS.Text);
            dblPhilHealth = toNumeric(txtPhilHealth.Text);
            dblPagIBIG = toNumeric(txtPagIBIG.Text);
            dblIncomeTaxPercent = toNumeric(txtIncomeTaxPercent.Text);
            dblPersonalExpenses = toNumeric(txtPersonalExpenses.Text);
            dblOtherExpenses = toNumeric(txtOtherExpenses.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtHourlyWage_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtNoOfHoursWorked_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtTotalNoOfHoursOvertime_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtNoOfDaysWorked_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtSSS_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtPhilHealth_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtPagIBIG_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtIncomeTaxPercent_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtPersonalExpenses_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtOtherExpenses_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtHourlyWage_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtNoOfHoursWorked_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtTotalNoOfHoursOvertime_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtNoOfDaysWorked_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtSSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtPhilHealth_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtPagIBIG_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtIncomeTaxPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtPersonalExpenses_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtOtherExpenses_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }
    }
}
