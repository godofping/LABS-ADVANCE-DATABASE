using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Certifications
    {
        public DataTable List()
        {
            return Helper.executeQuery("select * from certifications");
        }

        public EL.Registrations.Certifications Select(EL.Registrations.Certifications certificationEL)
        {
            DataTable dt = Helper.executeQuery("select * from certifications where certificationid = '" + certificationEL.Certificationid + "'");

            if (dt.Rows.Count > 0)
            {
                certificationEL.Certificationid = Convert.ToInt32(dt.Rows[0]["certificationid"]);
                certificationEL.Certification = dt.Rows[0]["certification"].ToString();

                return certificationEL;
            }
            else
            {
                return null;
            }
        }
    }
}
