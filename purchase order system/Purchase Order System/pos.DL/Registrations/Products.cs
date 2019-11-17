using System.Data;
namespace pos.DL.Registrations
{
    public class Products
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from products_view where `Product Name` like '%" + keywords + "%' or `Product Description` like '%" + keywords + "%' or `Product SKU` like '%" + keywords + "%' or `Product Price` like '%" + keywords + "%' or `Sub Category Name` like '%" + keywords + "%' or `Category Name` like '%" + keywords + "%'";
            return Helper.executeQuery(sQuery);
        }

        public DataTable List(int id)
        {
            string sQuery = "select * from products_view where `Product ID` = " + id + "";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Products productEL)
        {
            return Helper.executeNonQueryLong("insert into products (productname, productdescription, subcategoryid, productsku, productprice) values ('" + productEL.Productname + "', '" + productEL.Productdescription + "', '" + productEL.Subcategoryid + "', '" + productEL.Productsku + "', '" + productEL.Productprice + "')");
        }

        public bool Update(EL.Registrations.Products productEL)
        {
            return Helper.executeNonQueryBool("update products set productname = '" + productEL.Productname + "', productdescription = '" + productEL.Productdescription + "', subcategoryid = '" + productEL.Subcategoryid + "', productsku = '" + productEL.Productsku + "', productprice = '" + productEL.Productprice + "' where productid = '" + productEL.Productid + "' ");
        }

        public bool Delete(EL.Registrations.Products productEL)
        {
            return Helper.executeNonQueryBool("delete from products where productid = '" + productEL.Productid + "' ");
        }
    }
}
