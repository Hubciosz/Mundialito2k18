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
            lblTeam1.Content = grA[0].Name;
            lblTeam2.Content = grA[1].Name;
            lblTeam3.Content = grA[2].Name;
            lblTeam4.Content = grA[3].Name;
        }
    }
}
