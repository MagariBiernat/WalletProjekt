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
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        public int amount { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string desc { get; set; }

        public void AddNewPost()
        {
            SqlCommand comm = new SqlCommand();
            using(SqlConnection myCon = new SqlConnection(conn))
            using(myCon)
            {
                comm.CommandText = "INSERT INTO posts";
                //
            }
        }

    }
}
