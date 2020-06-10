using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KonacniProjekat
{
    public class PrijavaModel : PageModel
    {
        public int? SessionId {get; set;}
        [BindProperty]
        public Korisnici TrenutniKorisnik {get; set;}
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
                    SessionClass.TipKorisnika=PostojiKorisnik.TipKorisnika;
                    if(PostojiKorisnik.TipKorisnika=="V")
                    {
                          SessionClass.SessionId=(int)PostojiKorisnik.IdVodicaK;
                    }
                    else if(PostojiKorisnik.TipKorisnika=="T")
                    {
                         SessionClass.SessionId=(int)PostojiKorisnik.IdTuristeK;
                    }
                     else if(PostojiKorisnik.TipKorisnika=="A")
                    {
                         SessionClass.SessionId=(int)PostojiKorisnik.IdKorisnika;
                    }
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
