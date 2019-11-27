using System;
using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class basicinformations
    {

        public long Insert(EL.REGISTRATIONS.basicinformations basicinformationEL)
        {
            return Helper.executeNonQueryLong("INSERT INTO basicinformations (lastname, firstname, middleinitial, birthdate, address, contactnumber, emailaddress) VALUES ('" + basicinformationEL.Lastname + "', '" + basicinformationEL.Firstname + "', '" + basicinformationEL.Middleinitial + "', '" + basicinformationEL.Birthdate + "', '" + basicinformationEL.Address + "', '" + basicinformationEL.Contactnumber + "', '" + basicinformationEL.Emailaddress + "')");
        }

        public bool Update(EL.REGISTRATIONS.basicinformations basicinformationEL)
        {
            return Helper.executeNonQueryBool("UPDATE basicinformations SET lastname = '" + basicinformationEL.Lastname + "', firstname = '" + basicinformationEL.Firstname + "', middleinitial = '" + basicinformationEL.Middleinitial + "', birthdate = '" + basicinformationEL.Birthdate + "', address = '" + basicinformationEL.Address + "', contactnumber = '" + basicinformationEL.Contactnumber + "', emailaddress = '" + basicinformationEL.Emailaddress + "' WHERE basicinformationid = '" + basicinformationEL.Basicinformationid + "'");
        }

    }
}
