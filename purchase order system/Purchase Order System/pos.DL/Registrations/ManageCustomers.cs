using System;
using System.Data;

namespace pos.DL.Registrations
{
    public class ManageCustomers
    {

        public DataTable List()
        {
            String sQuery = "select * from customers_view";
           
            return Helper.executeQuery(sQuery);
        }

        public DataTable GetGenders()
        {
            String sQuery = "select * from genders_view";

            return Helper.executeQuery(sQuery);
        }

    }
}
