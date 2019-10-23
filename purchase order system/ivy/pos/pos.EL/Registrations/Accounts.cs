using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Registrations
{
    public class Accounts
    {
        int accountid;
        string accountusername;
        string accountpassword;
        string accountfullname;

        public int Accountid
        {
            get { return accountid; }
            set { accountid = value; }
        }
        

        public string Accountusername
        {
            get { return accountusername; }
            set { accountusername = value; }
        }
        

        public string Accountpassword
        {
            get { return accountpassword; }
            set { accountpassword = value; }
        }

        public string Accountfullname
        {
            get { return accountfullname; }
            set { accountfullname = value; }
        }




    }
}
