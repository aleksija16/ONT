using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KonacniProjekat
{
    public class VodicDodajModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public VodicDodajModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
        [BindProperty]
        public Vodici NoviVodic {get; set;}

        [BindProperty]
        public Korisnici NoviKorisnik {get; set;}


         public async Task<IActionResult> OnPostAsync()
       {
           if(!ModelState.IsValid)
           {
               return Page();
           }
           else{
                dbContext.Vodici.Add(NoviVodic);
                await dbContext.SaveChangesAsync();
                NoviKorisnik.IdTuristeK=NoviVodic.IdVodica;
                NoviKorisnik.TipKorisnika=Convert.ToString("V");
                dbContext.Korisnici.Add(NoviKorisnik);
               
                await dbContext.SaveChangesAsync();
                return RedirectToPage("./VodicSviNalozi");
            }
       }
    }
}
