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
          public IList<Ture> SveTure{get;set;}
        public IList<HallOfFame> SviHOF{get;set;}
         public async Task OnGetAsync(){
             if(SessionClass.TipKorisnika=="T")
             {
            SveRezervacije = await dbContext.Rezervacije.Where(x=>x.IdTuristeR==SessionClass.SessionId).ToListAsync();
            SveOcene = await dbContext.OcenjivanjeVodica.Where(x=>x.IdTuristeO==SessionClass.SessionId).ToListAsync();
            SviHOF = await dbContext.HallOfFame.Where(x=>x.IdTuristeHof==SessionClass.SessionId).ToListAsync();
             }
             else if(SessionClass.TipKorisnika=="V")
           {
            SveRezervacije = await dbContext.Rezervacije.Where(x=>x.IdVodicaR==SessionClass.SessionId).ToListAsync();
            SveOcene = await dbContext.OcenjivanjeVodica.Where(x=>x.IdVodicaO==SessionClass.SessionId).ToListAsync();
            SveTure = await dbContext.Ture.Where(x=>x.IdVodica==SessionClass.SessionId).ToListAsync();
           }
        }
    }
}
