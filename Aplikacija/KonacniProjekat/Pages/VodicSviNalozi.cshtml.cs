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
    public class VodicSviNaloziModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public VodicSviNaloziModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
    [BindProperty]
     public IList<Vodici> Vodici { get;set; }

        public async Task OnGetAsync()
        {
            Vodici = await dbContext.Vodici.ToListAsync();
        }
    
    public async Task<IActionResult> OnPostObrisiAsync(uint id)
        {
            Vodici PostojiVodic = await dbContext.Vodici.FindAsync(id);

            if (PostojiVodic != null)
            {
                dbContext.Vodici.Remove(PostojiVodic);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToPage();

        }
    }   
}
