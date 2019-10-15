using System.Data;
namespace pos.DL.Registrations
{
    public class Products
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from products_view where `Product ID` like '%" + keywords + "%' or `Product Name` like '%" + keywords + "%' or `Product Description` like '%" + keywords + "%' or `Product SKU` like '%" + keywords + "%' or `Product SKU` like '%" + keywords + "%' or `Product Price` like '%" + keywords + "%' or `Sub Category Name` like '%" + keywords + "%' or `Category Name` like '%" + keywords + "%'";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Products product)
        {
            return Helper.executeNonQueryLong("insert into products (productname, productdescription, subcategoryid, productsku, productprice) values ('" + product.Productname + "', '" + product.Productdescription + "', '" + product.Subcategoryid + "', '" + product.Productsku + "', '" + product.Productprice + "')");
        }

        public bool Update(EL.Registrations.Products product)
        {
            return Helper.executeNonQueryBool("update products set productname = '" + product.Productname + "', productdescription = '" + product.Productdescription + "', subcategoryid = '" + product.Subcategoryid + "', productsku = '" + product.Productsku + "', productprice = '" + product.Productprice + "' where productid = '" + product.Productid + "' ");
        }

        public bool Delete(EL.Registrations.Products product)
        {
            return Helper.executeNonQueryBool("update products set isdeleted = 1 where productid = '" + product.Productid + "' ");
        }
    }
}
