using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;


namespace Mundialito2k18
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        Team[] grA = new Team[4];

        public MainWindow()
        {
            string[] allTeams = File.ReadAllLines(@"./data/teams.dat");
            for (int i = 0; i < allTeams.Length; ++i)
            {
                grA[i] = new Team();
                grA[i].Name = allTeams[i];
                grA[i].Flag = "pack://application:,,,/images/" + grA[i].Name + ".png";
                string[] teamData = File.ReadAllLines(@"./data/Teams/" + grA[i].Name + ".dat");
                for (int j = 0; j < (grA[i].PlayersNumber + 1); ++j)
                {
                    if (j == 0)
                        grA[i].Coach = teamData[j];
                    else
                    {
                        grA[i].addPlayer(teamData[j], j-1, Player.position.GK);
                    }
                }
            }

            InitializeComponent();
            InitializeContent();
        }

        private void InitializeContent()
        {
            ChangeRowData(1, grA[0].Name, 0, 0, 0, 0, 0, 0, 0, ChangeMask.All);
            ChangeRowData(2, grA[1].Name, 0, 0, 0, 0, 0, 0, 0, ChangeMask.All);
            ChangeRowData(3, grA[2].Name, 0, 0, 0, 0, 0, 0, 0, ChangeMask.All);
            ChangeRowData(4, grA[3].Name, 0, 0, 0, 0, 0, 0, 0, ChangeMask.All);

            imgFlag1.Source = new BitmapImage(new Uri(@grA[0].Flag));
            imgFlag2.Source = new BitmapImage(new Uri(@grA[1].Flag));
            imgFlag3.Source = new BitmapImage(new Uri(@grA[2].Flag));
            imgFlag4.Source = new BitmapImage(new Uri(@grA[3].Flag));

        }

        private void ChangeRowBackground(int row, Brush newColor)
        {
            /*
             * Zielony:     SeaGreen
             * Czerwony:    IndianRed
             */

            switch (row)
            {
                case 1:
                    brdrPos1.Background     = newColor;
                    brdrTeam1.Background    = newColor;
                    brdrFlag1.Background    = newColor;
                    brdrPKT1.Background     = newColor;
                    brdrM1.Background       = newColor;
                    brdrW1.Background       = newColor;
                    brdrR1.Background       = newColor;
                    brdrP1.Background       = newColor;
                    brdrBplus1.Background   = newColor;
                    brdrBminus1.Background  = newColor;
                    break;

                case 2:
                    brdrPos2.Background     = newColor;
                    brdrTeam2.Background    = newColor;
                    brdrFlag2.Background    = newColor;
                    brdrPKT2.Background     = newColor;
                    brdrM2.Background       = newColor;
                    brdrW2.Background       = newColor;
                    brdrR2.Background       = newColor;
                    brdrP2.Background       = newColor;
                    brdrBplus2.Background   = newColor;
                    brdrBminus2.Background  = newColor;
                    break;

                case 3:
                    brdrPos3.Background     = newColor;
                    brdrTeam3.Background    = newColor;
                    brdrFlag3.Background    = newColor;
                    brdrPKT3.Background     = newColor;
                    brdrM3.Background       = newColor;
                    brdrW3.Background       = newColor;
                    brdrR3.Background       = newColor;
                    brdrP3.Background       = newColor;
                    brdrBplus3.Background   = newColor;
                    brdrBminus3.Background  = newColor;
                    break;

                case 4:
                    brdrPos4.Background     = newColor;
                    brdrTeam4.Background    = newColor;
                    brdrFlag4.Background    = newColor;
                    brdrPKT4.Background     = newColor;
                    brdrM4.Background       = newColor;
                    brdrW4.Background       = newColor;
                    brdrR4.Background       = newColor;
                    brdrP4.Background       = newColor;
                    brdrBplus4.Background   = newColor;
                    brdrBminus4.Background  = newColor;
                    break;

                default:
                    throw new Exception("Nieprawidłowy numer wiersza. Dostępna liczba wierszy: 1-4");
            }
        }

        [Flags]
        private enum ChangeMask //Implementacja maski bitowej do określenia co należy zmienić w wierszu
        {
            None    = 0,
            Team    = 1,
            PKT     = 2,
            M       = 4,
            W       = 8,
            R       = 16,
            P       = 32,
            Bplus   = 64,
            Bminus  = 128,
            Flag    = 256,  //Zaimplementuj to dalej
            All     = 512
        }

        private void ChangeRowData(int row, string Team, int PKT, int M, int W, int R, int P, int Bplus, int Bminus, ChangeMask mask)
        {
            switch (row)
            {
                case 1:
                    lblTeam1.Content    = (((mask & ChangeMask.Team) != ChangeMask.None)    || ((mask & ChangeMask.All) != ChangeMask.None)) ? Team                 : lblTeam1.Content;
                    lblPKT1.Content     = (((mask & ChangeMask.PKT) != ChangeMask.None)     || ((mask & ChangeMask.All) != ChangeMask.None)) ? PKT.ToString()       : lblPKT1.Content;
                    lblM1.Content       = (((mask & ChangeMask.M) != ChangeMask.None)       || ((mask & ChangeMask.All) != ChangeMask.None)) ? M.ToString()         : lblM1.Content;
                    lblW1.Content       = (((mask & ChangeMask.W) != ChangeMask.None)       || ((mask & ChangeMask.All) != ChangeMask.None)) ? W.ToString()         : lblW1.Content;
                    lblR1.Content       = (((mask & ChangeMask.R) != ChangeMask.None)       || ((mask & ChangeMask.All) != ChangeMask.None)) ? R.ToString()         : lblR1.Content;
                    lblP1.Content       = (((mask & ChangeMask.P) != ChangeMask.None)       || ((mask & ChangeMask.All) != ChangeMask.None)) ? P.ToString()         : lblP1.Content;
                    lblBplus1.Content   = (((mask & ChangeMask.Bplus) != ChangeMask.None)   || ((mask & ChangeMask.All) != ChangeMask.None)) ? Bplus.ToString()     : lblBplus1.Content;
                    lblBminus1.Content  = (((mask & ChangeMask.Bminus) != ChangeMask.None)  || ((mask & ChangeMask.All) != ChangeMask.None)) ? Bminus.ToString()    : lblBminus1.Content;
                    break;

                case 2:
                    lblTeam2.Content    = (((mask & ChangeMask.Team) != ChangeMask.None)    || ((mask & ChangeMask.All) != ChangeMask.None)) ? Team                 : lblTeam2.Content;
                    lblPKT2.Content     = (((mask & ChangeMask.PKT) != ChangeMask.None)     || ((mask & ChangeMask.All) != ChangeMask.None)) ? PKT.ToString()       : lblPKT2.Content;
                    lblM2.Content       = (((mask & ChangeMask.M) != ChangeMask.None)       || ((mask & ChangeMask.All) != ChangeMask.None)) ? M.ToString()         : lblM2.Content;
                    lblW2.Content       = (((mask & ChangeMask.W) != ChangeMask.None)       || ((mask & ChangeMask.All) != ChangeMask.None)) ? W.ToString()         : lblW2.Content;
                    lblR2.Content       = (((mask & ChangeMask.R) != ChangeMask.None)       || ((mask & ChangeMask.All) != ChangeMask.None)) ? R.ToString()         : lblR2.Content;
                    lblP2.Content       = (((mask & ChangeMask.P) != ChangeMask.None)       || ((mask & ChangeMask.All) != ChangeMask.None)) ? P.ToString()         : lblP2.Content;
                    lblBplus2.Content   = (((mask & ChangeMask.Bplus) != ChangeMask.None)   || ((mask & ChangeMask.All) != ChangeMask.None)) ? Bplus.ToString()     : lblBplus2.Content;
                    lblBminus2.Content  = (((mask & ChangeMask.Bminus) != ChangeMask.None)  || ((mask & ChangeMask.All) != ChangeMask.None)) ? Bminus.ToString()    : lblBminus2.Content;
                    break;
            }

        }
    }
}
