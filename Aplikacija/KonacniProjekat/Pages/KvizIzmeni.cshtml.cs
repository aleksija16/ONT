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

        [BindProperty(SupportsGet=true)]
        public string IzabranaTuraString {get; set;}

        public SelectList IzborZnamenitostiLista {get; set;}

        public SelectList IzborTuraLista {get; set;}
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            KvizId = id;
            OvajKviz = await dbContext.Kvizovi.FindAsync((uint)KvizId);

            if(OvajKviz == null)
            {
                 return NotFound();
            }

            if(OvajKviz.IdTureK != null)
            {
                IzabranaTuraString = await dbContext.Ture.Where(x => x.IdTure == OvajKviz.IdTureK).Select(x => x.NazivTure).FirstOrDefaultAsync();
            }
            
            if(OvajKviz.IdZnamenitostiK != null)
            {
                IzabranaZnamenitostString = await dbContext.Znamenitosti.Where(x => x.IdZnamenitosti == OvajKviz.IdZnamenitostiK).Select(x => x.NazivZnamenitosti).FirstOrDefaultAsync();
            }


            IQueryable<string> qZnamenitosti = dbContext.Znamenitosti.Select(X=>X.NazivZnamenitosti);
            IzborZnamenitostiLista = new SelectList(qZnamenitosti.ToList());
            
            IQueryable<string> qTure = dbContext.Ture.Where(x => x.TipTure == "T").Select(X=>X.NazivTure);
            IzborTuraLista = new SelectList(await qTure.ToListAsync());
            
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
            IQueryable<Ture> qIzabranaTura = dbContext.Ture.Where(x=>x.NazivTure == IzabranaTuraString);

            if(IzabranaZnamenitostString == "")
            {
                OvajKviz.IdZnamenitostiKNavigation = null;
            }
            else
            {
                OvajKviz.IdZnamenitostiKNavigation = await qIzabranaZnamenitost.FirstOrDefaultAsync();
            }

             if (IzabranaTuraString=="")
            {
                OvajKviz.IdTureKNavigation = null;
            }
            else
            {
                OvajKviz.IdTureKNavigation = await qIzabranaTura.FirstOrDefaultAsync();
            }

            dbContext.Kvizovi.Attach(OvajKviz).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return RedirectToPage("./KvizSvi");
        }
    }
}
