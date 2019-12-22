using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Educations
    {
        int educationid;
        int residentid;
        int educationalattainmentid;
        string course;
        string yeargraduated;

        public int Educationid { get => educationid; set => educationid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public int Educationalattainmentid { get => educationalattainmentid; set => educationalattainmentid = value; }
        public string Course { get => course; set => course = value; }
        public string Yeargraduated { get => yeargraduated; set => yeargraduated = value; }
    }
}
