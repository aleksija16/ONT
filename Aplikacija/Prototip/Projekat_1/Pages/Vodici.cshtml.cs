using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class VodiciModel : PageModel
    {
        public OrganizacijaContext dbContext;
        public IList<Vodici> SviVodici;
 
         public VodiciModel(OrganizacijaContext db){
             dbContext=db;
        }
        public void OnGet()
        {
            IQueryable<Vodici> qVodici=dbContext.Vodici;
            SviVodici=qVodici.ToList();
        }
    }
}