using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundialito2k18
{
    class Match
    {
        private Team _host;              //Formalny gospodarz
        private Team _visitor;           //Formalny gość
        private DateTime _date;         //Data spotkania
        private Referee _arbiter;       //Sędzia spotkania

        private uint _scoreHost;        //Bramki gospodarzy
        private uint _scoreVisitor;     //Bramki gości

        private uint _id;               //Numer identyfikujący spotkanie

        [Flags]
        private enum StatsMask
        {
            Empty = 0,
            Wins = 2,
            Draws = 4,
            Loses = 8
        };

        private StatsMask updateControl = StatsMask.Empty;
        
        public Match()
        {
            this.Host = new Team();
            this.Visitor = new Team();
            this.Date = new DateTime();
            this.Arbiter = new Referee();

            this.ScoreHost = 0;
            this.ScoreVisitor = 0;

            this.ID = 0;
        }
        
        /* Pierwszy konstruktor klasy Match:
         *  host (obiekt Team) - zespół będący formalnym gospodarzem spotkania
         *  visitor (obiekt Team) - zespół będący formalnie drużyną gości
         *  date (obiekt DateTime) - planowana data spotkania
         *  arbiter (obiekt Referee) - sędzia spotkania
         *  id - numer identyfikujący spotkanie
         */
        public Match(Team host, Team visitor, DateTime date, Referee arbiter, uint id, uint scoreHost, uint scoreVisitor)
        {
            this._host = host;
            this._visitor = visitor;
            this.Date = date;
            this.Arbiter = arbiter;
         
            this.ScoreHost = scoreHost;
            this.ScoreVisitor = scoreVisitor;

            this.ID = id;
        }

        /*
         * Drugi konstruktor klasy Match:
         *  match (obiekt Match) - zespół do przypisania
         */
        public Match(Match match)
        {
            this._host = match._host;
            this._visitor = match._visitor;
            this.Date = match.Date;
            this.Arbiter = match.Arbiter;

            this.ScoreHost = match.ScoreHost;
            this.ScoreVisitor = match.ScoreVisitor;

            this.ID = match.ID;
        }

        public Team Host {          get { return _host; }       set { _host = value; } }
        public Team Visitor {       get { return _visitor; }    set { _visitor = value; } }
        public DateTime Date {      get { return _date; }       set { _date = value; } }
        public Referee Arbiter {    get { return _arbiter; }    set { _arbiter = value; } }

        public uint ScoreHost {     get { return _scoreHost; }      set { _scoreHost = value;       UpdateTeamsInfo(); } }
        public uint ScoreVisitor {  get { return _scoreVisitor; }   set { _scoreVisitor = value;    UpdateTeamsInfo(); } }

        public uint ID { get { return _id; } set { _id = value; } }

        private void UpdateTeamsInfo()
        {
            Host.GroupMatches.GoalsPlus = ScoreHost;
            Host.GroupMatches.GoalsMinus = ScoreVisitor;

            Visitor.GroupMatches.GoalsPlus = ScoreVisitor;
            Visitor.GroupMatches.GoalsMinus = ScoreHost;

            if (ScoreHost > ScoreVisitor)
            {
                if ((updateControl & StatsMask.Wins) == StatsMask.Empty)
                {
                    (Host.GroupMatches.MatchesWin)++;
                    (Visitor.GroupMatches.MatchesLose)++;

                    if ((updateControl & StatsMask.Draws) != StatsMask.Empty)
                    {
                        (Host.GroupMatches.MatchesDraw)--;
                        (Visitor.GroupMatches.MatchesDraw)--;
                    }

                    if ((updateControl & StatsMask.Loses) != StatsMask.Empty)
                    {
                        (Host.GroupMatches.MatchesLose)--;
                        (Visitor.GroupMatches.MatchesWin)--;
                    }

                    updateControl = StatsMask.Wins;
                }
            }

            if (ScoreHost == ScoreVisitor)
            {
                if ((updateControl & StatsMask.Draws) == StatsMask.Empty)
                {
                    (Host.GroupMatches.MatchesDraw)++;
                    (Visitor.GroupMatches.MatchesDraw)++;

                    if ((updateControl & StatsMask.Wins) != StatsMask.Empty)
                    {
                        (Host.GroupMatches.MatchesWin)--;
                        (Visitor.GroupMatches.MatchesLose)--;
                    }

                    if ((updateControl & StatsMask.Loses) != StatsMask.Empty)
                    {
                        (Host.GroupMatches.MatchesLose)--;
                        (Visitor.GroupMatches.MatchesWin)--;
                    }

                    updateControl = StatsMask.Draws;
                }
            }

            if (ScoreHost < ScoreVisitor)
            {
                if ((updateControl & StatsMask.Loses) == StatsMask.Empty)
                {
                    (Host.GroupMatches.MatchesLose)++;
                    (Visitor.GroupMatches.MatchesWin)++;

                    if ((updateControl & StatsMask.Wins) != StatsMask.Empty)
                    {
                        (Host.GroupMatches.MatchesWin)--;
                        (Visitor.GroupMatches.MatchesLose)--;
                    }

                    if ((updateControl & StatsMask.Draws) != StatsMask.Empty)
                    {
                        (Host.GroupMatches.MatchesDraw)--;
                        (Visitor.GroupMatches.MatchesDraw)--;
                    }

                    updateControl = StatsMask.Loses;
                }
            }
        }
    }
}
