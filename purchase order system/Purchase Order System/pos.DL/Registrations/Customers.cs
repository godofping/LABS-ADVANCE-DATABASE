using System;
using System.Data;

namespace pos.DL.Registrations
{
    public class Customers
    {

        public DataTable List(string keywords)
        {
            String sQuery = "select * from customers_view where `Customer ID` like '%" + keywords + "%' or `First Name` like '%" + keywords + "%' or `Middle Name` like '%" + keywords + "%' or `Last Name` like '%" + keywords + "%' or `Gender` like '%" + keywords + "%' or `Birth Date` like '%" + keywords + "%' or `Contact Number` like '%" + keywords + "%' or `Email Address` like '%" + keywords + "%' or `Address` like '%" + keywords + "%' or `City` like '%" + keywords + "%' or `Province` like '%" + keywords + "%' or `Zip Code` like '%" + keywords + "%' ";
           
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Customers customer)
        {
            return Helper.executeNonQueryLong("insert into customers (contactdetailid, basicinformationid) values ('" + customer.Contactdetailid + "', '" + customer.Basicinformationid + "')");
        }

        public bool Delete(EL.Registrations.Customers customer)
        {
            return Helper.executeNonQueryBool("update customers set isdeleted = 1 where customerid = '" + customer.Customerid + "' ");
        }

    }
}
