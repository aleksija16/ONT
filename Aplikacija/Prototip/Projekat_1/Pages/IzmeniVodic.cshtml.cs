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
    public class IzmeniVodicModel : PageModel
    {
        private readonly OrganizacijaContext dbContext;

        [BindProperty]
        public Vodici TrenutniVodic {get; set;}

        public IzmeniVodicModel(OrganizacijaContext db)
        {
            dbContext=db;
        }
        public async Task<IActionResult> OnPostAsync(uint id)
        {
            TrenutniVodic = await dbContext.Vodici.Where(x=>x.IdVodica == id).FirstOrDefaultAsync();
            if(TrenutniVodic==null)
            {
                return RedirectToPage("./KorisnickiNaloziVodica");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSacuvajAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                dbContext.Vodici.Attach(TrenutniVodic).State=EntityState.Modified;
                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch(DbUpdateException e)
                {
                    throw new Exception("Greska: " + e.ToString());
                }
                return RedirectToPage("./KorisnickiNaloziVodica");
            }
        }
        
    }
}
