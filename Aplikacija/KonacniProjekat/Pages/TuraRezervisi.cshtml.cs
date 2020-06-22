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

        [BindProperty]
        public IList<Rezervacije> RezervacijeUzTuru{get;set;}

        
        public uint? TrenutnaPopunjenostTure=0;

        [BindProperty]
        public int KapacitetTure{get;set;}

        [BindProperty]
        public int? NeuspesnaRezervacija{get;set;}
        public async Task<IActionResult>OnGetAsync(int? id, int? neuspesno)
        {
            if(id!=null){
                TuraId=(int)id;
            }      

            NeuspesnaRezervacija=(int?)neuspesno;      
          
            OvaTura=await dbContext.Ture.Where( x => x.IdTure == (uint)id).FirstOrDefaultAsync();

            
            KapacitetTure=(int)OvaTura.Kapacitet;

            IQueryable<Rezervacije> qRezervacije=dbContext.Rezervacije.Where(x=>x.IdTureR==TuraId);
            RezervacijeUzTuru=await qRezervacije.ToListAsync();

            foreach(var r in RezervacijeUzTuru){
                TrenutnaPopunjenostTure+=r.BrojOsoba;
            }
            

            if(OvaTura==null){
                return NotFound();
            }

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if(RezervacijaTure==null){
                return this.Page();
            }

           

            if(KapacitetTure>=(RezervacijaTure.BrojOsoba+TrenutnaPopunjenostTure))
            {
            RezervacijaTure.IdTureRNavigation=await dbContext.Ture.FindAsync((uint)id);
            RezervacijaTure.IdTureR=RezervacijaTure.IdTureRNavigation.IdTure;
            RezervacijaTure.IdTuristeR=(uint)SessionClass.SessionId;
            RezervacijaTure.IdVodicaR = await dbContext.Ture.Where(x=>x.IdTure==id).Select(x=>x.IdVodica).FirstOrDefaultAsync();
            
            await dbContext.Rezervacije.AddAsync(RezervacijaTure);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./RezervacijaSve");
            }
            NeuspesnaRezervacija=1;
            return RedirectToPage("./TuraRezervisi", new{id=TuraId, neuspesno=NeuspesnaRezervacija});
        }

        
    }
}
