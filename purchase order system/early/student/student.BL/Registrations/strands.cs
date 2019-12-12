using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace student.BL.Registrations
{
    public class strands
    {
        DL.Registrations.strands strandDL = new student.DL.Registrations.strands();

        public DataTable List(string keyword)
        {
            return strandDL.List(keyword);
        }

        public DataTable Populations()
        {
            return strandDL.Populations();
        }

        public EL.Registrations.strands Select(EL.Registrations.strands strandEL)
        {
            return strandDL.Select(strandEL);
        }

        public long Insert(EL.Registrations.strands strandEL)
        {
            return strandDL.Insert(strandEL);
        }

        public bool Update(EL.Registrations.strands strandEL)
        {
            return strandDL.Update(strandEL);
        }

        public bool Delete(EL.Registrations.strands strandEL)
        {
            return strandDL.Delete(strandEL);
        }
    }
}
