using System;
using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class customers
    {
        public DataTable List(string keywords)
        {
            string sQuery = "SELECT * FROM view_customers WHERE `LAST NAME` like '%" + keywords + "%' OR `FIRST NAME` LIKE '%" + keywords + "%' OR `FIRST NAME` LIKE '%" + keywords + "%' OR `MIDDLE INITIAL` LIKE '%" + keywords + "%' OR `BIRTH DATE` LIKE '%" + keywords + "%' OR `ADDRESS` LIKE '%" + keywords + "%' OR `CONTACT NUMBER` LIKE '%" + keywords + "%' OR `EMAIL ADDRESS` LIKE '%" + keywords + "%'  OR `DATE REGISTERED` LIKE '%" + keywords + "%' ";

            return Helper.executeQuery(sQuery);
        }


        public long Insert(EL.REGISTRATIONS.customers customerEL)
        {
            return Helper.executeNonQueryLong("INSERT INTO customers (basicinformationid, dateregistered) VALUES ('" + customerEL.Basicinformationid + "', '" + DateTime.Now.ToString("yy-MM-dd") + "')");
        }


        public bool Delete(EL.REGISTRATIONS.customers customerEL)
        {
            return Helper.executeNonQueryBool("DELETE FROM customers WHERE customerid = '" + customerEL.Customerid + "' ");
        }

    }
}
