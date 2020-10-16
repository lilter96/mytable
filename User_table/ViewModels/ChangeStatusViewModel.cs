using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_table.Models;

namespace User_table.ViewModels
{
    public class ChangeStatusViewModel
    {
        public ChangeStatusViewModel()
        {
            AllUserNames = new List<User>();
            UnblockedUserNames = new List<string>();
        }
        public string UserName { get; set; }
        public IList<User> AllUserNames { get; set; }
        public IList<string> UnblockedUserNames { get; set; }
    }
}
