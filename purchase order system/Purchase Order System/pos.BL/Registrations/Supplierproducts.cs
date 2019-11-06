using System.Data;
namespace pos.BL.Registrations
{
    public class SupplierProducts
    {
        DL.Registrations.SupplierProducts SupplierProductDL = new DL.Registrations.SupplierProducts();
        public DataTable List(string keywords)
        {
            return SupplierProductDL.List(keywords);
        }

        public DataTable List(int id, int id1)
        {
            return SupplierProductDL.List(id, id1);
        }

        public DataTable List(int id)
        {
            return SupplierProductDL.List(id);
        }

        public DataTable Lists(int id, int id1)
        {
            return SupplierProductDL.Lists(id, id1);
        }
        
        public DataTable CheckIfExisting(EL.Registrations.SupplierProducts supplierProductEL)
        {
            return SupplierProductDL.CheckIfExisting(supplierProductEL);
        }

        public long Insert(EL.Registrations.SupplierProducts supplierProductEL)
        {
            return SupplierProductDL.Insert(supplierProductEL);
        }

        public bool Update(EL.Registrations.SupplierProducts supplierProductEL)
        {
            return SupplierProductDL.Update(supplierProductEL);
        }

        public bool Delete(EL.Registrations.SupplierProducts supplierProductEL)
        {
            return SupplierProductDL.Delete(supplierProductEL);
        }
    }
}
