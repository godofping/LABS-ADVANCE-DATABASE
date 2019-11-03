using System.Data;
namespace pos.DL.Registrations
{
    public class SupplierProducts
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from supplierproducts_view where  `Product Name` like '%" + keywords + "%' or `Product Description` like '%" + keywords + "%' or `Product SKU` like '%" + keywords + "%' or `Supplier` like '%" + keywords + "%'";
            return Helper.executeQuery(sQuery);
        }

        public DataTable List(int id, int id1)
        {
            string sQuery = "select * from supplierproducts_view where supplierid = " + id + " and subcategoryid = " + id1 + "";
            return Helper.executeQuery(sQuery);
        }

        public DataTable CheckIfExisting(EL.Registrations.SupplierProducts supplierProductEL)
        {
            string sQuery = "select * from supplierproducts_view where supplierid = " + supplierProductEL.Supplierid + " and productid = " + supplierProductEL.Productid + " ";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.SupplierProducts supplierProductEL)
        {
            return Helper.executeNonQueryLong("insert into supplierproducts (productid, supplierid) values ('" + supplierProductEL.Productid + "', '" + supplierProductEL.Supplierid + "')");
        }

        public bool Update(EL.Registrations.SupplierProducts supplierProductEL)
        {
            return Helper.executeNonQueryBool("update supplierproducts set productid = '" + supplierProductEL.Productid + "', supplierid = '" + supplierProductEL.Supplierid + "' where supplierproductid = '" + supplierProductEL.Supplierproductid + "'");
        }

        public bool Delete(EL.Registrations.SupplierProducts supplierProductEL)
        {
            return Helper.executeNonQueryBool("delete from supplierproducts where supplierproductid = '" + supplierProductEL.Supplierproductid + "' ");
        }
    }
}
