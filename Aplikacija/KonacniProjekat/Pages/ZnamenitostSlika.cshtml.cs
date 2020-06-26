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
    public class ZnamenitostSlikaModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public ZnamenitostSlikaModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
        [BindProperty]
        public Znamenitosti TrenutnaZnamenitost{get;set;}

        public int ZnamenitostId{get;set;}

        [BindProperty]
        public Slike NovaSlika{get;set;}
        public async Task<IActionResult> OnGet(int id){

            SessionId = SessionClass.SessionId;

            ZnamenitostId=id;

            TrenutnaZnamenitost=await dbContext.Znamenitosti.Where( x => x.IdZnamenitosti == (uint)ZnamenitostId).FirstOrDefaultAsync();

            return Page();
       }


       public async Task<IActionResult> OnPostAsync(int id)
       {
        
           if(!ModelState.IsValid)
           {
               return Page();
           }

       
            NovaSlika.IdZnamenitost= (uint)id;
            dbContext.Slike.Add(NovaSlika);
            await dbContext.SaveChangesAsync();

               return RedirectToPage("./ZnamenitostJedna", new {id = id});
           }
       
    }
}
