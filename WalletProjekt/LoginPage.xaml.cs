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

namespace WalletProjekt
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            LoginRegisterViewLogin();


        }
        public void LoginRegisterViewRegister()
        {
            LoginRegisterView.DataContext = new RegisterModel();
        }
        public void LoginRegisterViewLogin()
        {
            LoginRegisterView.DataContext = new LoginModel();
        }
    }
}
