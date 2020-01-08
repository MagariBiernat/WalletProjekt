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
            Thread.Sleep(300);
            Test();


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
        private void Test()
        {
            var firstName = user.firstName;
            var email = user.email;
            Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(email)));
        }
    }
   
}
