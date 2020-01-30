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
    public class UserData : IUserData
    {
        private readonly string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        public int userId {get;set;}
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime lastLoginDate { get; set; }
        public float balance { get; set; }
        public int SalaryDay { get; set; }
        public float SalaryAmount { get; set; }

        public float GetBalance()
        {
            return balance;
        }
        public float UpdateBalance(float value)
        {
            balance += value;
            return balance;
        }
        public void UpdateProfileNew()
        {
            SqlCommand comm = new SqlCommand();
            SqlConnection myCon = new SqlConnection(conn);
            using(myCon)
            {
                myCon.Open();
                comm.Connection = myCon;
                comm.CommandText = "SELECT firstName, lastName, monthly_salary, dayofmonth_salary FROM Users WHERE email = @email";
                comm.Parameters.AddWithValue("@email", this.email);
                SqlDataReader reader = comm.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.firstName = reader["firstName"].ToString();
                        this.lastName = reader["lastName"].ToString();
                        this.SalaryAmount = float.Parse(reader["monthly_salary"].ToString());
                        this.SalaryDay = Convert.ToInt32(reader["dayofmonth_salary"]);
                        break;
                    }
                }
            }
        }
        public bool UpdateProfileDatabase(string firstN, string lastN, float SalaryA, int SalaryD, string email)
        {
            SqlCommand comm = new SqlCommand();
            using(SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                comm.CommandText = "UPDATE Users SET firstName = @firstName, lastName = @lastName, monthly_salary = @salaryAmount, dayofmonth_salary = @salaryDay WHERE email = @email";
                comm.Parameters.AddWithValue("@firstName", firstN);
                comm.Parameters.AddWithValue("@lastName", lastN);
                comm.Parameters.AddWithValue("@salaryAmount", SalaryA);
                comm.Parameters.AddWithValue("@salaryDay", SalaryD);
                comm.Parameters.AddWithValue("@email", email);
                using (comm)
                {
                    myCon.Open();
                    comm.Connection = myCon;
                    int result = comm.ExecuteNonQuery();
                    if (result != -1)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        public bool UpdateBalance(int amount, string email)
        {
            float newbalance = balance + amount;
            SqlCommand comm = new SqlCommand();
            using (SqlConnection myCon = new SqlConnection(conn))
            using (myCon)
            {
                comm.CommandText = "UPDATE Users SET balance = @balance WHERE email = @email";
                comm.Parameters.AddWithValue("@balance", newbalance);
                comm.Parameters.AddWithValue("@email", email);
                using (comm)
                {
                    myCon.Open();
                    comm.Connection = myCon;
                    int result = comm.ExecuteNonQuery();
                    if (result != -1)
                    {
                        balance = newbalance;
                        return true;
                    }
                    else
                        return false;
                }
            }


        }
    }
}