using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace student.BL.Registrations
{
    public class accounts
    {
        DL.Registrations.accounts accountDL = new student.DL.Registrations.accounts();
        public DataTable List(String keyword)
        {
            return accountDL.List(keyword);
        }

        public DataTable Login(EL.Registrations.accounts accountEL)
        {
            return accountDL.Login(accountEL);
        }

        public EL.Registrations.accounts Select(EL.Registrations.accounts accountEL)
        {
            return accountDL.Select(accountEL);
        }

        public long Insert(EL.Registrations.accounts accountEL)
        {
            return accountDL.Insert(accountEL);
        }

        public Boolean Update(EL.Registrations.accounts accountEL)
        {
            return accountDL.Update(accountEL);
        }

        public Boolean Delete(EL.Registrations.accounts accountEL)
        {
            return accountDL.Delete(accountEL);
        }
    }
}
