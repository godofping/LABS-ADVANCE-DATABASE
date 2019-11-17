using System.Data;

namespace pos.DL.Registrations
{
    public class Staffs
    {


        public DataTable List(string keywords)
        {
            string sQuery = "select * from staffs_view where `Staff ID` like '%" + keywords + "%' or `First Name` like '%" + keywords + "%' or `Middle Name` like '%" + keywords + "%' or `Last Name` like '%" + keywords + "%' or `Gender` like '%" + keywords + "%' or `Birth Date` like '%" + keywords + "%' or `Contact Number` like '%" + keywords + "%' or `Email Address` like '%" + keywords + "%' or `Address` like '%" + keywords + "%' or `City` like '%" + keywords + "%' or `Province` like '%" + keywords + "%' or `Zip Code` like '%" + keywords + "%' or `Staff Position` like '%" + keywords + "%' or `Username` like '%" + keywords + "%' ";

            return Helper.executeQuery(sQuery);
        }

        public DataTable List(int id)
        {
            string sQuery = "select * from staffs_view where `Staff ID` = '" + id + "'";

            return Helper.executeQuery(sQuery);
        }

        public DataTable CheckUsername(EL.Registrations.Staffs staffEL)
        {
            return Helper.executeQuery("select * from staffs_view where `Username` = '" + staffEL.Username + "'");
        }

        public DataTable CheckUsername(EL.Registrations.Staffs staffEL, int id)
        {
            return Helper.executeQuery("select * from staffs_view where `Username` = '" + staffEL.Username + "' and `Staff ID` <> " + id + "");
        }

        public long Insert(EL.Registrations.Staffs staffEL)
        {
            return Helper.executeNonQueryLong("insert into staffs (username, password, contactdetailid, basicinformationid, staffpositionid) values ('" + staffEL.Username + "', '" + staffEL.Password + "', '" + staffEL.Contactdetailid + "', '" + staffEL.Basicinformationid + "', '" + staffEL.Staffpositionid + "')");
        }

        public bool Update(EL.Registrations.Staffs staffEL)
        {
            return Helper.executeNonQueryBool("update staffs set username = '" + staffEL.Username + "', password = '" + staffEL.Password + "', staffpositionid = '" + staffEL.Staffpositionid + "' where staffid = '" + staffEL.Staffid + "' ");
        }

        public bool Delete(EL.Registrations.Staffs staffEL)
        {
            return Helper.executeNonQueryBool("delete from staffs where staffid = '" + staffEL.Staffid + "' ");
        }


        public DataTable Login(EL.Registrations.Staffs staffEL)
        {
            string sQuery = "select * from staffs_view where `Username` = '" + staffEL.Username + "' and password = '" + staffEL.Password + "' ";
            return Helper.executeQuery(sQuery);
        }

    }
}
