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
    public class VodicOceniModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public VodicOceniModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        [BindProperty]
         public OcenjivanjeVodica JednaOcena {get; set;}
        [BindProperty]
        public IList<Rezervacije> TuristaRezervacije{get;set;}
        public int provera=0;
        public async Task OnGetAsync(int id)
        {
             IQueryable<Rezervacije> qTure = dbContext.Rezervacije.Include(x => x.IdTureRNavigation).Where(Y=>Y.IdTuristeR == SessionClass.SessionId);
             TuristaRezervacije= await qTure.Where(a =>a.IdVodicaR==(uint)id).ToListAsync();
             foreach(var item in TuristaRezervacije)
             {
                 if(item.IdVodicaR==(uint)id)
                 {
                    provera=1;
                 }
             }

        }
         public async Task<IActionResult> OnPostAsync(int id)
       {
           if(!ModelState.IsValid)
           {
               return Page();
           }
           else{
                JednaOcena.IdTuristeO=(uint)SessionClass.SessionId;
                JednaOcena.IdVodicaO=(uint)id;
                dbContext.OcenjivanjeVodica.Add(JednaOcena);
                await dbContext.SaveChangesAsync();
      
                var KonacnaOcena = dbContext.OcenjivanjeVodica.Where(x=>x.IdVodicaO==(uint)id).ToList();

                var VodicZaOcenjivanje = await dbContext.Vodici.FindAsync((uint)id);
            
                VodicZaOcenjivanje.Ocena=(decimal)KonacnaOcena.Average(y=>y.Ocena);          

                await dbContext.SaveChangesAsync();

                return RedirectToPage("./VodicSvi");

            }
       }
    }
}
