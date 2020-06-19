using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KonacniProjekat
{
    public class ProfilModel : PageModel
    {
        public readonly OrganizacijaContext dbContext;

        public ProfilModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public void OnGet()
        {}
    }
}
