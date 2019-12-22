using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Religions
    {
        public DataTable List()
        {
            return Helper.executeQuery("select * from religions");
        }

        public EL.Registrations.Religions Select(EL.Registrations.Religions religionEL)
        {
            DataTable dt = Helper.executeQuery("select * from religions where religionid = '" + religionEL.Religionid + "'");

            if (dt.Rows.Count > 0)
            {
                religionEL.Religionid = Convert.ToInt32(dt.Rows[0]["religionid"]);
                religionEL.Religion = dt.Rows[0]["religion"].ToString();

                return religionEL;
            }
            else
            {
                return null;
            }
        }
    }
}
