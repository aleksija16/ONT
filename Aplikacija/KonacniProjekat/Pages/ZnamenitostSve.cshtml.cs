using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KonacniProjekat
{
    public class ZnamenitostSveModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

       public SelectList SviTipovi { get; set; }

        [BindProperty]
        public string IzabraniTip { get; set; }

        public ZnamenitostSveModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
        public IList<Znamenitosti> SveZnamenitosti{get;set;}

        public async Task OnGetAsync()
        {
            SessionId = SessionClass.SessionId;

            IQueryable<Znamenitosti> qZnamenitosti=dbContext.Znamenitosti;
            SveZnamenitosti=await qZnamenitosti.ToListAsync();

            IQueryable<string> qZnamTip=dbContext.Znamenitosti.Select(x=>x.Tip).Distinct();
            SviTipovi=new SelectList(await qZnamTip.ToListAsync());
            
        }
    }
}
