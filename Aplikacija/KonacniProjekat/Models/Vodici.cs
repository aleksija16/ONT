using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KonacniProjekat.Models
{
    public partial class Vodici
    {
        public Vodici()
        {
            Anketa = new HashSet<Anketa>();
            OcenjivanjeVodica = new HashSet<OcenjivanjeVodica>();
            Rezervacije = new HashSet<Rezervacije>();
            Ture = new HashSet<Ture>();
        }

        public uint IdVodica { get; set; }
        public string ImeVodica { get; set; }
        public string PrezimeVodica { get; set; }
        public string Pol { get; set; }
        public string BrojTelefona { get; set; }
        public string Licenca { get; set; }
        public decimal? Ocena { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DatumRodjenja { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Slika { get; set; }

        public virtual Korisnici Korisnici { get; set; }
        public virtual ICollection<Anketa> Anketa { get; set; }
        public virtual ICollection<OcenjivanjeVodica> OcenjivanjeVodica { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
        public virtual ICollection<Ture> Ture { get; set; }
    }
}
