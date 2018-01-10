using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundialito2k18
{
    class Team
    {
        private const int playersNumber = 23;
        public short PlayersNumber { get { return playersNumber; } }

        private int playersInd;
        
        public string Name { set; get; }
        public string Coach { set; get; }
        
        private Player [] players = new Player[playersNumber];

        public Team()
        {
            Name = "n/a";
            Coach = "n/a";
            playersInd = 0;
            for (int i = 0; i < playersNumber; ++i)
            {
                players[i] = new Player();
            }
        }

        public bool addPlayer(string name, int num, Player.position pos)
        {
            bool status;

            if (playersInd >= PlayersNumber)
                status = false;
            else
            {
                status = true;
                players[playersInd].Name = name;
                players[playersInd].Number = num;
                players[playersInd].Position = pos;
                playersInd++;
            }

            return status;
        }

        public bool changePlayer(int index, string name, int num, Player.position pos)
        {
            bool status;

            if (index >= PlayersNumber)
                status = false;
            else
            {
                status = true;
                players[index].Name = name;
                players[index].Number = num;
                players[index].Position = pos;
            }

            return status;
        }

        public int findPlayer(string name, int num, bool numFind)
        {
            int playerIndex;
            
            for (playerIndex = 0; playerIndex < PlayersNumber; ++playerIndex)
            {
                if (numFind)
                {
                    if (players[playerIndex].Number == num)
                        break;
                }
                else
                {
                    if (players[playerIndex].Name == name)
                        break;
                }
            }

            if (playerIndex >= PlayersNumber)
                throw new Exception("Nie ma takiego zawodnika w tej reprezentacji.");

            return playerIndex;
        }
    }
}
