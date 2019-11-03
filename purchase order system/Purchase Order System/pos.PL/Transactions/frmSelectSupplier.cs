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
    public partial class frmSelectSupplier : Form
    {

        EL.Registrations.Suppliers supplierEL;

        BL.Registrations.Suppliers supplierBL = new BL.Registrations.Suppliers();


        frmManagePurchaseOrders frmManagePurchaseOrders;

        public frmSelectSupplier(frmManagePurchaseOrders _frmManagePurchaseOrders, EL.Registrations.Suppliers _supplierEL)
        {
            InitializeComponent();
            frmManagePurchaseOrders = _frmManagePurchaseOrders;
            supplierEL = _supplierEL;
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

        private void PopulateControls()
        {
            cbSupplierName.DisplayMember = "Supplier";
            cbSupplierName.ValueMember = "Supplier ID";
            cbSupplierName.DataSource = supplierBL.List("");
        }

        private void frmSelectSupplier_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            supplierEL.Supplierid = Convert.ToInt32(cbSupplierName.SelectedValue);
            supplierEL.Supplier = cbSupplierName.Text;

            

            frmManagePurchaseOrders.cbSupplierName.SelectedIndex = frmManagePurchaseOrders.cbSupplierName.FindString(cbSupplierName.Text);
            frmManagePurchaseOrders.ManageForm(true);
            this.Close();
        }
    }
}
