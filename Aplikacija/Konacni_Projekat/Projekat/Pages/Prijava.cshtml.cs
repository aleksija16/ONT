using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat.Pages
{
    public class PrijavaModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public PrijavaModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
        public void OnGet()
        {
        }
    }
}
