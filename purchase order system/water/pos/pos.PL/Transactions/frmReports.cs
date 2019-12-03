using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmReports : Form
    {
        pos.BL.Transactions.orders orderBL = new pos.BL.Transactions.orders();

        public frmReports()
        {
            InitializeComponent();
        }

        private void DGVLoad() 
        {
            dgv.DataSource = orderBL.List(dtpDate.Text);
            dgv.Columns["CUSTOMER ID"].Visible = false;
            dgv.Columns["C"].Visible = false;

            TotalSales();
           
        }

        private void TotalSales()
        {
            float sum = 0;
            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgv.Rows[i].Cells["TOTAL AMOUNT"].Value);
            }
            lblTotalSales.Text = sum.ToString();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            DGVLoad();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            DGVLoad();
        }
    }
}
