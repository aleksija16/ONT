using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KonacniProjekat
{
    public class TuraJednaModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public TuraJednaModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }

        [BindProperty]
        public Ture Ture {get; set;}

        [BindProperty]
        public Anketa RezultatiAnkete{get;set;}

        [BindProperty]
        public Vodici VodicTure{get;set;}

         public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null)
             {
                 return NotFound();
            }

            Ture = await dbContext.Ture.FirstOrDefaultAsync(m => m.IdTure == id);
            RezultatiAnkete=await dbContext.Anketa.FirstOrDefaultAsync(r=>r.IdTureAnk==id);
            VodicTure=await dbContext.Vodici.FirstOrDefaultAsync(e=>e.IdVodica==Ture.IdVodica);


            if (Ture == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
