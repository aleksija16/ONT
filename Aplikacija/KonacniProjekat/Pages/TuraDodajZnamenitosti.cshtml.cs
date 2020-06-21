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
    public class TuraDodajZnamenitostiModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}

        [BindProperty]
        public IList<Znamenitosti> SveZnamenitostiLista {get; set;}

        [BindProperty]
        public IList<int> IzabraneZnamenitosti {get; set;}

        [BindProperty]
        public IList<Znamenitosti> VecZnamenitostiUOvojTuri {get; set;}
        public Ture OvaTura {get; set;}

        public readonly OrganizacijaContext dbContext;

        public TuraDodajZnamenitostiModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            OvaTura = await dbContext.Ture.FindAsync((uint)id);

            SveZnamenitostiLista = await dbContext.Znamenitosti.ToListAsync();

            IQueryable<ZnamenitostiUTurama> qZnamenitostiUTuri = dbContext.ZnamenitostiUTurama.Include(x => x.IdZnamenitostiZutNavigation).Where(x => x.IdTureZut == (uint)id);
            VecZnamenitostiUOvojTuri = await qZnamenitostiUTuri.Select(x => x.IdZnamenitostiZutNavigation).ToListAsync();

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }
            IQueryable<ZnamenitostiUTurama> qZnamenitostiUTuri = dbContext.ZnamenitostiUTurama.Include(x => x.IdZnamenitostiZutNavigation).Where(x => x.IdTureZut == (uint)id);
            VecZnamenitostiUOvojTuri = await qZnamenitostiUTuri.Select(x => x.IdZnamenitostiZutNavigation).ToListAsync();

            for (int i=IzabraneZnamenitosti.Count()- 1; i>=0; i--)
            {
                Znamenitosti vecJeUtabeliZut = await qZnamenitostiUTuri.Where(x => x.IdZnamenitostiZut == IzabraneZnamenitosti[i]).Select(x => x.IdZnamenitostiZutNavigation).FirstOrDefaultAsync();

                ZnamenitostiUTurama novaVezaZut = new ZnamenitostiUTurama();
                novaVezaZut.IdTureZut = (uint)id;
                novaVezaZut.IdZnamenitostiZut = (uint)IzabraneZnamenitosti[i];
                
                if (vecJeUtabeliZut == null)
                {
                    await dbContext.ZnamenitostiUTurama.AddAsync(novaVezaZut);
                }
                else {
                    VecZnamenitostiUOvojTuri.Remove(vecJeUtabeliZut);
                }
                IzabraneZnamenitosti.Remove(IzabraneZnamenitosti[i]);                             
            }
            await dbContext.SaveChangesAsync();

            for (int i=0; i<VecZnamenitostiUOvojTuri.Count(); i++)
            {
                ZnamenitostiUTurama viseNePostojiVezaZut = new ZnamenitostiUTurama();
                viseNePostojiVezaZut.IdTureZut = (uint)id;
                viseNePostojiVezaZut.IdZnamenitostiZut = VecZnamenitostiUOvojTuri[i].IdZnamenitosti;
                viseNePostojiVezaZut.IdZnamenitostiUTurama = await qZnamenitostiUTuri.Where(x => x.IdZnamenitostiZut == viseNePostojiVezaZut.IdZnamenitostiZut).Select(x => x.IdZnamenitostiUTurama).FirstOrDefaultAsync();

                dbContext.ZnamenitostiUTurama.Remove(viseNePostojiVezaZut);
                 await dbContext.SaveChangesAsync();
        
            }
            await dbContext.SaveChangesAsync();
        
            return RedirectToPage("./TuraJedna", new {id = id});
        }
    }
}
