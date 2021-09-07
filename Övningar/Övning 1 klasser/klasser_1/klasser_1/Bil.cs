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
    }
}
