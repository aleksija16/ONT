using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekat_1.Model;

namespace Projekat_1
{
    public class PitanjaModel : PageModel
    {
    private readonly OrganizacijaContext dbContext;

    public PitanjaModel (OrganizacijaContext db)
    {
        dbContext=db;
    }

    [BindProperty]
    public IList<Pitanje> Pitanja { get;set; }
      public async Task OnGetAsync()
        {
            Pitanja = await dbContext.Pitanje.Include(p => p.Kviz).ToListAsync();
        }

         public async Task<IActionResult> OnPostObrisiAsync(uint id)
        {
            Pitanje PostojiPitanje = await dbContext.Pitanje.FindAsync(id);
            
            if (PostojiPitanje != null)
            {
                
                dbContext.Pitanje.Remove(PostojiPitanje);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToPage();

        }
    }
}
