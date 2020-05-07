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
    public class VodicJedanModel : PageModel
    {
        public int? SessionId {get; set;}
        [BindProperty]
        public Models.Vodici Vodici { get; set; }
        public readonly OrganizacijaContext dbContext;

        public VodicJedanModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
        
         public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vodici = await dbContext.Vodici.FirstOrDefaultAsync(m => m.IdVodica == id);

            if (Vodici == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
