using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KonacniProjekat.Models;
using Microsoft.EntityFrameworkCore;

namespace KonacniProjekat
{
    public class TuraRezervisiModel : PageModel
    {
        [BindProperty]
        public int? SessionId{get;set;}

        [BindProperty]
        public int TuraId{get;set;}

        public Ture OvaTura {get; set;}

        [BindProperty]
        public Rezervacije RezervacijaTure{get;set;}

        public readonly OrganizacijaContext dbContext;

        public TuraRezervisiModel(OrganizacijaContext db){
            dbContext=db;
        }

        [BindProperty]
        public IList<Rezervacije> RezervacijeUzTuru{get;set;}

        
        public uint? TrenutnaPopunjenostTure=0;

        [BindProperty]
        public int KapacitetTure{get;set;}

        [BindProperty]
        public int? NeuspesnaRezervacija{get;set;}

        [BindProperty]
        public int? NetacnaRezervacija{get;set;}

        [BindProperty]
        public string DaniOdrzavanja {get; set;}

        [BindProperty]
        public string DanasnjiDatum {get; set;}

        [BindProperty]
        public string NajkasnijiDatum {get; set;}

        [BindProperty]
        public bool NeispravnaTura {get; set;}

        public async Task<IActionResult>OnGetAsync(int? id, int? neuspesno, int? netacno)
        {

            if(id!=null){
                TuraId=(int)id;
            }      
            else return NotFound();

            OvaTura=await dbContext.Ture.Where( x => x.IdTure == (uint)id).FirstOrDefaultAsync();

            if(OvaTura == null)
            {
                return NotFound();
            }

            if(OvaTura.DanOdrzavanja == null || OvaTura.IdVodica == null)
            {
                NeispravnaTura = true;
                return this.Page();   
            }


            NeuspesnaRezervacija = (int?)neuspesno;      
            NetacnaRezervacija = (int?)netacno;

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

            DaniOdrzavanja = " ";
            string dani =  OvaTura.DanOdrzavanja;
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


            KapacitetTure=(int)OvaTura.Kapacitet;

            IQueryable<Rezervacije> qRezervacije=dbContext.Rezervacije.Where(x=>x.IdTureR==TuraId);
            RezervacijeUzTuru=await qRezervacije.ToListAsync();

            foreach(var r in RezervacijeUzTuru){
                TrenutnaPopunjenostTure+=r.BrojOsoba;
            }
            

            if(OvaTura==null){
                return NotFound();
            }

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if(RezervacijaTure==null){
                return this.Page();
            }

            String dan = RezervacijaTure.Datum.DayOfWeek.ToString();
            int no = (int)RezervacijaTure.Datum.DayOfWeek;

            OvaTura = await dbContext.Ture.FindAsync((uint)id);
            String daniOdrzavanja = OvaTura.DanOdrzavanja;
            if(!daniOdrzavanja.Contains(no.ToString())) 
            {
                NetacnaRezervacija=1;
                return RedirectToPage("./TuraRezervisi", new{id=TuraId, netacno=NetacnaRezervacija});
            }      

            if(KapacitetTure>=(RezervacijaTure.BrojOsoba+TrenutnaPopunjenostTure))
            {
                RezervacijaTure.IdTureRNavigation=await dbContext.Ture.FindAsync((uint)id);
                RezervacijaTure.IdTureR=RezervacijaTure.IdTureRNavigation.IdTure;
                RezervacijaTure.IdTuristeR=(uint)SessionClass.SessionId;
                RezervacijaTure.IdVodicaR = await dbContext.Ture.Where(x=>x.IdTure==id).Select(x=>x.IdVodica).FirstOrDefaultAsync();
            
                await dbContext.Rezervacije.AddAsync(RezervacijaTure);
                await dbContext.SaveChangesAsync();

                return RedirectToPage("./RezervacijaSve");
            }
            NeuspesnaRezervacija=1;
            return RedirectToPage("./TuraRezervisi", new{id=TuraId, neuspesno=NeuspesnaRezervacija});
        }

        
    }
}
