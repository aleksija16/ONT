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
    public class RezervacijaJednaModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public RezervacijaJednaModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
		[BindProperty]
        public Rezervacije TrenutnaRezervacija {get; set;}

        [BindProperty]
        public IList<Znamenitosti> ZnamenitostiUCustomRezervaciji {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            SessionId=SessionClass.SessionId;

            if (SessionId != null)
            {
                if (SessionClass.TipKorisnika == "A")
                {
                    TrenutnaRezervacija = await dbContext.Rezervacije
                        .Where(x=>x.IdRezervacije == (uint)id).FirstOrDefaultAsync();  
                }
                else if (SessionClass.TipKorisnika == "T")
                {
                    TrenutnaRezervacija = await dbContext.Rezervacije.Include(x => x.IdTureRNavigation)
                        .Where(x=>x.IdRezervacije == (uint)id).FirstOrDefaultAsync();
                }
                else if (SessionClass.TipKorisnika == "V")
                {
                    TrenutnaRezervacija = await dbContext.Rezervacije
                        .Where(x=>x.IdRezervacije == (uint)id).FirstOrDefaultAsync();
                }            

                TrenutnaRezervacija.IdTureRNavigation = await dbContext.Ture.Where(x => x.IdTure == TrenutnaRezervacija.IdTureR).FirstOrDefaultAsync();
                TrenutnaRezervacija.IdVodicaRNavigation = await dbContext.Vodici.Where(x => x.IdVodica == TrenutnaRezervacija.IdVodicaR).FirstOrDefaultAsync();
                TrenutnaRezervacija.IdTuristeRNavigation = await dbContext.Turisti.Where(x => x.IdTuriste == TrenutnaRezervacija.IdTuristeR).FirstOrDefaultAsync();

                if(TrenutnaRezervacija==null){
                    return NotFound();
                }

                if (TrenutnaRezervacija.IdTureRNavigation.TipTure == "C")
                {
                    IQueryable<Znamenitosti> qZnamenitosti = dbContext.ZnamenitostiUTurama
                        .Where(x => x.IdTureZut == TrenutnaRezervacija.IdTureR).Select(x => x.IdZnamenitostiZutNavigation);

                    ZnamenitostiUCustomRezervaciji = await qZnamenitosti.ToListAsync();
                }                        
            }

            return Page();
        }
    }
}
