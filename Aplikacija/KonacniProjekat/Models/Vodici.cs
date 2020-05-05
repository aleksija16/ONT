using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class Vodici
    {
        public Vodici()
        {
            Anketa = new HashSet<Anketa>();
        }

        public uint IdVodica { get; set; }
        public string ImeVodica { get; set; }
        public string PrezimeVodica { get; set; }
        public string Pol { get; set; }
        public string BrojTelefona { get; set; }
        public string Licenca { get; set; }
        public decimal? Ocena { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string Email { get; set; }

        public virtual Korisnici Korisnici { get; set; }
        public virtual OcenjivanjeVodica OcenjivanjeVodica { get; set; }
        public virtual Rezervacije Rezervacije { get; set; }
        public virtual Ture Ture { get; set; }
        public virtual ICollection<Anketa> Anketa { get; set; }
    }
}
