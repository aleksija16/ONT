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
        public int? PostojiVec {get; set;}

        [BindProperty]
        public Slike NovaSlika{get;set;}

        [BindProperty]
        public string TrenutniNaziv {get; set;}

        public async Task<IActionResult> OnGetAsync(int id, int? postoji){

        SessionId = SessionClass.SessionId;

        ZnamenitostId=id;
        PostojiVec = postoji;

        TrenutnaZnamenitost = await dbContext.Znamenitosti.FindAsync((uint)ZnamenitostId);

        if(TrenutnaZnamenitost==null)
        {
            return RedirectToPage("./ZnamenitostSve");
        }
        TrenutniNaziv = TrenutnaZnamenitost.NazivZnamenitosti;

        return Page();
       }


       public async Task<IActionResult> OnPostAsync(int id)
       {
           ZnamenitostId=id;
        
           if(!ModelState.IsValid)
           {
               return Page();
           }

           Znamenitosti PostojiZnamenitost = await dbContext.Znamenitosti.Where(x => x.NazivZnamenitosti == TrenutnaZnamenitost.NazivZnamenitosti).FirstOrDefaultAsync();
           if (PostojiZnamenitost != null)
           {
                PostojiVec = 1;
                TrenutnaZnamenitost.NazivZnamenitosti = TrenutniNaziv;
                return RedirectToPage("./ZnamenitostIzmeni", new{id = ZnamenitostId, postoji = PostojiVec});
           }

           TrenutnaZnamenitost.IdZnamenitosti=(uint)ZnamenitostId;
           
           dbContext.Znamenitosti.Attach(TrenutnaZnamenitost).State=EntityState.Modified;
           await dbContext.SaveChangesAsync();

           return RedirectToPage("./ZnamenitostJedna", new {id = id});
           }
       
    }
}
