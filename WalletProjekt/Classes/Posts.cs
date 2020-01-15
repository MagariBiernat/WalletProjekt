using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletProjekt.Interfaces;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WalletProjekt.Classes
{
    class Posts : IPosts
    {
        private readonly string  conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        public int amount { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
<<<<<<< Updated upstream
=======
        public string useremail { get; set; }
        public int postId { get; set; }
        public DateTime datetime { get; set; }
        private string postsDbName { get; set; }
>>>>>>> Stashed changes

        public void AddNewPost()
        {
            SqlCommand comm = new SqlCommand();
            using(SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                comm.CommandText = "INSERT INTO posts";
                //
            }
<<<<<<< Updated upstream
=======

        }
        public float ReadLastMonth()
        {
            DateTime ThirtyDaysAgo = DateTime.Now.AddDays(-30);
            float lastMonthBalance = 0;
            postsDbName = useremail+"PostsDatabase";
            SqlCommand command = new SqlCommand();
            using(SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                command.CommandText = "SELECT amount,category FROM " + postsDbName + " where datetime > @ago";
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
                            if(reader["category"].ToString() == "profit")
                            {
                                int i = Convert.ToInt32(reader["amount"]);
                                lastMonthBalance += Convert.ToSingle(i);
                            }
                            else
                            {
                                int i = Convert.ToInt32(reader["amount"]);
                                lastMonthBalance -= Convert.ToSingle(i);
                            }
                        }
                            
                    }
                    return lastMonthBalance;
                }
            }


>>>>>>> Stashed changes
        }

    }
}
