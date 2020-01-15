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
        string useremail { get; set; }
<<<<<<< Updated upstream
        void AddNewPost();
        void ReadThirtyPosts();
        void DeletePost();
=======
        int postId { get; set; }
        DateTime datetime { get; set; }
        bool AddNewPost();
        void ReadTenPosts(int page);
        bool DeletePost(int Id);
        float ReadLastMonth();
>>>>>>> Stashed changes

        
    }
}
