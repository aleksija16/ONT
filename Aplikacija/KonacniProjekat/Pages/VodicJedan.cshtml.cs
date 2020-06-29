using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KonacniProjekat
{
    public class VodicJedanModel : PageModel
    {
        public int? SessionId {get; set;}
        [BindProperty]
        public Vodici TrenutniVodic { get; set; }
        public readonly OrganizacijaContext dbContext;

        public VodicJedanModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
        
           public IActionResult OnGet(int id)
        {
            TrenutniVodic = dbContext.Vodici.Where(x=>x.IdVodica == id).FirstOrDefault();
            return Page();
        }
    }
}
