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
    public class ZnamenitostiUTuramaModel : PageModel
    {
        private readonly OrganizacijaContext dbContext;

        public ZnamenitostiUTuramaModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IList<ZnamenitostiUTurama> ZnamenitostiUTurama { get;set; }

        public async Task OnGetAsync()
        {
            ZnamenitostiUTurama = await dbContext.ZnamenitostiUTurama
                .Include(z => z.Tura)
                .Include(z => z.Znamenitost).ToListAsync();
        }
    }
}
