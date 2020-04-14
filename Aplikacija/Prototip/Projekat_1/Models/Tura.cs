using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekat_1.Models
{
    public class Tura
    {
        public int Id {get; set;}

        [Required]   
        public String Ime { get; set;}

        public float Trajanje { get; set;}

        public String MestoPolaska {get; set;}

        public int Cena {get; set;}

        public String KraciOpis {get; set;}

        public String DanOdrzavanja {get; set;}

        public String VremeOdrzavanja {get; set;}

        public int Kapacitet {get; set;}

        public Vodic Vodic {get; set;}

        public IList<Znamenitost> Znamenitosti {get; set;}
    }
}