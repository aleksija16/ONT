using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat.Areas.Vodici
{
    public class AccountsModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public AccountsModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
        public IList<Models.Vodici> SviVodici {get; set;}
   
      public IActionResult OnGet()
        {
            SviVodici = dbContext.Vodici.ToList();
            return Page();
    
        }
         public async Task<IActionResult> OnPostObrisiAsync(uint id)
        {
            Models.Vodici PostojiVodic = await dbContext.Vodici.FindAsync(id);

            if (PostojiVodic != null)
            {
                dbContext.Vodici.Remove(PostojiVodic);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToPage("./Index");

        }

    }
}
