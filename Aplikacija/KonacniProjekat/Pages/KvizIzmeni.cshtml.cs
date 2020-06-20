using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KonacniProjekat
{
    public class KvizIzmeniModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public KvizIzmeniModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        [BindProperty]
        public int KvizId {get; set;}

        [BindProperty]
        public Kvizovi OvajKviz {get; set;}

        [BindProperty(SupportsGet=true)]
        public string IzabranaZnamenitostString {get; set;}

        public SelectList IzborZnamenitostiLista {get; set;}
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (SessionClass.TipKorisnika != "A")
            {
                return StatusCode(403);
            }

            KvizId = id;
            OvajKviz = await dbContext.Kvizovi.FindAsync((uint)KvizId);

            if(OvajKviz == null)
            {
                 return NotFound();
            }

            IQueryable<string> qZnamenitosti = dbContext.Znamenitosti.Select(X=>X.NazivZnamenitosti);
            IzborZnamenitostiLista = new SelectList(qZnamenitosti.ToList());
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            OvajKviz.IdKviza = (uint)KvizId;   
       
            IQueryable<Znamenitosti> qIzabranaZnamenitost = dbContext.Znamenitosti.Where(x=>x.NazivZnamenitosti == IzabranaZnamenitostString);


            if(IzabranaZnamenitostString == "")
            {
                OvajKviz.IdZnamenitostiKNavigation = null;
            }
            else
            {
                OvajKviz.IdZnamenitostiKNavigation = await qIzabranaZnamenitost.FirstOrDefaultAsync();
            }

            dbContext.Kvizovi.Attach(OvajKviz).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return RedirectToPage("./KvizSvi", new { id = SessionId});
        }
    }
}
