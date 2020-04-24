using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Projekat_1.Model;

namespace Projekat_1
{
    public class PrijavaModel : PageModel
    {
        [BindProperty]
        public Korisnici TrenutniKorisnik {get; set;}

        [BindProperty]
        public int? SessionId {get; set;}

        public enum TipKorisnika
        {
            Admin,
            Turista,
            Vodic
        }

        [BindProperty]
        public TipKorisnika TipTrenutnogKorisnika {get;set;}

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
                    SessionId = (int?)PostojiKorisnik.IdKorisnika;
                    
                    if (PostojiKorisnik.IdTuristeKor!=null)
                    {
                        TipTrenutnogKorisnika = TipKorisnika.Turista;
                    } 
                    else if (PostojiKorisnik.IdVodicaKor != null) 
                    {
                        TipTrenutnogKorisnika = TipKorisnika.Vodic;
                    }
                    else 
                    {
                        TipTrenutnogKorisnika = TipKorisnika.Admin;
                    }

                    return Page();
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
