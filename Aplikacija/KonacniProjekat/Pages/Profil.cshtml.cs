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
        public Korisnici Korisnik {get;set;}
         public async Task OnGetAsync(){
             if(SessionClass.TipKorisnika=="T")
             {
                Korisnik = await dbContext.Korisnici.Where(x=>x.IdTuristeK==SessionClass.SessionId).FirstOrDefaultAsync();
                Korisnik.IdTuristeKNavigation=await dbContext.Turisti.Where(x=>x.IdTuriste==Korisnik.IdTuristeK).FirstOrDefaultAsync();
                SveRezervacije = await dbContext.Rezervacije.Where(x=>x.IdTuristeR==SessionClass.SessionId).ToListAsync();
                foreach(var rezervacija in SveRezervacije)
                {
                     rezervacija.IdTureRNavigation=await dbContext.Ture.Where(x=>x.IdTure==rezervacija.IdTureR).FirstOrDefaultAsync();
                     rezervacija.IdVodicaRNavigation=await dbContext.Vodici.Where(x=>x.IdVodica==rezervacija.IdVodicaR).FirstOrDefaultAsync();
                }
                SveOcene = await dbContext.OcenjivanjeVodica.Where(x=>x.IdTuristeO==SessionClass.SessionId).ToListAsync();
                foreach(var ocena in SveOcene)
                {
                    ocena.IdVodicaONavigation=await dbContext.Vodici.Where(x=>x.IdVodica==ocena.IdVodicaO).FirstOrDefaultAsync();
                    ocena.IdTureONavigation= await dbContext.Ture.Where(x=>x.IdTure==ocena.IdTureO).FirstOrDefaultAsync();
                }
                SviHOF = await dbContext.HallOfFame.Where(x=>x.IdTuristeHof==SessionClass.SessionId).ToListAsync();
                foreach(var hof in SviHOF)
                {
                    hof.IdKvizaHofNavigation = await dbContext.Kvizovi.Where(x=>x.IdKviza==hof.IdKvizaHof).FirstOrDefaultAsync();
                }
            }

             else if(SessionClass.TipKorisnika=="V")
           {
                Korisnik = await dbContext.Korisnici.Where(x=>x.IdVodicaK==SessionClass.SessionId).FirstOrDefaultAsync();
                Korisnik.IdVodicaKNavigation=await dbContext.Vodici.Where(x=>x.IdVodica==Korisnik.IdVodicaK).FirstOrDefaultAsync();
                SveRezervacije = await dbContext.Rezervacije.Where(x=>x.IdVodicaR==SessionClass.SessionId).ToListAsync();
                foreach(var rezervacija in SveRezervacije)
                {
                     rezervacija.IdTureRNavigation=await dbContext.Ture.Where(x=>x.IdTure==rezervacija.IdTureR).FirstOrDefaultAsync();
                     rezervacija.IdTuristeRNavigation=await dbContext.Turisti.Where(x=>x.IdTuriste==rezervacija.IdTuristeR).FirstOrDefaultAsync();
                }
                SveOcene = await dbContext.OcenjivanjeVodica.Where(x=>x.IdVodicaO==SessionClass.SessionId).ToListAsync();
                foreach(var ocena in SveOcene)
                {
                    ocena.IdTureONavigation= await dbContext.Ture.Where(x=>x.IdTure==ocena.IdTureO).FirstOrDefaultAsync();
                }
                SveTure = await dbContext.Ture.Where(x=>x.IdVodica==SessionClass.SessionId).ToListAsync();
           }
        }
    }
}
