using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KonacniProjekat
{
    public class TuraDodajModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public TuraDodajModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

         public Ture NovaTura{get;set;}

        public async Task<IActionResult> OnPostAsync(){
            if(!ModelState.IsValid){
                return Page();
            }
            else{
                dbContext.Ture.Add(NovaTura);
                await dbContext.SaveChangesAsync();

                return RedirectToPage("./TuraSve");
            }
        }
    }
}
