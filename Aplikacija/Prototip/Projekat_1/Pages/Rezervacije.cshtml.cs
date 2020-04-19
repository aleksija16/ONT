using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class RezervacijeModel : PageModel
    {
        public OrganizacijaContext dbContext;

        public IList<Rezervacije> SveRezervacije;

        public RezervacijeModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public void OnGet()
        {
            IQueryable<Rezervacije> qRezervacije = dbContext.Rezervacije;
            SveRezervacije = qRezervacije.ToList();
        }
    }
}
