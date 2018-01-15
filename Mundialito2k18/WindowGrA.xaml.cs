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
using System.Windows.Shapes;

using System.IO;

namespace Mundialito2k18
{
    /// <summary>
    /// Interaction logic for WindowGrA.xaml
    /// </summary>
    public partial class WindowGrA : Window
    {
        private Group GroupA;

        public WindowGrA()
        {
            InitializeComponent();
            InitializeContent();
        }

        private void InitializeContent()
        {
            string[] allTeams = File.ReadAllLines(@"./data/teamsA.dat");
            Match[] matches = new Match[6];
            Team team = new Team();
            GroupA = new Group();
            foreach (string tm in allTeams)
            {
                team = new Team(tm, new BitmapImage(new Uri(@"pack://application:,,,/images/" + tm + ".png")), new Person());
                GroupA.AddTeam(team);
            }
            GroupA.GetTeam(0).GroupMatches.MatchesWin = 2;

            GroupA.GetTeam(1).GroupMatches.MatchesWin = 1;
            GroupA.GetTeam(1).GroupMatches.MatchesDraw = 1;
            
            GroupA.GetTeam(2).GroupMatches.MatchesDraw = 1;
            GroupA.GetTeam(2).GroupMatches.MatchesLose = 1;

            GroupA.GetTeam(3).GroupMatches.MatchesLose = 2;
            for (int i = 0; i < 4; ++i)
            {
                ChangeRowData(i+1, i);
            }
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
                    brdrPos1.Background = newColor;
                    brdrTeam1.Background = newColor;
                    brdrFlag1.Background = newColor;
                    brdrPKT1.Background = newColor;
                    brdrM1.Background = newColor;
                    brdrW1.Background = newColor;
                    brdrR1.Background = newColor;
                    brdrP1.Background = newColor;
                    brdrBplus1.Background = newColor;
                    brdrBminus1.Background = newColor;
                    break;

                case 2:
                    brdrPos2.Background = newColor;
                    brdrTeam2.Background = newColor;
                    brdrFlag2.Background = newColor;
                    brdrPKT2.Background = newColor;
                    brdrM2.Background = newColor;
                    brdrW2.Background = newColor;
                    brdrR2.Background = newColor;
                    brdrP2.Background = newColor;
                    brdrBplus2.Background = newColor;
                    brdrBminus2.Background = newColor;
                    break;

                case 3:
                    brdrPos3.Background = newColor;
                    brdrTeam3.Background = newColor;
                    brdrFlag3.Background = newColor;
                    brdrPKT3.Background = newColor;
                    brdrM3.Background = newColor;
                    brdrW3.Background = newColor;
                    brdrR3.Background = newColor;
                    brdrP3.Background = newColor;
                    brdrBplus3.Background = newColor;
                    brdrBminus3.Background = newColor;
                    break;

                case 4:
                    brdrPos4.Background = newColor;
                    brdrTeam4.Background = newColor;
                    brdrFlag4.Background = newColor;
                    brdrPKT4.Background = newColor;
                    brdrM4.Background = newColor;
                    brdrW4.Background = newColor;
                    brdrR4.Background = newColor;
                    brdrP4.Background = newColor;
                    brdrBplus4.Background = newColor;
                    brdrBminus4.Background = newColor;
                    break;

                default:
                    throw new Exception("Nieprawidłowy numer wiersza. Dostępna liczba wierszy: 1-4");
            }
        }

        private void ChangeRowData(int row, int numTeam)
        {
            switch (row)
            {
                case 1:
                    lblTeam1.Content = GroupA.GetTeam(numTeam).Country;
                    imgFlag1.Source = GroupA.GetTeam(numTeam).Flag;
                    lblPKT1.Content = GroupA.GetTeam(numTeam).GroupMatches.Points.ToString();
                    lblM1.Content = GroupA.GetTeam(numTeam).GroupMatches.Matches.ToString();
                    lblW1.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesWin.ToString();
                    lblR1.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesDraw.ToString();
                    lblP1.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesLose.ToString();
                    lblBplus1.Content = GroupA.GetTeam(numTeam).GroupMatches.GoalsPlus.ToString();
                    lblBminus1.Content = GroupA.GetTeam(numTeam).GroupMatches.GoalsMinus.ToString();
                    break;

                case 2:
                    lblTeam2.Content = GroupA.GetTeam(numTeam).Country;
                    imgFlag2.Source = GroupA.GetTeam(numTeam).Flag;
                    lblPKT2.Content = GroupA.GetTeam(numTeam).GroupMatches.Points.ToString();
                    lblM2.Content = GroupA.GetTeam(numTeam).GroupMatches.Matches.ToString();
                    lblW2.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesWin.ToString();
                    lblR2.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesDraw.ToString();
                    lblP2.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesLose.ToString();
                    lblBplus2.Content = GroupA.GetTeam(numTeam).GroupMatches.GoalsPlus.ToString();
                    lblBminus2.Content = GroupA.GetTeam(numTeam).GroupMatches.GoalsMinus.ToString();
                    break;

                case 3:
                    lblTeam3.Content = GroupA.GetTeam(numTeam).Country;
                    imgFlag3.Source = GroupA.GetTeam(numTeam).Flag;
                    lblPKT3.Content = GroupA.GetTeam(numTeam).GroupMatches.Points.ToString();
                    lblM3.Content = GroupA.GetTeam(numTeam).GroupMatches.Matches.ToString();
                    lblW3.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesWin.ToString();
                    lblR3.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesDraw.ToString();
                    lblP3.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesLose.ToString();
                    lblBplus3.Content = GroupA.GetTeam(numTeam).GroupMatches.GoalsPlus.ToString();
                    lblBminus3.Content = GroupA.GetTeam(numTeam).GroupMatches.GoalsMinus.ToString();
                    break;

                case 4:
                    lblTeam4.Content = GroupA.GetTeam(numTeam).Country;
                    imgFlag4.Source = GroupA.GetTeam(numTeam).Flag;
                    lblPKT4.Content = GroupA.GetTeam(numTeam).GroupMatches.Points.ToString();
                    lblM4.Content = GroupA.GetTeam(numTeam).GroupMatches.Matches.ToString();
                    lblW4.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesWin.ToString();
                    lblR4.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesDraw.ToString();
                    lblP4.Content = GroupA.GetTeam(numTeam).GroupMatches.MatchesLose.ToString();
                    lblBplus4.Content = GroupA.GetTeam(numTeam).GroupMatches.GoalsPlus.ToString();
                    lblBminus4.Content = GroupA.GetTeam(numTeam).GroupMatches.GoalsMinus.ToString();
                    break;

                default:
                    throw new Exception("Nieprawidłowy numer wiersza. Dostępna liczba wierszy: 1-4");

            }
        }

        private void lblBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow WinMain = new MainWindow();
            WinMain.Show();
            this.Close();
        }
    }
}
