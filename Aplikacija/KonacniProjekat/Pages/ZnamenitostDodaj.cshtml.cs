using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KonacniProjekat
{
    public class ZnamenitostDodajModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public ZnamenitostDodajModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
		[BindProperty]
        public Znamenitosti NovaZnamenitost{get;set;}

        public async Task<IActionResult> OnPostAsync(){
            if(!ModelState.IsValid){
                return Page();
            }
            else{
                dbContext.Znamenitosti.Add(NovaZnamenitost);
                await dbContext.SaveChangesAsync();

                return RedirectToPage("./ZnamenitostSve");
            }
        }
    }
}
