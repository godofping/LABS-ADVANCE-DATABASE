using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Homeaddressess
    {
        public EL.Registrations.Homeaddressess Select(EL.Registrations.Homeaddressess homeaddressEL)
        {
            DataTable dt = Helper.executeQuery("select * from homeaddressess where residentid = '" + homeaddressEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                homeaddressEL.Homeaddressid = Convert.ToInt32(dt.Rows[0]["homeaddressid"]);
                homeaddressEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                homeaddressEL.Purokid = Convert.ToInt32(dt.Rows[0]["purokid"]);
                homeaddressEL.Housenumber = dt.Rows[0]["housenumber"].ToString();
                homeaddressEL.Street = dt.Rows[0]["street"].ToString();
                homeaddressEL.Subdivision = dt.Rows[0]["subdivision"].ToString();

                return homeaddressEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Homeaddressess homeaddressEL)
        {
            return Helper.executeNonQueryLong("insert into homeaddressess (residentid, purokid, housenumber, street, subdivision) values ('" + homeaddressEL.Residentid + "', '" + homeaddressEL.Purokid + "', '" + homeaddressEL.Housenumber + "', '" + homeaddressEL.Street + "', '" + homeaddressEL.Subdivision + "')");
        }

        public Boolean Update(EL.Registrations.Homeaddressess homeaddressEL)
        {
            return Helper.executeNonQueryBool("update homeaddressess set purokid = '" + homeaddressEL.Purokid + "', housenumber = '" + homeaddressEL.Housenumber + "', street = '" + homeaddressEL.Street + "', subdivision = '" + homeaddressEL.Subdivision + "' where residentid = '" + homeaddressEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Homeaddressess homeaddressEL)
        {
            return Helper.executeNonQueryBool("delete from homeaddressess where residentid = '" + homeaddressEL.Residentid + "'");
        }
    }
}
