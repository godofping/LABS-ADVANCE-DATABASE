using System;
using System.Collections.Generic;
using System.Text;

namespace pos.DL.Registrations
{
    public class Customers
    {
        public Boolean Insert(pos.EL.Registrations.Customers cus)
        {
            return Helper.executeNonQuery("insert into customers (lastname, firstname, middleinitial, age, address, tribe) values ('" + cus.Lastname + "', '" + cus.Firstname + "', '" + cus.Middleinitial + "', '" + cus.Age + "', '" + cus.Address + "', '" + cus.Tribe  + "')");
        }
    }
}
