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
    public class TuraObrisiModel : PageModel
    {
        [BindProperty]
        public int? SessionId{get;set;}

        [BindProperty]
        public int TuraId{get;set;}

        public Ture TuraZaBrisanje {get; set;}
        public readonly OrganizacijaContext dbContext;

        public TuraObrisiModel(OrganizacijaContext db){
            dbContext=db;
        }
        public async Task<IActionResult>OnGetAsync(int id)
        {
            SessionId = SessionClass.SessionId;
            TuraId=id;

            TuraZaBrisanje=await dbContext.Ture.Where( x => x.IdTure ==(uint)TuraId).FirstOrDefaultAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            
            TuraId=id;
    
            TuraZaBrisanje=await dbContext.Ture.FindAsync((uint)TuraId);

            if(TuraZaBrisanje==null){
                return NotFound();
            }

            dbContext.Ture.Remove(TuraZaBrisanje);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./TuraSve");
        }
    }
}
