using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class staffs
    {
        public DataTable List(string keywords)
        {
            string sQuery = "SELECT * FROM view_staffs WHERE `LAST NAME` LIKE '%" + keywords + "%' OR `FIRST NAME` LIKE '%" + keywords + "%' OR `MIDDLE INITIAL` LIKE '%" + keywords + "%' OR `FIRST NAME` LIKE '%" + keywords + "%' OR `BIRTH DATE` LIKE '%" + keywords + "%' OR `ADDRESS` LIKE '%" + keywords + "%' OR `CONTACT NUMBER` LIKE '%" + keywords + "%' OR `EMAIL ADDRESS` LIKE '%" + keywords + "%' OR `DESIGNATION` LIKE '%" + keywords + "%' OR `DATE HIRED` LIKE '%" + keywords + "%' ";

            return Helper.executeQuery(sQuery);
        }

        public DataTable List()
        {
            string sQuery = "SELECT * FROM view_staffs WHERE (`DESIGNATION` = 'MANAGER' OR `DESIGNATION` = 'CASHIER') AND `STAFF ID` NOT IN (SELECT `STAFF ID` FROM view_staffsaccount)";

            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.REGISTRATIONS.staffs staffEL)
        {
            string sQuery = "INSERT INTO staffs (basicinformationid, designationid, datehired) VALUES ('" + staffEL.Basicinformationid + "', '" + staffEL.Designationid + "', '" + staffEL.Datehired + "')";

            return Helper.executeNonQueryLong(sQuery);
        }

        public bool Update(EL.REGISTRATIONS.staffs staffEL)
        {
            string sQuery = "UPDATE staffs SET designationid = '" + staffEL.Designationid + "', datehired = '" + staffEL.Datehired + "' WHERE staffid = '" + staffEL.Staffid + "'";

            return Helper.executeNonQueryBool(sQuery);
        }

        public bool Delete(EL.REGISTRATIONS.staffs staffEL)
        {
            string sQuery = "DELETE FROM staffs where staffid = '" + staffEL.Staffid + "'";

            return Helper.executeNonQueryBool(sQuery);
        }

    }
}
