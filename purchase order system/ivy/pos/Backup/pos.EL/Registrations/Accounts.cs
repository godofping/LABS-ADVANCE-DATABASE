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
        string accountfirstname;
        string accountmiddlename;
        string accountlastname;

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

        public string Accountfirstname
        {
            get { return accountfirstname; }
            set { accountfirstname = value; }
        }


        public string Accountmiddlename
        {
            get { return accountmiddlename; }
            set { accountmiddlename = value; }
        }


        public string Accountlastname
        {
            get { return accountlastname; }
            set { accountlastname = value; }
        }


    }
}
