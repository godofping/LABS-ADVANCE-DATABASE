using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Accomplishments
    {
        DL.Registrations.Accomplishments accomplishmentDL = new DL.Registrations.Accomplishments();
        public DataTable List(String keyword)
        {
            return accomplishmentDL.List(keyword);
        }

        public EL.Registrations.Accomplishments Select(EL.Registrations.Accomplishments accomplishmentEL)
        {
            return accomplishmentDL.Select(accomplishmentEL);
        }

        public long Insert(EL.Registrations.Accomplishments accomplishmentEL)
        {
            return accomplishmentDL.Insert(accomplishmentEL);
        }

        public Boolean Update(EL.Registrations.Accomplishments accomplishmentEL)
        {
            return accomplishmentDL.Update(accomplishmentEL);
        }

        public Boolean Delete(EL.Registrations.Accomplishments accomplishmentEL)
        {
            return accomplishmentDL.Delete(accomplishmentEL);
        }
    }
}
