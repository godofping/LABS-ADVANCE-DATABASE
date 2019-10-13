using System;
using System.Data;

namespace pos.DL.Registrations
{
    public class Staffs
    {


        public DataTable List(string keywords)
        {
            String sQuery = "select * from staffs_view where `Staff ID` like '%" + keywords + "%' or `First Name` like '%" + keywords + "%' or `Middle Name` like '%" + keywords + "%' or `Last Name` like '%" + keywords + "%' or `Gender` like '%" + keywords + "%' or `Birth Date` like '%" + keywords + "%' or `Contact Number` like '%" + keywords + "%' or `Email Address` like '%" + keywords + "%' or `Address` like '%" + keywords + "%' or `City` like '%" + keywords + "%' or `Province` like '%" + keywords + "%' or `Zip Code` like '%" + keywords + "%' or `Staff Position` like '%" + keywords + "%' or `Username` like '%" + keywords + "%' ";

            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Staffs staff)
        {
            return Helper.executeNonQueryLong("insert into staffs (username, password, contactdetailid, basicinformationid, staffpositionid) values ('" + staff.Username + "', '" + staff.Password + "', '" + staff.Contactdetailid + "', '" + staff.Basicinformationid + "', '" + staff.Staffpositionid + "')");
        }

        public bool Update(EL.Registrations.Staffs staff)
        {
            return Helper.executeNonQueryBool("update staffs set username = '" + staff.Username + "', password = '" + staff.Password + "', staffpositionid = '" + staff.Staffpositionid + "' where staffid = '" + staff.Staffid + "' ");
        }

        public bool Delete(EL.Registrations.Staffs staff)
        {
            return Helper.executeNonQueryBool("update staffs set isdeleted = 1 where staffid = '" + staff.Staffid + "' ");
        }

    }
}
