using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KonacniProjekat.Pages
{
    public class IndexModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        [BindProperty]
        public IList<Znamenitosti> SveZnamenitosti{get;set;}

        public IndexModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        public void OnGet()
        {
            SveZnamenitosti = dbContext.Znamenitosti.ToList();
        }
    }
}
