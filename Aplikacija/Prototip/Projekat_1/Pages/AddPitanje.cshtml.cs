
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekat_1.Model;

namespace Projekat_1
{
    public class AddPitanjeModel : PageModel
    {
        private readonly OrganizacijaContext dbContext;
      
        [BindProperty]
        public string ErrorMessage {get; set;}

        public AddPitanjeModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

      

        [BindProperty]
        public Pitanje Pitanje { get; set; }
     
           public IActionResult OnGet()
        {
            return Page();
        }
      
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            dbContext.Pitanje.Add(Pitanje);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./Pitanja");
        }


        
    }
}

