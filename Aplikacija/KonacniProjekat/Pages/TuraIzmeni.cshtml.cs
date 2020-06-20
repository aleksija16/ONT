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
    public class TuraIzmeniModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}

        [BindProperty]
        public int TuraId {get; set;}

        [BindProperty]
        public Ture OvaTura {get; set;}

        [BindProperty]
        public IList<Znamenitosti> SveZnamenitostiLista {get; set;}

        public SelectList SviVodici {get; set;}

        [BindProperty]
        public string IzabraniVodic {get; set;}

        [BindProperty]
        public int[] IzabraniDani {get; set;}

        [BindProperty]
        public IList<int> IzabraneZnamenitosti {get; set;}

        [BindProperty]
        public IList<Znamenitosti> VecZnamenitostiUOvojTuri {get; set;}

        public readonly OrganizacijaContext dbContext;

        public TuraIzmeniModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SessionId = SessionClass.SessionId;
            TuraId = id;
            OvaTura = await dbContext.Ture.FindAsync((uint)TuraId);

            if (OvaTura == null)
            {
                return NotFound();
            }

            IQueryable<Vodici> qVodici = dbContext.Vodici.OrderBy(x => x.IdVodica);
            IList<uint> SviVodiciId = await qVodici.Select(x => x.IdVodica).ToListAsync();
            IList<string> SviVodiciImena = await qVodici.Select(x => x.ImeVodica).ToListAsync();
            IList<string> SviVodiciPrezimena = await qVodici.Select(x => x.PrezimeVodica).ToListAsync();

            IList<string> SviVodiciObicnaLista = new List<string>();
            for (var i=0; i<SviVodiciId.Count(); i++)
            {
                SviVodiciObicnaLista.Add(SviVodiciImena[i] + " " + SviVodiciPrezimena[i] + " [Id:" + SviVodiciId[i].ToString() + "]");
            }

            

            SviVodici = new SelectList(SviVodiciObicnaLista);

            SveZnamenitostiLista = await dbContext.Znamenitosti.ToListAsync();

            IQueryable<ZnamenitostiUTurama> qZnamenitostiUTuri = dbContext.ZnamenitostiUTurama.Include(x => x.IdZnamenitostiZutNavigation).Where(x => x.IdTureZut == (uint)TuraId);
            VecZnamenitostiUOvojTuri = await qZnamenitostiUTuri.Select(x => x.IdZnamenitostiZutNavigation).ToListAsync();

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            OvaTura.IdTure = (uint) TuraId;
            OvaTura.TipTure = await dbContext.Ture.Where(x => x.IdTure == (uint)TuraId).Select(x => x.TipTure).FirstOrDefaultAsync();

            if(IzabraniVodic == null)
            {
                OvaTura.IdVodica = await dbContext.Ture.Where(x => x.IdTure == (uint)TuraId).Select(x => x.IdVodica).FirstOrDefaultAsync();
            }

            string daniOdrzavanjaOveTure = "";
            foreach (int i in IzabraniDani){
                switch (i)
                {
                    case 1:
                        daniOdrzavanjaOveTure += "ponedeljak";
                        break;
                    case 2:
                        daniOdrzavanjaOveTure += "utorak";
                        break;
                    case 3:
                        daniOdrzavanjaOveTure += "sreda";
                        break;
                    case 4:
                        daniOdrzavanjaOveTure += "četvrtak";
                        break;
                    case 5:
                        daniOdrzavanjaOveTure += "petak";
                        break;
                    case 6:
                        daniOdrzavanjaOveTure += "subota";
                        break;
                    case 7:
                        daniOdrzavanjaOveTure += "nedelja";
                        break;
                }

                daniOdrzavanjaOveTure += ", ";
            }
            daniOdrzavanjaOveTure = daniOdrzavanjaOveTure.Remove(daniOdrzavanjaOveTure.Length - 2);
            OvaTura.DanOdrzavanja = daniOdrzavanjaOveTure;

            IQueryable<ZnamenitostiUTurama> qZnamenitostiUTuri = dbContext.ZnamenitostiUTurama.Include(x => x.IdZnamenitostiZutNavigation).Where(x => x.IdTureZut == (uint)TuraId);
            VecZnamenitostiUOvojTuri = await qZnamenitostiUTuri.Select(x => x.IdZnamenitostiZutNavigation).ToListAsync();

            

            for (int i=IzabraneZnamenitosti.Count()- 1; i>=0; i--)
            {
                Znamenitosti vecJeUtabeliZut = await qZnamenitostiUTuri.Where(x => x.IdZnamenitostiZut == IzabraneZnamenitosti[i]).Select(x => x.IdZnamenitostiZutNavigation).FirstOrDefaultAsync();

                ZnamenitostiUTurama novaVezaZut = new ZnamenitostiUTurama();
                novaVezaZut.IdTureZut = (uint)TuraId;
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
                viseNePostojiVezaZut.IdTureZut = (uint)TuraId;
                viseNePostojiVezaZut.IdZnamenitostiZut = VecZnamenitostiUOvojTuri[i].IdZnamenitosti;
                viseNePostojiVezaZut.IdZnamenitostiUTurama = await qZnamenitostiUTuri.Where(x => x.IdZnamenitostiZut == viseNePostojiVezaZut.IdZnamenitostiZut).Select(x => x.IdZnamenitostiUTurama).FirstOrDefaultAsync();

                dbContext.ZnamenitostiUTurama.Remove(viseNePostojiVezaZut);
            }

            dbContext.Ture.Attach(OvaTura).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        
            return RedirectToPage("./TuraJedna", new {id = TuraId});
        }
    }
}
