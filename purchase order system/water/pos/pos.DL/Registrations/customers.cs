using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pos.EL;

namespace pos.DL.Registrations
{
    public class customers
    {

        public System.Data.DataTable List(string keywords)
        {
            string sQuery = "SELECT * FROM view_customers WHERE `C` LIKE '%" + keywords + "%' ";

            return Helper.executeQuery(sQuery);
        }


        public long Insert(pos.EL.Registrations.customers customerEL)
        {
            return Helper.executeNonQueryLong("INSERT INTO customers (firstname, middlename, lastname, contactnumber, address) VALUES ('" + customerEL.Firstname + "', '" + customerEL.Middlename + "', '" + customerEL.Lastname + "', '" + customerEL.Contactnumber + "', '" + customerEL.Address + "')");
        }

        public bool Update(pos.EL.Registrations.customers customerEL)
        {
            return Helper.executeNonQueryBool("UPDATE customers set firstname = '" + customerEL.Firstname + "', middlename = '" + customerEL.Middlename + "', lastname = '" + customerEL.Lastname + "', contactnumber = '" + customerEL.Contactnumber + "', address = '" + customerEL.Address + "' WHERE customerid = '" + customerEL.Customerid + "' ");
        }


        public bool Delete(pos.EL.Registrations.customers customerEL)
        {
            return Helper.executeNonQueryBool("DELETE FROM customers WHERE customerid = '" + customerEL.Customerid + "' ");
        }
    }
}
