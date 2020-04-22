using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class PitanjaModel : PageModel
    {
        public OrganizacijaContext dbContext;

        public IList<Pitanje> SvaPitanja;

        public PitanjaModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public void OnGet()
        {
            IQueryable<Pitanje> qPitanje = dbContext.Pitanje;
            SvaPitanja = qPitanje.ToList();
        }
    }
}
