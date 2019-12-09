using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace student.BL.Registrations
{
    public class students
    {
        DL.Registrations.students studentDL = new student.DL.Registrations.students();

        public DataTable List(string keyword)
        {
            return studentDL.List(keyword);
        }

        public EL.Registrations.students Select(EL.Registrations.students studentEL)
        {
            return studentDL.Select(studentEL);
        }

        public long Insert(EL.Registrations.students studentEL)
        {
            return studentDL.Insert(studentEL);
        }

        public bool Update(EL.Registrations.students studentEL)
        {
            return studentDL.Update(studentEL);
        }

        public bool Delete(EL.Registrations.students studentEL)
        {
            return studentDL.Delete(studentEL);
        }
    }
}
