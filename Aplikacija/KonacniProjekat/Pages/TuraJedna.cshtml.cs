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
    public class TuraJednaModel : PageModel
    {
        public int? SessionId {get; set;}

        [BindProperty]
        public Ture Ture {get; set;}
        public readonly OrganizacijaContext dbContext;

        public TuraJednaModel(OrganizacijaContext db)
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

            Ture = await dbContext.Ture.FirstOrDefaultAsync(m => m.IdTure == id);

            if (Ture == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}