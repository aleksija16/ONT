using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class PitanjaModel : PageModel
    {
        public OrganizacijaContext dbContext {get; set;}

        public IList<Pitanje> SvaPitanja;
    public IList<Odgovor> SviOdgovori;
        public PitanjaModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IActionResult OnGet()
        {
            SvaPitanja=dbContext.Pitanje.ToList();
            return Page();
        }

         public async Task<IActionResult> OnPostObrisiAsync(uint id)
        {
            Pitanje PostojiPitanje = await dbContext.Pitanje.FindAsync(id);
            
            if (PostojiPitanje != null)
            {
                
                dbContext.Pitanje.Remove(PostojiPitanje);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToPage();

        }
    }
}
