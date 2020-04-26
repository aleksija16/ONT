using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace MyApp.Namespace
{
    public class AddTureModel : PageModel
    {
        private readonly OrganizacijaContext dbContext;

        [BindProperty]
        public Ture JednaTura {get; set;}

        public IList<Znamenitosti> SveZnamenitosti;

        public Ture TrenutnaTura{get;set;}

        public IList<Vodici> SviVodici;

        [BindProperty]
        public string ErrorMessage {get; set;}

        public AddTureModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public void OnGet()
        {
            IQueryable<Vodici> qVodici = dbContext.Vodici;
            SviVodici=qVodici.ToList();
            
            IQueryable<Znamenitosti> qZnamenitosti=dbContext.Znamenitosti;
            SveZnamenitosti=qZnamenitosti.ToList();
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
                    dbContext.Ture.Add(JednaTura);
                    await dbContext.SaveChangesAsync();

                    return RedirectToPage("./Ture");
                }
            }
        }
    }
}