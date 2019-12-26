using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace student.EL.Registrations
{
    public class accounts
    {
        int accountid;

        public int Accountid
        {
            get { return accountid; }
            set { accountid = value; }
        }
        string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
