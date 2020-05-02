using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat.Areas.Vodici
{
    public class AddModel : PageModel
    {
      //  [BindProperty]
       // public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

         public AddModel(OrganizacijaContext db)
        {
            dbContext = db;
          //  SessionId = null;
        }
        
        [BindProperty]
        public Models.Vodici NoviVodic { get; set; }
        [BindProperty]
        public Models.Korisnici NoviKorisnik { get; set; }
     public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else{
                dbContext.Vodici.Add(NoviVodic);
                await dbContext.SaveChangesAsync();
                NoviKorisnik.IdVodicaK=NoviVodic.IdVodica;
                NoviKorisnik.TipKorisnika=Convert.ToString("V");
                dbContext.Korisnici.Add(NoviKorisnik);
               
                await dbContext.SaveChangesAsync();
              return RedirectToPage("/ViewOne?=NoviVodic.IdVodica", new { area = "Vodici" });
            }
        }
  
    }
}
