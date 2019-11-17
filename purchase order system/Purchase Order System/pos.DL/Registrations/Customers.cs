using System.Data;

namespace pos.DL.Registrations
{
    public class Customers
    {

        public DataTable List(string keywords)
        {
            string sQuery = "select * from customers_view where  `First Name` like '%" + keywords + "%' or `Middle Name` like '%" + keywords + "%' or `Last Name` like '%" + keywords + "%' or `Gender` like '%" + keywords + "%' or `Birth Date` like '%" + keywords + "%' or `Contact Number` like '%" + keywords + "%' or `Email Address` like '%" + keywords + "%' or `Address` like '%" + keywords + "%' or `City` like '%" + keywords + "%' or `Province` like '%" + keywords + "%' or `Zip Code` like '%" + keywords + "%' ";
           
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Customers customerEL)
        {
            return Helper.executeNonQueryLong("insert into customers (contactdetailid, basicinformationid) values ('" + customerEL.Contactdetailid + "', '" + customerEL.Basicinformationid + "')");
        }

        public bool Delete(EL.Registrations.Customers customerEL)
        {
            return Helper.executeNonQueryBool("delete from customers where customerid = '" + customerEL.Customerid + "' ");
        }

    }
}
