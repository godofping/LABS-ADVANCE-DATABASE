using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.DL.Registrations
{
    public class products
    {
        public DataTable List(string keywords)
        {
            keywords = MySql.Data.MySqlClient.MySqlHelper.EscapeString(keywords);
            return Helper.executeQuery("select * from products_view where c like '%" + keywords + "%'");
        }

        public EL.Registrations.products Select(EL.Registrations.products productEL)
        {
            var dt = Helper.executeQuery("select * from products where productid = '" + productEL.Productid + "'");

            if (dt.Rows.Count > 0)
            {
                productEL.Productid = Convert.ToInt32(dt.Rows[0]["productid"].ToString());
                productEL.Categoryid = Convert.ToInt32(dt.Rows[0]["categoryid"].ToString());
                productEL.Productname = dt.Rows[0]["productname"].ToString();
                productEL.Description = dt.Rows[0]["description"].ToString();
                productEL.Price = Convert.ToSingle(dt.Rows[0]["price"].ToString());
                productEL.Stocks = Convert.ToInt32(dt.Rows[0]["stocks"].ToString());
                return productEL;
            }
            else
            {
                return null;
            }

        }

        public long Insert(EL.Registrations.products productEL)
        {
            productEL.Productname = MySql.Data.MySqlClient.MySqlHelper.EscapeString(productEL.Productname);
            productEL.Description = MySql.Data.MySqlClient.MySqlHelper.EscapeString(productEL.Description);
            return Helper.executeNonQueryLong("insert into products (categoryid, productname, description, price, stocks) values ('" + productEL.Categoryid + "', '" + productEL.Productname + "', '" + productEL.Description + "', '" + productEL.Price + "', '" + productEL.Stocks + "')");
        }

        public bool Update(EL.Registrations.products productEL)
        {
            productEL.Productname = MySql.Data.MySqlClient.MySqlHelper.EscapeString(productEL.Productname);
            productEL.Description = MySql.Data.MySqlClient.MySqlHelper.EscapeString(productEL.Description);
            return Helper.executeNonQueryBool("update products set categoryid = '" + productEL.Categoryid + "', productname = '" + productEL.Productname + "', description = '" + productEL.Description + "', price = '" + productEL.Price + "', stocks = '" + productEL.Stocks + "' where productid = '" + productEL.Productid + "'");
        }

        public bool Delete(EL.Registrations.products productEL)
        {
            return Helper.executeNonQueryBool("delete from products where productid = '" + productEL.Productid + "'");
        }
    }
}
