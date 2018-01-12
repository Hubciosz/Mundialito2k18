using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundialito2k18
{
    class Match
    {
        private Team host;              //Formalny gospodarz
        private Team visitor;           //Formalny gość
        private DateTime date;          //Data spotkania
        private Referee arbiter;        //Sędzia spotkania

        private uint _scoreHost;        //Bramki gospodarzy
        private uint _scoreVisitor;     //Bramki gości
   
        /* Konstruktor klasy Match:
         *  host (obiekt Team) - zespół będący formalnym gospodarzem spotkania
         *  visitor (obiekt Team) - zespół będący formalnie drużyną gości
         *  date (obiekt DateTime) - planowana data spotkania
         *  arbiter (obiekt Referee) - sędzia spotkania
         */
        public Match(Team host, Team visitor, DateTime date, Referee arbiter)
        {
            this.host = host;
            this.visitor = visitor;
            this.date = date;
            this.arbiter = arbiter;
            ScoreHost = 0;
            ScoreVisitor = 0;
        }

        public Team Host { get => host; }
        public Team Visitor { get => visitor; }
        public DateTime Date { get => date; set => date = value; }
        public Referee Arbiter { get => arbiter; set => arbiter = value; }

        public uint ScoreHost { get => _scoreHost; set => _scoreHost = value; }
        public uint ScoreVisitor { get => _scoreVisitor; set => _scoreVisitor = value; }
    }
}
