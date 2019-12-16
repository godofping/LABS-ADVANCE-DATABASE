using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmRerportDailySales : Form
    {
        EL.Transactions.productsintransactions productsintransactionEL = new EL.Transactions.productsintransactions();
        EL.Transactions.transactions transactionEL = new EL.Transactions.transactions();

        BL.Transactions.productsintransactions productsintransactionBL = new BL.Transactions.productsintransactions();
        BL.Transactions.transactions transactionBL = new BL.Transactions.transactions();


        public frmRerportDailySales()
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

        private void frmRerportDailySales_Load(object sender, EventArgs e)
        {
            dtpDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void pbGenerateReport_Click(object sender, EventArgs e)
        {
            crDailySales crDailySales = new crDailySales();


            crDailySales.Database.Tables["transactions_view"].SetDataSource(transactionBL.DailySales(dtpDate.Text));
            crDailySales.Database.Tables["SALES"].SetDataSource(transactionBL.TodaySales(dtpDate.Text));

            crvDailySales.ReportSource = null;
            crvDailySales.ReportSource = crDailySales;
            crvDailySales.Refresh();
        }

    
    }
}
