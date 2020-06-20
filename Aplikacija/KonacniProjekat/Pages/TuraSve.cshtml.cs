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
    public class TuraSveModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public TuraSveModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        [BindProperty]
        public IList<Ture> SveTure{get;set;}

        public async Task OnGetAsync(){
            SessionId = SessionClass.SessionId;

            IQueryable<Ture> qTure=dbContext.Ture;
            SveTure=await qTure.ToListAsync();
        }
        
    }
}
