using System.Data;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class designations
    {
        DL.REGISTRATIONS.designations designationDL = new DL.REGISTRATIONS.designations();
        public DataTable List()
        {
            return designationDL.List();
        }
    }
}
