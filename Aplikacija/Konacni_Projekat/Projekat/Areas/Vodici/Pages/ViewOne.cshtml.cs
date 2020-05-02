using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekat.Models;

namespace Projekat.Areas.Vodici
{
    public class ViewOneModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public ViewOneModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
         public Models.Vodici Vodici { get; set; }

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
