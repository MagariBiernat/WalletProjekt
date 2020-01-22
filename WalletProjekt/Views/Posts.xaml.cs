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
using System.Data.Sql;
using System.Data.SqlClient;

namespace WalletProjekt.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Posts.xaml
    /// </summary>
    public partial class Posts : UserControl
    {
        UserData user;
        // ??? int num = 0;
        public Posts()
        {
            GetUser();
            InitializeComponent();
        }
        private void GetUser()
        {
            user = ((MainWindow)App.Current.MainWindow).GetUserData();
        }
        private void DisplayTenPosts(int page)
        {
            string email = user.email+"PostsDatabase";
            page = Convert.ToInt32(PageNumber.Text);
            page *= 10;
            SqlCommand comm = new SqlCommand();
            using(SqlConnection myCon = new SqlConnection())
            using(myCon)
            {
                if (page == 1)
                {
                    comm.CommandText = "SELECT Id, amount, category,datetime,description FROM ";
                }
                else
                    comm.CommandText = "SELECT Id, amount, category,datetime,description FROM";


            }
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeletePost_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MoreInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
