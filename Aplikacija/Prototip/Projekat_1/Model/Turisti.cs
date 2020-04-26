using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Turisti
    {
        public Turisti()
        {
            Rezervacije = new HashSet<Rezervacije>();
        }

        public uint IdTuriste { get; set; }
        public string ImeTuriste { get; set; }
        public string PrezimeTuriste { get; set; }
        public string Pol { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
