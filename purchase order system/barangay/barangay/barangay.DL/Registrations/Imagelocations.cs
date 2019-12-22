using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Imagelocations
    {
        public EL.Registrations.Imagelocations Select(EL.Registrations.Imagelocations imagelocationEL)
        {
            DataTable dt = Helper.executeQuery("select * from homeaddressess where residentid = '" + imagelocationEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                imagelocationEL.Imagelocationid = Convert.ToInt32(dt.Rows[0]["imagelocationid"]);
                imagelocationEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                imagelocationEL.Imagelocation = dt.Rows[0]["imagelocation"].ToString();

                return imagelocationEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Imagelocations imagelocationEL)
        {
            return Helper.executeNonQueryLong("insert into imagelocations (residentid, imagelocation) values ('" + imagelocationEL.Residentid + "', '" + imagelocationEL.Imagelocation + "')");
        }

        public Boolean Update(EL.Registrations.Imagelocations imagelocationEL)
        {
            return Helper.executeNonQueryBool("update imagelocations set imagelocation = '" + imagelocationEL.Imagelocation + "' where residentid = '" + imagelocationEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Imagelocations imagelocationEL)
        {
            return Helper.executeNonQueryBool("delete from imagelocations where residentid = '" + imagelocationEL.Residentid + "'");
        }
    }
}
