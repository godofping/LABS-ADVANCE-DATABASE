using System;
using System.Data;

namespace pos.DL.Registrations
{
    public class Customers
    {

        public DataTable List()
        {
            String sQuery = "select * from customers_view";
           
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Customers customer)
        {
            return Helper.executeNonQuery("insert into customers (contactdetailid, basicinformationid) values ('" + customer.Contactdetailid + "', '" + customer.Basicinformationid + "')");
        }

    }
}
