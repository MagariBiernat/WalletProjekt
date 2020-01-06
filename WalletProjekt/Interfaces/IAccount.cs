using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletProjekt
{
     interface IAccount
    {
        string _email { get; set; }
        string _password { get; set; }
        string _firstName { get; set; }
        string _lastName { get; set; }
    }
}
