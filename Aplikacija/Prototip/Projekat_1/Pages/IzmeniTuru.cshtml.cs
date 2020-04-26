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
    public class IzmeniTuruModel : PageModel
    {
        private readonly OrganizacijaContext dbContext;

        [BindProperty]
        public Ture TrenutnaTura {get; set;}

        public IzmeniTuruModel(OrganizacijaContext db)
        {
            dbContext=db;
        }
        public async Task<IActionResult> OnPostAsync(uint id)
        {
            TrenutnaTura = await dbContext.Ture.Where(x=>x.IdTure == id).FirstOrDefaultAsync();
            if(TrenutnaTura==null)
            {
                return RedirectToPage("./Ture");
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
                dbContext.Ture.Attach(TrenutnaTura).State=EntityState.Modified;
                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch(DbUpdateException e)
                {
                    throw new Exception("Greska: " + e.ToString());
                }
                return RedirectToPage("./Ture");
            }
        }
        
    }
}
