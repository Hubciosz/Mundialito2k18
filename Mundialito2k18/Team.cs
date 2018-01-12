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

        /*
         * Pierwszy konstruktor klasy:
         *  country - nazwa kraju, reprezentowanego przez drużynę
         *  flag - flaga państwa
         *  coach (klasa Person) - menadżer drużyny
         */
        public Team(string country, BitmapImage flag, Person coach)
        {
            _country = country;
            _flag = flag;
            _coach = coach;
            players = new Player[PlayersMaxNum];
        }

        /*
         * Drugi konstruktor klasy:
         *  country - nazwa kraju, reprezentowanego przez drużynę
         *  flag - flaga państwa
         *  coach (klasa Person) - menadżer drużyny
         *  pl (tablica Player) - tablica zawodników drużyny
         */
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

        /*
         * Metoda dodająca gracza do drużyny:
         *  pl (obiekt Player) - gracz do dodania
         *  
         *  Jej typowe użycie powinno mieć miejsce po wykorzystaniu pierwszego konstruktora, 
         *  tworzączego pustą tablicę zawodników.
         *  
         *  Metoda zgłasza wyjątek, gdy zostały już zajęte wszystkie miejsca w drużynie,
         *  warunkowane przez wartość PlayersMaxNum.
         */
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

        /*
         * Metoda zmieniająca wybranego zawodnika w drużynie:
         *  index - indeks zawodnika do usunięcia z drużyny
         *  pl (obiekt Player) - zawodnik do wprowadzenia do drużyny
         *  
         * Jej typowe użycie powinno wykorzystywać metodę FindPlayer do uzyskania indeksu zawodnika usuwanego
         * z drużyny.
         * Metoda zgłasza wyjątek jeżeli podany indeks wychodzi poza zakres zawodników będących obecnie
         * w drużynie, warunkowany przez playersActNum.
         */
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

        /*
         * Metoda wyszukująca danego gracza wśród zawodników drużyny:
         *  name - imię gracza
         *  surname - nazwisko gracza
         *  num - numer gracza na koszulce
         *  numFind - flaga wyboru sposobu poszukiwania zawodnika
         *  
         * Możliwe jest poszukiwanie zawodnika poprzez jego imię i nazwisko (numFind == false),
         * bądź przez jego numer na koszulce (numFind == true). Metoda zwraca indeks znalezionego
         * zawodnika. Jeżeli nie udało się go odszukać wśród graczy drużyny, zgłaszany jest wyjątek.
         */ 
        public int FindPlayer(string name, string surname, uint num, bool numFind)
        {
            int playerIndex = 0;
            bool breakCond = false;
            
            for(playerIndex = 0; playerIndex < playersActNum; ++playerIndex)
            {
                breakCond = numFind ? (players[playerIndex].Number == num) : (String.Equals(players[playerIndex].Name, name) && String.Equals(players[playerIndex].Surname, surname));
                if (breakCond)
                {
                    break;
                }
            }

            if (playerIndex >= PlayersMaxNum)
                throw new Exception("Nie ma takiego zawodnika w tej reprezentacji.");

            return playerIndex;
        }
    }
}
