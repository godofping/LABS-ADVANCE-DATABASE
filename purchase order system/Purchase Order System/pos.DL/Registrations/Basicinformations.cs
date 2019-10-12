using System;
using System.Collections.Generic;
using System.Text;

namespace pos.DL.Registrations
{
    public class Basicinformations
    {
        public long Insert(EL.Registrations.Basicinformations basicinformation)
        {
            return Helper.executeNonQueryLong("insert into basicinformations (firstname, middlename, lastname, gender, birthdate) values ('" + basicinformation.Firstname + "', '" + basicinformation.Middlename + "', '" + basicinformation.Lastname + "', '" + basicinformation.Gender + "', '" + basicinformation.Birthdate + "')");
        }

        public bool Update(EL.Registrations.Basicinformations basicinformation)
        {
            return Helper.executeNonQueryBool("update basicinformations set firstname = '" + basicinformation.Firstname + "', middlename = '" + basicinformation.Middlename + "', lastname = '" + basicinformation.Lastname + "', gender = '" + basicinformation.Gender + "', birthdate = '" + basicinformation.Birthdate + "' where basicinformationid = '" + basicinformation.Basicinformationid + "'");
        }
    }
}
