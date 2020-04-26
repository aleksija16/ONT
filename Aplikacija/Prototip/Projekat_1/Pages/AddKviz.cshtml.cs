
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
    public class AddKvizModel : PageModel
    {
        private readonly OrganizacijaContext dbcontex;

        public AddKvizModel(OrganizacijaContext db)
        {
            dbcontex=db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kviz Kviz {get; set;}

        public async Task<IActionResult> OnPostAsync()
        {
             if (!ModelState.IsValid)
            {
                return Page();
            }

            dbcontex.Kviz.Add(Kviz);
            await dbcontex.SaveChangesAsync();

            return RedirectToPage("./Kvizovi");
        }

    }
}