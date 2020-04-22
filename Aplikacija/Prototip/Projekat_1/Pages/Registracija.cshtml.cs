using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Projekat_1.Model;

namespace MyApp.Namespace
{
    public class RegistracijaModel : PageModel
    {

        public OrganizacijaContext dbContext {get;set;}

        [BindProperty]
        public Turisti NoviTurista{get;set;}

        [BindProperty]
        public Korisnici NoviKorisnik{get; set;}

        public RegistracijaModel(OrganizacijaContext db){
            dbContext=db;
        }

        public async Task<IActionResult> OnPostAsync(){
            if(!ModelState.IsValid){
                return Page();
            }
            else{
                 dbContext.Korisnici.Add(NoviKorisnik);
                 NoviKorisnik.IdTuristeKor=NoviTurista.IdTuriste;
                dbContext.Turisti.Add(NoviTurista);
                
               
                await dbContext.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }

    }
}
