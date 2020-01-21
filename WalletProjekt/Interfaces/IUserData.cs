using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletProjekt.Interfaces
{
    interface IUserData
    {
        string firstName { get; set; }
        string lastName { get; set; }
        string email { get; set; }
        DateTime dateCreated { get; set; }
        DateTime lastLoginDate { get; set; }
        float balance { get; set; }
        int SalaryDay { get; set; }
        float SalaryAmount { get; set; }

        float GetBalance();

    }
}
