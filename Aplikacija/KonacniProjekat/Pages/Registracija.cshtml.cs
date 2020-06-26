using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KonacniProjekat
{
    public class RegistracijaModel : PageModel
    {
        public int? SessionId {get; set;}
        [BindProperty]
        public Turisti NoviTurista{ get; set;}
        [BindProperty]
        public Korisnici NoviKorisnik{ get; set;}

        [BindProperty]
        public bool PostojiVec {get; set;}

        public readonly OrganizacijaContext dbContext;

        public RegistracijaModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId=null;
        }

         public async Task<IActionResult> OnPostAsync()
       {
           if(!ModelState.IsValid)
           {
               return Page();
           }
           else{

                Korisnici PostojiUsername = dbContext.Korisnici.Where(x => x.Username == NoviKorisnik.Username).FirstOrDefault();
                if (PostojiUsername != null)
                {
                    PostojiVec = true;
                    return this.Page();
                }
               
                dbContext.Turisti.Add(NoviTurista);
                await dbContext.SaveChangesAsync();
                NoviKorisnik.IdTuristeK=NoviTurista.IdTuriste;
                NoviKorisnik.TipKorisnika=Convert.ToString("T");
                dbContext.Korisnici.Add(NoviKorisnik);
               
                await dbContext.SaveChangesAsync();
                return RedirectToPage("./Prijava");
            }
       }
    }
}
