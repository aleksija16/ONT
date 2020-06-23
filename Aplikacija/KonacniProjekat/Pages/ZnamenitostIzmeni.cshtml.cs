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
    public class ZnamenitostIzmeniModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public ZnamenitostIzmeniModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
        [BindProperty]
       public Znamenitosti TrenutnaZnamenitost{get;set;}

         [BindProperty]
        public int ZnamenitostId{get;set;}

        [BindProperty]
        public Slike NovaSlika{get;set;}
         //int zid;
       public async Task<IActionResult> OnGetAsync(int id){

        SessionId = SessionClass.SessionId;

        ZnamenitostId=id;
           
         TrenutnaZnamenitost = await dbContext.Znamenitosti.FindAsync((uint)ZnamenitostId);

           if(TrenutnaZnamenitost==null)
           {
               return RedirectToPage("./ZnamenitostSve");
           }
           return Page();
       }


       public async Task<IActionResult> OnPostAsync()
       {
        
           if(!ModelState.IsValid)
           {
               return Page();
           }

           TrenutnaZnamenitost.IdZnamenitosti=(uint)ZnamenitostId;
           
           dbContext.Znamenitosti.Attach(TrenutnaZnamenitost).State=EntityState.Modified;
           await dbContext.SaveChangesAsync();

           return RedirectToPage("./ZnamenitostSve");
           }
       
    }
}
