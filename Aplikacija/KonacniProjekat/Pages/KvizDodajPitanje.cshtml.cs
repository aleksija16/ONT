using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonacniProjekat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KonacniProjekat
{
    public class KvizDodajPitanjeModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}

        [BindProperty(SupportsGet=true)]
        public int KvizId { get; set; }

        public readonly OrganizacijaContext dbContext;        

        [BindProperty]
        public Pitanja NovoPitanje {get; set;}

        [BindProperty]
        public int IzborTacnogOdgovoraInt {get; set;}

        public KvizDodajPitanjeModel(OrganizacijaContext db)
        {
            dbContext = db;
        }
        
        public PageResult OnGet(int? id, int kviz)
        {
            SessionId = id;
            KvizId = kviz;

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            NovoPitanje.IdKvizaNavigation = await dbContext.Kvizovi.FindAsync((uint)KvizId);

            switch(IzborTacnogOdgovoraInt){
                case 1:  NovoPitanje.TacanOdgovor = NovoPitanje.OdgovorA;
                    break;
                case 2: NovoPitanje.TacanOdgovor = NovoPitanje.OdgovorB;
                    break;
                case 3: NovoPitanje.TacanOdgovor = NovoPitanje.OdgovorC;
                    break;
            };

            

            await dbContext.Pitanja.AddAsync(NovoPitanje);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./KvizJedan", new {id = SessionId, kviz = KvizId});
        }
    }
}
