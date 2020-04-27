using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekat_1.Model;

namespace Projekat_1
{
    public class JedanKvizModel : PageModel
    
    {
        
        private readonly OrganizacijaContext dbContext;

        public JedanKvizModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        public IList<Pitanje> Pitanje { get;set; }
   
        public async Task OnGetAsync()
        {
            Pitanje = await dbContext.Pitanje.Include(p => p.Kviz).ToListAsync();
        }
      

    }
}