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
    public class KvizIzmeniPitanjeModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        [BindProperty(SupportsGet=true)]
        public int PitanjeId {get; set;}

        [BindProperty(SupportsGet=true)]
        public int KvizId {get; set;}

        [BindProperty(SupportsGet=true)]
        public Pitanja OvoPitanje {get; set;}

        [BindProperty]
        public int IzborTacnogOdgovoraInt {get; set;}

        public KvizIzmeniPitanjeModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (SessionClass.TipKorisnika != "A")
            {
                return this.StatusCode(403);
            }
            
            PitanjeId = id;

            OvoPitanje = await dbContext.Pitanja.Include(x=>x.IdKvizaNavigation).Where(x=>x.IdPitanja == (uint)PitanjeId).FirstOrDefaultAsync();
            KvizId = (int)OvoPitanje.IdKviza;

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            OvoPitanje.IdPitanja = (uint)PitanjeId;

            OvoPitanje.IdKvizaNavigation = await dbContext.Kvizovi.FindAsync((uint)KvizId);

            switch(IzborTacnogOdgovoraInt){
                case 1:  OvoPitanje.TacanOdgovor = OvoPitanje.OdgovorA;
                    break;
                case 2: OvoPitanje.TacanOdgovor = OvoPitanje.OdgovorB;
                    break;
                case 3: OvoPitanje.TacanOdgovor = OvoPitanje.OdgovorC;
                    break;
            };

            dbContext.Pitanja.Attach(OvoPitanje).State = EntityState.Modified;  
            await dbContext.SaveChangesAsync();
            return RedirectToPage("./KvizJedan", new {id = KvizId});
        

        }
    }
}
