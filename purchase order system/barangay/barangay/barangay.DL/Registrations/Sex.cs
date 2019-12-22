using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Sex
    {
        public DataTable List()
        {
            return Helper.executeQuery("select * from sex");
        }

        public EL.Registrations.Sex Select(EL.Registrations.Sex sexEL)
        {
            DataTable dt = Helper.executeQuery("select * from sex where sexid = '" + sexEL.Sexid + "'");

            if (dt.Rows.Count > 0)
            {
                sexEL.Sexid = Convert.ToInt32(dt.Rows[0]["sexid"]);
                sexEL.Sex = dt.Rows[0]["sex"].ToString();

                return sexEL;
            }
            else
            {
                return null;
            }
        }
    }
}
