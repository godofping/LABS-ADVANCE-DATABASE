using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace pos.DL.Registrations
{
    public class Accounts
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from accounts_view where username";

            return Helper.executeQuery(sQuery);
        }

        public DataTable List(int id)
        {
            string sQuery = "select * from staffs_view where `Staff ID` = '" + id + "'";

            return Helper.executeQuery(sQuery);
        }


        public DataTable CheckUsername(EL.Registrations.Accounts account)
        {
            return Helper.executeQuery("select * from accounts_view where `Username` = '" + account.Accountusername + "'");
        }


        public long Insert(EL.Registrations.Accounts account)
        {
            return Helper.executeNonQueryLong("insert into accounts (accountusername, accountpassword, accountfirstname, accountmiddlename, accountlastname) values ('" + account.Accountusername + "', '" + account.Accountpassword + "', '" + account.Accountfirstname + "', '" + account.Accountmiddlename + "', '" + account.Accountlastname + "')");
        }

        public bool Update(EL.Registrations.Accounts account)
        {
            return Helper.executeNonQueryBool("update accounts set accountpassword = '" + account.Accountpassword + "', accountfirstname = '" + account.Accountfirstname + "', accountmiddlename = '" + account.Accountmiddlename + "', accountlastname = '" + account.Accountlastname + "' where accountid = " + account.Accountid + "");
        }

        public bool Delete(EL.Registrations.Accounts account)
        {
            return Helper.executeNonQueryBool("delete from accounts where accountid = " + account.Accountid + "");
        }


        public DataTable Login(EL.Registrations.Accounts account)
        {
            string sQuery = "select * from accounts_view where `Username` = '" + account.Accountusername + "' and password = '" + account.Accountpassword + "' ";
            return Helper.executeQuery(sQuery);
        }
    }
}
