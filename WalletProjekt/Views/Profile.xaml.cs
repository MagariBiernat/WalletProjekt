
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
using System.Data.Sql;
using System.Data.SqlClient;

namespace WalletProjekt.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

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
            UserData obj = new UserData
            {
                email = user.email
            };
            obj.UpdateProfileNew();
            FirstNameVar.Text = obj.firstName;
            LastNameVar.Text = obj.lastName;
            EmailVar.Text = obj.email;
            MonthSalaryAmountVar.Text = obj.SalaryAmount.ToString();
            SalaryDayVar.Text = "Every " + obj.SalaryDay + "th of the month.";


        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void WordsValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z]+");
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
            int SalaryDay = 1;
            if(MonthSalaryAmountVarChange.Text == "" || MonthSalaryAmountVarChange.Text == "0")
            {
                SalaryAmount = 0;
            }
            else
            {
                SalaryAmount = float.Parse(MonthSalaryAmountVarChange.Text);
            }
            if(!(SalaryDayCombobox.SelectedIndex < 1) || !(SalaryDayCombobox.SelectedIndex > 28))
            {
                SalaryDay = Convert.ToInt32(SalaryDayCombobox.SelectedIndex);
            }
            /// Save Changes to Database
            user.UpdateProfileDatabase(firstNameChanged,lastNameChanged, SalaryAmount, SalaryDay, user.email);
            FillProfile();
            InfoChange.Visibility = Visibility.Hidden;
            Info.Visibility = Visibility.Visible;
            
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            List<Posty> lista = new List<Posty>();
            string dbname = "PostsDatabase" + user.userId.ToString();

            SqlCommand comm = new SqlCommand();
            SqlConnection connn = new SqlConnection(conn);
            using(connn)
            {
                comm.CommandText = "SELECT amount, category, profit, datetime FROM " + dbname + " ORDER BY datetime DESC";
                connn.Open();
                comm.Connection = connn;
                SqlDataReader reader = comm.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        lista.Add(new Posty()
                        {
                            Amount = reader["amount"].ToString(),
                            Datetime = reader["datetime"].ToString(),
                            category = reader["category"].ToString(),
                            profit = reader["profit"].ToString()
                        }) ;
                        
                    }
                }

            }


            StringBuilder sb = new StringBuilder(); 
            sb.AppendLine("Amount, Date, Category, Profit");
            foreach (var item in lista)
            {
                sb.AppendLine($"{item.Amount},{item.Datetime},{item.category},{item.profit}");
            }

        }
    }
    class Posty
    {
        public string Amount { get; set; }
        public string Datetime { get; set; }
        public string category { get; set; }
        public string profit { get; set; }
    }
}
