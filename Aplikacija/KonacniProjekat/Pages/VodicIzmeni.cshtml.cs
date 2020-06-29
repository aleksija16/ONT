using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KonacniProjekat
{
    public class VodicIzmeniModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}

        [BindProperty]
        public Vodici OvajVodic {get; set;}
        [BindProperty]
        public int VodicId{get;set;}

        public readonly OrganizacijaContext dbContext;

        public VodicIzmeniModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            VodicId=id;
            OvajVodic = await dbContext.Vodici.FindAsync((uint)id);

            if (OvajVodic == null)
            {
                return NotFound();
            }

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            OvajVodic.IdVodica = (uint) id;


            dbContext.Vodici.Attach(OvajVodic).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        
            return RedirectToPage("./VodicJedan", new {id = id});
        }
    }
}
