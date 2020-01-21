
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
    /// Logika interakcji dla klasy Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        UserData user;
        public Profile()
        {
            GetUser();
            InitializeComponent();
            FillProfile();


        }
        private void GetUser()
        {
            user = ((MainWindow)App.Current.MainWindow).GetUserData();
        }
        private void FillProfile()
        {
            FirstNameVar.Text = user.firstName;
            LastNameVar.Text = user.lastName;
            EmailVar.Text = user.email;
            LastLoginDateVar.Text = user.lastLoginDate.ToShortDateString();
            MonthSalaryAmountVar.Text = user.SalaryAmount.ToString();
            SalaryDayVar.Text = "Every " + user.SalaryDay + "th of the month.";


        }
    }
}
