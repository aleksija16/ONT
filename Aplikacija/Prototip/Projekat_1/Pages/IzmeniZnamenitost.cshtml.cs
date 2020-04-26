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
    public class IzmeniZnamenitostModel : PageModel
    {
        public OrganizacijaContext dbContext {get; set;}

        [BindProperty]
        public Znamenitosti TrenutnaZnamenitost {get; set;}

        public IzmeniZnamenitostModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IActionResult OnGet(int id)
        {
            TrenutnaZnamenitost = dbContext.Znamenitosti.Where(x=>x.IdZnamenitosti == id).FirstOrDefault();
            if(TrenutnaZnamenitost==null)
            {
                return RedirectToPage("./Znamenitosti");
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
                dbContext.Znamenitosti.Attach(TrenutnaZnamenitost).State=EntityState.Modified;
                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch(DbUpdateException e)
                {
                    throw new Exception("Greska: " + e.ToString());
                }
                return RedirectToPage("./Znamenitosti");
            }
        }
    }
}