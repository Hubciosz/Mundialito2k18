using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Mundialito2k18
{
    class Team
    {
        private string _country;        //Nazwa państwa
        private BitmapImage _flag;      //Obraz z miniaturką flagi
        private Person _coach;          //Trener
        private Player[] players;      //Piłkarze

        private const int _playersMaxNum = 23;      //Maksymalna liczba piłkarzy w drużynie
        private int playersActNum;                  //Aktualna liczba piłkarzy w drużynie

        public string Country { get => _country; }
        public BitmapImage Flag { get => _flag; }
        internal Person Coach { get => _coach; set => _coach = value; }

        public static int PlayersMaxNum => _playersMaxNum;

        /*** KONSTRUKTORY ***/
        public Team(string country, BitmapImage flag, Person coach)
        {
            _country = country;
            _flag = flag;
            _coach = coach;
            players = new Player[PlayersMaxNum];
        }

        public Team(string country, BitmapImage flag, Person coach, Player [] pl)
        {
            _country = country;
            _flag = flag;
            _coach = coach;
            players = new Player[PlayersMaxNum];

            if (pl.Length > players.Length)
            {
                throw new Exception($"Podano {pl.Length.ToString()} zawodników. Maksymalna liczba zawodników w drużynie to {PlayersMaxNum.ToString()}.");
            }
            else
            {
                int i = 0;
                for (i = 0; i < pl.Length; ++i)
                {
                    players[i] = pl[i];
                }
                playersActNum = i;
            }
        }

        public void AddPlayer(Player pl)
        {
            if(playersActNum >= PlayersMaxNum)
            {
                throw new Exception($"Aktualna liczba piłkarzy w drużynie: {playersActNum.ToString()}. Maksymalna liczba piłkarzy w drużynie: {PlayersMaxNum}. Spróbuj użyć metody ChangePlayer()");
            }
            else
            {
                players[playersActNum++] = pl;
            }
        }

        public void ChangePlayer(int index, Player pl)
        {
            if (index >= playersActNum)
            {
                throw new Exception($"Podany indeks {index.ToString()} jest większy, niż indeks ostatniego piłkarza na liście {(playersActNum - 1).ToString()}");
            }
            else
            {
                players[index] = pl;
            }

        }

        public int FindPlayer(string name, string surname, int num, bool numFind)
        {
            int playerIndex = 0;
            

            if (playerIndex >= PlayersMaxNum)
                throw new Exception("Nie ma takiego zawodnika w tej reprezentacji.");

            return playerIndex;
        }
    }
}
