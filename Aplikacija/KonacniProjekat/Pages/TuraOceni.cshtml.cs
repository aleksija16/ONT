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

        public readonly OrganizacijaContext dbContext;

        public TuraOceniModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            SessionId = 1 ; //SessionClass.SessionId;
            TuraId = id;

            //if (SessionId == null || SessionClass.TipKorisnika != "Turista")
            //{
            //    return NotFound();
            //}

            OvaTura = await dbContext.Ture.Where( x => x.IdTure == (uint)TuraId).FirstOrDefaultAsync();

            if(OvaTura == null)
            {
                return NotFound();
            }

            IQueryable<string> qZnamenitosti = dbContext.ZnamenitostiUTurama.Include(x => x.IdZnamenitostiZutNavigation).Where(X=>X.IdTureZut == (uint)TuraId)
                                                .Select(x =>x.IdZnamenitostiZutNavigation.NazivZnamenitosti);
            IzborZnamenitostiLista = new SelectList(await qZnamenitosti.ToListAsync());

            return this.Page();            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (OcenaTure == null)
            {
                return this.Page();
            }

            IQueryable<Turisti> qTurista = dbContext.Korisnici.Include(x => x.IdTuristeKNavigation).Where(x => x.IdKorisnika == (uint) SessionId).Select(x => x.IdTuristeKNavigation);

            OcenaTure.IdTuristeAnkNavigation = await qTurista.FirstOrDefaultAsync();
            OcenaTure.IdTuristeAnk = OcenaTure.IdTuristeAnkNavigation.IdTuriste;

            OcenaTure.IdTureAnkNavigation = await dbContext.Ture.FindAsync((uint)TuraId);
            OcenaTure.IdTureAnk = OcenaTure.IdTureAnkNavigation.IdTure;

            OcenaTure.IdVodicaAnk = OcenaTure.IdTureAnkNavigation.IdVodica;
            OcenaTure.IdVodicaAnkNavigation = await dbContext.Vodici.FindAsync((uint)OcenaTure.IdTuristeAnk);

            OcenaTure.NajinteresantnijaZnamenitost = IzabranaNajzanimljivijaZnamenitostString;
            OcenaTure.NajdosadnijaZnamenitost = IzabranaNajdosadnijaZnamenitostString;

            await dbContext.Anketa.AddAsync(OcenaTure);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./TuraJedna", new {id = TuraId});
        }
    }
}
