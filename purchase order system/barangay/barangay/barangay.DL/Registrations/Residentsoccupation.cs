using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Residentsoccupation
    {
        public EL.Registrations.Residentsoccupation Select(EL.Registrations.Residentsoccupation residentoccupationEL)
        {
            DataTable dt = Helper.executeQuery("select * from residentsoccupation where residentid = '" + residentoccupationEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                residentoccupationEL.Residentoccupationid = Convert.ToInt32(dt.Rows[0]["residentoccupationid"]);
                residentoccupationEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                residentoccupationEL.Occupationid = Convert.ToInt32(dt.Rows[0]["occupationid"]);

                return residentoccupationEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Residentsoccupation residentoccupationEL)
        {
            return Helper.executeNonQueryLong("insert into residentsoccupation (residentid, occupationid) values ('" + residentoccupationEL.Residentid + "', '" + residentoccupationEL.Occupationid + "')");
        }

        public Boolean Update(EL.Registrations.Residentsoccupation residentoccupationEL)
        {
            return Helper.executeNonQueryBool("update residentsoccupation set occupationid = '" + residentoccupationEL.Occupationid + "' where residentid = '" + residentoccupationEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Residentsoccupation residentoccupationEL)
        {
            return Helper.executeNonQueryBool("delete from residentsoccupation where residentid = '" + residentoccupationEL.Residentid + "'");
        }
    }
}
