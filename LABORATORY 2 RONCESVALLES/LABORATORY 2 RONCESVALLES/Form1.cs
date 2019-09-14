using System;
using System.Windows.Forms;

namespace LABORATORY_2_RONCESVALLES
{
    public partial class Form1 : Form
    {

        string strEmaployeeName;
        string strPosition;


        double dblHourlyWage;
        double dblHoursOfWork;
        double dblOvertimeHourlyWage;
        double dblOvertimeHoursOfWork;
        double dblBasicPay;
        double dblSSS;
        double dblPHILHEALTH;
        double dblPAGIBIG;
        double dblIncomeTax;
        double dblPersonalExpenses;
        double dblOtherExpenses;
        double dblTotalMonthlyNetPay;
        double dblTotalMonthlyDedcutions;
        double dblMonthlySavings;
        double dblYearlySavings;



        public Form1()
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

            dblBasicPay = dblHourlyWage * dblHoursOfWork;
            dblBasicPay = dblBasicPay + (dblOvertimeHourlyWage * dblOvertimeHoursOfWork);
            lblBasicPay.Text = "₱" + String.Format("{0:n}", dblBasicPay);

            dblTotalMonthlyDedcutions = dblSSS + dblPHILHEALTH + dblPAGIBIG + dblIncomeTax + dblPersonalExpenses + dblOtherExpenses;
            dblTotalMonthlyNetPay = dblBasicPay - dblTotalMonthlyDedcutions;
            lblTotalMonthlyNetPay.Text = "₱" + String.Format("{0:n}", dblTotalMonthlyNetPay);

            lblTotalMonthlyDeductions.Text = "₱" + String.Format("{0:n}", dblTotalMonthlyDedcutions);

            dblMonthlySavings = dblTotalMonthlyNetPay - dblTotalMonthlyDedcutions;
            lblMonthlySavings.Text = "₱" + String.Format("{0:n}", dblMonthlySavings);

            dblYearlySavings = dblMonthlySavings * 12;
            lblYearlySavings.Text = "₱" + String.Format("{0:n}", dblYearlySavings);


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
                return 0.00;
            }


        }

        private void getData()
        {
            dblHourlyWage = toNumeric(txtHourlyWage.Text);
            dblHoursOfWork = toNumeric(txtHoursOfWork.Text);
            dblOvertimeHourlyWage = toNumeric(txtOvertimeHourlyWage.Text);
            dblOvertimeHoursOfWork = toNumeric(txtOvertimeHoursOfWork.Text);
            dblSSS = toNumeric(txtSSS.Text);
            dblPHILHEALTH = toNumeric(txtPHILHEALTH.Text);
            dblPAGIBIG = toNumeric(txtPAGIBIG.Text);
            dblIncomeTax = toNumeric(txtIncomeTax.Text);
            dblPersonalExpenses = toNumeric(txtPersonalExpenses.Text);
            dblOtherExpenses = toNumeric(txtOtherExpenses.Text);
        }

        private void TxtHourlyWage_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }


        private void TxtHoursOfWork_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtOvertimeHourlyWage_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtOvertimeHoursOfWork_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtSSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtPHILHEALTH_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtPAGIBIG_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void TxtIncomeTax_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtHourlyWage_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtHoursOfWork_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtOvertimeHourlyWage_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtOvertimeHoursOfWork_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtSSS_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtPHILHEALTH_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtPAGIBIG_OnValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void TxtIncomeTax_OnValueChanged(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            calculate();
        }


    }
}
