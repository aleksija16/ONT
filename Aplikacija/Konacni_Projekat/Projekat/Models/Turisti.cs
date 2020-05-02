using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Projekat.Models
{
    public partial class Turisti
    {
        public Turisti()
        {
            Anketa = new HashSet<Anketa>();
        }

        public uint IdTuriste { get; set; }
        public string ImeTuriste { get; set; }
        public string PrezimeTuriste { get; set; }
        public string Pol { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DatumRodjenja { get; set; }
        public string Email { get; set; }

        public virtual HallOfFame Halloffame { get; set; }
        public virtual Korisnici Korisnici { get; set; }
        public virtual OcenjivanjeVodica OcenjivanjeVodica { get; set; }
        public virtual Rezervacije Rezervacije { get; set; }
        public virtual ICollection<Anketa> Anketa { get; set; }
    }
}
