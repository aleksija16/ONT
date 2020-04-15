using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class ZnamenitostiModel : PageModel
    {
        public OrganizacijaContext dbContext;

        public IList<Znamenitosti> SveZnamenitosti;

        public ZnamenitostiModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public void OnGet()
        {
            IQueryable<Znamenitosti> qZnamenitosti = dbContext.Znamenitosti;
            SveZnamenitosti = qZnamenitosti.ToList();
        }
    }
}
