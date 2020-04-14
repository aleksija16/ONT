using System.ComponentModel.DataAnnotations;

namespace Projekat_1.Models
{
    public class Znamenitost 
    {
        public int Id {get; set;}

        public String Ime {get; set;}

        public String Lokacija {get; set;}

        public String KraciOpis {get; set;}

        public String KontaktTelefone {get; set;}

        public String RadnoVreme {get; set;}

        public int CenaUlaska {get; set;}

        public String Dostupnost {get; set;}

    }
    
}