using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WalletProjekt.Classes
{
    public class Account : IAccount
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        public string _email { get; set; }
        public string _password { get; set; }
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public DateTime _dateCreated = DateTime.Now;
        public bool Added = false;
        // Add user to database while registering.
        public int AddUserToDatabase()
        {


            SqlCommand command = new SqlCommand();
            using (SqlConnection myCon = new SqlConnection(conn))
            using (myCon)
            {
                string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");
                command.CommandText = "INSERT INTO Users (email,password,date_created,firstName,lastName) " +
                    "VALUES ('@email','@password',@date_created, 'firstName','@lastName');";
                command.Parameters.AddWithValue("@email", _email);
                command.Parameters.AddWithValue("@password", _password);
                command.Parameters.Add("@date_created", System.Data.SqlDbType.Date
                    ).Value = dateCreated;
                command.Parameters.AddWithValue("@firstName", _firstName);
                command.Parameters.AddWithValue("@lastName", _lastName);
                using (command)
                {
                    myCon.Open();
                    command.Connection = myCon;

                    int ExecuteReturnValue = command.ExecuteNonQuery();
                    myCon.Close();


                    if (ExecuteReturnValue >= 0)
                    {
                        Added = true;
                        CreatePostsDatabase();
                        return 1;
                    }

                    else
                        return 0;

                }

            }
        }
        // Create a table for user for his posts.
        public void CreatePostsDatabase()
        {
            string userName = _email + "PostsDatabase";
            SqlCommand comm = new SqlCommand();
            using (SqlConnection myCon = new SqlConnection(conn))
            using (myCon)
            {
                comm.CommandText = "CREATE TABLE [dbo].[" + userName + "]" +
                                    "([Id] INT NOT NULL PRIMARY KEY IDENTITY," +
                                    "[amount] FLOAT NOT NULL," +
                                    "[category] NVARCHAR(50) NOT NULL," +
                                    "[datetime] DATETIME2 NOT NULL," +
                                    "[desc] NVARCHAR(MAX) NULL )";
                using (comm)
                {
                    myCon.Open();
                    comm.Connection = myCon;
                    comm.ExecuteNonQuery();
                    myCon.Close();
                }
            }
        }
    }
}
