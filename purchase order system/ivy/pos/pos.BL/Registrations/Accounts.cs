using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace pos.BL.Registrations
{
    public class Accounts
    {
        DL.Registrations.Accounts accountDL = new DL.Registrations.Accounts();

        public DataTable List(string keywords)
        {
            return accountDL.List(keywords);
        }

        public DataTable List(int id)
        {
            return accountDL.List(id);
        }

        public DataTable CheckUsername(EL.Registrations.Accounts account)
        {
            return accountDL.CheckUsername(account);
        }


        public long Insert(pos.EL.Registrations.Accounts account)
        {
            return accountDL.Insert(account);
        }

        public bool Edit(pos.EL.Registrations.Accounts account)
        {
            return accountDL.Edit(account);
        }

        public bool Delete(pos.EL.Registrations.Accounts account)
        {
            return accountDL.Delete(account);
        }

        public DataTable Login(pos.EL.Registrations.Accounts account)
        {
            return accountDL.Login(account);
        }

    }
}
