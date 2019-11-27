using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.EL.REGISTRATIONS
{
    public class staffsaccount
    {
        int staffaccountid;
        int staffid;
        string username;
        string password;

        public int Staffaccountid { get => staffaccountid; set => staffaccountid = value; }
        public int Staffid { get => staffid; set => staffid = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
