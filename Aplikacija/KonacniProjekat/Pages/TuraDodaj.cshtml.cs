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
        public int? PostojiVec {get; set;}

        [BindProperty]
        public Rezervacije NovaRezervacija {get; set;}

        [BindProperty]
        public int[] IzabraniDani { get; set; }

        public SelectList SviVodici { get; set; }

        [BindProperty]
        public string IzabraniVodic { get; set; }

        [BindProperty]
        public IList<Znamenitosti> SveZnamenitosti {get; set;}

        [BindProperty]
        public IList<int> IzabraneZnamenitosti {get; set;}

        [BindProperty]
        public string DanasnjiDatum {get; set;}

        [BindProperty]
        public string NajkasnijiDatum {get; set;}

        [BindProperty]
        public int? ZauzetVodic {get; set;}

        public async Task<IActionResult> OnGetAsync(int? zauzet, int? postoji)
        {
            SessionId = SessionClass.SessionId;

            IQueryable<Vodici> qVodici = dbContext.Vodici.OrderBy(x => x.IdVodica);
            IList<uint> SviVodiciId = await qVodici.Select(x => x.IdVodica).ToListAsync();
            IList<string> SviVodiciImena = await qVodici.Select(x => x.ImeVodica).ToListAsync();
            IList<string> SviVodiciPrezimena = await qVodici.Select(x => x.PrezimeVodica).ToListAsync();

            ZauzetVodic = zauzet;
            PostojiVec = postoji;


            if (SessionClass.TipKorisnika == "T")
            {
                String month = DateTime.Now.Month.ToString();
                if (DateTime.Now.Month < 10)
                {
                    month = month.Insert(0, "0");
                }
                String day = DateTime.Now.Day.ToString();
                if (DateTime.Now.Day < 10)
                {
                    day = day.Insert(0, "0");
                }
                DanasnjiDatum = DateTime.Now.Year.ToString() + "-" + month + "-" + day;

                DateTime NajkasnijiDan = DateTime.Now.AddMonths(6);
                String monthFuture = NajkasnijiDan.Month.ToString();
                if (NajkasnijiDan.Month < 10)
                {
                    monthFuture = monthFuture.Insert(0, "0");
                }
                String dayFuture = NajkasnijiDan.Day.ToString();
                if (NajkasnijiDan.Day < 10)
                {
                    dayFuture = dayFuture.Insert(0, "0");
                }
                NajkasnijiDatum = NajkasnijiDan.Year.ToString() + "-" + monthFuture + "-" + dayFuture;
            }

            IList<string> SviVodiciObicnaLista = new List<string>();
            for (var i=0; i<SviVodiciId.Count(); i++)
            {
                SviVodiciObicnaLista.Add(SviVodiciImena[i] + " " + SviVodiciPrezimena[i] + " [" + SviVodiciId[i].ToString() + "]");
            }

            SviVodici = new SelectList(SviVodiciObicnaLista);
            SveZnamenitosti = await dbContext.Znamenitosti.ToListAsync();

            return this.Page();
        }

        public async Task<IActionResult> OnPostTuraAsync()
        {

            if (!ModelState.IsValid)
            {
                return this.Page();
            }
			
			NovaTura.TipTure="T";

            Ture PostojiTura = await dbContext.Ture.Where(x => x.NazivTure == NovaTura.NazivTure).FirstOrDefaultAsync();
            if(PostojiTura != null)
            {
                PostojiVec = 1;
                return RedirectToPage("./TuraDodaj", new{postoji = PostojiVec});
            }

            string daniOdrzavanjaTure = "";
            foreach (int i in IzabraniDani)
            {
                switch (i)
                {
                    case 1:
                        daniOdrzavanjaTure += "1";
                        break;
                    case 2:
                        daniOdrzavanjaTure += "2";
                        break;
                    case 3:
                        daniOdrzavanjaTure += "3";
                        break;
                    case 4:
                        daniOdrzavanjaTure += "4";
                        break;
                    case 5:
                        daniOdrzavanjaTure += "5";
                        break;
                    case 6:
                        daniOdrzavanjaTure += "6";
                        break;
                    case 7:
                        daniOdrzavanjaTure += "0";
                        break;
                }

                daniOdrzavanjaTure += " ";
            }
            if (daniOdrzavanjaTure != "")
            {
                daniOdrzavanjaTure = daniOdrzavanjaTure.Trim();
                NovaTura.DanOdrzavanja = daniOdrzavanjaTure;    
            }

            IzabraniVodic = IzabraniVodic.Substring(IzabraniVodic.IndexOf('[') + 1);
            IzabraniVodic = IzabraniVodic.Trim(']');          


            IQueryable<Vodici> qIzabraniVodic=dbContext.Vodici.Where(x=>x.IdVodica == (uint) Convert.ToInt32(IzabraniVodic));
            NovaTura.IdVodicaNavigation=await qIzabraniVodic.FirstOrDefaultAsync();

       
            dbContext.Ture.Add(NovaTura);
            await dbContext.SaveChangesAsync();
			
			for(int i=IzabraneZnamenitosti.Count()-1; i>=0; i--){
                ZnamenitostiUTurama novaZut = new ZnamenitostiUTurama();
                novaZut.IdTureZut=NovaTura.IdTure;
                novaZut.IdZnamenitostiZut=(uint)IzabraneZnamenitosti[i];

                await dbContext.ZnamenitostiUTurama.AddAsync(novaZut);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToPage("./TuraSve");

        }

        public async Task<IActionResult> OnPostRezervacijaAsync()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }
			

			NovaTura.TipTure = "C";

            NovaTura.NazivTure = "Custom rezervacija uz nalog: " + SessionClass.ImeKorisnika;
            
            uint IzabraniVodicId;
            IzabraniVodic = IzabraniVodic.Substring(IzabraniVodic.IndexOf('[') + 1);
            IzabraniVodicId = Convert.ToUInt32(IzabraniVodic.Trim(']'));          

            int no = (int)NovaRezervacija.Datum.DayOfWeek;
            IQueryable<string> sveTureSaOvimVodicem = dbContext.Ture.Where(x => x.IdVodica == IzabraniVodicId).Where(x => x.TipTure == "T").Select(x => x.DanOdrzavanja);
            List<string> listaTuraDaniOdrzavanja = await sveTureSaOvimVodicem.ToListAsync();

            foreach (var dani in listaTuraDaniOdrzavanja)
            {
                if (dani == null || dani.Contains(no.ToString()))
                {
                    ZauzetVodic = 1;
                    return RedirectToPage("./TuraDodaj", new {zauzet=ZauzetVodic});
                }
            }     
            
            IQueryable<DateTime> sveRezervacijeSaOvimVodicem = dbContext.Rezervacije.Where(x => x.IdVodicaR == IzabraniVodicId).Select(x => x.Datum);
            List<DateTime> listaDatumaRezervacija = await sveRezervacijeSaOvimVodicem.ToListAsync();
            
            foreach (var datum in listaDatumaRezervacija)
            {
                if (datum == NovaRezervacija.Datum)
                {
                    ZauzetVodic = 1;
                    return RedirectToPage("./TuraDodaj", new {zauzet = ZauzetVodic});
                }
            }


            IQueryable<Vodici> qIzabraniVodic=dbContext.Vodici.Where(x=>x.IdVodica == Convert.ToUInt32(IzabraniVodicId));
            NovaTura.IdVodicaNavigation=await qIzabraniVodic.FirstOrDefaultAsync();

            dbContext.Ture.Add(NovaTura);
            await dbContext.SaveChangesAsync();
			
			for(int i=IzabraneZnamenitosti.Count()-1; i>=0; i--){
                ZnamenitostiUTurama novaZut = new ZnamenitostiUTurama();
                novaZut.IdTureZut=NovaTura.IdTure;
                novaZut.IdZnamenitostiZut=(uint)IzabraneZnamenitosti[i];

                await dbContext.ZnamenitostiUTurama.AddAsync(novaZut);
                await dbContext.SaveChangesAsync();
            }

            NovaRezervacija.BrojOsoba = NovaTura.Kapacitet;
            NovaRezervacija.IdTureR = NovaTura.IdTure;
            NovaRezervacija.IdVodicaR = NovaTura.IdVodica;
            NovaRezervacija.IdTuristeR = (uint?)SessionClass.SessionId;

            await dbContext.Rezervacije.AddAsync(NovaRezervacija);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./RezervacijaSve");
        }
    }
}

