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

        public async Task OnGetAsync()
        {
            SviVodici = dbContext.Vodici.ToList();
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

        public async Task<IActionResult> OnPostIzmeniAsync(uint id)
        {
            return RedirectToPage();
        }
    }
}
