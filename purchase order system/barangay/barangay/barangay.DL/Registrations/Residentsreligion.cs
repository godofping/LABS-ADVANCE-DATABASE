using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Residentsreligion
    {
        public EL.Registrations.Residentsreligion Select(EL.Registrations.Residentsreligion residentreligionEL)
        {
            DataTable dt = Helper.executeQuery("select * from residentsreligion where residentid = '" + residentreligionEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                residentreligionEL.Residentreligionid = Convert.ToInt32(dt.Rows[0]["residentreligionid"]);
                residentreligionEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                residentreligionEL.Religionid = Convert.ToInt32(dt.Rows[0]["religionid"]);

                return residentreligionEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Residentsreligion residentreligionEL)
        {
            return Helper.executeNonQueryLong("insert into residentsreligion (residentid, religionid) values ('" + residentreligionEL.Residentid + "', '" + residentreligionEL.Religionid + "')");
        }

        public Boolean Update(EL.Registrations.Residentsreligion residentreligionEL)
        {
            return Helper.executeNonQueryBool("update residentsreligion set religionid = '" + residentreligionEL.Religionid + "' where residentid = '" + residentreligionEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Residentsreligion residentreligionEL)
        {
            return Helper.executeNonQueryBool("delete from residentsreligion where residentid = '" + residentreligionEL.Residentid + "'");
        }
    }
}
