using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundialito2k18
{
    class GroupStats
    {
        private uint _matchesWin;
        private uint _matchesDraw;
        private uint _matchesLose;
        private uint _goalsPlus;
        private uint _goalsMinus;
        
        private uint _points;
        private uint _matches;

        public uint MatchesWin {    get { return _matchesWin; }     set { _matchesWin = value;  CalculateMatches();     CalculatePoints(); } }
        public uint MatchesDraw {   get { return _matchesDraw; }    set { _matchesDraw = value; CalculateMatches();     CalculatePoints(); } }
        public uint MatchesLose {   get { return _matchesLose; }    set { _matchesLose = value; CalculateMatches(); } }
        public uint GoalsPlus {     get { return _goalsPlus; }      set { _goalsPlus = value; } }
        public uint GoalsMinus {    get { return _goalsMinus; }     set { _goalsMinus = value; } }
        
        public uint Points {    get { return _points; } }
        public uint Matches {   get { return _matches; } }

        private void CalculatePoints()
        {
            _points = 3 * _matchesWin + _matchesDraw;
        }

        private void CalculateMatches()
        {
            _matches = _matchesWin + _matchesDraw + _matchesLose;
        }
    }
}
