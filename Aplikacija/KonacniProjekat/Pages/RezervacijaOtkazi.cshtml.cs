using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KonacniProjekat.Models;

namespace KonacniProjekat
{
    public class RezervacijaOtkaziModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}

        [BindProperty]
        public int RezervacijaId {get; set;}

        public Rezervacije RezervacijaZaOtkazivanje {get; set;}

        public readonly OrganizacijaContext dbContext;

        public RezervacijaOtkaziModel(OrganizacijaContext db)
        {
            dbContext = db;
        } 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            RezervacijaId = id;
            SessionId = SessionClass.SessionId;

            RezervacijaZaOtkazivanje = await dbContext.Rezervacije.Include(x => x.IdTureRNavigation)
                .Where(x => x.IdRezervacije == RezervacijaId).FirstOrDefaultAsync();

            if (RezervacijaZaOtkazivanje == null || RezervacijaZaOtkazivanje.IdTuristeR != SessionId)
            {
                return NotFound();            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            RezervacijaZaOtkazivanje = await dbContext.Rezervacije.FindAsync((uint)RezervacijaId);

            if(RezervacijaZaOtkazivanje == null)
            {
                return NotFound();
            }

            dbContext.Rezervacije.Remove(RezervacijaZaOtkazivanje);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./RezervacijaSve");
        }
    }
}
