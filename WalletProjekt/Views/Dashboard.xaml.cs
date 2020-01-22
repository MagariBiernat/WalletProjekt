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
using WalletProjekt.Classes;
using System.Threading;

namespace WalletProjekt.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        UserData user;
        public Dashboard()
        {
            GetUser();
            InitializeComponent();


            //var parent = VisualTreeHelper.GetParent(this);
            //while (!(parent is Page))
            //{
            //    parent = VisualTreeHelper.GetParent(parent);
            //}
            //(parent as MainMenu)
        }
        private void GetUser()
        {
            user = ((MainWindow)App.Current.MainWindow).GetUserData();
        }
        private void Last30Days()
        {
            Classes.Posts Last30Days = new Classes.Posts();
            Last30Days.useremail = user.email;
            float balance = Last30Days.ReadLastMonth(user.userId);

            LastMonthBalanceVar.Text = balance.ToString();
        }
        private void AverageDaily()
        {
            Classes.Posts Last30DaysToAverage = new Classes.Posts();
            Last30DaysToAverage.useremail = user.email;
            float balance = Last30DaysToAverage.ReadLastMonth(user.userId);
            AverageDailyVar.Text = (balance / 30).ToString();
        }

        private void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            Last30Days();
            AverageDaily();
        }
    }
   
}
