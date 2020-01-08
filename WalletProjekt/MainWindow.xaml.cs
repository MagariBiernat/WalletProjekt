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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserData user;
        public MainWindow()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new LoginPage());
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();
        private void ButtonPower_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void MinimalizeButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        public void LoginSuccesGoMainMenu() => frame.NavigationService.Navigate(new MainMenu());
        public void ReceiveUserData(UserData User)
        {
            user = User;
        }
        public UserData GetUserData()
        {
            return user;
        }

    }
}
