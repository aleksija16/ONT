using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekat.Models;

namespace Projekat.Areas.Vodici
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public IndexModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
      
        public IList<Models.Vodici> Vodici { get;set; }

        public async Task OnGetAsync()
        {
            Vodici = await dbContext.Vodici.ToListAsync();
        }
    }
}
