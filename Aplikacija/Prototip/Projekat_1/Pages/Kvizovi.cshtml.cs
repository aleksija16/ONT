using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace MyApp.Namespace
{
    public class KvizoviModel : PageModel
    {
       public OrganizacijaContext dbContext;

        public IList<Kviz> SviKvizovi;

        public KvizoviModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public void OnGet()
        {
            IQueryable<Kviz> qKviz = dbContext.Kviz;
            SviKvizovi = qKviz.ToList();
        }
    }
}
