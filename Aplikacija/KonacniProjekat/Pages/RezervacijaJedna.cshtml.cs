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

        public async Task<IActionResult> OnGetAsync(int? id, int rezervacija)
        {
            SessionId=id;

            TrenutnaRezervacija = await dbContext.Rezervacije.Where(x=>x.IdRezervacije == (uint)rezervacija).FirstOrDefaultAsync();

            if(TrenutnaRezervacija==null){
                return NotFound();
            }
            return Page();
        }
    }
}
