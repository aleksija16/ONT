using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KonacniProjekat.Models;
using Microsoft.EntityFrameworkCore;

namespace KonacniProjekat
{
    public class VodicObrisiModel : PageModel
    {
        [BindProperty]
        public Vodici VodicZaBrisanje {get; set;}
         [BindProperty]
        public IList<Rezervacije> Rezervacije {get;set;}
        public readonly OrganizacijaContext dbContext;

        public VodicObrisiModel(OrganizacijaContext db){
            dbContext=db;
        }
        public int provera=0;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            VodicZaBrisanje=await dbContext.Vodici.Where( x => x.IdVodica ==(uint)id).FirstOrDefaultAsync();
            IQueryable<Rezervacije> qRezervacije = dbContext.Rezervacije.Where(x=>x.Datum>DateTime.Now);
            Rezervacije= await qRezervacije.Where(a =>a.IdVodicaR==(uint)id).ToListAsync();
             foreach(var item in Rezervacije)
             {
                 if(item.IdVodicaR==(uint)id)
                 {
                    provera=1;
                 }
             }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
        
            VodicZaBrisanje=await dbContext.Vodici.FindAsync((uint)id);

            if(VodicZaBrisanje==null){
                return NotFound();
            }

            dbContext.Vodici.Remove(VodicZaBrisanje);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./VodicSvi");
        }
    }
}
