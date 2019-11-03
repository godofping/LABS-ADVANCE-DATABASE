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

        EL.Registrations.Suppliers SupplierInfo;

        BL.Registrations.Suppliers SupplierBL = new BL.Registrations.Suppliers();


        frmManagePurchaseOrders frmManagePurchaseOrders;

        public frmSelectSupplier(frmManagePurchaseOrders FrmManagePurchaseOrders, EL.Registrations.Suppliers supplierInfo)
        {
            InitializeComponent();
            frmManagePurchaseOrders = FrmManagePurchaseOrders;
            SupplierInfo = supplierInfo;
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

        private void populateControls()
        {
            cbSupplierName.DisplayMember = "Supplier";
            cbSupplierName.ValueMember = "Supplier ID";
            cbSupplierName.DataSource = SupplierBL.List("");
        }

        private void frmSelectSupplier_Load(object sender, EventArgs e)
        {
            populateControls();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SupplierInfo.Supplierid = Convert.ToInt32(cbSupplierName.SelectedValue);
            SupplierInfo.Supplier = cbSupplierName.Text;

            

            frmManagePurchaseOrders.cbSupplierName.SelectedIndex = frmManagePurchaseOrders.cbSupplierName.FindString(cbSupplierName.Text);
            frmManagePurchaseOrders.manageForm(true);
            this.Close();
        }
    }
}
