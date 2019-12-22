using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Accomplishments
    {
        int accomplishmentid;
        string title;
        string dateaccomplished;

        public int Accomplishmentid { get => accomplishmentid; set => accomplishmentid = value; }
        public string Title { get => title; set => title = value; }
        public string Dateaccomplished { get => dateaccomplished; set => dateaccomplished = value; }
    }
}
