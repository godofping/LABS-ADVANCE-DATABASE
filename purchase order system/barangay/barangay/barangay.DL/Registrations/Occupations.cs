using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Occupations
    {
        public DataTable List()
        {
            return Helper.executeQuery("select * from occupations");
        }

        public EL.Registrations.Occupations Select(EL.Registrations.Occupations occupationEL)
        {
            DataTable dt = Helper.executeQuery("select * from occupations where occupationid = '" + occupationEL.Occupationid + "'");

            if (dt.Rows.Count > 0)
            {
                occupationEL.Occupationid = Convert.ToInt32(dt.Rows[0]["occupationid"]);
                occupationEL.Occupation = dt.Rows[0]["occupation"].ToString();

                return occupationEL;
            }
            else
            {
                return null;
            }
        }
    }
}
