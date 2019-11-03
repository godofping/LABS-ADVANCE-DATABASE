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
    public partial class frmManagePurchaseOrderProducts : Form
    {
        frmManagePurchaseOrders frmManagePurchaseOrders;
        public frmManagePurchaseOrderProducts(frmManagePurchaseOrders _frmManagePurchaseOrders)
        {
            InitializeComponent();
            frmManagePurchaseOrders = _frmManagePurchaseOrders;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
