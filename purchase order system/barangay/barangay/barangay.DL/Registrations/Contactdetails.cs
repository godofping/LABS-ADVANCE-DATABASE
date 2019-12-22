using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Contactdetails
    {
        public EL.Registrations.Contactdetails Select(EL.Registrations.Contactdetails contactdetailEL)
        {
            DataTable dt = Helper.executeQuery("select * from contactdetails where residentid = '" + contactdetailEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                contactdetailEL.Contactdetailid = Convert.ToInt32(dt.Rows[0]["contactdetailid"]);
                contactdetailEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                contactdetailEL.Emailaddress = dt.Rows[0]["emailaddress"].ToString();
                contactdetailEL.Phonenumber = dt.Rows[0]["phonenumber"].ToString();
                contactdetailEL.Cellphonenumber = dt.Rows[0]["cellphonenumber"].ToString();

                return contactdetailEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Contactdetails contactdetailEL)
        {
            return Helper.executeNonQueryLong("insert into contactdetails (residentid, emailaddress, phonenumber, cellphonenumber) values ('" + contactdetailEL.Residentid + "', '" + contactdetailEL.Emailaddress + "', '" + contactdetailEL.Phonenumber + "', '" + contactdetailEL.Cellphonenumber + "')");
        }

        public Boolean Update(EL.Registrations.Contactdetails contactdetailEL)
        {
            return Helper.executeNonQueryBool("update contactdetails set emailaddress = '" + contactdetailEL.Emailaddress + "', phonenumber = '" + contactdetailEL.Phonenumber + "', cellphonenumber = '" + contactdetailEL.Cellphonenumber + "' where residentid = '" + contactdetailEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Contactdetails contactdetailEL)
        {
            return Helper.executeNonQueryBool("delete from contactdetails where residentid = '" + contactdetailEL.Residentid + "'");
        }
    }
}
