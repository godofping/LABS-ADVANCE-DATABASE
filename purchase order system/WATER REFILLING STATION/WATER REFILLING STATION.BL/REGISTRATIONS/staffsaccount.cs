using System.Data;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class staffsaccount
    {
        DL.REGISTRATIONS.staffsaccount staffsaccountDL = new DL.REGISTRATIONS.staffsaccount();
        public DataTable List(string keywords)
        {
            return staffsaccountDL.List(keywords);
        }

        public DataTable List(int id)
        {
            return staffsaccountDL.List(id);
        }

        public DataTable CheckUsername(EL.REGISTRATIONS.staffsaccount staffsaccountEL)
        {
            return staffsaccountDL.CheckUsername(staffsaccountEL);
        }

        public long Insert(EL.REGISTRATIONS.staffsaccount staffsaccountEL)
        {
            return staffsaccountDL.Insert(staffsaccountEL);
        }

        public bool Update(EL.REGISTRATIONS.staffsaccount staffsaccountEL)
        {
            return staffsaccountDL.Update(staffsaccountEL);    
        }

        public bool Delete(EL.REGISTRATIONS.staffsaccount staffsaccountEL)
        {
            return staffsaccountDL.Delete(staffsaccountEL);
        }

        public DataTable Login(EL.REGISTRATIONS.staffsaccount staffsaccountEL)
        {
            return staffsaccountDL.Login(staffsaccountEL);   
        }
    }
}
