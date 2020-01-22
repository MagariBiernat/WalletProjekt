using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletProjekt.Interfaces
{
    interface IUserData
    {
        int userId { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string email { get; set; }
        DateTime dateCreated { get; set; }
        DateTime lastLoginDate { get; set; }
        float balance { get; set; }
        int SalaryDay { get; set; }
        float SalaryAmount { get; set; }

        float GetBalance();
        bool UpdateProfileDatabase(string firstN, string lastN, float SalaryA, int SalaryD, string email);
        bool UpdateBalance(int amount, string email);

    }
}
