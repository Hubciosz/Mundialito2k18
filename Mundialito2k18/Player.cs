using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundialito2k18
{
    class Player : Person
    {
        public enum Pos { GK, DF, MD, FW };

        private uint _number;       //Numer zawodnika
        private Pos _position;      //Pozycja na boisku
        private string _club;       //Aktualny klub zawodnika

        public uint Number { get => _number; set => _number = value; }
        internal Pos Position { get => _position; set => _position = value; }
        public string Club { get => _club; set => _club = value; }
    }
}
