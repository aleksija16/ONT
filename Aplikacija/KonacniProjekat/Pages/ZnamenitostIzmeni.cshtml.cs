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
        public Slike NovaSlika{get;set;}
         //int zid;
       public IActionResult OnGet(int id){
           SessionId = SessionClass.SessionId;
           
           TrenutnaZnamenitost=dbContext.Znamenitosti.Where(x=>x.IdZnamenitosti==id).FirstOrDefault();
           if(TrenutnaZnamenitost==null){
               return RedirectToPage("./ZnamenitostSve");
           }
           return Page();
       }


       public async Task<IActionResult> OnPostSacuvajAsync(){
           if(!ModelState.IsValid){
               return Page();
           }
           else{
               dbContext.Znamenitosti.Attach(TrenutnaZnamenitost).State=EntityState.Modified;
               await dbContext.SaveChangesAsync();
              
               NovaSlika.IdZnamenitost= TrenutnaZnamenitost.IdZnamenitosti;
                dbContext.Slike.Add(NovaSlika);
                await dbContext.SaveChangesAsync();

               return RedirectToPage("./ZnamenitostSve");
           }
       }
    }
}
