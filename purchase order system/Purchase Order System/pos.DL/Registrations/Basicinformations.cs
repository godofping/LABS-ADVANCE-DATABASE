using System;
using System.Collections.Generic;
using System.Text;

namespace pos.DL.Registrations
{
    public class BasicInformations
    {
        public long Insert(EL.Registrations.BasicInformations basicInformationEL)
        {
            return Helper.executeNonQueryLong("insert into basicinformations (firstname, middlename, lastname, gender, birthdate) values ('" + basicInformationEL.Firstname + "', '" + basicInformationEL.Middlename + "', '" + basicInformationEL.Lastname + "', '" + basicInformationEL.Gender + "', '" + basicInformationEL.Birthdate + "')");
        }

        public bool Update(EL.Registrations.BasicInformations basicInformationEL)
        {
            return Helper.executeNonQueryBool("update basicinformations set firstname = '" + basicInformationEL.Firstname + "', middlename = '" + basicInformationEL.Middlename + "', lastname = '" + basicInformationEL.Lastname + "', gender = '" + basicInformationEL.Gender + "', birthdate = '" + basicInformationEL.Birthdate + "' where basicinformationid = '" + basicInformationEL.Basicinformationid + "'");
        }
    }
}
