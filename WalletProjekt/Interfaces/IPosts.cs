using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletProjekt.Interfaces
{
    interface IPosts
    {
        int amount { get; set; }
        string category { get; set; }
        string type { get; set; }
        string desc { get; set; }
        void AddNewPost();

        
    }
}
