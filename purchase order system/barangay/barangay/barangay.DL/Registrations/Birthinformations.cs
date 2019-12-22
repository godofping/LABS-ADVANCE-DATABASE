using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Birthinformations
    {
        public EL.Registrations.Birthinformations Select(EL.Registrations.Birthinformations birthinformationEL)
        {
            DataTable dt = Helper.executeQuery("select * from birthinformations where residentid = '" + birthinformationEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                birthinformationEL.Birthinformationid = Convert.ToInt32(dt.Rows[0]["birthinformationid"]);
                birthinformationEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                birthinformationEL.Birthplace = dt.Rows[0]["birthplace"].ToString();
                birthinformationEL.Birthdate = dt.Rows[0]["birthdate"].ToString();

                return birthinformationEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Birthinformations birthinformationEL)
        {
            return Helper.executeNonQueryLong("insert into birthinformations (residentid, birthplace, birthdate) values ('" + birthinformationEL.Residentid + "', '" + birthinformationEL.Birthplace + "', '" + birthinformationEL.Birthdate + "')");
        }

        public Boolean Update(EL.Registrations.Birthinformations birthinformationEL)
        {
            return Helper.executeNonQueryBool("update birthinformations set birthplace = '" + birthinformationEL.Birthplace + "', birthdate = '" + birthinformationEL.Birthdate + "' where residentid = '" + birthinformationEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Birthinformations birthinformationEL)
        {
            return Helper.executeNonQueryBool("delete from birthinformations where residentid = '" + birthinformationEL.Residentid + "'");
        }

    }
}
