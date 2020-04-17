using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace MyApp.Namespace
{
    public class AddVodicModel : PageModel
    {
        [BindProperty]
        public Vodici NoviVodic {get; set;}

        [BindProperty]
        public Korisnici NoviKorisnik {get; set;}

        public OrganizacijaContext dbContext  {get; set;}

        public AddVodicModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                
                dbContext.Korisnici.Add(NoviKorisnik);

                dbContext.Vodici.Add(NoviVodic);
                await dbContext.SaveChangesAsync();
                return Page();
            }
        }
    }
}
