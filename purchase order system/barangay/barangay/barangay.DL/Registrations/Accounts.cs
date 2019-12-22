using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Accounts
    {
        public DataTable List(String keyword)
        {
            return Helper.executeQuery("select * from accounts where username like '" + keyword + "%'");
        }

        public EL.Registrations.Accounts Select(EL.Registrations.Accounts accountEL)
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

        public long Insert(EL.Registrations.Accounts accountEL)
        {
            return Helper.executeNonQueryLong("insert into accounts (username, password) values ('" + accountEL.Username + "', '" + accountEL.Password + "')");
        }

        public Boolean Update(EL.Registrations.Accounts accountEL)
        {
            return Helper.executeNonQueryBool("update accounts set username = '" + accountEL.Username + "', password = '" + accountEL.Password + "' where accountid = '" + accountEL.Accountid + "'");
        }

        public Boolean Delete(EL.Registrations.Accounts accountEL)
        {
            return Helper.executeNonQueryBool("delete from accounts where accountid = '" + accountEL.Accountid + "'");
        }
    }
}
