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
using System.Globalization;


namespace Mundialito2k18
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowGrA GrA = new WindowGrA(); 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void lblGrA_Click(object sender, RoutedEventArgs e)
        {
            if (!(GrA.IsLoaded))
            {
                GrA = new WindowGrA();
                GrA.Show();
            }
        }

        private void lblExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void menuGrupaA_Click(object sender, RoutedEventArgs e)
        {
            if (!(GrA.IsLoaded))
            {
                GrA = new WindowGrA();
                GrA.Show();
            }
        }
    }
}
