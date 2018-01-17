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
            Match match = new Match();
            Team team = new Team();
            GroupA = new Group();
            
            string[] allTeams = File.ReadAllLines(@"./data/A/teams.dat");
            string[] cm;
            foreach (string tm in allTeams)
            {
                team = new Team(tm, new BitmapImage(new Uri(@"pack://application:,,,/images/" + tm + ".png")), new Person());
                GroupA.AddTeam(team);
            }

            string[] allMatches = File.ReadAllLines(@"./data/A/matches.dat");
            foreach (string mt in allMatches)
            {
                cm = mt.Split('|');
                FindTeam(cm[7]);
                match = new Match(  GroupA.GetTeam(FindTeam(cm[7])),    
                                    GroupA.GetTeam(FindTeam(cm[8])),    
                                    new DateTime(2018, Convert.ToInt32(cm[4]), Convert.ToInt32(cm[3]), Convert.ToInt32(cm[5]), Convert.ToInt32(cm[6]), 00),
                                    new Referee(),
                                    Convert.ToUInt32(cm[0]),
                                    Convert.ToUInt32(cm[1]),
                                    Convert.ToUInt32(cm[2])  );
                GroupA.AddMatch(match);
            }

            //GroupA.GetMatch(0).ScoreHost = 1;
            //GroupA.GetTeam(0).GroupMatches.MatchesWin = 2;

            //GroupA.GetTeam(1).GroupMatches.MatchesWin = 1;
            //GroupA.GetTeam(1).GroupMatches.MatchesDraw = 1;
            
            //GroupA.GetTeam(2).GroupMatches.MatchesDraw = 1;
            //GroupA.GetTeam(2).GroupMatches.MatchesLose = 1;

            //GroupA.GetTeam(3).GroupMatches.MatchesLose = 2;

            for (int i = 0; i < 4; ++i)
            {
                ChangeRowData(i+1, i, false);
            }

            for (int i = 0; i < 2; ++i)
            {
                ChangeMatchData(i + 1, i, false);
            }

            //lblMatch1Date.Content = (new DateTime(2018, 06, 18, 17, 00, 00)).ToString("f");
            //lblMatch1Host.Content = GroupA.GetTeam(0).Country;
            //imgMatch1HostFlag.Source = GroupA.GetTeam(0).Flag;

            //lblMatch1Visitor.Content = GroupA.GetTeam(2).Country;
            //imgMatch1VisitorFlag.Source = GroupA.GetTeam(2).Flag;

            //lblMatch2Date.Content = (new DateTime(2018, 06, 19, 21, 00, 00)).ToString("f");
            //lblMatch2Host.Content = GroupA.GetTeam(1).Country;
            //imgMatch2HostFlag.Source = GroupA.GetTeam(1).Flag;

            //lblMatch2Visitor.Content = GroupA.GetTeam(3).Country;
            //imgMatch2VisitorFlag.Source = GroupA.GetTeam(3).Flag;
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
                    brdrBdiff1.Background = newColor;
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
                    brdrBdiff2.Background = newColor;
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
                    brdrBdiff3.Background = newColor;
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
                    brdrBdiff4.Background = newColor;
                    break;

                default:
                    throw new Exception("Nieprawidłowy numer wiersza. Dostępna liczba wierszy: 1-4");
            }
        }

        private void ChangeRowData(int row, int numTeam, bool fullMode)
        {
            switch (row)
            {
                case 1:
                    lblTeam1.Content = GroupA.GetTeam(numTeam).Country;
                    imgFlag1.Source = GroupA.GetTeam(numTeam).Flag;
                    lblPKT1.Content =   fullMode ? GroupA.GetTeam(numTeam).GroupMatches.Points.ToString() : 0.ToString();
                    lblM1.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.Matches.ToString() : 0.ToString();
                    lblW1.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesWin.ToString() : 0.ToString();
                    lblR1.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesDraw.ToString() : 0.ToString();
                    lblP1.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesLose.ToString() : 0.ToString();
                    lblBplus1.Content = fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsPlus.ToString() : 0.ToString();
                    lblBminus1.Content= fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsMinus.ToString() : 0.ToString();
                    lblBdiff1.Content = fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsDiff.ToString() : 0.ToString();
                    break;

                case 2:
                    lblTeam2.Content = GroupA.GetTeam(numTeam).Country;
                    imgFlag2.Source = GroupA.GetTeam(numTeam).Flag;
                    lblPKT2.Content =   fullMode ? GroupA.GetTeam(numTeam).GroupMatches.Points.ToString() : 0.ToString();
                    lblM2.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.Matches.ToString() : 0.ToString();
                    lblW2.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesWin.ToString() : 0.ToString();
                    lblR2.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesDraw.ToString() : 0.ToString();
                    lblP2.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesLose.ToString() : 0.ToString();
                    lblBplus2.Content = fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsPlus.ToString() : 0.ToString();
                    lblBminus2.Content= fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsMinus.ToString() : 0.ToString();
                    lblBdiff2.Content = fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsDiff.ToString() : 0.ToString();
                    break;

                case 3:
                    lblTeam3.Content = GroupA.GetTeam(numTeam).Country;
                    imgFlag3.Source = GroupA.GetTeam(numTeam).Flag;
                    lblPKT3.Content =   fullMode ? GroupA.GetTeam(numTeam).GroupMatches.Points.ToString() : 0.ToString();
                    lblM3.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.Matches.ToString() : 0.ToString();
                    lblW3.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesWin.ToString() : 0.ToString();
                    lblR3.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesDraw.ToString() : 0.ToString();
                    lblP3.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesLose.ToString() : 0.ToString();
                    lblBplus3.Content = fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsPlus.ToString() : 0.ToString();
                    lblBminus3.Content= fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsMinus.ToString() : 0.ToString();
                    lblBdiff3.Content = fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsDiff.ToString() : 0.ToString();
                    break;

                case 4:
                    lblTeam4.Content = GroupA.GetTeam(numTeam).Country;
                    imgFlag4.Source = GroupA.GetTeam(numTeam).Flag;
                    lblPKT4.Content =   fullMode ? GroupA.GetTeam(numTeam).GroupMatches.Points.ToString() : 0.ToString();
                    lblM4.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.Matches.ToString() : 0.ToString();
                    lblW4.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesWin.ToString() : 0.ToString();
                    lblR4.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesDraw.ToString() : 0.ToString();
                    lblP4.Content =     fullMode ? GroupA.GetTeam(numTeam).GroupMatches.MatchesLose.ToString() : 0.ToString();
                    lblBplus4.Content = fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsPlus.ToString() : 0.ToString();
                    lblBminus4.Content= fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsMinus.ToString() : 0.ToString();
                    lblBdiff4.Content = fullMode ? GroupA.GetTeam(numTeam).GroupMatches.GoalsDiff.ToString() : 0.ToString();
                    break;

                default:
                    throw new Exception("Nieprawidłowy numer wiersza. Dostępna liczba wierszy: 1-4");

            }
        }

        private void ChangeMatchData(int row, int numMatch, bool fullMode)
        {
            switch (row)
            {
                case 1:
                    lblMatch1Nr.Content = GroupA.GetMatch(numMatch).ID.ToString();
                    lblMatch1Date.Content = GroupA.GetMatch(numMatch).Date.ToString("f");
                    
                    imgMatch1HostFlag.Source = GroupA.GetMatch(numMatch).Host.Flag;
                    lblMatch1Host.Content = GroupA.GetMatch(numMatch).Host.Country.ToString();

                    txtMatch1Host.Text =    fullMode ? GroupA.GetMatch(numMatch).ScoreHost.ToString() : "";
                    txtMatch1Visitor.Text = fullMode ? GroupA.GetMatch(numMatch).ScoreVisitor.ToString() : "";

                    lblMatch1Visitor.Content = GroupA.GetMatch(numMatch).Visitor.Country.ToString();
                    imgMatch1VisitorFlag.Source = GroupA.GetMatch(numMatch).Visitor.Flag;
                    break;

                case 2:
                    lblMatch2Nr.Content = GroupA.GetMatch(numMatch).ID.ToString();
                    lblMatch2Date.Content = GroupA.GetMatch(numMatch).Date.ToString("f");

                    imgMatch2HostFlag.Source = GroupA.GetMatch(numMatch).Host.Flag;
                    lblMatch2Host.Content = GroupA.GetMatch(numMatch).Host.Country.ToString();

                    txtMatch2Host.Text =    fullMode ? GroupA.GetMatch(numMatch).ScoreHost.ToString() : "";
                    txtMatch2Visitor.Text = fullMode ? GroupA.GetMatch(numMatch).ScoreVisitor.ToString() : "";

                    lblMatch2Visitor.Content = GroupA.GetMatch(numMatch).Visitor.Country.ToString();
                    imgMatch2VisitorFlag.Source = GroupA.GetMatch(numMatch).Visitor.Flag;
                    break;

                    //Pozostałe przypadki do dopisania po wprowadzeniu kolejnych tabelek w XAML-u
                default:
                    throw new Exception("Nieprawidłowy numer wiersza. Dostępna liczba wierszy: 1-6");
            }
        }

        private int FindTeam(string teamCountry)
        {
            int i;
            for (i = 0; i < 4; ++i)
            {
                if (String.Compare(GroupA.GetTeam(i).Country, teamCountry) == 0)
                {
                    break;
                }
            }

            return i;
        }

        private void menuBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ScoreChanged(int numMatch)
        {
            uint hostLocalScore;
            uint visitorLocalScore;

            switch (numMatch)
            {
                case 0:
                    uint.TryParse(txtMatch1Host.Text.ToString(), out hostLocalScore);
                    uint.TryParse(txtMatch1Visitor.Text.ToString(), out visitorLocalScore);
                    GroupA.GetMatch(numMatch).ScoreHost = hostLocalScore;
                    GroupA.GetMatch(numMatch).ScoreVisitor = visitorLocalScore;
                    ChangeRowData(1, FindTeam(GroupA.GetMatch(numMatch).Host.Country), hostLocalScore != default(uint));
                    ChangeRowData(2, FindTeam(GroupA.GetMatch(numMatch).Visitor.Country), visitorLocalScore != default(uint));
                    break;
            }
        }

        private void txtMatch1Host_TextChanged(object sender, TextChangedEventArgs e)
        {
            ScoreChanged(0);
        }
        
        private void txtMatch1Visitor_TextChanged(object sender, TextChangedEventArgs e)
        {
            ScoreChanged(0);
        }
    }
}
