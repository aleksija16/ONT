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
    public class VodicSviModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public VodicSviModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
        
    [BindProperty]
     public IList<Vodici> Vodici { get;set; }

        public async Task OnGetAsync()
        {
            Vodici = await dbContext.Vodici.ToListAsync();
        }
    }
}
