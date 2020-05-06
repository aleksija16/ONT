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
    public class KvizJedanModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        [BindProperty]
        public Kvizovi OvajKviz {get; set;}

        [BindProperty]
        public IList<Pitanja> PitanjaUzKviz {get; set;}

        public KvizJedanModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id, int kviz)
        {
            SessionId = id;

            OvajKviz = await dbContext.Kvizovi.Where(x=>x.IdKviza == (uint)kviz).FirstOrDefaultAsync();

            if(OvajKviz == null)
            {
                return NotFound();
            }

            PitanjaUzKviz = await dbContext.Pitanja.Where(x=>x.IdKviza == (uint)kviz).OrderBy(x=>x.IdPitanja).ToListAsync();

            return Page();
        }
    }
}
