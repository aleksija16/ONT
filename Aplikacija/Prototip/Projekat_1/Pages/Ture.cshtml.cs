using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace MyApp.Namespace
{
    public class TureModel : PageModel
    {
        public IList<Ture> SveTure{get;set;}

        public OrganizacijaContext dbContext{get;set;}

        public TureModel(OrganizacijaContext db){
            dbContext=db;
        }
        public IActionResult OnGet()
        {
            SveTure=dbContext.Ture.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostObrisiAsync(uint id)
        {
            Ture PostojiTura = await dbContext.Ture.FindAsync(id);

            if (PostojiTura != null)
            {
                dbContext.Ture.Remove(PostojiTura);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToPage();

        }
    }
}
