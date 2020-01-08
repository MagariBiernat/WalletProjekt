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
using System.Data.Sql;
using System.Data.SqlClient;

namespace WalletProjekt.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
        }

        private void RegisterNewAccountButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent(this);
            while (!(parent is Page))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            
            (parent as LoginPage).LoginRegisterViewRegister();
            
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // string email = emailVar.Text;
            // string password = passwordVar.Password;
            // int CheckIfEmailMatchesPassword = ValidateLogin(email, password);
            // if(CheckIfEmailMatchesPassword == 1)
            // {
            // success login :)
            // };

            ((MainWindow)App.Current.MainWindow).LoginSuccesGoMainMenu();
        }

        private int ValidateLogin(string email, string password)
        {
            SqlCommand command = new SqlCommand();
            using(SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                command.CommandText = "SELECT password FROM users WHERE email = @email";
                command.Parameters.AddWithValue("@email", email);
                command.Connection = myCon;
                SqlDataReader reader = command.ExecuteReader();
                string PasswordFromDatabase = String.Empty;
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                           PasswordFromDatabase = reader["password"].ToString();
                        break; // the loop goes only once.
                    }
                    
                }
                else
                {
                    return 0;
                }
                if (!String.IsNullOrEmpty(PasswordFromDatabase))
                {
                    if(password == PasswordFromDatabase)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                return 0;
            }

        }
    }
}
