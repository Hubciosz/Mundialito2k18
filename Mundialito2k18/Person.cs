using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundialito2k18
{
    class Person
    {
        private string _name;       //Imię
        private string _surname;    //Nazwisko
        private uint _age;          //Wiek
        private uint _nationality;  //Narodowść

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public uint Age { get => _age; set => _age = value; }
        public uint Nationality { get => _nationality; set => _nationality = value; }
    }
}
