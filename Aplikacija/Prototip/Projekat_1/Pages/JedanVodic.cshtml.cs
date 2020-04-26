using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class JedanVodicModel : PageModel
    {
        public OrganizacijaContext dbContext {get; set;}

        [BindProperty]
        public Vodici TrenutniVodic {get; set;}

        public JedanVodicModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IActionResult OnGet(int id)
        {
            TrenutniVodic = dbContext.Vodici.Where(x=>x.IdVodica == id).FirstOrDefault();
            return Page();
        }
    }
}
