using System.Data;

namespace pos.BL.Registrations
{
    public class Suppliers
    {
        DL.Registrations.Suppliers supplierDL = new DL.Registrations.Suppliers();
        public DataTable List(string keywords)
        {
            return supplierDL.List(keywords);
        }

        public long Insert(EL.Registrations.Suppliers supplierEL)
        {
            return supplierDL.Insert(supplierEL);
        }
        public bool Update(EL.Registrations.Suppliers supplierEL)
        {
            return supplierDL.Update(supplierEL);
        }

        public bool Delete(EL.Registrations.Suppliers supplierEL)
        {
            return supplierDL.Delete(supplierEL);
        }

    }
}
