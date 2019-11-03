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

        public DataTable List(int id)
        {
            return StaffDL.List(id);
        }

        public DataTable CheckUsername(EL.Registrations.Staffs staffEL)
        {
            return StaffDL.CheckUsername(staffEL);
        }

        public DataTable CheckUsername(EL.Registrations.Staffs staffEL, int id)
        {
            return StaffDL.CheckUsername(staffEL, id);
        }

        public long Insert(EL.Registrations.Staffs staffEL)
        {
            return StaffDL.Insert(staffEL);
        }

        public bool Update(EL.Registrations.Staffs staffEL)
        {
            return StaffDL.Update(staffEL);
        }

        public bool Delete(EL.Registrations.Staffs staffEL)
        {
            return StaffDL.Delete(staffEL);
        }

        public DataTable Login(EL.Registrations.Staffs staffEL)
        {
            return StaffDL.Login(staffEL);
        }
    }
}
