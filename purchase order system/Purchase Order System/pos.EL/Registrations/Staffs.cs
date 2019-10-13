using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Staffs
    {
        int staffid;
        string username;
        string password;
        int contactdetailid;
        int basicinformationid;
        int staffpositionid;
        int isdeleted;

        public int Staffid { get => staffid; set => staffid = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Contactdetailid { get => contactdetailid; set => contactdetailid = value; }
        public int Basicinformationid { get => basicinformationid; set => basicinformationid = value; }
        public int Staffpositionid { get => staffpositionid; set => staffpositionid = value; }
        public int Isdeleted { get => isdeleted; set => isdeleted = value; }
    }
}
