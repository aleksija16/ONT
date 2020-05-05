using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat.Areas.Znamenitosti
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

         public EditModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
       
	    [BindProperty]
        public Models.Znamenitosti TrenutnaZnamenitost {get; set;}

         public IActionResult OnGet(int id)
        {
            TrenutnaZnamenitost = dbContext.Znamenitosti.Where(x=>x.IdZnamenitosti == id).FirstOrDefault();
            if(TrenutnaZnamenitost==null)
            {
                return RedirectToPage("/Znamenitosti");
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
                return RedirectToPage("/Znamenitosti");
            }
        }
    }
}
