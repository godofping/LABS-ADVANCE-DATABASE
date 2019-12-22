using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Filelocations
    {
        int filelocationid;
        int accomplishmentid;
        string filelocation;

        public int Filelocationid { get => filelocationid; set => filelocationid = value; }
        public int Accomplishmentid { get => accomplishmentid; set => accomplishmentid = value; }
        public string Filelocation { get => filelocation; set => filelocation = value; }
    }
}
