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
    public partial class frmReportInventory : Form
    {

        EL.Registrations.products productEL = new EL.Registrations.products();

        BL.Registrations.products productBL = new BL.Registrations.products();

        public frmReportInventory()
        {
            InitializeComponent();
        }

        private void frmReportInventory_Load(object sender, EventArgs e)
        {
            crInventory crInventory = new crInventory();


            crInventory.Database.Tables["products_view"].SetDataSource(productBL.List(""));


            crvInventory.ReportSource = null;
            crvInventory.ReportSource = crInventory;
            crvInventory.Refresh();
        }
    }
}
