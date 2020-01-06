using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletProjekt.Classes
{
    public class Account : IAccount
    {
        public string _email { get; set; }
        public string _password { get; set; }
        public string _firstName { get; set; }
        public string _lastName { get; set; }
    }
}
