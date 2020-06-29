using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KonacniProjekat
{
    public class OdjavaModel : PageModel
    {
        public int? SessionId {get; set;}
        [BindProperty]
        public Korisnici TrenutniKorisnik {get; set;}
        public readonly OrganizacijaContext dbContext;

        public OdjavaModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }          
            else
            {
                SessionClass.SessionId=null;
                SessionClass.TipKorisnika="";
               
                return RedirectToPage("./Index");
            }
        }
    }
}
