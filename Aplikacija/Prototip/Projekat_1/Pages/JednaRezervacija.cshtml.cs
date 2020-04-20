using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class JednaRezervacijaModel : PageModel
    {
        public OrganizacijaContext dbContext {get; set;}

        [BindProperty]
        public Rezervacije TrenutnaRezervacija {get; set;}

        public JednaRezervacijaModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IActionResult OnGet(int id)
        {
            TrenutnaRezervacija = dbContext.Rezervacije.Where(x=>x.IdRezervacije == id).FirstOrDefault();
            return Page();
        }
    }
}
