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
using System.Data.Sql;
using System.Data.SqlClient;

namespace WalletProjekt.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        public Register()
        {
            InitializeComponent();
        }

        private void PizzaCheckBoxRegistrationForm_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dayuum mate, You just won a free pizza ");
        }

        private void BackFromRegistrationForm_Click(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent(this);
            while (!(parent is Page))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
           // (parent as LoginPage).CenterView.Width = 350;
            (parent as LoginPage).LoginRegisterViewLogin();

        }
        private void RegisterButtonFinish_Click(object sender, RoutedEventArgs e)
        {
            
            RegisterUser();
            // Account new_user = new Account() { _firstName = , _lastName = }
        }
        private void RegisterUser()
        {
            if (CheckIfFormCorrectAndNotEmpty())
            {
                if (PasswordsAreEqual())
                {
                    if(TermsAgreed())
                    {
                        if (CheckIfEmailExistsInDatabase(EmailVar.Text))
                        {
                            Account newUser = new Account()
                            {
                                _email = EmailVar.Text,
                                _password = FirstPassword.Password,
                                _firstName = FirstNameVar.Text,
                                _lastName = LastNameVar.Text
                            };
                            int result = newUser.AddUserToDatabase();
                            if (result >= 0 )
                            {
                                MessageBox.Show("User has been successfully created. Please log in now.");

                                var parent = VisualTreeHelper.GetParent(this);
                                while (!(parent is Page))
                                {
                                    parent = VisualTreeHelper.GetParent(parent);
                                }
                                (parent as LoginPage).LoginRegisterViewLogin();
                            }
                            else
                            {
                                MessageBox.Show("An error has occured while creating a new user. ");
                            }

                        }
                        else
                        {
                            MessageBox.Show("An account with this email already exists.");
                            
                        }
                    }
                    else { MessageBox.Show("Please agree to our terms."); } 
                    
                }
                else
                {
                    MessageBox.Show("Passwords are not equal!");
                }
            }
            else
            {
                MessageBox.Show("Some of fields are empty.");
            }
        }
        private bool CheckIfEmailExistsInDatabase(string email)
        {
            SqlCommand command = new SqlCommand();
            using(SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                command.CommandText = "SELECT * FROM users WHERE email = @email";
                command.Parameters.AddWithValue("@email", email);
                using(command)
                {
                    myCon.Open();
                    command.Connection = myCon;
                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

        }

        private bool TermsAgreed()
        {
            if (TermsCheckBox.IsChecked == true)
                return true;
            else
                return false;
        }
        private bool CheckIfFormCorrectAndNotEmpty()
        {
            if (string.IsNullOrEmpty(FirstNameVar.Text)
                || string.IsNullOrEmpty(LastNameVar.Text)
                || string.IsNullOrEmpty(EmailVar.Text)
                || string.IsNullOrEmpty(FirstPassword.Password)
                || string.IsNullOrEmpty(SecondPassword.Password))
            {
                return false;
                
            }
            return true;
        }
        private bool PasswordsAreEqual()
        {
            if (FirstPassword.Password != SecondPassword.Password)
            {
                return false;
            }
            else
                return true;
        }
    }
}
