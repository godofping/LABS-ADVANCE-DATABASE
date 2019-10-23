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
            string sQuery = "select * from accounts_view where `Account Username` like '%" + keywords + "%' or `Account Password` like '%" + keywords + "%' or `Account Full Name` like '%" + keywords + "%' ";

            return Helper.executeQuery(sQuery);
        }

        public DataTable List(int id)
        {
            string sQuery = "select * from accounts_view where `Account ID` = '" + id + "'";

            return Helper.executeQuery(sQuery);
        }


        public DataTable CheckUsername(EL.Registrations.Accounts account)
        {
            return Helper.executeQuery("select * from accounts_view where `Account Username` = '" + account.Accountusername + "'");
        }


        public long Insert(EL.Registrations.Accounts account)
        {
            return Helper.executeNonQueryLong("insert into accounts (accountusername, accountpassword, accountfullname) values ('" + account.Accountusername + "', '" + account.Accountpassword + "', '" + account.Accountfullname + "')");
        }

        public bool Edit(EL.Registrations.Accounts account)
        {
            return Helper.executeNonQueryBool("update accounts set accountpassword = '" + account.Accountpassword + "', accountfullname = '" + account.Accountfullname + "'");
        }

        public bool Delete(EL.Registrations.Accounts account)
        {
            return Helper.executeNonQueryBool("delete from accounts where accountid = " + account.Accountid + "");
        }


        public DataTable Login(EL.Registrations.Accounts account)
        {
            string sQuery = "select * from accounts_view where `Account Username` = '" + account.Accountusername + "' and `Account Password` = '" + account.Accountpassword + "' ";
            return Helper.executeQuery(sQuery);
        }
    }
}
