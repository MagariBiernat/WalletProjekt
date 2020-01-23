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
using System.Data;

namespace WalletProjekt.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Posts.xaml
    /// </summary>
    public partial class Posts : UserControl
    {
        UserData user;
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        // ??? int num = 0;
        public Posts()
        {
            GetUser();
            InitializeComponent();
            DisplayTenPosts(1);
        }
        private void GetUser()
        {
            user = ((MainWindow)App.Current.MainWindow).GetUserData();
        }
        private void DisplayTenPosts(int page)
        {
            string dbname = "PostsDatabase"+user.userId.ToString();
            page = Convert.ToInt32(PageNumber.Text);
            page *= 10;
            SqlCommand comm = new SqlCommand();
            using(SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                if (PageNumber.Text == "1")
                {
                    comm.CommandText = "SELECT TOP 10 Id, amount, category, profit,datetime,description FROM " + dbname+" ORDER BY datetime DESC ";
                }
                else
                    comm.CommandText = "SELECT Id, amount, category,profit, datetime,description FROM " + dbname + " ORDER BY datetime DESC OFFSET "+page+" ROWS FETCH NEXT 10 ROWS ONLY";
                myCon.Open();
                comm.Connection = myCon;
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable dt = new DataTable(dbname);
                adapter.Fill(dt);
                PostsData.ItemsSource = dt.DefaultView;
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
