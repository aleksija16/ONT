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
        
        [BindProperty(SupportsGet=true)]
        public string IzabranaZnamenitostString {get; set;}

        public SelectList IzborZnamenitostiLista {get; set;}

        public async Task OnGetAsync(int? id)
        {
            SessionId = id;
            IQueryable<string> qZnamenitosti = dbContext.Znamenitosti.Select(X=>X.NazivZnamenitosti);

            IzborZnamenitostiLista = new SelectList(qZnamenitosti.ToList());
           
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (NoviKviz==null)
            {
                return Page();
            }

            IQueryable<Znamenitosti> qIzabranaZnamenitost = dbContext.Znamenitosti.Where(x=>x.NazivZnamenitosti == IzabranaZnamenitostString);

            if (IzabranaZnamenitostString=="")
            {
                NoviKviz.IdZnamenitostiKNavigation = null;
            }
            else
            {
                NoviKviz.IdZnamenitostiKNavigation = await qIzabranaZnamenitost.FirstOrDefaultAsync();
            }
            dbContext.Kvizovi.Add(NoviKviz);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./KvizSvi");
        }
    }
}
