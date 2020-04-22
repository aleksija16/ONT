using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace MyApp.Namespace
{
    public class OceniVodicaModel : PageModel
    {
        public readonly OrganizacijaContext dbContext;
        [BindProperty]
        public OcenjivanjeVodica JednaOcena {get; set;}

        public OceniVodicaModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnPostAsync(uint id)
        {
            JednaOcena.IdVodicaOcenjivanje = id;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                await dbContext.OcenjivanjeVodica.AddAsync(JednaOcena);
                await dbContext.SaveChangesAsync();

                return RedirectToPage("./JedanVodic");

            }
        }
    }
}
