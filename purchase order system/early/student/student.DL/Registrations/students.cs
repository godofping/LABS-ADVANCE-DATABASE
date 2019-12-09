using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace student.DL.Registrations
{
    public class students
    {

        public DataTable List(string keyword)
        {
            return Helper.executeQuery("select * from students_view where `C` like '%" + keyword + "%'");
        }

        public EL.Registrations.students Select(EL.Registrations.students studentEL)
        {
            var dt = Helper.executeQuery("select * from students_view where `STUDENT ID` = '" + studentEL.Studentid + "'");
            if (dt.Rows.Count > 0)
            {
                studentEL.Studentid = Convert.ToInt32(dt.Rows[0]["STUDENT ID"].ToString());
                studentEL.Strandid = Convert.ToInt32(dt.Rows[0]["STRAND ID"].ToString());
                studentEL.Lrn = dt.Rows[0]["LRN"].ToString();
                studentEL.Lastname = dt.Rows[0]["LAST NAME"].ToString();
                studentEL.Firstname = dt.Rows[0]["FIRST NAME"].ToString();
                studentEL.Middleinitial = dt.Rows[0]["MIDDLE INITIAL"].ToString();
                studentEL.Address = dt.Rows[0]["ADDRESS"].ToString();
                studentEL.Parentsorguardian = dt.Rows[0]["PARENTS OR GUARDIAN"].ToString();
                studentEL.Contactnumber = dt.Rows[0]["CONTACT NUMBER"].ToString();
                studentEL.Lastschoolattended = dt.Rows[0]["LAST SCHOOL ATTENDED"].ToString();
                studentEL.Schoolyear = dt.Rows[0]["SCHOOL YEAR"].ToString();
                studentEL.Yearlevel = dt.Rows[0]["YEAR LEVEL"].ToString();
                return studentEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.students studentEL)
        {
            return Helper.executeNonQueryLong("insert into students (strandid, lrn, lastname, firstname, middleinitial, address, parentsorguardian, contactnumber, lastschoolattended, schoolyear, yearlevel, dateadded) values ('" + studentEL.Strandid + "', '" + studentEL.Lrn + "', '" + studentEL.Lastname + "', '" + studentEL.Firstname + "', '" + studentEL.Middleinitial + "', '" + studentEL.Address + "', '" + studentEL.Parentsorguardian + "', '" + studentEL.Contactnumber + "', '" + studentEL.Lastschoolattended + "', '" + studentEL.Schoolyear + "', '" + studentEL.Yearlevel + "', '" + studentEL.Dateadded + "')");
        }

        public bool Update(EL.Registrations.students studentEL)
        {
            return Helper.executeNonQueryBool("update students set strandid = '" + studentEL.Strandid + "', lastname = '" + studentEL.Lastname + "', firstname = '" + studentEL.Firstname + "', middleinitial = '" + studentEL.Middleinitial + "', address = '" + studentEL.Address + "', parentsorguardian = '" + studentEL.Parentsorguardian + "', contactnumber = '" + studentEL.Contactnumber + "', lastschoolattended = '" + studentEL.Lastschoolattended + "', schoolyear = '" + studentEL.Schoolyear + "', yearlevel = '" + studentEL.Yearlevel + "', dateadded = '" + studentEL.Dateadded + "' where studentid = '" + studentEL.Strandid + "'");
        }

        public bool Delete(EL.Registrations.students studentEL)
        {
            return Helper.executeNonQueryBool("delete from students where studentid = '" + studentEL.Studentid + "'");
        }
    }
}
