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
    public class ZnamenitostSveModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public ZnamenitostSveModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
        public IList<Znamenitosti> SveZnamenitosti{get;set;}

        public async Task OnGetAsync(int? id){

            SessionId=id;

            IQueryable<Znamenitosti> qZnamenitosti=dbContext.Znamenitosti;
            SveZnamenitosti=await qZnamenitosti.ToListAsync();
        }
    }
}
