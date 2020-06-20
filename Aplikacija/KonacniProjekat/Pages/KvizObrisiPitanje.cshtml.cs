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
    public class KvizObrisiPitanjeModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        
        public readonly OrganizacijaContext dbContext;

        [BindProperty]
        public int PitanjeId {get; set;}
        
        [BindProperty]
        public Pitanja PitanjeZaBrisanje {get; set;}

        public KvizObrisiPitanjeModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (SessionClass.TipKorisnika == "A")
            {
                PitanjeId = id;
                PitanjeZaBrisanje = await dbContext.Pitanja.Include(x=>x.IdKvizaNavigation).Where(x=>x.IdPitanja == (uint)PitanjeId).FirstOrDefaultAsync();
                if (PitanjeZaBrisanje == null) return NotFound();
                
                return this.Page();
            }
            
            return this.StatusCode(403);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            PitanjeZaBrisanje = await dbContext.Pitanja.FindAsync((uint)PitanjeId);

            if (PitanjeZaBrisanje == null)
            {
                return NotFound();
            }

            int IdKviza = (int)PitanjeZaBrisanje.IdKviza;
            dbContext.Pitanja.Remove(PitanjeZaBrisanje);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./KvizJedan", new { id = IdKviza});
        
        }
    }
}
