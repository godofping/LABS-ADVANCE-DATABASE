using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace student.DL.Registrations
{
    public class accounts
    {
        public DataTable List(String keyword)
        {
            return Helper.executeQuery("select * from accounts_view where `C` like '%" + keyword + "%'");
        }

        public DataTable Login(EL.Registrations.accounts accountEL)
        {
            return Helper.executeQuery("select * from accounts where username = '" + accountEL.Username + "' and password = '" + accountEL.Password + "'");
        }

        public EL.Registrations.accounts Select(EL.Registrations.accounts accountEL)
        {
            DataTable dt = Helper.executeQuery("select * from accounts where accountid = '" + accountEL.Accountid + "'");

            if (dt.Rows.Count > 0)
            {
                accountEL.Accountid = Convert.ToInt32(dt.Rows[0]["accountid"]);
                accountEL.Username = dt.Rows[0]["username"].ToString();
                accountEL.Password = dt.Rows[0]["password"].ToString();

                return accountEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.accounts accountEL)
        {
            return Helper.executeNonQueryLong("insert into accounts (username, password) values ('" + accountEL.Username + "', '" + accountEL.Password + "')");
        }

        public Boolean Update(EL.Registrations.accounts accountEL)
        {
            return Helper.executeNonQueryBool("update accounts set username = '" + accountEL.Username + "', password = '" + accountEL.Password + "' where accountid = '" + accountEL.Accountid + "'");
        }

        public Boolean Delete(EL.Registrations.accounts accountEL)
        {
            return Helper.executeNonQueryBool("delete from accounts where accountid = '" + accountEL.Accountid + "'");
        }
    }
}
