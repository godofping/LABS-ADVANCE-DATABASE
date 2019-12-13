using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.DL.Registrations
{
    public class customers
    {
        public DataTable List(string keywords)
        {
            keywords = MySql.Data.MySqlClient.MySqlHelper.EscapeString(keywords);
            return Helper.executeQuery("select * from customers_view where c like '%" + keywords + "%'");
        }

        public EL.Registrations.customers Select(EL.Registrations.customers customerEL)
        {
            var dt = Helper.executeQuery("select * from customers where customerid = '" + customerEL.Customerid + "'");

            if (dt.Rows.Count > 0)
            {
                customerEL.Customerid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                customerEL.Fullname = dt.Rows[0]["fullname"].ToString();
                customerEL.Contactnumber = dt.Rows[0]["contactnumber"].ToString();
                return customerEL;
            }
            else
            {
                return null;
            }

        }

        public long Insert(EL.Registrations.customers customerEL)
        {
            customerEL.Fullname = MySql.Data.MySqlClient.MySqlHelper.EscapeString(customerEL.Fullname);
            customerEL.Fullname = MySql.Data.MySqlClient.MySqlHelper.EscapeString(customerEL.Fullname);
            return Helper.executeNonQueryLong("insert into customers (fullname, contactnumber) values ('" + customerEL.Fullname + "', '" + customerEL.Contactnumber + "')");
        }

        public bool Update(EL.Registrations.customers customerEL)
        {
            customerEL.Fullname = MySql.Data.MySqlClient.MySqlHelper.EscapeString(customerEL.Fullname);
            customerEL.Fullname = MySql.Data.MySqlClient.MySqlHelper.EscapeString(customerEL.Fullname);
            return Helper.executeNonQueryBool("update customers set fullname = '" + customerEL.Fullname + "', contactnumber = '" + customerEL.Contactnumber + "' where customerid = '" + customerEL.Customerid + "'");
        }

        public bool Delete(EL.Registrations.customers customerEL)
        {
            return Helper.executeNonQueryBool("delete from customers where customerid = '" + customerEL.Customerid + "'");
        }
    }
}
