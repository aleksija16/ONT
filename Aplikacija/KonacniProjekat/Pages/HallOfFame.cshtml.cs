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
    public class HallOfFameModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public HallOfFameModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
        public IList<HallOfFame> HallOfFame { get;set; }
        public IList<Turisti> Turisti {get;set;}
        public IList<Kvizovi> sviKvizovi {get;set;}
        public Kvizovi trenutniKviz{get;set;}
        public async Task OnGetAsync(int id)
        {
            sviKvizovi = await dbContext.Kvizovi.ToListAsync();   
            Turisti = await dbContext.Turisti.ToListAsync();
            HallOfFame = await dbContext.HallOfFame.Where(x=>x.IdKvizaHof==id).OrderByDescending(x=>x.Poeni).ToListAsync();
            trenutniKviz = dbContext.Kvizovi.Where(x=>x.IdKviza == id).FirstOrDefault();
        }

    }
}
