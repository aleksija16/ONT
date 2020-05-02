using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat.Pages
{
    public class RegistracijaModel : PageModel
    {
        public readonly OrganizacijaContext dbContext;
        [BindProperty]
        public Turisti NoviTurista{ get; set;}
        [BindProperty]
        public Korisnici NoviKorisnik{ get; set;}
      //  public int? SessionId {get; set;}
   

        public RegistracijaModel(OrganizacijaContext db)
        {
            dbContext = db;
          //  SessionId = null;
        }
        
       public async Task<IActionResult> OnPostAsync()
       {
           if(!ModelState.IsValid)
           {
               return Page();
           }
           else{
                dbContext.Turisti.Add(NoviTurista);
                await dbContext.SaveChangesAsync();
                NoviKorisnik.IdTuristeK=NoviTurista.IdTuriste;
                NoviKorisnik.TipKorisnika=Convert.ToString("T");
                dbContext.Korisnici.Add(NoviKorisnik);
               
                await dbContext.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
       }
    }
}
