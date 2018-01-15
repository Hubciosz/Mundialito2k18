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
        private DateTime _date;         //Data spotkania
        private Referee _arbiter;       //Sędzia spotkania

        private uint _scoreHost;        //Bramki gospodarzy
        private uint _scoreVisitor;     //Bramki gości

        private uint _id;               //Numer identyfikujący spotkanie
        
        /* Pierwszy konstruktor klasy Match:
         *  host (obiekt Team) - zespół będący formalnym gospodarzem spotkania
         *  visitor (obiekt Team) - zespół będący formalnie drużyną gości
         *  date (obiekt DateTime) - planowana data spotkania
         *  arbiter (obiekt Referee) - sędzia spotkania
         *  id - numer identyfikujący spotkanie
         */
        public Match(Team host, Team visitor, DateTime date, Referee arbiter, uint id)
        {
            this.host = host;
            this.visitor = visitor;
            this.Date = date;
            this.Arbiter = arbiter;
         
            ScoreHost = 0;
            ScoreVisitor = 0;

            this.ID = id;
        }

        /*
         * Drugi konstruktor klasy Match:
         *  match (obiekt Match) - zespół do przypisania
         */
        public Match(Match match)
        {
            this.host = match.host;
            this.visitor = match.visitor;
            this.Date = match.Date;
            this.Arbiter = match.Arbiter;

            this.ScoreHost = match.ScoreHost;
            this.ScoreVisitor = match.ScoreVisitor;

            this.ID = match.ID;
        }

        public Team Host {          get { return host; } }
        public Team Visitor {       get { return visitor; } }
        public DateTime Date {      get { return _date; }       set { _date = value; } }
        public Referee Arbiter {    get { return _arbiter; }    set { _arbiter = value; } }

        public uint ScoreHost {     get { return _scoreHost; }      set { _scoreHost = value; } }
        public uint ScoreVisitor {  get { return _scoreVisitor; }   set { _scoreVisitor = value; } }

        public uint ID { get { return _id; } set { _id = value; } }
    }
}
