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
    public class TuraDodajModel : PageModel
    {
        public int? SessionId { get; set; }
        public readonly OrganizacijaContext dbContext;

        public TuraDodajModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        [BindProperty]
        public Ture NovaTura { get; set; }

        [BindProperty]
        public int[] IzabraniDani { get; set; }

        public SelectList SviVodici { get; set; }

        [BindProperty]
        public string IzabraniVodic { get; set; }

        [BindProperty]
        public IList<Znamenitosti> SveZnamenitosti {get; set;}

        [BindProperty]
        public IList<int> IzabraneZnamenitosti {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            SessionId=id;

            IQueryable<string> qVodici=dbContext.Vodici.Select(x=>x.ImeVodica);
            SviVodici=new SelectList(await qVodici.ToListAsync());

        
           SveZnamenitosti = await dbContext.Znamenitosti.ToListAsync();

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            string daniOdrzavanjaTure = "";
            foreach (int i in IzabraniDani)
            {
                switch (i)
                {
                    case 1:
                        daniOdrzavanjaTure += "Ponedeljak";
                        break;
                    case 2:
                        daniOdrzavanjaTure += "Utorak";
                        break;
                    case 3:
                        daniOdrzavanjaTure += "Sreda";
                        break;
                    case 4:
                        daniOdrzavanjaTure += "Četvrtak";
                        break;
                    case 5:
                        daniOdrzavanjaTure += "Petak";
                        break;
                    case 6:
                        daniOdrzavanjaTure += "Subota";
                        break;
                    case 7:
                        daniOdrzavanjaTure += "Nedelja";
                        break;
                }

                daniOdrzavanjaTure += ", ";
            }
            daniOdrzavanjaTure = daniOdrzavanjaTure.Remove(daniOdrzavanjaTure.Length - 2);
            NovaTura.DanOdrzavanja = daniOdrzavanjaTure;

            IQueryable<Vodici> qIzabraniVodic=dbContext.Vodici.Where(x=>x.ImeVodica==IzabraniVodic);
            NovaTura.IdVodicaNavigation=await qIzabraniVodic.FirstOrDefaultAsync();

            /*
            for(int i=IzabraneZnamenitosti.Count()-1; i>0; i--){
            ZnamenitostiUTurama novaZut=new ZnamenitostiUTurama();
            novaZut.IdTureZut=NovaTura.IdTure;
            novaZut.IdZnamenitostiZut=(uint)IzabraneZnamenitosti[i];

            dbContext.ZnamenitostiUTurama.Add(novaZut);
            }
*/
            dbContext.Ture.Add(NovaTura);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./TuraSve");

        }
    }
}
