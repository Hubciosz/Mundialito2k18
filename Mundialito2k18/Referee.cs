using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundialito2k18
{
    class Referee : Person
    {
        private uint _yellows = 0;      //Liczba wlepionych żółtych kartek
        private uint _reds = 0;         //Liczba wlepionych czerwonych kartek
        private uint _matches = 0;      //Liczba poprowadzonych spotkań

        public uint Yellows {   get { return _yellows; }    set { _yellows = value; } }
        public uint Reds {      get { return _reds; }       set { _reds = value; } }
        public uint Matches {   get { return _matches; }    set { _matches = value; } }
    }
}
