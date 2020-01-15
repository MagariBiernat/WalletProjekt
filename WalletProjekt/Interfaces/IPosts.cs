using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletProjekt.Interfaces
{
    interface IPosts
    {
        float amount { get; set; }
        string category { get; set; }
        string type { get; set; }
        string desc { get; set; }
        string useremail { get; set; }
        int postId { get; set; }
        DateTime datetime { get; set; }
        bool AddNewPost();
        void ReadTenPosts(int page);
        bool DeletePost(int Id);
        void ReadLastMonth();

        
    }
}
