using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KonacniProjekat.Models
{
    public partial class Turisti
    {
        public Turisti()
        {
            Anketa = new HashSet<Anketa>();
            HallOfFame = new HashSet<HallOfFame>();
            OcenjivanjeVodica = new HashSet<OcenjivanjeVodica>();
            Rezervacije = new HashSet<Rezervacije>();
        }

        public uint IdTuriste { get; set; }
        public string ImeTuriste { get; set; }
        public string PrezimeTuriste { get; set; }
        public string Pol { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DatumRodjenja { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public virtual Korisnici Korisnici { get; set; }
        public virtual ICollection<Anketa> Anketa { get; set; }
        public virtual ICollection<HallOfFame> HallOfFame { get; set; }
        public virtual ICollection<OcenjivanjeVodica> OcenjivanjeVodica { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
