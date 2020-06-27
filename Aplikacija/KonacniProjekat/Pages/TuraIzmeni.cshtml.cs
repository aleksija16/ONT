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
        public string VecIzabraniDaniString {get; set;}

        [BindProperty]
        public string DaniOdrzavanjaPreIzmene {get; set;}

        [BindProperty]
        public IList<int> IzabraneZnamenitosti {get; set;}

        [BindProperty]
        public IList<int> ZnamenitostiZaUklanjanje {get; set;}

        [BindProperty]
        public IList<Znamenitosti> VecZnamenitostiUOvojTuri {get; set;}

        [BindProperty]
        public IList<Znamenitosti> ZnamenitostiKojeNisuUTuri {get; set;}

        [BindProperty]
        public string VecZnamenitostiUOvojTuriString {get; set;}

        public readonly OrganizacijaContext dbContext;

        public TuraIzmeniModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            TuraId = id;
          
            OvaTura = await dbContext.Ture.Include(x => x.IdVodicaNavigation).Where( x => x.IdTure == (uint)id).FirstOrDefaultAsync();

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
                SviVodiciObicnaLista.Add(SviVodiciImena[i] + " " + SviVodiciPrezimena[i] + " [" + SviVodiciId[i].ToString() + "]");
            }
            SviVodici = new SelectList(SviVodiciObicnaLista);

            if (OvaTura.IdVodica != null)
            {
                IzabraniVodic = "";
                IzabraniVodic = OvaTura.IdVodicaNavigation.ImeVodica + " " + OvaTura.IdVodicaNavigation.PrezimeVodica+ " [" + OvaTura.IdVodica.ToString() + "]";
            }
            
            DaniOdrzavanjaPreIzmene = OvaTura.DanOdrzavanja;

            VecIzabraniDaniString = "";
            if (OvaTura.DanOdrzavanja != null)
            {
                String[] daniString = OvaTura.DanOdrzavanja.Split(' ');
                int[] VecIzabraniDani = new int[daniString.Length];
                for (int i=0; i<daniString.Count(); i++)
                {
                    VecIzabraniDani[i] = Convert.ToInt32(daniString[i]);
                    switch(VecIzabraniDani[i])
                    {
                        case 0:
                            VecIzabraniDaniString += "nedelja";
                            break;
                        case 1:
                            VecIzabraniDaniString += "ponedeljak";
                            break;
                        case 2:
                            VecIzabraniDaniString += "utorak";
                            break;
                        case 3:
                            VecIzabraniDaniString += "sreda";
                            break;
                        case 4:
                            VecIzabraniDaniString += "četvrtak";
                            break;
                        case 5:
                            VecIzabraniDaniString += "petak";
                            break;
                        case 6:
                            VecIzabraniDaniString += "subota";
                            break;
                    }

                    VecIzabraniDaniString += ", ";
                }
                if (VecIzabraniDaniString != "")
                {
                    VecIzabraniDaniString = VecIzabraniDaniString.Remove(VecIzabraniDaniString.Length - 2);    
                }
            
            }

            

            IQueryable<ZnamenitostiUTurama> qZnamenitostiUTuri = dbContext.ZnamenitostiUTurama.Include(x => x.IdZnamenitostiZutNavigation).Where(x => x.IdTureZut == (uint)TuraId);
            VecZnamenitostiUOvojTuri = await qZnamenitostiUTuri.Select(x => x.IdZnamenitostiZutNavigation).ToListAsync();

            IQueryable<Znamenitosti> qZnamenitostiNisuUTuri = dbContext.Znamenitosti;
            ZnamenitostiKojeNisuUTuri = await qZnamenitostiNisuUTuri.ToListAsync();

            VecZnamenitostiUOvojTuriString = "";
            foreach (var znam in VecZnamenitostiUOvojTuri)
            {
                ZnamenitostiKojeNisuUTuri.Remove(znam);
                VecZnamenitostiUOvojTuriString = VecZnamenitostiUOvojTuriString.Insert(VecZnamenitostiUOvojTuriString.Length, znam.NazivZnamenitosti);
                VecZnamenitostiUOvojTuriString = VecZnamenitostiUOvojTuriString.Insert(VecZnamenitostiUOvojTuriString.Length, ", ");
            }
            VecZnamenitostiUOvojTuriString = VecZnamenitostiUOvojTuriString.Trim().Trim(',');

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            OvaTura.IdTure = (uint) id;
            OvaTura.TipTure = await dbContext.Ture.Where(x => x.IdTure == (uint)id).Select(x => x.TipTure).FirstOrDefaultAsync();

            if(IzabraniVodic == null)
            {
                OvaTura.IdVodica = await dbContext.Ture.Where(x => x.IdTure == (uint)id).Select(x => x.IdVodica).FirstOrDefaultAsync();
            }
            string daniOdrzavanjaOveTure = "";
            foreach (int i in IzabraniDani){
                switch (i)
                {
                    case 1:
                        daniOdrzavanjaOveTure += "1";
                        break;
                    case 2:
                        daniOdrzavanjaOveTure += "2";
                        break;
                    case 3:
                        daniOdrzavanjaOveTure += "3";
                        break;
                    case 4:
                        daniOdrzavanjaOveTure += "4";
                        break;
                    case 5:
                        daniOdrzavanjaOveTure += "5";
                        break;
                    case 6:
                        daniOdrzavanjaOveTure += "6";
                        break;
                    case 7:
                        daniOdrzavanjaOveTure += "0";
                        break;
                }

                daniOdrzavanjaOveTure += " ";
            }
            if (daniOdrzavanjaOveTure != "")
            {
                daniOdrzavanjaOveTure = daniOdrzavanjaOveTure.Trim();
                OvaTura.DanOdrzavanja = daniOdrzavanjaOveTure;    
            }
            else
            {
                OvaTura.DanOdrzavanja = DaniOdrzavanjaPreIzmene;
            }

            IzabraniVodic = IzabraniVodic.Substring(IzabraniVodic.IndexOf('[') + 1);
            IzabraniVodic = IzabraniVodic.Trim(']');          


            IQueryable<Vodici> qIzabraniVodic=dbContext.Vodici.Where(x=>x.IdVodica == (uint) Convert.ToInt32(IzabraniVodic));
            OvaTura.IdVodicaNavigation=await qIzabraniVodic.FirstOrDefaultAsync();

            IQueryable<ZnamenitostiUTurama> qZnamenitostiUTuri = dbContext.ZnamenitostiUTurama.Include(x => x.IdZnamenitostiZutNavigation).Where(x => x.IdTureZut == (uint)id);
            VecZnamenitostiUOvojTuri = await qZnamenitostiUTuri.Select(x => x.IdZnamenitostiZutNavigation).ToListAsync();
           


            // for (int i=IzabraneZnamenitosti.Count()- 1; i>=0; i--)
            // {
            //     Znamenitosti vecJeUtabeliZut = await qZnamenitostiUTuri.Where(x => x.IdZnamenitostiZut == IzabraneZnamenitosti[i]).Select(x => x.IdZnamenitostiZutNavigation).FirstOrDefaultAsync();

            //     ZnamenitostiUTurama novaVezaZut = new ZnamenitostiUTurama();
            //     novaVezaZut.IdTureZut = (uint)id;
            //     novaVezaZut.IdZnamenitostiZut = (uint)IzabraneZnamenitosti[i];
                
            //     if (vecJeUtabeliZut == null)
            //     {
            //         await dbContext.ZnamenitostiUTurama.AddAsync(novaVezaZut);
            //     }
            //     else {
            //         VecZnamenitostiUOvojTuri.Remove(vecJeUtabeliZut);
            //     }
            //     IzabraneZnamenitosti.Remove(IzabraneZnamenitosti[i]);                             
            // }
            // await dbContext.SaveChangesAsync();

            // for (int i=0; i<VecZnamenitostiUOvojTuri.Count(); i++)
            // {
            //     ZnamenitostiUTurama viseNePostojiVezaZut = new ZnamenitostiUTurama();
            //     viseNePostojiVezaZut.IdTureZut = (uint)id;
            //     viseNePostojiVezaZut.IdZnamenitostiZut = VecZnamenitostiUOvojTuri[i].IdZnamenitosti;
            //     viseNePostojiVezaZut.IdZnamenitostiUTurama = await qZnamenitostiUTuri.Where(x => x.IdZnamenitostiZut == viseNePostojiVezaZut.IdZnamenitostiZut).Select(x => x.IdZnamenitostiUTurama).FirstOrDefaultAsync();

            //     dbContext.ZnamenitostiUTurama.Remove(viseNePostojiVezaZut);
            // }

            for (int i = ZnamenitostiZaUklanjanje.Count() - 1; i>=0; i--)
            {
                ZnamenitostiUTurama zutZaUklanjanje = await dbContext.ZnamenitostiUTurama.Where(x => x.IdTureZut == (uint)TuraId).Where(x => x.IdZnamenitostiZut == (uint)ZnamenitostiZaUklanjanje[i]).FirstOrDefaultAsync();
                dbContext.ZnamenitostiUTurama.Remove(zutZaUklanjanje);
            }
            await dbContext.SaveChangesAsync();

            for (int i = IzabraneZnamenitosti.Count() - 1; i>=0; i--)
            {
                ZnamenitostiUTurama novaZut = new ZnamenitostiUTurama();
                novaZut.IdTureZut = (uint)TuraId;
                novaZut.IdZnamenitostiZut = (uint)IzabraneZnamenitosti[i];
                await dbContext.ZnamenitostiUTurama.AddAsync(novaZut);
            }
            await dbContext.SaveChangesAsync();

            dbContext.Ture.Attach(OvaTura).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        
            return RedirectToPage("./TuraJedna", new {id = id});
        }
    }
}
