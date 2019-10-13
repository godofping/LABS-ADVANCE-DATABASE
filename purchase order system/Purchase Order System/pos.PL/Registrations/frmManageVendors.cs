using System.Windows.Forms;

namespace pos.PL.Registrations
{
    public partial class frmManageVendors : Form
    {
        EL.Registrations.Vendors VendorInfo = new EL.Registrations.Vendors();
        EL.Registrations.Contactdetails ContactDetailInfo = new EL.Registrations.Contactdetails();
        EL.Registrations.Vendorcategories VendorCategoryInfo = new EL.Registrations.Vendorcategories();
        EL.Registrations.Addresses AddressInfo = new EL.Registrations.Addresses();

        BL.Registrations.Vendors VendorBL = new BL.Registrations.Vendors();
        BL.Registrations.Contactdetails ContacDetailBL = new BL.Registrations.Contactdetails();
        BL.Registrations.Vendorcategories VendorCategoryBL = new BL.Registrations.Vendorcategories();
        BL.Registrations.Addresses AddressBL = new BL.Registrations.Addresses();

        string current = "";

        public frmManageVendors()
        {
            InitializeComponent();
        }



    }
}
