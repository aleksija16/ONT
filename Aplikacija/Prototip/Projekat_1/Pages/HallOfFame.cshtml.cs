using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekat_1.Model;

namespace Projekat_1
{
    public class HallOfFameModel : PageModel
    {

        public readonly OrganizacijaContext dbContext;
        public int rednibroj;
        public HallOfFameModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
         public IList<HallOfFame> HallOfFame { get;set; }
        public async Task OnGetAsync()
        {
            HallOfFame = await dbContext.HallOfFame.OrderByDescending(x=>x.BrojPoena).ToListAsync();
            rednibroj=0;

        }
    }
}
