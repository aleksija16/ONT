using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat.Areas.Vodici
{
    public class RateModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public RateModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
        public void OnGet()
        {
        }
         [BindProperty]
        public OcenjivanjeVodica JednaOcena {get; set;}
         public async Task<IActionResult> OnPostAsync(uint id)
        {
            JednaOcena.IdVodicaO = id;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                await dbContext.OcenjivanjeVodica.AddAsync(JednaOcena);
                await dbContext.SaveChangesAsync();

                var KonacnaOcena = dbContext.OcenjivanjeVodica
                .Where(x=>x.IdVodicaO == id).Average(y=>y.Ocena);

                var VodicZaOcenjivanje = await dbContext.Vodici
                .FindAsync(id);
    
                VodicZaOcenjivanje.Ocena=(uint)KonacnaOcena;            

                await dbContext.SaveChangesAsync();

               return RedirectToAction("Index");

            }
        }
    }
}
