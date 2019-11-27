using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class staffsaccount
    {
        public DataTable List(string keywords)
        {
            string sQuery = "SELECT * FROM view_staffsaccount WHERE `USERNAME` LIKE '%" + keywords + "%' OR `LAST NAME` LIKE '%" + keywords + "%' OR `FIRST NAME` LIKE '%" + keywords + "%' OR `MIDDLE INITIAL` LIKE '%" + keywords + "%' OR `DESIGNATION` LIKE '%" + keywords + "%'";

            return Helper.executeQuery(sQuery);
        }

        public DataTable List(int id)
        {
            string sQuery = "SELECT * FROM view_staffsaccount WHERE `STAFF ACCOUNT ID` = '" + id + "'";

            return Helper.executeQuery(sQuery);
        }

        public DataTable CheckUsername(EL.REGISTRATIONS.staffsaccount staffsaccountEL)
        {
            return Helper.executeQuery("SELECT * FROM view_staffsaccount WHERE `USERNAME` = '" + staffsaccountEL.Username + "'");
        }


        public long Insert(EL.REGISTRATIONS.staffsaccount staffsaccountEL)
        {
            return Helper.executeNonQueryLong("INSERT INTO staffsaccount (staffid, username, password) VALUES ('" + staffsaccountEL.Staffid + "', '" + staffsaccountEL.Username + "', '" + staffsaccountEL.Password + "')");
        }

        public bool Update(EL.REGISTRATIONS.staffsaccount staffsaccountEL)
        {
            return Helper.executeNonQueryBool("UPDATE staffsaccount SET username = '" + staffsaccountEL.Username + "', password = '" + staffsaccountEL.Password + "' WHERE staffaccountid = '" + staffsaccountEL.Staffaccountid + "' ");
        }

        public bool Delete(EL.REGISTRATIONS.staffsaccount staffsaccountEL)
        {
            return Helper.executeNonQueryBool("DELETE FROM staffsaccount WHERE staffaccountid = '" + staffsaccountEL.Staffaccountid + "' ");
        }

        public DataTable Login(EL.REGISTRATIONS.staffsaccount staffsaccountEL)
        {
            string sQuery = "SELECT * FROM view_staffsaccount WHERE `USERNAME` = '" + staffsaccountEL.Username + "' AND `PASSWORD` = '" + staffsaccountEL.Password + "' ";
            return Helper.executeQuery(sQuery);
        }
    }
}
