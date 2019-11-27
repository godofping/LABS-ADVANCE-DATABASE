using System.Data;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class staffs
    {
        DL.REGISTRATIONS.staffs staffDL = new DL.REGISTRATIONS.staffs();
        public DataTable List(string keywords)
        {
            return staffDL.List(keywords);
        }

        public DataTable List()
        {
            return staffDL.List();
        }

        public long Insert(EL.REGISTRATIONS.staffs staffEL)
        {
            return staffDL.Insert(staffEL);
        }

        public bool Update(EL.REGISTRATIONS.staffs staffEL)
        {
            return staffDL.Update(staffEL);
        }

        public bool Delete(EL.REGISTRATIONS.staffs staffEL)
        {
            return staffDL.Delete(staffEL);
        }
    }
}
