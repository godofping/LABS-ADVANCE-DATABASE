using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Issuances
    {
        DL.Registrations.Issuances issuanceDL = new DL.Registrations.Issuances();
        public DataTable List(String keyword)
        {
            return issuanceDL.List(keyword);
        }

        public DataTable ListForReports(String keyword)
        {
            return issuanceDL.ListForReports(keyword);
        }

        public EL.Registrations.Issuances Select(EL.Registrations.Issuances issuanceEL)
        {
            return issuanceDL.Select(issuanceEL);
        }

        public long Insert(EL.Registrations.Issuances issuanceEL)
        {
            return issuanceDL.Insert(issuanceEL);
        }

        public Boolean Update(EL.Registrations.Issuances issuanceEL)
        {
            return issuanceDL.Update(issuanceEL);
        }

        public Boolean Delete(EL.Registrations.Issuances issuanceEL)
        {
            return issuanceDL.Delete(issuanceEL);
        }
    }
}
