using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class JednaTuraModel : PageModel
    {
        [BindProperty]
        public Ture TrenutnaTura {get; set;}

        public readonly OrganizacijaContext dbContext;

        public JednaTuraModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IActionResult OnGet(uint id)
        {  
            TrenutnaTura = dbContext.Ture.Where(x=>x.IdTure == id).FirstOrDefault();
            return Page();

        }
    }
}
