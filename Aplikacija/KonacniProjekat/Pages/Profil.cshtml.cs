using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KonacniProjekat
{
    public class ProfilModel : PageModel
    {
        public readonly OrganizacijaContext dbContext;

        public ProfilModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IList<Rezervacije> SveRezervacije{get;set;}
         public IList<OcenjivanjeVodica> SveOcene{get;set;}

         public async Task OnGetAsync(){
            SveRezervacije = await dbContext.Rezervacije.Where(x=>x.IdTuristeR==SessionClass.SessionId).ToListAsync();
            SveOcene = await dbContext.OcenjivanjeVodica.Where(x=>x.IdTuristeO==SessionClass.SessionId).ToListAsync();
        }
    }
}
