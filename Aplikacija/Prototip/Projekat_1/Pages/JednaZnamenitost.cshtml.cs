using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class JednaZnamenitostModel : PageModel
    {
        public OrganizacijaContext dbContext {get; set;}

        [BindProperty]
        public Znamenitosti TrenutnaZnamenitost {get; set;}

        public JednaZnamenitostModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IActionResult OnGet(int id)
        {
            TrenutnaZnamenitost = dbContext.Znamenitosti.Where(x=>x.IdZnamenitosti == id).FirstOrDefault();
            return Page();
        }
    }
}
