using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekat_1.Model;

namespace Projekat_1
{
    public class DeletePitanjeModel : PageModel
    {
        private readonly OrganizacijaContext dbcontext;

        public DeletePitanjeModel(OrganizacijaContext db)
        {
            dbcontext = db;
        }

        [BindProperty]
        public Pitanje Pitanja { get; set; }

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pitanja = await dbcontext.Pitanje
                .Include(p => p.Kviz).FirstOrDefaultAsync(m => m.IdPitanje == id);

            if (Pitanja == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pitanja = await dbcontext.Pitanje.FindAsync(id);

            if (Pitanja != null)
            {
                dbcontext.Pitanje.Remove(Pitanja);
                await dbcontext.SaveChangesAsync();
            }

            return RedirectToPage("./Pitanja");
        }
    }
}
