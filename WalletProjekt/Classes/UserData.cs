using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletProjekt.Interfaces;

namespace WalletProjekt.Classes
{
    public class UserData : IUserData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime lastLoginDate { get; set; }
        public float balance { get; set; }
        public int SalaryDay { get; set; }
        public float SalaryAmount { get; set; }

    }
}
