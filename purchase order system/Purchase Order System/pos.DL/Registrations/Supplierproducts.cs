using System.Data;
namespace pos.DL.Registrations
{
    public class Supplierproducts
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from supplierproducts_view where  `Product Name` like '%" + keywords + "%' or `Product Description` like '%" + keywords + "%' or `Product SKU` like '%" + keywords + "%' or `Supplier` like '%" + keywords + "%'";
            return Helper.executeQuery(sQuery);
        }

        public DataTable CheckIfExisting(EL.Registrations.Supplierproducts supplierproduct)
        {
            string sQuery = "select * from supplierproducts_view where supplierid = " + supplierproduct.Supplierid + " and productid = " + supplierproduct.Productid + " ";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Supplierproducts supplierproduct)
        {
            return Helper.executeNonQueryLong("insert into supplierproducts (productid, supplierid) values ('" + supplierproduct.Productid + "', '" + supplierproduct.Supplierid + "')");
        }

        public bool Update(EL.Registrations.Supplierproducts supplierproduct)
        {
            return Helper.executeNonQueryBool("update supplierproducts set productid = '" + supplierproduct.Productid + "', supplierid = '" + supplierproduct.Supplierid + "' where supplierproductid = '" + supplierproduct.Supplierproductid + "'");
        }

        public bool Delete(EL.Registrations.Supplierproducts supplierproduct)
        {
            return Helper.executeNonQueryBool("delete from supplierproducts where supplierproductid = '" + supplierproduct.Supplierproductid + "' ");
        }
    }
}
