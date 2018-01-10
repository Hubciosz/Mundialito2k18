using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundialito2k18
{
    class Player
    {
        public enum position { GK, DF, MD, FW };
        
        public string Name { set; get; }
        public int Number { set; get; }
        public position Position { set; get; }
    }
}
