using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KonacniProjekat
{
    public class KvizUradiModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        [BindProperty]
        public int KvizId {get; set;}

        [BindProperty]
        public List<string> KorisnikoviOdgovori {get; set;}

        public Kvizovi KvizZaIzradu {get; set;}

        [BindProperty]
        public IList<Pitanja> PitanjaZaIzradu {get; set;}

        [BindProperty]
        public int? BrojTacnihOdgovora {get; set;}

        public HallOfFame RezultatIzradeKviza {get; set;}

        [BindProperty]
        public string PorukaZaKorisnikaNepopunjenKviz {get; set;}

        [BindProperty]
        public bool DostupanPrikaz {get; set;}

        [BindProperty]
        public bool ZavrsenKviz {get; set;}

        [BindProperty]
        public int? VecJeRadioKviz {get; set;}

        [BindProperty]
        public string NazivKviza {get; set;}

        public KvizUradiModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnGetAsync(int id, int? radio)
        {
            SessionId = SessionClass.SessionId;
            KvizId = id;

            VecJeRadioKviz = (int?)radio;
 
            if(SessionId != null)
            {                
                if(SessionClass.TipKorisnika == "T" )
                    DostupanPrikaz = true;
                else DostupanPrikaz = false;
            }
            else DostupanPrikaz = false;

            if (!DostupanPrikaz) return StatusCode(403);


            KvizZaIzradu = await dbContext.Kvizovi.FindAsync((uint)id);

            if (await dbContext.HallOfFame.Where(x => x.IdKvizaHof == (uint)KvizId).Where(y => y.IdTuristeHof == SessionClass.SessionId).FirstOrDefaultAsync() != null)
            {
                VecJeRadioKviz = 1;
            }

            NazivKviza = KvizZaIzradu.NazivKviza;

            if (KvizZaIzradu == null)
            {
                return NotFound();
            }

            PitanjaZaIzradu = await dbContext.Pitanja.Where(x=>x.IdKviza == (uint) id).ToListAsync();

            ZavrsenKviz = false;

            KorisnikoviOdgovori = new List<string>();
            for(int i=0; i<PitanjaZaIzradu.Count(); i++)
            {
                KorisnikoviOdgovori.Add(i.ToString() +  "&^*");
            }

            return this.Page();
        }

        public async Task<IActionResult> OnPost()
        {

            PitanjaZaIzradu = await dbContext.Pitanja.Where(x=>x.IdKviza == (uint)KvizId).ToListAsync();

            BrojTacnihOdgovora = 0;

            for(var i=0; i<KorisnikoviOdgovori.Count(); i++)
            {
                if (KorisnikoviOdgovori[i] == PitanjaZaIzradu[i].TacanOdgovor)
                {
                    BrojTacnihOdgovora++;
                }
            }

            ZavrsenKviz = true;

            
            RezultatIzradeKviza = new HallOfFame();

            RezultatIzradeKviza.DatumRadjenja = DateTime.Now;
            RezultatIzradeKviza.IdKvizaHof = (uint)KvizId;
            RezultatIzradeKviza.IdTuristeHof = (uint)SessionId;
            RezultatIzradeKviza.Poeni = ((int) BrojTacnihOdgovora) * 100 / KorisnikoviOdgovori.Count(); //Racuna se u %, mozda da budu konkretno poeni?
            dbContext.HallOfFame.Add(RezultatIzradeKviza);

            await dbContext.SaveChangesAsync();

            return this.Page();    								 
        }
    }
}
