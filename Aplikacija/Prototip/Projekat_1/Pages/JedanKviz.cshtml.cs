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
            TrenutniKviz = dbContext.Pitanje.Where(x=>x.KvizId == id).FirstOrDefault();

            IQueryable<Pitanje> qPitanje = dbContext.Pitanje.Where(x => x.KvizId==id);
            SvaPitanja = qPitanje.ToList();
             IQueryable<Odgovor> qOdg = dbContext.Odgovor;
            SviOdgovori = qOdg.ToList();
            return Page();
        }
        
      
    }

}
