using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Statuses
    {
        int statusid;
        string status;
        string of;

        public int Statusid { get => statusid; set => statusid = value; }
        public string Status { get => status; set => status = value; }
        public string Of { get => of; set => of = value; }
    }
}
