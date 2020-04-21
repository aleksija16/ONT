using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class JedanKvizModel : PageModel
    
    {
        public OrganizacijaContext dbContext {get; set;}

        [BindProperty]
        public Kviz TrenutniKviz {get; set;}

        public JedanKvizModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public IActionResult OnGet(int id)
        {
            TrenutniKviz = dbContext.Kviz.Where(x=>x.Idkviz == id).FirstOrDefault();
            return Page();
        }
    }

}
