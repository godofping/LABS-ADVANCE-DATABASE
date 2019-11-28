using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class products
    {
        public DataTable List(string keywords)
        {
            string sQuery = "SELECT * FROM view_products WHERE `PRICE` LIKE '%" + keywords + "%' OR `PARTICULAR` LIKE '%" + keywords + "%' OR `CONTAINER TYPE` LIKE '%" + keywords + "%' OR `PRODUCT CATEGORY` LIKE '%" + keywords + "%'";
            return Helper.executeQuery(sQuery);
        }

        public DataTable IsExisting(EL.REGISTRATIONS.products productEL)
        {
            string sQuery = "SELECT * FROM products WHERE  productcategoryid = '" + productEL.Productcategoryid + "' AND particularid = '" + productEL.Particularid + "' AND containertypeid = '" + productEL.Containertypeid + "' AND price = '" + productEL.Price + "' AND productid <> " + productEL.Productid + " ";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.REGISTRATIONS.products productEL)
        {
            return Helper.executeNonQueryLong("INSERT INTO products (productcategoryid, particularid, containertypeid, price) VALUES ('" + productEL.Productcategoryid + "', " + productEL.Particularid + ", " + productEL.Containertypeid + ", '" + productEL.Price + "')");
        }

        public bool Update(EL.REGISTRATIONS.products productEL)
        {
            return Helper.executeNonQueryBool("UPDATE products SET productcategoryid = '" + productEL.Productcategoryid + "', particularid = '" + productEL.Particularid + "', containertypeid = '" + productEL.Containertypeid + "', price = '" + productEL.Price + "' where productid = '" + productEL.Productid + "'");
        }


        public bool Delete(EL.REGISTRATIONS.products productEL)
        {
            return Helper.executeNonQueryBool("DELETE FROM products WHERE productid = '" + productEL.Productid + "' ");
        }
    }
}
