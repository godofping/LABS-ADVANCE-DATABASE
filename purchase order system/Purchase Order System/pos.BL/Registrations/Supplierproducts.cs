using System.Data;
namespace pos.BL.Registrations
{
    public class Supplierproducts
    {
        DL.Registrations.Supplierproducts SupplierProductDL = new DL.Registrations.Supplierproducts();
        public DataTable List(string keywords)
        {
            return SupplierProductDL.List(keywords);
        }

        public long Insert(EL.Registrations.Supplierproducts supplierproduct)
        {
            return SupplierProductDL.Insert(supplierproduct);
        }

        public bool Update(EL.Registrations.Supplierproducts supplierproduct)
        {
            return SupplierProductDL.Update(supplierproduct);
        }

        public bool Delete(EL.Registrations.Supplierproducts supplierproduct)
        {
            return SupplierProductDL.Delete(supplierproduct);
        }
    }
}
