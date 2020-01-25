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
        UserData user;
        // UserData user = ((MainWindow)App.Current.MainWindow).GetUserData();
        public MainMenu()
        {
            GetUser();
            InitializeComponent();
            DashboardModel Dashboard = new DashboardModel();
            MainContent.DataContext = Dashboard;
            
        }
        private void GetUser()
        {
            user = ((MainWindow)App.Current.MainWindow).GetUserData();
        }
        public void ReadBalance()
        {
            float balance = user.GetBalance();
            BalanceVar.Text = balance.ToString();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            DashboardModel Dashboard = new DashboardModel();
            MainContent.DataContext = Dashboard;
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            ProfileModel Profile = new ProfileModel();
            MainContent.DataContext = Profile;
        }

        private void Posts_Click(object sender, RoutedEventArgs e)
        {
            PostsModel Posts = new PostsModel();
            MainContent.DataContext = Posts;
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            StatsModel Stats = new StatsModel();
            MainContent.DataContext = Stats;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ReadBalance();
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            WasteModel Waste = new WasteModel();
            MainContent.DataContext = Waste;
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            ProfitModel Profit = new ProfitModel();
            MainContent.DataContext = Profit;
        }
    }
}
