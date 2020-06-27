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
    public class TuraJednaModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public TuraJednaModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }

        [BindProperty]
        public Ture Tura {get; set;}

        [BindProperty]
        public string DaniOdrzavanja {get; set;}

        [BindProperty]
        public Anketa RezultatiAnkete{get;set;}

        [BindProperty]
        public List<string> NajinteresantnijeZnamenitostiNaziv {get; set;}

        [BindProperty]
        public List<string> NajdosadnijeZnamenitostiNaziv {get; set;}

        [BindProperty]
        public IList<string> TipTuristeNaziv {get; set;}        

        [BindProperty]
        public Vodici VodicTure{get;set;}

        [BindProperty]
        public IList<Znamenitosti> ZnamenitostiUTuri{get;set;}

        [BindProperty]
        public bool NeispravnaTura {get; set;}

         public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null)
             {
                 return NotFound();
            }

            Tura = await dbContext.Ture.FirstOrDefaultAsync(m => m.IdTure == id);
            if (Tura == null)
            {
                return NotFound();
            }

            if (Tura.DanOdrzavanja == null || Tura.IdVodica == null)
            {
                NeispravnaTura = true;
            }
            else
            {
                NeispravnaTura = false;
            }

            DaniOdrzavanja = " ";
            string dani =  Tura.DanOdrzavanja;
            if (dani != null) {
                string[] danPoDan = dani.Split(' ');
            for (int j = 0; j < danPoDan.Count(); j++)
            { int i = Convert.ToInt32(danPoDan[j]);
                switch (i)
                {
                    case 1:
                        DaniOdrzavanja += "ponedeljak";
                        break;
                    case 2:
                        DaniOdrzavanja += "utorak";
                        break;
                    case 3:
                        DaniOdrzavanja += "sreda";
                        break;
                    case 4:
                        DaniOdrzavanja += "četvrtak";
                        break;
                    case 5:
                        DaniOdrzavanja += "petak";
                        break;
                    case 6:
                        DaniOdrzavanja += "subota";
                        break;
                    case 0:
                        DaniOdrzavanja += "nedelja";
                        break;
                }

                DaniOdrzavanja += ", ";
            }
            if (DaniOdrzavanja != " ")
            {
                DaniOdrzavanja = DaniOdrzavanja.Remove(DaniOdrzavanja.Length - 2);    
            }
            }
            

            IList<Anketa> SviRezultatiAnketa = await dbContext.Anketa.Where(x => x.IdTureAnk == id).ToListAsync();

            if (SviRezultatiAnketa != null && SviRezultatiAnketa.Count() != 0) 
            {
                RezultatiAnkete = new Anketa();
                RezultatiAnkete.FizickaZahtevnostTure = (uint?) SviRezultatiAnketa.Average(x => Convert.ToInt32(x.FizickaZahtevnostTure));
                RezultatiAnkete.OrganizovanostTure = (uint?) SviRezultatiAnketa.Average(x => Convert.ToInt32(x.OrganizovanostTure));
                RezultatiAnkete.InformisanostVodica = (uint?) SviRezultatiAnketa.Average(x => Convert.ToInt32(x.InformisanostVodica));
                RezultatiAnkete.KonacnaOcena = (uint) SviRezultatiAnketa.Average(x => Convert.ToInt32(x.KonacnaOcena));
            
                var qNajinteresantnijeZnamenitosti = SviRezultatiAnketa.GroupBy(x => x.NajinteresantnijaZnamenitost)
                    .Select(grupa => new { Znamenitost = grupa.Key, BrojPonavljanja = grupa.Count()});

                if (qNajinteresantnijeZnamenitosti != null)
                {
                    List<string> qLista = qNajinteresantnijeZnamenitosti.OrderBy(x => x.BrojPonavljanja).Select(x => x.Znamenitost).ToList();
                    if (qLista.Count() > 3)
                        qLista.Take(3);


                    NajinteresantnijeZnamenitostiNaziv = new List<string>(3);
                    foreach(var znam in qLista)
                    {
                        NajinteresantnijeZnamenitostiNaziv.Add(znam);
                    }                
                    
                }


                var qNajdosadnijeZnamenitosti = SviRezultatiAnketa.GroupBy(x => x.NajdosadnijaZnamenitost)
                    .Select(grupa => new { Znamenitost = grupa.Key, BrojPonavljanja = grupa.Count()});
                
                if (qNajdosadnijeZnamenitosti != null)
                {
                    List<string> qLista = qNajdosadnijeZnamenitosti.OrderBy(x => x.BrojPonavljanja).Select(x => x.Znamenitost).ToList();
                    if (qLista.Count() > 3)
                        qLista.Take(3);


                    NajdosadnijeZnamenitostiNaziv = new List<string>(3);
                    foreach(var znam in qLista)
                    {
                        NajdosadnijeZnamenitostiNaziv.Add(znam);
                    }
              
                }

                var qTipTuriste = SviRezultatiAnketa.GroupBy(x => x.TipTuriste)
                    .Select(grupa => new { Tip = grupa.Key, BrojPonavljanja = grupa.Count()});
                
                if (qTipTuriste != null)
                {
                    List<string> qLista = qTipTuriste.OrderBy(x => x.BrojPonavljanja).Select(x => x.Tip).ToList();
                    if (qLista.Count() > 3)
                        qLista.Take(3);

                    TipTuristeNaziv = new List<string>(3);
                    foreach(var tip in qLista)
                    {
                        TipTuristeNaziv.Add(tip);
                    }

                    
                }
                
            }
            
            VodicTure=await dbContext.Vodici.FirstOrDefaultAsync(e=>e.IdVodica==Tura.IdVodica);

            IQueryable<ZnamenitostiUTurama> qZnamenitosti=dbContext.ZnamenitostiUTurama.Include(x=>x.IdZnamenitostiZutNavigation).Where(x=>x.IdTureZut==id);
            ZnamenitostiUTuri=await qZnamenitosti.Select(x=>x.IdZnamenitostiZutNavigation).ToListAsync();


            
            return Page();
        }
    }
}
