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

        public KvizUradiModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnGetAsync(uint? id, int kviz)
        {
            SessionId = (int?)id;
            KvizId = kviz;


            //Privilegije za radjenje kviza
            /* if(SessionId != null)
            {
                Korisnici PostojiKorisnik = await dbContext.Korisnici.FindAsync((uint)id);
                if(PostojiKorisnik != null){
                    if(PostojiKorisnik.TipKorisnika == "T" )
                        DostupanPrikaz = true;
                    else DostupanPrikaz = false;
                }
                else DostupanPrikaz = false;
            }
            else DostupanPrikaz = false;
            
            if (!DostupanPrikaz) return NotFound(); */


            KvizZaIzradu = await dbContext.Kvizovi.FindAsync((uint)kviz);

            if (KvizZaIzradu == null)
            {
                return NotFound();
            }

            PitanjaZaIzradu = await dbContext.Pitanja.Where(x=>x.IdKviza == (uint) kviz).ToListAsync();

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
            KvizZaIzradu = await dbContext.Kvizovi.FindAsync((uint)KvizId);

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

            /*
            //Dodavanje u HOF tabelu
            RezultatIzradeKviza.DatumRadjenja = DateTime.Now;
            RezultatIzradeKviza.IdKvizaHof = (uint)KvizId;
            RezultatIzradeKviza.IdTuristeHof = (uint)SessionId;
            RezultatIzradeKviza.Poeni = ((int) BrojTacnihOdgovora) * 100 / KorisnikoviOdgovori.Count(); //Racuna se u %, mozda da budu konkretno poeni?
            dbContext.HallOfFame.Add(RezultatIzradeKviza);*/


            return this.Page();

            //return RedirectToPage("./KvizJedan", new { id = SessionId, kviz = KvizId}); 
            //Mozda kad se zavrsi kviz da se korisniku prikaze lista svih tacnih odgovora?
            //Mozda da se samo prikaze rezultat na ovoj stranici?
        }
    }
}
