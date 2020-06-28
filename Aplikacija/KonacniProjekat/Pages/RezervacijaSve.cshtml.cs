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
    public class RezervacijaSveModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public RezervacijaSveModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IList<Rezervacije> SveRezervacije{get;set;}

        public async Task OnGetAsync(int? id){

            SessionId=SessionClass.SessionId;

            if (SessionId != null)
            {
                if (SessionClass.TipKorisnika == "A")
                {
                    IQueryable<Rezervacije> qRezervacije = dbContext.Rezervacije;
                    SveRezervacije=await qRezervacije.ToListAsync();
                    foreach(var rezervacija in SveRezervacije)
                    {
                        rezervacija.IdTureRNavigation= await dbContext.Ture.Where(x=>x.IdTure == rezervacija.IdTureR).FirstOrDefaultAsync();
                    }
                    return;
                }

                if (SessionClass.TipKorisnika == "T")
                {
                    IQueryable<Rezervacije> qRezervacije = dbContext.Rezervacije.Where(x => x.IdTuristeR == SessionId);
                    SveRezervacije = await qRezervacije.ToListAsync();
                           foreach(var rezervacija in SveRezervacije)
                    {
                        rezervacija.IdTureRNavigation= await dbContext.Ture.Where(x=>x.IdTure == rezervacija.IdTureR).FirstOrDefaultAsync();
                    }
                    return;
                }

                if (SessionClass.TipKorisnika == "V")
                {
                    IQueryable<Rezervacije> qRezervacije = dbContext.Rezervacije.Where(x => x.IdVodicaR == SessionId);
                    SveRezervacije=await qRezervacije.ToListAsync();
                           foreach(var rezervacija in SveRezervacije)
                    {
                        rezervacija.IdTureRNavigation= await dbContext.Ture.Where(x=>x.IdTure == rezervacija.IdTureR).FirstOrDefaultAsync();
                    }
                    return;
                }


                
            }
            
        }
    }
}
