using System.Data;

namespace pos.BL.Registrations
{
    public class Staffs
    {
        DL.Registrations.Staffs StaffDL = new DL.Registrations.Staffs();
        public DataTable List(string keywords)
        {
            return StaffDL.List(keywords);
        }

        public long Insert(EL.Registrations.Staffs staff)
        {
            return StaffDL.Insert(staff);
        }

        public bool Update(EL.Registrations.Staffs staff)
        {
            return StaffDL.Update(staff);
        }

        public bool Delete(EL.Registrations.Staffs staff)
        {
            return StaffDL.Delete(staff);
        }

        public DataTable Login(EL.Registrations.Staffs staff)
        {
            return StaffDL.Login(staff);
        }
    }
}
