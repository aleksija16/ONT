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
    public class KvizDodajModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public KvizDodajModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        [BindProperty]
        public Kvizovi NoviKviz {get; set;}

        [BindProperty]
        public int? PostojiVec {get; set;}

        [BindProperty(SupportsGet=true)]
        public string IzabranaZnamenitostString {get; set;}

        [BindProperty(SupportsGet=true)]
        public string IzabranaTuraString {get; set;}

        public SelectList IzborZnamenitostiLista {get; set;}

        public SelectList IzborTuraLista {get; set;}

        public async Task<IActionResult> OnGetAsync(int? postoji)
        {
            IQueryable<string> qZnamenitosti = dbContext.Znamenitosti.Select(X=>X.NazivZnamenitosti);
            IzborZnamenitostiLista = new SelectList(await qZnamenitosti.ToListAsync());

            IQueryable<string> qTure = dbContext.Ture.Where(x => x.TipTure == "T").Select(X=>X.NazivTure);
            IzborTuraLista = new SelectList(await qTure.ToListAsync());
           
            PostojiVec = postoji;

           return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (NoviKviz==null)
            {
                return Page();
            }

            IQueryable<Znamenitosti> qIzabranaZnamenitost = dbContext.Znamenitosti.Where(x=>x.NazivZnamenitosti == IzabranaZnamenitostString);
            IQueryable<Ture> qIzabranaTura = dbContext.Ture.Where(x=>x.NazivTure == IzabranaTuraString);

            if (IzabranaZnamenitostString=="")
            {
                NoviKviz.IdZnamenitostiKNavigation = null;
            }
            else
            {
                NoviKviz.IdZnamenitostiKNavigation = await qIzabranaZnamenitost.FirstOrDefaultAsync();
            }

            if (IzabranaTuraString=="")
            {
                NoviKviz.IdTureKNavigation = null;
            }
            else
            {
                NoviKviz.IdTureKNavigation = await qIzabranaTura.FirstOrDefaultAsync();
            }

            Kvizovi PostojiKviz = await dbContext.Kvizovi.Where(x => x.NazivKviza == NoviKviz.NazivKviza).FirstOrDefaultAsync();
            if (PostojiKviz != null)
            {
                PostojiVec = 1;
                return RedirectToPage("./KvizDodaj", new{postoji = PostojiVec});
            }

            dbContext.Kvizovi.Add(NoviKviz);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./KvizSvi");
        }
    }
}
