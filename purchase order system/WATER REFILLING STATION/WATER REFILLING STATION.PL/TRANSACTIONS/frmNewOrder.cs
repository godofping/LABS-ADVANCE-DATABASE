using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.TRANSACTIONS
{
    public partial class frmNewOrder : Form
    {
        EL.REGISTRATIONS.productcategories productcategoryEL = new EL.REGISTRATIONS.productcategories();

        BL.REGISTRATIONS.productcategories productcategoryBL = new BL.REGISTRATIONS.productcategories();

        public frmNewOrder()
        {
            InitializeComponent();
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbCategoryType, productcategoryBL.List(), "PRODUCT CATEGORY", "PRODUCT CATEGORY ID");
        }

        private void frmNewOrder_Load(object sender, EventArgs e)
        {
            PopulateCB();
        }
    }
}
