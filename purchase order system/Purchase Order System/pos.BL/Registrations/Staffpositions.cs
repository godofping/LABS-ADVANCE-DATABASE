using System.Data;

namespace pos.BL.Registrations
{
    public class StaffPositions
    {
        DL.Registrations.StaffPositions StaffPositionDL = new DL.Registrations.StaffPositions();

        public DataTable List()
        {
            return StaffPositionDL.List();
        }

    }
}
