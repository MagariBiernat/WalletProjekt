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
        private int PostsRows { get; set;}
        public Posts()
        {
            GetUser();
            InitializeComponent();
            PostsRows = GetNumberOfRows();
            if(PostsRows <= 10)
            {
                NextPageButton.IsEnabled = false;
            }
            DisplayTenPosts(1);
        }
        private void GetUser()
        {
            user = ((MainWindow)App.Current.MainWindow).GetUserData();
        }
        private void DisplayTenPosts(int page)
        {
            PostsData.ItemsSource = null;
            string dbname = "PostsDatabase" + user.userId.ToString();
            SqlCommand comm = new SqlCommand();
            int OFFSET = (page - 1) * 10;
            using(SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                if (page == 1)
                {
                    comm.CommandText = "SELECT TOP 10 Id, amount, category, profit, datetime ,description FROM " + dbname+" ORDER BY datetime DESC ";
                }
                else
                    comm.CommandText = "SELECT Id, amount, category,profit, datetime ,description FROM " + dbname + " ORDER BY datetime DESC OFFSET "+OFFSET+" ROWS FETCH NEXT 10 ROWS ONLY";
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
            int page = Convert.ToInt32(PageNumber.Text);
            page -= 1;
            if(page >= 1)
            {
                if (page == 1)
                {
                    PreviousPageButton.IsEnabled = false;
                }
                NextPageButton.IsEnabled = true;
                PageNumber.Text = page.ToString();
                DisplayTenPosts(page);
                
            }
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            int page = Convert.ToInt32(PageNumber.Text);
            page += 1;
            float pages = (float)PostsRows / 10;
            if((page-1 * 10) < PostsRows)
            {
                if((page * 10) > PostsRows)
                {
                    NextPageButton.IsEnabled = false;
                }
                PreviousPageButton.IsEnabled = true;
                PageNumber.Text = page.ToString();
                DisplayTenPosts(page);
            }
            
        }
        private void DeleteRow(int id)
        {
            string dbname = "PostsDatabase" + user.userId.ToString();
            SqlCommand command = new SqlCommand();
            SqlConnection myCon = new SqlConnection(conn);
            using (myCon)
            {
                command.CommandText = "DELETE FROM " + dbname + " WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                myCon.Open();
                command.Connection = myCon;
                command.ExecuteNonQuery();
                myCon.Close();
            }

            
        }
        private void DeletePost_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)PostsData.SelectedItem;
            int selected_id = Convert.ToInt32(drv["Id"]);
            DeleteRow(selected_id);
            DisplayTenPosts(Convert.ToInt32(PageNumber.Text));
        }
        private void MoreInfo_Click(object sender, RoutedEventArgs e)
        {
            string dbname = "PostsDatabase" + user.userId.ToString();
            DataRowView drv = (DataRowView)PostsData.SelectedItem;
            int selected_id = Convert.ToInt32(drv["Id"]);

            SqlCommand command = new SqlCommand();
            SqlConnection myCon = new SqlConnection(conn);
            using (myCon)
            {
                command.CommandText = "SELECT amount, category, datetime, description FROM "+dbname+" WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", selected_id);
                myCon.Open();
                command.Connection = myCon;
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        var amount = float.Parse(reader["amount"].ToString());
                        var category = reader["category"].ToString();
                        var datetime = reader["datetime"].ToString();
                        var description = reader["description"].ToString();
                        var MoreInfo = new MoreInfo
                        {
                            Amount = amount,
                            Category = category,
                            Description = description,
                            Datetime = datetime
                        };
                        MaterialDesignThemes.Wpf.DialogHost.Show(MoreInfo);
                    }
                }

                myCon.Close();
            }

        }
       
        private int GetNumberOfRows()
        {
            string dbname = "PostsDatabase" + user.userId.ToString();
            string stmt = "SELECT COUNT(*) FROM "+dbname;
            int count = 0;
            using (SqlConnection myCon = new SqlConnection(conn))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, myCon))
                {
                    myCon.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;
        }
    }
    class MoreInfo
    {
        public float Amount { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Datetime { get; set; }
    }
}
