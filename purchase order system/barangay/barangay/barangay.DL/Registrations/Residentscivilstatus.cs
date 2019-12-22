using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Residentscivilstatus
    {
        public EL.Registrations.Residentscivilstatus Select(EL.Registrations.Residentscivilstatus residentcivilstatusEL)
        {
            DataTable dt = Helper.executeQuery("select * from residentscivilstatus where residentid = '" + residentcivilstatusEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                residentcivilstatusEL.Residentcivilstatusid = Convert.ToInt32(dt.Rows[0]["residentcivilstatusid"]);
                residentcivilstatusEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                residentcivilstatusEL.Civilstatusid = Convert.ToInt32(dt.Rows[0]["civilstatusid"]);

                return residentcivilstatusEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Residentscivilstatus residentcivilstatusEL)
        {
            return Helper.executeNonQueryLong("insert into residentscivilstatus (residentid, civilstatusid) values ('" + residentcivilstatusEL.Residentid + "', '" + residentcivilstatusEL.Civilstatusid + "')");
        }

        public Boolean Update(EL.Registrations.Residentscivilstatus residentcivilstatusEL)
        {
            return Helper.executeNonQueryBool("update residentscivilstatus set civilstatusid = '" + residentcivilstatusEL.Civilstatusid + "' where residentid = '" + residentcivilstatusEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Residentscivilstatus residentcivilstatusEL)
        {
            return Helper.executeNonQueryBool("delete from residentscivilstatus where residentid = '" + residentcivilstatusEL.Residentid + "'");
        }
    }
}
