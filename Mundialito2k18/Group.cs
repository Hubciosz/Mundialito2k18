using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundialito2k18
{
    class Group
    {
        private Match[] matches;        //Mecze rozgrywane w danej grupie
        private Team[] teams;           //Zespoły w danej grupie

        private const ushort matchesMaxNum = 6;
        private ushort matchesActNum = 0;

        private const ushort teamsMaxNum = 4;
        private ushort teamsActNum = 0;

        public Group()
        {
            this.matches = new Match[matchesMaxNum];
            for (int i = 0; i < matchesMaxNum; ++i)
            {
                matches[i] = new Match();
            }

            this.teams = new Team[teamsMaxNum];
            for (int i = 0; i < teamsMaxNum; ++i)
            {
                teams[i] = new Team();
            }
        }

        public Group(Match[] matches, Team[] teams)
        {
            this.matches = new Match[matchesMaxNum];
            this.teams = new Team[teamsMaxNum];

            for (ushort i = 0; i < matchesMaxNum; ++i)
            {
                this.matches[i] = matches[i];
            }

            for (ushort i = 0; i < teamsMaxNum; ++i)
            {
                this.teams[i] = teams[i];
            }
        }

        public Match GetMatch(int num)
        {
            return matches[num];
        }

        public void AddMatch(Match match)
        {
            if (matchesActNum < matchesMaxNum)
            {
                matches[matchesActNum].Host = match.Host;
                matches[matchesActNum].Visitor = match.Visitor;
                matches[matchesActNum].Date = match.Date;
                matches[matchesActNum].Arbiter = match.Arbiter;
                matches[matchesActNum].ScoreHost = match.ScoreHost;
                matches[matchesActNum].ScoreVisitor = match.ScoreVisitor;
                matches[matchesActNum].ID = match.ID;
                matchesActNum++;
            }
        }

        public Team GetTeam(int num)
        {
            return teams[num];
        }

        public void AddTeam(Team team)
        {
            if (teamsActNum < teamsMaxNum)
            {
                teams[teamsActNum].Country = team.Country;
                teams[teamsActNum].Flag = team.Flag;
                teams[teamsActNum].Coach = team.Coach;
                teams[teamsActNum].CopyPlayers(team);
                teamsActNum++;
            }
        }
    }
}
