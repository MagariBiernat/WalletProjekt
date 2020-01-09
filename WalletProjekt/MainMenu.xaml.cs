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
using WalletProjekt.ViewModels;
using WalletProjekt.Views;
using WalletProjekt.Classes;

namespace WalletProjekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        UserData user = ((MainWindow)App.Current.MainWindow).GetUserData();
        public MainMenu()
        {
            
            InitializeComponent();
            DashboardModel Dashboard = new DashboardModel();
            MainContent.DataContext = Dashboard;
            
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
