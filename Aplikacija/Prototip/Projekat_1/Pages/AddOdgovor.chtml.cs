
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace MyApp.Namespace
{
    public class AddOdgovorModel : PageModel
    {
        private readonly OrganizacijaContext dbContext;

        [BindProperty]
        public Odgovor JedanOdgovor {get; set;}

        [BindProperty]
        public string ErrorMessage {get; set;}

        public AddOdgovorModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            } 
            else
            {
                
                {
                    dbContext.Odgovor.Add(JedanOdgovor);
                    await dbContext.SaveChangesAsync();

                    return RedirectToPage("./Pitanja");
                }
            }
        }
    }
}

