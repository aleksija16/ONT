using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekat_1.Model;

namespace MyApp.Namespace
{
    public class IzmeniTuruModel : PageModel
    {

        public Ture TrenutnaTura{get;set;}
        public OrganizacijaContext dbContext;

        public IList<Znamenitosti> SveZnamenitosti;

        public IList<Vodici> SviVodici;

        public IzmeniTuruModel(OrganizacijaContext db){
            dbContext=db;
        }
        
        public void OnGet()
        {
            IQueryable<Znamenitosti> qZnamenitosti=dbContext.Znamenitosti;
            SveZnamenitosti=qZnamenitosti.ToList();

            IQueryable<Vodici> qVodici=dbContext.Vodici;
            SviVodici=qVodici.ToList();
        }

        public async Task<IActionResult> OnPostAsync(uint id){
            TrenutnaTura=await dbContext.Ture.Where(x=>x.IdTure==id).FirstOrDefaultAsync();
            if(TrenutnaTura==null){
                return RedirectToPage("./Ture");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSacuvajAsync(){
            if(!ModelState.IsValid){
                return Page();
            }
            else{
                dbContext.Ture.Attach(TrenutnaTura).State=EntityState.Modified;
                try{
                    await dbContext.SaveChangesAsync();
                }
                catch(DbUpdateException e){
                    throw new Exception("Greska "+e.ToString());
                }
                return RedirectToPage("./Ture");
            }
        }
    }
}
