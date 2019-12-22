using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Accounts
    {
        DL.Registrations.Accounts accountDL = new DL.Registrations.Accounts();
        public DataTable List(String keyword)
        {
            return accountDL.List(keyword);
        }

        public EL.Registrations.Accounts Select(EL.Registrations.Accounts accountEL)
        {
            return accountDL.Select(accountEL);
        }

        public long Insert(EL.Registrations.Accounts accountEL)
        {
            return accountDL.Insert(accountEL);
        }

        public Boolean Update(EL.Registrations.Accounts accountEL)
        {
            return accountDL.Update(accountEL);
        }

        public Boolean Delete(EL.Registrations.Accounts accountEL)
        {
            return accountDL.Delete(accountEL);
        }
    }
}
