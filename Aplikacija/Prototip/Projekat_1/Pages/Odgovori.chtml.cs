using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class OdgovoriModel : PageModel
    {
        public OrganizacijaContext dbContext {get; set;}

        [BindProperty]
        public Odgovor TrenutnoPitanje {get; set;}
            public IList<Odgovor> SviOdgovori;
        public OdgovoriModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IActionResult OnGet(int id)
        {
           TrenutnoPitanje = dbContext.Odgovor.Where(x=>x.Pitanjeid == id).FirstOrDefault();

            IQueryable<Odgovor> qOdgovor = dbContext.Odgovor.Where(x => x.Pitanjeid==id);
            SviOdgovori = qOdgovor.ToList();
            return Page();
        }
    }
}
