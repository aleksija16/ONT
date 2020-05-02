using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat.Pages
{
    public class PrijavaModel : PageModel
    {
        [BindProperty]
        public Korisnici TrenutniKorisnik {get; set;}
       [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public PrijavaModel(OrganizacijaContext db)
        {
            dbContext = db;
           SessionId = null;
        }
         public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }          
            else
            {
                Korisnici PostojiKorisnik = dbContext.Korisnici.Where(x=>x.Username == TrenutniKorisnik.Username).FirstOrDefault();
                if (PostojiKorisnik != null && PostojiKorisnik.Password == TrenutniKorisnik.Password)
                {
                    
                    return RedirectToPage("./Index");
                }
                else
                {
                SessionId = -1;
                    return Page();
                }

            }
        }
    }
}
