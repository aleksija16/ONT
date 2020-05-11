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
    public class TuraSveModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public TuraSveModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

		 [BindProperty]
         public IList<Ture> SveTure{get;set;}

        public async Task OnGetAsync(int? id){
            SessionId=id;

            IQueryable<Ture> qTure=dbContext.Ture;
            SveTure=await qTure.ToListAsync();
        }
		
		public async Task<IActionResult> OnPostRezervisiAsync(uint tura)
        {
            Ture PostojiTura = await dbContext.Ture.FindAsync(tura);

            if (PostojiTura != null)
            {
                Rezervacije NovaRezervacija = new Rezervacije();

                NovaRezervacija.IdTureR=PostojiTura.IdTure;
                
                await dbContext.Rezervacije.AddAsync(NovaRezervacija);
                await dbContext.SaveChangesAsync();

                
                return RedirectToPage("./RezervacijaSve"); 
            }
            else return Page();
        }
    }
}
