using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat.Areas.Znamenitosti
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public IndexModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
        public void OnGet()
        {
        }
    }
}
