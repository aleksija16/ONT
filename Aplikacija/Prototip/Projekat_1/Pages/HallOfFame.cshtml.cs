using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class HallOfFameModel : PageModel
    {

        public OrganizacijaContext dbContext;

        public IList<HallOfFame> SviUcesnici;

 public HallOfFameModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        public void OnGet()
        {
             IQueryable<HallOfFame> qHallOfFame = dbContext.HallOfFame;
            SviUcesnici = qHallOfFame.ToList();
        }
    }
}
