using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekat_1.Model;

namespace Projekat_1
{
    public class EditPitanjeModel : PageModel
    {
        private readonly OrganizacijaContext dbcontext;

        public EditPitanjeModel(OrganizacijaContext db)
        {
            dbcontext = db;
        }

        [BindProperty]
        public Pitanje Pitanje { get; set; }

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pitanje = await dbcontext.Pitanje
                .Include(p => p.Kviz).FirstOrDefaultAsync(m => m.IdPitanje == id);

            if (Pitanje == null)
            {
                return NotFound();
            }
           ViewData["KvizId"] = new SelectList(dbcontext.Kviz, "Idkviz", "Nazivkviza");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            dbcontext.Attach(Pitanje).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PitanjaExists(Pitanje.IdPitanje))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Pitanja");
        }

        private bool PitanjaExists(uint id)
        {
            return dbcontext.Pitanje.Any(e => e.IdPitanje == id);
        }
    }
}
