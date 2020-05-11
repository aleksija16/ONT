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
    public class RezervacijaSveModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public RezervacijaSveModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IList<Rezervacije> SveRezervacije{get;set;}

        public async Task OnGetAsync(int? id){

            SessionId=id;

            IQueryable<Rezervacije> qRezervacije=dbContext.Rezervacije;
            SveRezervacije=await qRezervacije.ToListAsync();
        }
    }
}
