using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Residents
    {
        public DataTable List(String keyword)
        {
            return Helper.executeQuery("select * from residents_view where householdnumber like '" + keyword + "%' or householdmember like '" + keyword + "%' or lastname like '" + keyword + "%' or firstname like '" + keyword + "%' or middlename like '" + keyword + "%'");
        }
        public DataTable ListNames(String keyword)
        {
            return Helper.executeQuery("select residentid, lastname, firstname, middlename  from residents_view where lastname like '" + keyword + "%' or firstname like '" + keyword + "%' or middlename like '" + keyword + "%'");
        }

        public DataTable ListResidencyCertification(int id)
        {
            return Helper.executeQuery("select * from residency_view where residentid = '" + id + "'");
        }
        public DataTable ListIdentificationCard(int id)
        {
            return Helper.executeQuery("select * from identificationcard_view where residentid = '" + id + "'");
        }
  
        public DataTable ListByHousehold(int id)
        {
            return Helper.executeQuery("select householdmember, lastname, firstname, middlename from residents_view where householdid = '" + id + "'");
        }
        public DataTable ListByHouseholdHeads(String keyword)
        {
            return Helper.executeQuery("select * from residents_view where (householdnumber like '" + keyword + "%' or householdmember like 'HEAD' or lastname like '" + keyword + "%' or firstname like '" + keyword + "%' or middlename like '" + keyword + "%') and householdmember = 'HEAD'");
        }
        public DataTable ListByOutOfSchoolYouth(String keyword)
        {
            return Helper.executeQuery("select * from residents_view where (householdnumber like '" + keyword + "%' or householdmember like 'HEAD' or lastname like '" + keyword + "%' or firstname like '" + keyword + "%' or middlename like '" + keyword + "%') and ((educationalattainment = 'none' or educationalattainment = 'Elementary Level' or educationalattainment = 'Elementary Graduate' or educationalattainment = 'High School Level' or educationalattainment = 'High School Graduate' or educationalattainment = 'College Level') and (age <= 24 and age >= 12))");
        }
        public DataTable ListBySeniorCitizen(String keyword)
        {
            return Helper.executeQuery("select * from residents_view where (householdnumber like '" + keyword + "%' or householdmember like 'HEAD' or lastname like '" + keyword + "%' or firstname like '" + keyword + "%' or middlename like '" + keyword + "%') and age >= 65");
        }
        public DataTable ListByWomen(String keyword)
        {
            return Helper.executeQuery("select * from residents_view where (householdnumber like '" + keyword + "%' or householdmember like '" + keyword + "%' or lastname like '" + keyword + "%' or firstname like '" + keyword + "%' or middlename like '" + keyword + "%') and sex = 'Female'");
        }
        public DataTable ListByPWD(String keyword)
        {
            return Helper.executeQuery("select * from residents_view where (householdnumber like '" + keyword + "%' or householdmember like '" + keyword + "%' or lastname like '" + keyword + "%' or firstname like '" + keyword + "%' or middlename like '" + keyword + "%') and ispwd = 1");
        }

        public EL.Registrations.Residents Select(EL.Registrations.Residents residentEL)
        {
            DataTable dt = Helper.executeQuery("select * from residents where residentid = '" + residentEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                residentEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                residentEL.Barangayidnumber = dt.Rows[0]["barangayidnumber"].ToString();
                residentEL.Lastname = dt.Rows[0]["lastname"].ToString();
                residentEL.Firstname = dt.Rows[0]["firstname"].ToString();
                residentEL.Middlename = dt.Rows[0]["middlename"].ToString();
                residentEL.Height = dt.Rows[0]["height"].ToString();
                residentEL.Weight = dt.Rows[0]["weight"].ToString();
                residentEL.Precintnumber = dt.Rows[0]["precintnumber"].ToString();
                residentEL.Ctcnumber = dt.Rows[0]["ctcnumber"].ToString();
                residentEL.Dateaccomplished = dt.Rows[0]["dateaccomplished"].ToString();
                residentEL.Daterecorded = dt.Rows[0]["daterecorded"].ToString();
                residentEL.Ispwd = Convert.ToInt32(dt.Rows[0]["ispwd"]);

                return residentEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Residents residentEL)
        {
            return Helper.executeNonQueryLong("insert into residents (barangayidnumber, lastname, firstname, middlename, height, weight, precintnumber, ctcnumber, dateaccomplished, daterecorded, ispwd) values ('" + residentEL.Barangayidnumber + "', '" + residentEL.Lastname + "', '" + residentEL.Firstname + "', '" + residentEL.Middlename + "', '" + residentEL.Height + "', '" + residentEL.Weight + "','" + residentEL.Precintnumber + "', '" + residentEL.Ctcnumber + "', '" + residentEL.Dateaccomplished + "', '" + residentEL.Daterecorded + "', '" + residentEL.Ispwd + "')");
        }

        public Boolean Update(EL.Registrations.Residents residentEL)
        {
            return Helper.executeNonQueryBool("update residents set barangayidnumber = '" + residentEL.Barangayidnumber + "', lastname = '" + residentEL.Lastname + "', firstname = '" + residentEL.Firstname + "', middlename = '" + residentEL.Middlename + "', height = '" + residentEL.Height + "', weight = '" + residentEL.Weight + "', precintnumber = '" + residentEL.Precintnumber + "', ctcnumber = '" + residentEL.Ctcnumber + "', dateaccomplished = '" + residentEL.Dateaccomplished + "', ispwd = '" + residentEL.Ispwd + "' where residentid = '" + residentEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Residents residentEL)
        {
            return Helper.executeNonQueryBool("delete from residents where residentid = '" + residentEL.Residentid + "'");
        }
    }
}
