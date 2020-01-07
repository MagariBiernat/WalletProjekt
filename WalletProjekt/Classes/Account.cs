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
        public int AddUserToDatabase()
        {
            

            SqlCommand command = new SqlCommand();
            using (SqlConnection myCon = new SqlConnection(conn))
            using (myCon)
            {
                command.CommandText = "INSERT INTO users (email,password,date_created,firstName,lastName) " +
                    "VALUES ('@email',@password','@date_created','@firstName','@lastName');";
                command.Parameters.AddWithValue("@email",_email);
                command.Parameters.AddWithValue("@password",_password);
                command.Parameters.AddWithValue("@date_created",_dateCreated.ToString("yyyy/MM/dd H:mm:ss"));
                command.Parameters.AddWithValue("@firstName",_firstName);
                command.Parameters.AddWithValue("@lastName",_lastName);
                using(command)
                {
                    myCon.Open();
                    command.Connection = myCon;
                    int ExecuteReturnValue = command.ExecuteNonQuery();

                    if (ExecuteReturnValue >= 0)
                    {
                        Added = true;
                        return 1;
                    }
                        
                    else
                        return 0;
                    
                }

            }
        }
    }
}
