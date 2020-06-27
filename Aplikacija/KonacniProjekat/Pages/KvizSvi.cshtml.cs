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

        [BindProperty]
        public IList<int> BrojUcesnikaPoKvizu {get; set;}

        [BindProperty]
        public IList<string> NajboljiRezultatPoKvizuString {get; set;}

        [BindProperty]
        public IList<Kvizovi> KvizTura {get; set;}
        public IList<Kvizovi> KvizZnamenitosti { get; set; }

        public IList<Kvizovi> KvizOstali {get; set;}

        public KvizSviModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        public async Task OnGetAsync()
        {
            SessionId = SessionClass.SessionId;
            KvizTura = await dbContext.Kvizovi.Where(x=>x.IdTureK != null).ToListAsync();
            foreach(var kviz in KvizTura)
            {
                kviz.IdTureKNavigation=await dbContext.Ture.Where(x=>x.IdTure==kviz.IdTureK).FirstOrDefaultAsync();
            }
            KvizZnamenitosti= await dbContext.Kvizovi.Where(x=>x.IdZnamenitostiK!=null).ToListAsync();
            foreach(var kviz in KvizZnamenitosti)
            {
                kviz.IdZnamenitostiKNavigation=await dbContext.Znamenitosti.Where(x=>x.IdZnamenitosti==kviz.IdZnamenitostiK).FirstOrDefaultAsync();
            }
            KvizOstali = await dbContext.Kvizovi.Where(x => x.IdTureK == null).Where(x => x.IdZnamenitostiK == null).ToListAsync();

            IQueryable<Kvizovi> qKvizovi = dbContext.Kvizovi.Include(x=>x.IdZnamenitostiKNavigation).OrderBy(x=>x.IdKviza);
            SviKvizovi = await qKvizovi.ToListAsync();


            int NajveciIdKvizova = (int)(await qKvizovi.OrderByDescending(x=>x.IdKviza).FirstOrDefaultAsync()).IdKviza;

            BrojPitanjaPoKvizu = new List<int>();
            BrojUcesnikaPoKvizu = new List<int>();
            NajboljiRezultatPoKvizuString = new List<string>();

            for (int i=0; i<NajveciIdKvizova; i++)
            {
                BrojPitanjaPoKvizu.Add(0);
                BrojUcesnikaPoKvizu.Add(0);
                NajboljiRezultatPoKvizuString.Add("Ovaj kviz niko još uvek nije radio.");
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

            foreach(var line in dbContext.HallOfFame.Select(x=> new {x.IdKvizaHof, x.IdTuristeHof}).Distinct().ToList().GroupBy( x => x.IdKvizaHof)
                        .Select(group => new  {
                                Metric = group.Key,
                                Count = group.Count()
                        })
                        .OrderBy(x => x.Metric))
                        {
                            BrojUcesnikaPoKvizu[(int)line.Metric - 1] = line.Count;
                        }

            
            foreach(var line in dbContext.HallOfFame.Select(x => new { x.IdKvizaHof, /*x.IdTuristeHof,*/ x.Poeni}).ToList().GroupBy(x => x.IdKvizaHof)
                        .Select(group => new {
                                Metric = group.Key,
                                MaxValue = group.Max(x => x.Poeni)
                        })
                        .OrderBy(x => x.Metric))
                        {
                            NajboljiRezultatPoKvizuString[(int)line.Metric - 1] = line.MaxValue.ToString();
                        } 


        }
    }
}
