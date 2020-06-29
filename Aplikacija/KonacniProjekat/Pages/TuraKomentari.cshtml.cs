using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class TuraKomentariModel : PageModel
    {

        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public TuraKomentariModel(OrganizacijaContext db){
            dbContext=db;
            SessionId=null;
        }

        [BindProperty]
        public Ture Tura {get; set;}

        [BindProperty]
        public IList<Anketa> RezultatiAnketa{get;set;}
        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if(id==null){
                return NotFound();
            }

            Tura = await dbContext.Ture.FirstOrDefaultAsync(m => m.IdTure == id);
            if (Tura == null)
            {
                return NotFound();
            }

            RezultatiAnketa = await dbContext.Anketa.Where(x => x.IdTureAnk == id).ToListAsync();

            

            return Page();
        }
    }
}
