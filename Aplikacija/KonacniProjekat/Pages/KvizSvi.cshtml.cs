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
    public class KvizSviModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public IList<Kvizovi> SviKvizovi {get; set;}

        public KvizSviModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        public async Task OnGetAsync(int? id)
        {
            SessionId = id;

            IQueryable<Kvizovi> qKvizovi = dbContext.Kvizovi.Include(x=>x.IdZnamenitostiKNavigation);
            SviKvizovi = await qKvizovi.ToListAsync();
        }
    }
}
