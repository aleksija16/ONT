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
    public class TuraRezervisiModel : PageModel
    {
        [BindProperty]
        public int? SessionId{get;set;}

        [BindProperty]
        public int TuraId{get;set;}

        public Ture OvaTura {get; set;}

        [BindProperty]
        public Rezervacije RezervacijaTure{get;set;}

        public readonly OrganizacijaContext dbContext;

        public TuraRezervisiModel(OrganizacijaContext db){
            dbContext=db;
        }

        public async Task<IActionResult>OnGetAsync(int id)
        {
            SessionId = SessionClass.SessionId;
            TuraId=id;

            OvaTura=await dbContext.Ture.Where( x => x.IdTure == (uint)TuraId).FirstOrDefaultAsync();

            if(OvaTura==null){
                return NotFound();
            }

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(){
            if(RezervacijaTure==null){
                return this.Page();
            }

            RezervacijaTure.IdTureRNavigation=await dbContext.Ture.FindAsync((uint)TuraId);
            RezervacijaTure.IdTureR=RezervacijaTure.IdTureRNavigation.IdTure;
            RezervacijaTure.IdTuristeR=(uint)SessionClass.SessionId;
            RezervacijaTure.IdVodicaR = await dbContext.Ture.Where(x=>x.IdTure==(uint)TuraId).Select(x=>x.IdVodica).FirstOrDefaultAsync();
            
            await dbContext.Rezervacije.AddAsync(RezervacijaTure);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./RezervacijaSve");
        }

        
    }
}
