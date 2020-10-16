using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace User_table.Views.User
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<int> AreChecked { get; set; }
    }
}
