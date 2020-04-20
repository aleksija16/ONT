using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace MyApp.Namespace
{
    public class KorisnickiNaloziVodicaModel : PageModel
    {

        public IList<Vodici> SviVodici {get; set;}
        
        public OrganizacijaContext dbContext {get; set;}

        public KorisnickiNaloziVodicaModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IActionResult OnGet()
        {
            SviVodici = dbContext.Vodici.ToList();
            return Page();
    
        }

        public async Task<IActionResult> OnPostObrisiAsync(uint id)
        {
            Vodici PostojiVodic = await dbContext.Vodici.FindAsync(id);

            if (PostojiVodic != null)
            {
                dbContext.Vodici.Remove(PostojiVodic);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToPage();

        }


    }
}
