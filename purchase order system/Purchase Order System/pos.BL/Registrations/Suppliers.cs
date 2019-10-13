using System.Data;

namespace pos.BL.Registrations
{
    public class Vendors
    {
        DL.Registrations.Vendors VendorDL = new DL.Registrations.Vendors();
        public DataTable List(string keywords)
        {
            return VendorDL.List(keywords);
        }

        public long Insert(EL.Registrations.Vendors vendor)
        {
            return VendorDL.Insert(vendor);
        }
        public bool Update(EL.Registrations.Vendors vendor)
        {
            return VendorDL.Update(vendor);
        }

        public bool Delete(EL.Registrations.Vendors vendor)
        {
            return VendorDL.Delete(vendor);
        }

    }
}
