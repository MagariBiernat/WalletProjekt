
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
using System.Text.RegularExpressions;
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
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 28 ; i++)
            {
                SalaryDayCombobox.Items.Add(i.ToString());
            }
        }
        private void GetUser()
        {
            user = ((MainWindow)App.Current.MainWindow).GetUserData();
        }
        public void FillProfile()
        {
            FirstNameVar.Text = user.firstName;
            LastNameVar.Text = user.lastName;
            EmailVar.Text = user.email;
            LastLoginDateVar.Text = user.lastLoginDate.ToShortDateString();
            MonthSalaryAmountVar.Text = user.SalaryAmount.ToString();
            SalaryDayVar.Text = "Every " + user.SalaryDay + "th of the month.";


        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void WordsValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[A-Za-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Info.Visibility = Visibility.Hidden;
            InfoChange.Visibility = Visibility.Visible;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string firstNameChanged = firstNameVarChang.Text;
            string lastNameChanged = lastNameVarChang.Text;
            float SalaryAmount;
            if(MonthSalaryAmountVarChange.Text == "" || MonthSalaryAmountVarChange.Text == "0")
            {
                SalaryAmount = 0;
            }
            else
            {
                SalaryAmount = float.Parse(MonthSalaryAmountVarChange.Text);
            }
            int SalaryDay = Convert.ToInt32(SalaryDayCombobox.SelectedIndex);
            /// Save Changes to Database
            user.UpdateProfileDatabase(firstNameChanged,lastNameChanged, SalaryAmount, SalaryDay, user.email);
            InfoChange.Visibility = Visibility.Hidden;
            Info.Visibility = Visibility.Visible;
            
        }

        
    }
}
