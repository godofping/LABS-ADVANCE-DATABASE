using System.Data;

namespace pos.BL.Registrations
{
    public class Staffpositions
    {
        DL.Registrations.Staffpositions StaffPositionDL = new DL.Registrations.Staffpositions();

        public DataTable List()
        {
            return StaffPositionDL.List();
        }

    }
}
