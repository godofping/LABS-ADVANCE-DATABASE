using System;

namespace pos.DL.Registrations
{
    public class Customers
    {
        public Boolean Insert(pos.EL.Registrations.Customers cus)
        {
            
            return Helper.executeNonQuery("insert into customers (lastname, firstname, middleinitial, age, address, tribe) values ('" + cus.Lastname + "', '" + cus.Firstname + "', '" + cus.Middleinitial + "', '" + cus.Age + "', '" + cus.Address + "', '" + cus.Tribe + "')");
        }

        public Boolean Update(pos.EL.Registrations.Customers cus)
        {
            return Helper.executeNonQuery("update customers set lastname = '" + cus.Lastname + "',firstname = '" + cus.Firstname + "', middleinitial = '" + cus.Middleinitial + "', age = '" + cus.Age + "', address = '" + cus.Address + "', tribe = '" + cus.Tribe + "' where customerid = '" + cus.Customerid + "'");
        }

        public Boolean Delete(pos.EL.Registrations.Customers cus)
        {
            return Helper.executeNonQuery("delete from customers where customerid = '" + cus.Customerid + "'");
        }
    }
}
