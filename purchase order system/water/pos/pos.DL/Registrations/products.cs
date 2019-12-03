using System;
using System.Data;  
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.DL.Registrations
{
    public class products
    {
        public DataTable List(string keywords)
        {
            string sQuery = "SELECT * FROM view_products WHERE `C` LIKE '%" + keywords + "%' ";

            return Helper.executeQuery(sQuery);
        }

        public DataTable Select(int id)
        {
            string sQuery = "SELECT * FROM view_products WHERE `PRODUCT ID` = '" + id + "'  ";

            return Helper.executeQuery(sQuery);
        }

        public long Insert(pos.EL.Registrations.products productEL)
        {
            return Helper.executeNonQueryLong("INSERT INTO products (productcode, productname, price, stock) VALUES ('" + productEL.Productcode + "', '" + productEL.Productname + "', '" + productEL.Price + "', '" + productEL.Stock + "')");
        }

        public bool Update(pos.EL.Registrations.products productEL)
        {
            return Helper.executeNonQueryBool("UPDATE products set productcode = '" + productEL.Productcode + "', productname = '" + productEL.Productname + "', price = '" + productEL.Price + "', stock = '" + productEL.Stock + "' WHERE productid = '" + productEL.Productid + "' ");
        }


        public bool Delete(pos.EL.Registrations.products productEL)
        {
            return Helper.executeNonQueryBool("DELETE FROM products WHERE productid = '" + productEL.Productid + "' ");
        }


    }
}
