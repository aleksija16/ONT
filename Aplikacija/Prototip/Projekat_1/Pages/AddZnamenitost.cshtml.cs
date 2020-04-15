using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace MyApp.Namespace
{
    public class AddZnamenitostModel : PageModel
    {
        private readonly OrganizacijaContext dbContext;

        [BindProperty]
        public Znamenitosti JednaZnamenitost {get; set;}

        [BindProperty]
        public string ErrorMessage {get; set;}

        public AddZnamenitostModel(OrganizacijaContext db)
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
                //Znamenitosti postojiVecTaZnamenitost = dbContext.Znamenitosti.Where(x=>x.NazivZnamenitosti==JednaZnamenitost.NazivZnamenitosti).FirstOrDefault();
                //if (postojiVecTaZnamenitost != null)
                //{
                  //  ErrorMessage="Vec postoji znamenitost sa tim imenom.";
                    //return Page();
                //}
                //else
                {
                    dbContext.Znamenitosti.Add(JednaZnamenitost);
                    await dbContext.SaveChangesAsync();

                    return RedirectToPage("./Znamenitosti");
                }
            }
        }
    }
}
