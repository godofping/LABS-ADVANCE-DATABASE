using System.Data;

namespace pos.BL.Registrations
{
    public class Suppliers
    {
        DL.Registrations.Suppliers VendorDL = new DL.Registrations.Suppliers();
        public DataTable List(string keywords)
        {
            return VendorDL.List(keywords);
        }

        public long Insert(EL.Registrations.Suppliers vendor)
        {
            return VendorDL.Insert(vendor);
        }
        public bool Update(EL.Registrations.Suppliers vendor)
        {
            return VendorDL.Update(vendor);
        }

        public bool Delete(EL.Registrations.Suppliers vendor)
        {
            return VendorDL.Delete(vendor);
        }

    }
}
