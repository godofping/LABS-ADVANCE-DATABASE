using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            int intGrade = Convert.ToInt32(txtGrade.Text);
            String strResult;

            if (intGrade <= 100 && intGrade >= 95)
            {
                strResult = "A";
            }
            else if (intGrade <= 95 && intGrade >= 90)
            {
                strResult = "B";
            }
            else if (intGrade <= 90 && intGrade >= 85)
            {
                strResult = "C";
            }
            else if (intGrade <= 85 && intGrade >= 80)
            {
                strResult = "D";
            }
            else if (intGrade <= 80 && intGrade >= 75)
            {
                strResult = "E";
            }
            else if (intGrade <= 75 && intGrade >= 60)
            {
                strResult = "F";
            }
            else
            {
                strResult = "Invalid";
            }

            MessageBox.Show("Your grade is " + strResult);
        }
    }
}
