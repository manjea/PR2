using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasser_1
{
    class Bil
    {
        public string marke { get; private set; }
        public int arsmodell { get; private set; }
        public double mil { get; private set; }

        public Bil(string _marke, int _arsmodell, double _mil)
        {
            marke = _marke;
            arsmodell = _arsmodell;
            mil = _mil;
        }

        public void setMil(double _m)
        {
            mil = _m;
        }

        public void setArsmodell(int _am)
        {
            arsmodell = _am;
        }

        public void setMarke(string _ma)
        {
            marke = _ma;
        }

        public string returnInfo()
        {
            return this.marke + "\t" + this.arsmodell.ToString() + "\t" + this.mil.ToString();
        }
    }
}
