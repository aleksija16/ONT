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
    public class ZnamenitostObrisiModel : PageModel
    {
        [BindProperty]
        public int? SessionId{get;set;}

        [BindProperty]
        public int ZnamenitostId{get;set;}

        public Znamenitosti ZnamenitostZaBrisanje {get; set;}
        public readonly OrganizacijaContext dbContext;
        public ZnamenitostObrisiModel(OrganizacijaContext db){
            dbContext=db;
        }
        public async Task<IActionResult>OnGetAsync(int znamenitost)
        {
            ZnamenitostId=znamenitost;

            ZnamenitostZaBrisanje=await dbContext.Znamenitosti.Where( x => x.IdZnamenitosti == (uint)ZnamenitostId).FirstOrDefaultAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(){
    
            ZnamenitostZaBrisanje=await dbContext.Znamenitosti.FindAsync((uint)ZnamenitostId);

            if(ZnamenitostZaBrisanje==null){
                return NotFound();
            }

            dbContext.Znamenitosti.Remove(ZnamenitostZaBrisanje);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./ZnamenitostSve");
        }
    }
}
