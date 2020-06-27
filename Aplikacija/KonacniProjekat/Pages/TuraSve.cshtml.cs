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
    public class TuraSveModel : PageModel
    {
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

        public TuraSveModel(OrganizacijaContext db)
        {
            dbContext = db;
        }

        [BindProperty]
        public IList<Ture> SveTure{get;set;}

        public SelectList SviVodiciLista {get; set;}

        [BindProperty]
        public string IzabraniVodic {get; set;}

        public async Task OnGetAsync(){
            SessionId = SessionClass.SessionId;

            IQueryable<Ture> qTure=dbContext.Ture.Where(x=>x.TipTure=="T");
            SveTure=await qTure.ToListAsync();

            IQueryable<Vodici> qVodici = dbContext.Vodici;
            IList<string> SviVodiciImena = await qVodici.Select(x => x.ImeVodica).ToListAsync();
            IList<string> SviVodiciPrezimena = await qVodici.Select(x => x.PrezimeVodica).ToListAsync();
            IList<uint> SviVodiciId = await qVodici.Select(x => x.IdVodica).ToListAsync();

            IList<string> SviVodiciObicnaLista = new List<string>();
            for (var i=0; i<SviVodiciImena.Count(); i++)
            {
                SviVodiciObicnaLista.Add(SviVodiciImena[i] + " " + SviVodiciPrezimena[i] + " [" + SviVodiciId[i].ToString() + "]");
            }
            SviVodiciLista = new SelectList(SviVodiciObicnaLista);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            IQueryable<Ture> qTure=dbContext.Ture.Where(x=>x.TipTure=="T");

            IQueryable<Vodici> qVodici = dbContext.Vodici;
            IList<string> SviVodiciImena = await qVodici.Select(x => x.ImeVodica).ToListAsync();
            IList<string> SviVodiciPrezimena = await qVodici.Select(x => x.PrezimeVodica).ToListAsync();
            IList<uint> SviVodiciId = await qVodici.Select(x => x.IdVodica).ToListAsync();

            IList<string> SviVodiciObicnaLista = new List<string>();
            for (var i=0; i<SviVodiciImena.Count(); i++)
            {
                SviVodiciObicnaLista.Add(SviVodiciImena[i] + " " + SviVodiciPrezimena[i] + " [" + SviVodiciId[i].ToString() + "]");
            }
            SviVodiciLista = new SelectList(SviVodiciObicnaLista);

            if (IzabraniVodic == "Prikaži sve")
            {
                SveTure=await qTure.ToListAsync();
            }
            else
            {
                String idVodica = IzabraniVodic.Substring(IzabraniVodic.IndexOf('[') + 1);
                idVodica = idVodica.Trim(']');
                uint idVodicaUInt = Convert.ToUInt32(idVodica);

                IQueryable<Ture> qTureFilter = dbContext.Ture.Where(x => x.TipTure == "T").Where(x => x.IdVodica == idVodicaUInt);
                SveTure = await qTureFilter.ToListAsync();
            }

            return Page();


        }
        
    }
}
