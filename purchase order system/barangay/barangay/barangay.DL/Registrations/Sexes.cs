using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Sexes
    {
        public DataTable List()
        {
            return Helper.executeQuery("select * from sexes");
        }

        public EL.Registrations.Sexes Select(EL.Registrations.Sexes sexEL)
        {
            DataTable dt = Helper.executeQuery("select * from sexes where sexid = '" + sexEL.Sexid + "'");

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
