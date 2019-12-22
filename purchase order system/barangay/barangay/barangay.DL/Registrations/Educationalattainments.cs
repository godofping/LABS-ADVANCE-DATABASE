using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Educationalattainments
    {
        public DataTable List()
        {
            return Helper.executeQuery("select * from educationalattainments");
        }

        public EL.Registrations.Educationalattainments Select(EL.Registrations.Educationalattainments educationalattainmentEL)
        {
            DataTable dt = Helper.executeQuery("select * from educationalattainments where educationalattainmentid = '" + educationalattainmentEL.Educationalattainmentid + "'");

            if (dt.Rows.Count > 0)
            {
                educationalattainmentEL.Educationalattainmentid = Convert.ToInt32(dt.Rows[0]["educationalattainmentid"]);
                educationalattainmentEL.Educationalattainment = dt.Rows[0]["educationalattainment"].ToString();

                return educationalattainmentEL;
            }
            else
            {
                return null;
            }
        }
    }
}
