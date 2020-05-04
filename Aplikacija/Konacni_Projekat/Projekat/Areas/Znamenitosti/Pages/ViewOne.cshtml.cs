using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat.Areas.Znamenitosti
{
    public class ViewOneModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public ViewOneModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
       
		public Models.Znamenitosti Znamenitosti{get; set;}

        public async Task<IActionResult> OnGetAsync(uint? id){
            if(id==null){
                return NotFound();
            }

            Znamenitosti=await dbContext.Znamenitosti.FirstOrDefaultAsync(m=>m.IdZnamenitosti==id);

            if(Znamenitosti==null){
                return NotFound();
            }

            return Page();
        }
    }
}
