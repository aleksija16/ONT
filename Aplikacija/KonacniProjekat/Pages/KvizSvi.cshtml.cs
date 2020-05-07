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

        [BindProperty]
        public IList<int> BrojPitanjaPoKvizu {get; set;}

        public KvizSviModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        public async Task OnGetAsync(int? id)
        {
            SessionId = id;

            IQueryable<Kvizovi> qKvizovi = dbContext.Kvizovi.Include(x=>x.IdZnamenitostiKNavigation).OrderBy(x=>x.IdKviza);
            SviKvizovi = await qKvizovi.ToListAsync();


            int NajveciIdKvizova = (int)(await qKvizovi.OrderByDescending(x=>x.IdKviza).FirstOrDefaultAsync()).IdKviza;

            BrojPitanjaPoKvizu = new List<int>();

            for (int i=0; i<NajveciIdKvizova; i++)
            {
                BrojPitanjaPoKvizu.Add(0);
            }

            foreach(var line in dbContext.Pitanja.ToList().GroupBy(x => x.IdKviza)
                        .Select(group => new { 
                                Metric = group.Key, 
                                Count = group.Count() 
                            })
                        .OrderBy(x => x.Metric))
                {
                    BrojPitanjaPoKvizu[(int)line.Metric -1] = line.Count;
                }

            
            // da li mozda moze da se javi greska ako pitanje ima IdKviza=null ? - treba proveriti

        }
    }
}
