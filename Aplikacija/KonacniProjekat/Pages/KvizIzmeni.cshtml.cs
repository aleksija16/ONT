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
        public int? PostojiVec {get; set;}

        [BindProperty]
        public Kvizovi OvajKviz {get; set;}

        [BindProperty]
        public string TrenutniNaziv {get; set;}

        [BindProperty(SupportsGet=true)]
        public string IzabranaZnamenitostString {get; set;}

        [BindProperty(SupportsGet=true)]
        public string IzabranaTuraString {get; set;}

        public SelectList IzborZnamenitostiLista {get; set;}

        public SelectList IzborTuraLista {get; set;}
        
        public async Task<IActionResult> OnGetAsync(int id, int? postoji)
        {
            KvizId = id;
            OvajKviz = await dbContext.Kvizovi.FindAsync((uint)KvizId);

            PostojiVec = postoji;

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

            TrenutniNaziv = OvajKviz.NazivKviza;

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

            if (TrenutniNaziv != OvajKviz.NazivKviza)
            {
                Kvizovi PostojiKviz = await dbContext.Kvizovi.Where(x => x.NazivKviza == OvajKviz.NazivKviza).FirstOrDefaultAsync();
                if (PostojiKviz != null)
                {
                    PostojiVec = 1;
                    OvajKviz.NazivKviza = TrenutniNaziv;
                    return RedirectToPage("./KvizIzmeni", new{id = KvizId, postoji = PostojiVec});
                }
            }
       
            

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
