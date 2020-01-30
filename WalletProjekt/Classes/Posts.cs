using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletProjekt.Interfaces;
using WalletProjekt.Views;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WalletProjekt.Classes
{
    class Posts : IPosts
    {
        UserData user = new UserData();
        private readonly string  conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        public float amount { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public string useremail { get; set; }
        public int postId { get; set; }
        public DateTime datetime { get; set; }
        private string postsDbName { get; set; }


        public bool AddNewPost(int _amount, string _category,string _profit, string _desc, string email ,int Id)
        {
            datetime = DateTime.Now;
            SqlCommand comm = new SqlCommand();
            using(SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                comm.CommandText = "INSERT INTO PostsDatabase"+Id.ToString()+" (amount , category , profit, datetime, description) VALUES (@amount, @category, @profit, @datetime , @desc)";
                comm.Parameters.AddWithValue("@amount", _amount);
                comm.Parameters.AddWithValue("@category", _category);
                comm.Parameters.AddWithValue("@profit", _profit);
                comm.Parameters.Add("@datetime", System.Data.SqlDbType.Date).Value = datetime;
                comm.Parameters.AddWithValue("@desc", _desc);
                using(comm)
                {
                    myCon.Open();
                    comm.Connection = myCon;
                    int result = comm.ExecuteNonQuery();
                    if (result != -1)
                    {
                        user.UpdateBalance(_amount, email);
                        return true;
                    }
                    else
                        return false;
                }
                
            }
        }
        

        public float ReadLastMonth(int Id)
        {
            DateTime ThirtyDaysAgo = DateTime.Now.AddDays(-30);
            float lastMonthBalance = 0;
            postsDbName = "PostsDatabase"+Id.ToString();
            SqlCommand command = new SqlCommand();
            using(SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                //command.CommandText = "SELECT * FROM " + useremail + "PostsDatabase ORDER BY datetime DESC LIMIT 10 OFFSET @OFFSET";

                //command.Parameters.AddWithValue("@OFFSET", OFFSET);
                command.CommandText = "SELECT amount,profit  FROM " + postsDbName + " where datetime > @ago";
                command.Parameters.AddWithValue("@ago", ThirtyDaysAgo);
                using(command)
                {
                    myCon.Open();
                    command.Connection = myCon;
                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            
                            if (reader["profit"].ToString() == "yes")
                            {
                                float i = float.Parse(reader["amount"].ToString());
                                lastMonthBalance += Convert.ToSingle(i);
                            }
                            else
                            {
                                float i = float.Parse(reader["amount"].ToString());
                                lastMonthBalance += Convert.ToSingle(i);
                            }
                        }

                    }
                    return lastMonthBalance;
                }
            }

        }
        public bool DeletePost(int Id)
        {
            SqlCommand command = new SqlCommand();
            postsDbName = "PostsDatabase" + Id.ToString();
            using (SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                command.CommandText = "DELETE FROM " + postsDbName + " WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", Id);
                using(command)
                {
                    myCon.Open();
                    command.Connection = myCon;
                    int result = command.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }

        }
        

    }
}
