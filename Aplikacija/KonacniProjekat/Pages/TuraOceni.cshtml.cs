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
    public class TuraOceniModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}

        [BindProperty]
        public int TuraId {get; set;}

        public Ture OvaTura {get; set;}

        [BindProperty]
        public Anketa OcenaTure {get; set;}

        [BindProperty(SupportsGet=true)]
        public string IzabranaNajzanimljivijaZnamenitostString {get; set;}

        [BindProperty(SupportsGet=true)]
        public string IzabranaNajdosadnijaZnamenitostString {get; set;}
        
        public SelectList IzborZnamenitostiLista {get; set;}

        [BindProperty]
        public bool VecPopunjenaAnketa {get; set;}
        public IList<Rezervacije> TuristaRezervacije {get;set;}
        public readonly OrganizacijaContext dbContext;
        public int provera=0;
        public TuraOceniModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            SessionId = SessionClass.SessionId;
            TuraId = id;
            OvaTura = await dbContext.Ture.Where( x => x.IdTure == (uint)TuraId).FirstOrDefaultAsync();

            if(OvaTura == null)
            {
                return NotFound();
            }

            if (SessionClass.TipKorisnika == "T")
            {
                 IQueryable<Rezervacije> qRezervacije = dbContext.Rezervacije.Where(Y=>Y.IdTuristeR == SessionClass.SessionId);
             TuristaRezervacije= await qRezervacije.Where(a =>a.IdTureR==(uint)id).Where(x=>x.Datum<DateTime.Now).ToListAsync();
             foreach(var item in TuristaRezervacije)
             {
                 if(item.IdTureR==(uint)id)
                 {
                    provera=1;
                 }
             }
                Anketa postojiAnketa = await dbContext.Anketa.Where(x => x.IdTuristeAnk == SessionClass.SessionId).Where(x => x.IdTureAnk == (uint)id).FirstOrDefaultAsync();
                if (postojiAnketa != null)
                {
                    VecPopunjenaAnketa = true;
                    return this.Page();
                }


                IQueryable<string> qZnamenitosti = dbContext.ZnamenitostiUTurama.Include(x => x.IdZnamenitostiZutNavigation).Where(X=>X.IdTureZut == (uint)TuraId)
                                                .Select(x =>x.IdZnamenitostiZutNavigation.NazivZnamenitosti);
                IzborZnamenitostiLista = new SelectList(await qZnamenitosti.ToListAsync());

            }

            
            return this.Page();            
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (OcenaTure == null)
            {
                return this.Page();
            }

            IQueryable<Turisti> qTurista = dbContext.Korisnici.Include(x => x.IdTuristeKNavigation).Where(x => x.IdKorisnika == (uint) SessionId).Select(x => x.IdTuristeKNavigation);

            OcenaTure.IdTuristeAnk =(uint) SessionClass.SessionId;

            OcenaTure.IdTureAnk =(uint)id;
            OvaTura = await dbContext.Ture.Where( x => x.IdTure == (uint)id).FirstOrDefaultAsync();
            OcenaTure.IdVodicaAnk = OvaTura.IdVodica;
           

            OcenaTure.NajinteresantnijaZnamenitost = IzabranaNajzanimljivijaZnamenitostString;
            OcenaTure.NajdosadnijaZnamenitost = IzabranaNajdosadnijaZnamenitostString;

            await dbContext.Anketa.AddAsync(OcenaTure);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./TuraJedna", new {id = id});
        }
    }
}
