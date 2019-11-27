using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.EL.REGISTRATIONS
{
    public class staffs
    {
        int staffid;
        int basicinformationid;
        int designationid;
        string datehired;

        public int Staffid { get => staffid; set => staffid = value; }
        public int Basicinformationid { get => basicinformationid; set => basicinformationid = value; }
        public int Designationid { get => designationid; set => designationid = value; }
        public string Datehired { get => datehired; set => datehired = value; }
    }
}
