using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class JedanKvizModel : PageModel
    
    {
        public OrganizacijaContext dbContext {get; set;}

        [BindProperty]
        public Pitanje TrenutniKviz {get; set;}
          public IList<Pitanje> SvaPitanja;
           public IList<Odgovor> SviOdgovori;
        public JedanKvizModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IActionResult OnGet(int id)
        {
            TrenutniKviz = dbContext.Pitanje.Where(x=>x.Kvizid == id).FirstOrDefault();

            IQueryable<Pitanje> qZnamenitosti = dbContext.Pitanje.Where(x => x.Kvizid==id);
            SvaPitanja = qZnamenitosti.ToList();
             IQueryable<Odgovor> qOdg = dbContext.Odgovor;
            SviOdgovori = qOdg.ToList();
            return Page();
        }
        
      
    }

}
