using System;
using System.Collections.Generic;
using System.Text;

namespace pos.DL.Registrations
{
    public class Basicinformations
    {
        public long Insert(EL.Registrations.Basicinformations basicinformation)
        {
            return Helper.executeNonQuery("insert into basicinformations (firstname, middlename, lastname, gender, birthdate) values ('" + basicinformation.Firstname + "', '" + basicinformation.Middlename + "', '" + basicinformation.Lastname + "', '" + basicinformation.Gender + "', '" + basicinformation.Birthdate + "')");
        }
    }
}
