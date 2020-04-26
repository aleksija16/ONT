using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;
using Microsoft.EntityFrameworkCore;

namespace Projekat_1
{
    public class ListaTuristaUzRezervacijuModel : PageModel
    {

        [BindProperty]
        public IQueryable<Rezervacije> TrenutnaRezervacija {get; set;}

        [BindProperty]
        public IList<Turisti> ListaTuristaUzRezervaciju {get; set;}

        [BindProperty]
        public string ImeTure {get; set;}

        [BindProperty]
        public Vodici VodicUzRezervaciju {get; set;}

        public readonly OrganizacijaContext dbContext;

        public ListaTuristaUzRezervacijuModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnGetAsync(uint id)
        {
            TrenutnaRezervacija = dbContext.Rezervacije
            .Include(x=>x.IdTuristeRezNavigation).Where(x=>x.IdTureRez==id);
            
            ListaTuristaUzRezervaciju = await TrenutnaRezervacija.Select(x=>x.IdTuristeRezNavigation).ToListAsync();
            ImeTure = TrenutnaRezervacija.Select(x=>x.IdTureRezNavigation.NazivTure).Distinct().FirstOrDefault();
            VodicUzRezervaciju = TrenutnaRezervacija.Select(x=>x.IdVodicaRezNavigation).FirstOrDefault();


            return Page();
        }
    }
}
